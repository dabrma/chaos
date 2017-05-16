using Chaos.Engine;
using Chaos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using ExtendedXmlSerialization;
using System.Windows.Forms;
using Chaos.Model.DTOs;

namespace Chaos.Model
{
    class GameLoader : IFile
    {
        List<Player> LoadedPlayers = new List<Player>();
        List<Monster> LoadedMonsters = new List<Monster>();
        readonly ExtendedXmlSerializer xml = new ExtendedXmlSerializer();

        public string GetPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return "";
        }
        public void LoadGame()
        {
            var state = LoadData();
            LoadPlayers(state);
            LoadMonsters(state);

            var game = new GameForm();
            var gameboard = new Gameboard(game.GetGamePanel, game.GetNameField, game.GetMovesLeftLabel);
            var gameEngine = new GameEngine(LoadedPlayers.Count - 1, gameboard, game);
            var spellboard = new SpellBoard(game.GetSpellPanel, LoadedPlayers, gameEngine, 98, false);
            foreach (Tile tile in gameboard.GetElementsCollection())
            {
                var coords = tile.GetCoordinates();
                var occupant = LoadedMonsters.Find(x => x.coordinates == coords);
                if (occupant != null)
                {
                    tile.SetOccupant(occupant);
                }
            }
            game.Show();
        }

        private string DeserializedData()
        {
            string data = File.ReadAllText(GetPath());
            if (!string.IsNullOrEmpty(data))
            {
                return data;
            }

            throw new IOException();
        }
        
        private GameState LoadData()
        {
            var data = DeserializedData();
            return xml.Deserialize<GameState>(data);
        }

        private void LoadPlayers(GameState state)
        {
            SpellsGenerator generator = new SpellsGenerator();
            foreach(PlayerDTO dto in state.players)
            {
                var playerFromDTO = new Player(dto.Name);
                var playerIndex = state.players.IndexOf(dto);
                foreach(string spellName in state.players[playerIndex].Spells)
                {
                    playerFromDTO.AvailableSpells.Add(generator.GetSpellByName(spellName));
                }

                LoadedPlayers.Add(playerFromDTO);
            }
        }
        private void LoadMonsters(GameState state)
        {
            var temp = new List<Monster>();
            MonsterGenerator generator = new MonsterGenerator();
            foreach(MonsterDTO dto in state.monsters)
            {
                Player owner = LoadedPlayers.Find(x => x.Name == dto.Owner);
                var monsterFromDTO = new Monster();
                if(dto.Name == "Wizard")
                {
                    dto.Name = "Wizard" + owner.Name.Substring(owner.Name.Length-1);
                }
                monsterFromDTO = generator.GetMonsterByName(dto.Name, owner);
                monsterFromDTO.Moves = dto.Moves;
                monsterFromDTO.MovesRemaining = dto.MovesRemaining;
                monsterFromDTO.Attack = dto.Attack;
                monsterFromDTO.Health = dto.Health;
                monsterFromDTO.MaxHealth = dto.MaxHealth;
                monsterFromDTO.coordinates = dto.Coordinates;

                LoadedMonsters.Add(monsterFromDTO);
            }
        }

    }
    
}

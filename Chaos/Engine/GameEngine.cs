
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chaos.Model;


namespace Chaos.Engine
{
    class GameEngine
    {
        public Gameboard gameboard { get; set; }
        public SpellBoard spellboard { get; set; }
        private MonsterGenerator monsterGenerator;
        private Player currentPlayer;
        List<Player> players = new List<Player>();
        public Player GetCurrentPlayer { get { return currentPlayer; } }
        public List<Player> GetPlayers { get { return players; } }

        public GameEngine(int NumberOfPlayers, Gameboard gameboard)
        {
            this.gameboard = gameboard;
            monsterGenerator = new MonsterGenerator();
            GenerateWizards(NumberOfPlayers);
            gameboard.players = players;
            gameboard.currentPlayer = players[0];
        }


        public void AddMonster(int posX, int posY)
        {
            Monster monster = monsterGenerator.Monsters[2];
            monster.Owner = players[0];
            gameboard.tiles[posX, posY].OcupantEnter(monster);

        }
        private void UpdateSpellboard()
        {
            spellboard.UpdateSpellboard(currentPlayer);
        }
        public void AddMonster(Monster monster, Player owner, int posX, int posY)
        {
            monster.Owner = owner;
            gameboard.tiles[posX, posY].OcupantEnter(monster);

        }
        public void TurnChange()
        {
            gameboard.currentPlayer = gameboard.currentPlayer == players[0] ? players[1] : players[0];
            currentPlayer = gameboard.currentPlayer;
            gameboard.resetEventData();
            ResetMonsterMovement();
            SoundEngine.say(currentPlayer.Name);
            gameboard.SwitchEvents();
            UpdateSpellboard();
            

        }
        private void ResetMonsterMovement()
        {
            foreach (Tile tile in gameboard.tiles)
            {
                if (tile.Occupant.Owner == currentPlayer && currentPlayer != null)
                {
                    var monster = tile.Occupant as Monster;
                    monster.MovesRemaining = monster.Moves;
                }
            }
        }
        private void GenerateWizards(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player("Player" + (i+1), i+1);
                players.Add(player);
            }

            var wizard1 = monsterGenerator.Monsters[3];
            wizard1.Name = "Wizard";
            wizard1.Caption = wizard1.Name;
            var wizard2 = monsterGenerator.Monsters[1];
            wizard2.Name = "Wizard";
            wizard2.Caption = wizard1.Name;

            AddMonster(wizard1, players[0], 0, 0);
            AddMonster(wizard2, players[1], 11, 11);
        }




        private void GameOver()
        {
            MessageBox.Show(String.Format("Congratulations {0}, you've won!", currentPlayer));
        }

    }
}

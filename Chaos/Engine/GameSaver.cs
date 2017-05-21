using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Chaos.Engine;
using Chaos.Interfaces;
using Chaos.Model.DTOs;
using ExtendedXmlSerialization;

namespace Chaos.Model
{
    public class GameSaver : IFile
    {
        private readonly IEnumerable<Tile> gameboardElements;
        private readonly List<Player> players = new List<Player>();

        public GameSaver(IEnumerable<Tile> gameboard, List<Player> players)
        {
            gameboardElements = gameboard;
            this.players = players;
        }

        public string GetPath()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Text Files | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                return saveFileDialog.FileName;

            return "";
        }

        private List<MonsterDTO> monsterDTOs()
        {
            var temp = new List<MonsterDTO>();
            foreach (var tile in gameboardElements)
                if (tile.GetOccupant() is Monster)
                {
                    var m = tile.GetOccupant() as Monster;
                    var dto = new MonsterDTO();
                    dto.Owner = m.Owner.Name;
                    dto.Coordinates = tile.GetCoordinates();
                    dto.Name = m.Name;
                    dto.MaxHealth = m.MaxHealth;
                    dto.Health = m.Health;
                    dto.Attack = m.Attack;
                    dto.MagicResistance = m.MagicResistance;
                    dto.Moves = m.Moves;
                    dto.MovesRemaining = m.MovesRemaining;
                    temp.Add(dto);
                }
            return temp;
        }

        private List<PlayerDTO> playerDTOs()
        {
            var temp = new List<PlayerDTO>();
            foreach (var p in players)
            {
                var dto = new PlayerDTO();
                dto.Name = p.Name;

                foreach (var s in p.AvailableSpells)
                    dto.Spells.Add(s.Caption);
                temp.Add(dto);
            }
            return temp;
        }

        public void SaveGame()
        {
            var filePath = GetPath();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                var state = new GameState();
                state.monsters = monsterDTOs();
                state.players = playerDTOs();

                var xml = new ExtendedXmlSerializer();
                File.AppendAllText(filePath, xml.Serialize(state));
            }
        }
    }
}
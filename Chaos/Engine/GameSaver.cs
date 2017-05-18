using Chaos.Engine;
using Chaos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtendedXmlSerialization;
using Chaos.Model.DTOs;

namespace Chaos.Model
{
    public class GameSaver : IFile
    {
        readonly IEnumerable<Tile> gameboardElements;
        readonly List<Player> players = new List<Player>();

        public GameSaver(IEnumerable<Tile> gameboard, List<Player> players)
        {
            this.gameboardElements = gameboard;
            this.players = players;
        }

        public string GetPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Text Files | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return "";         
        }

        private List<MonsterDTO> monsterDTOs()
        {
            var temp = new List<MonsterDTO>();
            foreach(Tile tile in gameboardElements)
            {
                if(tile.GetOccupant() is Monster)
                {
                    Monster m = tile.GetOccupant() as Monster;
                    MonsterDTO dto = new MonsterDTO();
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
            }
            return temp;
        }
        private List<PlayerDTO> playerDTOs()
        {
            var temp = new List<PlayerDTO>();
            foreach(Player p in players)
            {
                PlayerDTO dto = new PlayerDTO();
                dto.Name = p.Name;

                foreach(Spell s in p.AvailableSpells)
                {
                    dto.Spells.Add(s.Caption);
                }
                temp.Add(dto);
            }
            return temp;
        }
        public void SaveGame()
        {
            var filePath = GetPath();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                GameState state = new GameState();
                state.monsters = monsterDTOs();
                state.players = playerDTOs();

                ExtendedXmlSerializer xml = new ExtendedXmlSerializer();
                File.AppendAllText(filePath, xml.Serialize(state));
            }
        } 
    }
}

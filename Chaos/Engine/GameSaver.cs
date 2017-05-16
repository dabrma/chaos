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

namespace Chaos.Model
{
    public class GameSaver : IFile
    {
        IEnumerable<Tile> gameboardElements;
        List<Player> players = new List<Player>();

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
            List<MonsterDTO> temp = new List<MonsterDTO>();
            foreach(Tile tile in gameboardElements)
            {
                if(tile.GetOccupant() is Monster)
                {
                    Monster m = tile.GetOccupant() as Monster;
                    MonsterDTO dto = new MonsterDTO();
                    dto.Owner = m.Owner;
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

        public void SaveGame()
        {
            var filePath = GetPath();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                ExtendedXmlSerializer xml = new ExtendedXmlSerializer();
                File.WriteAllText(filePath, xml.Serialize(monsterDTOs()));
            }
        } 
    }
}

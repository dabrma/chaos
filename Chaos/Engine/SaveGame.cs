using Chaos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaos.Engine
{
    class SaveGame
    {
        private Tile[] tiles;
        private List<Spell> spells;

        public SaveGame(Tile[] tiles, List<Spell> spells)
        {
            this.tiles = tiles;
            this.spells = spells;
        }

        public void Save()
        {
            StringBuilder sb = new StringBuilder();
            string filePath = SavePath();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                using (var streamWriter = new StreamWriter(filePath))
                {
                    //Save monsters
                    foreach (var tile in tiles)
                    {
                        if (tile.Occupant.GetType() == typeof(Monster))
                        {
                            var monster = tile.Occupant as Monster;
                            streamWriter.WriteAsync(monster.ToString());
                        }
                    }
                }
            }
        }

        private string SavePath()
        {
            var save = new SaveFileDialog();
            if(save.ShowDialog() == DialogResult.OK)
            {
                return save.FileName;
            }

            return "";
        }
    }
}

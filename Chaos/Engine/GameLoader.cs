using Chaos.Engine;
using Chaos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaos.Model
{
    class GameLoader : IFile
    {
        List<Player> LoadedPlayers = new List<Player>();
        List<Monster> LoadedMonsters = new List<Monster>();
        Dictionary<Player, Spell> LoadedSpells = new Dictionary<Player, Spell>();

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
            var filePath = GetPath();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {

                }
            }
        }
        
        private void LoadPlayers(StreamReader source)
        {
            while(source.ReadLine() != null)
            {
                string line = source.ReadLine();
                if (line.StartsWith("Player:"))
                {
                    var Name = line.Split(' ');
                    Player newPlayer = new Player(Name[1]);
                    LoadedPlayers.Add(newPlayer);
                }
            }
        }

        private void LoadSpells(StreamReader source)
        {
            SpellsGenerator spellGen = new SpellsGenerator();
            while (source.ReadLine() != null)
            {
                string line = source.ReadLine();
                if (line.StartsWith("Spell:")) {

                    var spellLine = line.Split(' ');
                    var name = spellLine[2];
                    var owner = spellLine[1];
                    var spell = spellGen.GetSpellByName(name);
                    //    spell.Owner = LoadedPlayers.Where(x => x.Name == name)
               //     Spell newSpell = new Spell

                
            }
            }
        }
    }
    
}

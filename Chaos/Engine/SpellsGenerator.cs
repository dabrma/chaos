using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaos.Model;

namespace Chaos.Engine
{
    class SpellsGenerator
    {
        private string[] gameObjectStrings = null;
        Random random = new Random();

        public SpellsGenerator()
        {
            gameObjectStrings = Properties.Resources.Spells.Split('\n');
          //  GenerateSpellFromText(gameObjectStrings);

           /* foreach (string gameObjectString in gameObjectStrings)
            {
                var deserializedGameObject = gameObjectString.Split(' ');
                GenerateSpellFromText(deserializedGameObject);
            }*/
        }

        
        public Spell GenerateSpellFromText(Player owner)
        {
            // Generate random spell
            var radnIndex = random.Next(0, 3);
            var spell = new Spell();
            spell.Caption = gameObjectStrings[radnIndex];
            spell.Owner = owner;
            spell.Sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject(gameObjectStrings[radnIndex].TrimEnd('\r'));

            return spell;
        }


    }
}

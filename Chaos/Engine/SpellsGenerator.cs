using System;
using System.Drawing;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    internal class SpellsGenerator
    {
        private readonly string[] gameObjectStrings;
        private readonly Random random = new Random();

        public SpellsGenerator()
        {
            gameObjectStrings = Resources.Spells.Split('\n');
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
            var radnIndex = random.Next(0, gameObjectStrings.Length);
            var spell = new Spell();
            spell.Caption = gameObjectStrings[radnIndex];
            spell.Owner = owner;
            spell.Sprite = (Bitmap) Resources.ResourceManager.GetObject(gameObjectStrings[radnIndex].TrimEnd('\r'));

            return spell;
        }
    }
}
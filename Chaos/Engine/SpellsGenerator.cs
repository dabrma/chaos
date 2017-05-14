using System;
using System.Drawing;
using System.Linq;
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


        public Spell GenerateSpellFromText()
        {
            // Generate random spell
            var randomIndex = random.Next(0, gameObjectStrings.Length);
            string[] spellData = gameObjectStrings.ElementAt(randomIndex).Split(' ');
            var spell = new Spell();
            spell.CanCastOnNothing = int.Parse(spellData[1]) == 1;
            spell.CanCastOnMonster = int.Parse(spellData[2]) == 1;

            if (spell.CanCastOnMonster)
            {
                spell.EffectPower = int.Parse(spellData[3]);
                spell.EffectLabel = spellData[4];
            }

            spell.Caption = spellData[0].TrimEnd('\r');

            spell.Sprite = (Bitmap) Resources.ResourceManager.GetObject(spellData[0].TrimEnd('\r'));

            return spell;
        }
    }
}
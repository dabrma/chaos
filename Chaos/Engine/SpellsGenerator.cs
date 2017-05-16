using System;
using System.Drawing;
using System.Linq;
using Chaos.Model;
using Chaos.Properties;
using System.Collections.Generic;

namespace Chaos.Engine
{
    public class SpellsGenerator
    {
        private readonly string[] gameObjectStrings;
        private readonly Random random = new Random();
        public List<Spell> spells = new List<Spell>();

        public SpellsGenerator()
        {
            gameObjectStrings = Resources.Spells.Split('\n');

             foreach (string spellLine in gameObjectStrings)
             {
                var s = spellLine.Split(' ');
                stringTrimmer(s);
                Spell spell = new Spell();
                spell.Caption = s[0];
                spell.CanCastOnNothing = int.Parse(s[1]) == 1;
                spell.CanCastOnMonster = int.Parse(s[2]) == 1;
                if (spell.CanCastOnMonster)
                {
                    spell.EffectPower = int.Parse(s[3]);
                    spell.EffectLabel = s[4];
                }
                spell.Sprite = (Bitmap)Resources.ResourceManager.GetObject(s[0]);

                spells.Add(spell);
            }
        }

        public void stringTrimmer(string[] source)
        {
            foreach(string untrimmedString in source)
            {
                 untrimmedString.TrimEnd('\r');
            }
        }

        public Spell GetSpellByName(string name)
        {
            foreach (Spell spell in spells)
            {
                if (spell.Caption == name)
                {
                      return new Spell().DeepCopy(spell);
                }

            }
            throw new NullReferenceException();
        }

        public Spell GenerateRandomSpell()
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
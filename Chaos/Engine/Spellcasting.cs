using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    class Spellcasting
    {

      //  private readonly Gameboard gameboard;
        private readonly GameEngine gameEngine;

        public Spellcasting(Gameboard gameboard, GameEngine gameEngine)
        {
         //   this.gameboard = gameboard;
            this.gameEngine = gameEngine;
        }

        public async Task PlayBoostAnimation(Bitmap previousBitmap)
        {
            gameEngine.GetTargetField.Field.Image = Resources.Boost;
            await Task.Delay(550);
            gameEngine.GetTargetField.Field.Image = previousBitmap;
        }

        public void ApplySpellEffect(Spell spell, Monster target)
        {
            switch (spell.EffectLabel)
            {
                case "C":
                    target.Attack = target.Attack + spell.EffectPower > 1 ? target.Attack + spell.EffectPower : 1;
                    break;
                case "H":
                    target.Health += spell.EffectPower;
                    break;
            }
        }
    }
}

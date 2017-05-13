using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Properties;
using Chaos.Utility;

namespace Chaos.Engine
{
    class Spellcasting
    {

      //  private readonly Gameboard gameboard;
        private readonly GameEngine gameEngine;
        private Tile targetField;

        public Spellcasting(Gameboard gameboard, GameEngine gameEngine)
        {
         //   this.gameboard = gameboard;
            this.gameEngine = gameEngine;
        }

        public async Task PlayBoostAnimation(Tile targeTile, Bitmap previousBitmap)
        {
            targeTile.Field.Image = Resources.Boost;
            await Task.Delay(550);
            targeTile.Field.Image = previousBitmap;
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
        public bool finishedCasting = false;
        public async Task<bool> CastSpell(Tile target)
        {
            var currentPlayerIndex = gameEngine.GetPlayers.IndexOf(gameEngine.CurrentPlayer);
            var finishedCasting = currentPlayerIndex + 1 == gameEngine.GetPlayers.Count;
            var spell = gameEngine.GetCurrentSpell();
            if (spell.CanCastOnNothing && target.Occupant.GetType() == typeof(Nothing) && !this.finishedCasting)
            {
                var monsterFromSpell = gameEngine.monsterGenerator.GetMonsterByName(spell.Caption, gameEngine.CurrentPlayer);
                monsterFromSpell.Owner = gameEngine.CurrentPlayer;
                target.OcupantEnter(monsterFromSpell);
                SoundEngine.play("SingleCast");
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();

            }

            if (spell.CanCastOnMonster && target.Occupant.GetType() == typeof(Monster) && !this.finishedCasting)
            {
                Monster spellTarget = target.Occupant as Monster;
                targetField = target;
                ApplySpellEffect(spell, spellTarget);
                SoundEngine.play("Boosting");
                await PlayBoostAnimation(target, spellTarget.Sprite);
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();
            }

            if (finishedCasting)
            {
                this.finishedCasting = true;
                return finishedCasting;
            }
            else
            {
                return false;
            }


        }
    }
}

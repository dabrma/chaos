using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Chaos.Model;
using Chaos.Properties;
using System.Windows.Forms;

namespace Chaos.Engine
{
    internal class Spellcasting
    {
        private readonly GameEngine gameEngine;

        public bool finishedCasting;
        private Tile targetField;
        private MonsterActions actions;

        public Spellcasting(Gameboard gameboard, GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        private void DamageSpellAction(int spellPower, Monster target)
        {
            int LeftOverDamage = 0;

            if (target.MagicResistance > 0)
            {
                target.MagicResistance = target.MagicResistance + spellPower;
                LeftOverDamage = target.MagicResistance;
                if (target.MagicResistance <= 0)
                {
                    target.MagicResistance = 0;
                    target.Health += LeftOverDamage;
                }
            }

            else if (target.MagicResistance <= 0)
            {
                target.Health += spellPower;
            }

            if (target.Health <= 0)
            {
                targetField.SetOccupant();
            }
        }


        public async Task PlayBoostAnimation(Tile targeTile, Bitmap previousBitmap)
        {
            targeTile.Field.Image = Resources.Boost;
            await Task.Delay(550);
            targeTile.Field.Image = previousBitmap;
        }

        public void ApplySpellEffect(Spell spell, Monster target)
        {
            switch (spell.EffectLabel.First().ToString())
            {
                case "C":
                    target.Attack = target.Attack + spell.EffectPower > 1 ? target.Attack + spell.EffectPower : 1;
                    break;
                case "H":
                    if (spell.EffectPower < 0)
                    {
                        SoundEngine.play("CombatSpell");
                        DamageSpellAction(spell.EffectPower, target);
                    }
                    else
                    {
                        SoundEngine.play("Boosting");
                        target.Health += spell.EffectPower;
                        target.MaxHealth += spell.EffectPower;
                    }
                    break;
                case "S":
                    target.Moves = target.Moves + spell.EffectPower > 1 ? target.Moves + spell.EffectPower : 1;
                    SoundEngine.play(spell.EffectPower < 0 ? "Debuffing" : "SpeedUp");
                    break;
            }
        }

        public async Task<bool> CastSpell(Tile target, MouseEventArgs e)
        {
            var currentPlayerIndex = gameEngine.Players.IndexOf(gameEngine.CurrentPlayer);
            var finishedCasting = currentPlayerIndex + 1 == gameEngine.Players.Count;
            var spell = gameEngine.GetCurrentSpell();

            if(e.Button == MouseButtons.Right)
            {
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();
            }

            else if (spell.CanCastOnNothing && target.GetOccupant() is Nothing &&
                !this.finishedCasting &&
                MonsterActions.isActionLegal(gameEngine.GetWizardCoordinates(), target.GetCoordinates()))
            {
                var monsterFromSpell =
                    gameEngine.monsterGenerator.GetMonsterByName(spell.Caption, gameEngine.CurrentPlayer);
                monsterFromSpell.Owner = gameEngine.CurrentPlayer;
                target.SetOccupant(monsterFromSpell);
                SoundEngine.play("SingleCast");
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();
            }

            else if (spell.CanCastOnMonster && target.GetOccupant() is Monster &&
                     !this.finishedCasting)
            {
                var spellTarget = target.GetOccupant() as Monster;
                targetField = target;
                ApplySpellEffect(spell, spellTarget);
                await PlayBoostAnimation(target, spellTarget.Sprite);
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();
            }

            else
            {
                return false;
            }

            if (finishedCasting)
            {
                this.finishedCasting = true;
                return finishedCasting;
            }
            return false;
        }
    }
}
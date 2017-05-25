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

        public async Task PlayAnimation (Tile target, Bitmap previousSprite, string animationResource, int msDelay = 500)
        {
            try
            {
                var prevSprite = previousSprite;
                targetField.Field.Image = (Bitmap)Resources.ResourceManager.GetObject(animationResource);
                await Task.Delay(msDelay);
                targetField.Field.Image = prevSprite;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        public async Task ApplySpellEffect(Spell spell, Monster target)
        {
            switch (spell.EffectLabel.First().ToString())
            {
                case "C":
                    SoundEngine.PlaySound("Boosting");
                    await PlayAnimation(targetField, targetField.GetOccupant().Sprite, "Boost");
                    target.Attack = target.Attack + spell.EffectPower > 1 ? target.Attack + spell.EffectPower : 1;
                    break;
                case "H":
                    if (spell.EffectPower < 0)
                    {
                        SoundEngine.PlaySound("CombatSpell");
                        await PlayAnimation(targetField, targetField.GetOccupant().Sprite, "Damage");
                        DamageSpellAction(spell.EffectPower, target);
                    }
                    else
                    {
                        SoundEngine.PlaySound("Boosting");
                        await PlayAnimation(targetField, targetField.GetOccupant().Sprite, "Boost");
                        target.Health += spell.EffectPower;
                        target.MaxHealth += spell.EffectPower;
                    }
                    break;
                case "S":
                    target.Moves = target.Moves + spell.EffectPower > 1 ? target.Moves + spell.EffectPower : 1;
                    SoundEngine.PlaySound(spell.EffectPower < 0 ? "Debuffing" : "SpeedUp");
                    break;
            }
        }

        public async Task<bool> CastSpell(Tile target, MouseEventArgs e)
        {
            var currentPlayerIndex = gameEngine.Players.IndexOf(gameEngine.CurrentPlayer);
            var finishedCasting = currentPlayerIndex + 1 == gameEngine.Players.Count;
            var spell = gameEngine.GetCurrentSpell();

          
            if (e.Button == MouseButtons.Right)
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
                targetField = target;
                SoundEngine.PlaySound("SingleCast");
                await PlayAnimation(targetField, monsterFromSpell.Sprite, "Casting");
                target.SetOccupant(monsterFromSpell);
                gameEngine.CurrentPlayer = gameEngine.SwitchPlayer();
            }

            else if (spell.CanCastOnMonster && target.GetOccupant() is Monster &&
                     !this.finishedCasting)
            {
                var spellTarget = target.GetOccupant() as Monster;
                targetField = target;
                await ApplySpellEffect(spell, spellTarget);
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
using System.Drawing;
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
                SoundEngine.play("Boosting");
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
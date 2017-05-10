using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    public class MonsterActions
    {
        private readonly Gameboard gameboard;
        private readonly GameEngine gameEngine;

        public MonsterActions(Gameboard gameboard, GameEngine gameEngine)
        {
            this.gameboard = gameboard;
            this.gameEngine = gameEngine;
        }

        public bool Move(Tile source, Tile target)
        {
            var ocuppant = (Monster)source.Occupant;
            var sourceCoords = findCoordinatesInMatrix(source);
            var targetCoords = findCoordinatesInMatrix(target);
            if (isMoveLegal(sourceCoords, targetCoords) && ocuppant.MovesRemaining > 0)
            {
                source.OcuppantLeave();
                target.OcupantEnter(ocuppant);
                ocuppant.MovesRemaining--;
                SoundEngine.playStepSound();
                return true;
            }

            return false;
        }

        public async Task<bool> Attack(Monster attacker, Monster defender)
        {
            var prevSprite = gameEngine.GetTargetField.Occupant.Sprite;

            if (defender.isUndead && !attacker.isUndead)
            {
                SoundEngine.playUndeadAttackSound();
                PostCombat(attacker);
                return false;
            }

            defender.Health = defender.Health - attacker.Attack;

            if (defender.Health <= 0)
            {
                 await Die(attacker, defender, prevSprite);
            }

            else
            {
                SoundEngine.playAttackSound();
                await playCombatAnimation(prevSprite);
            }
            PostCombat(attacker);
            return true;
        }

        private void PostCombat(Monster attacker)
        {
            attacker.MovesRemaining = 0;
            attacker.canAttack = false;
        }

        private async Task Die(Monster attacker, Monster defender, Bitmap prevBitmap)
        {
            SoundEngine.playAttackMoveSound();
            await playCombatAnimation(prevBitmap);

            gameEngine.GetTargetField.OcuppantLeave();
            gameEngine.GetSourceField.OcuppantLeave();
            gameEngine.GetTargetField.OcupantEnter(attacker);

            if (defender.Name == "Wizard")
                MessageBox.Show("Game Over!");
        }


        private Point findCoordinatesInMatrix(Tile searchTarget)
        {
            var itemPosition = new Point();
            var h = gameboard.tiles.GetLength(0);
            var w = gameboard.tiles.GetLength(1);

            for (var row = 0; row < h; row++)
            for (var col = 0; col < w; col++)
                if (gameboard.tiles[row, col].Equals(searchTarget))
                    return new Point(row, col);
            return itemPosition;
        }

        public bool isMoveLegal(Point sourcePoint, Point targetPoint)
        {
            if (
                sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y ||
                sourcePoint.X == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y ||
                sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y ||
                sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y == targetPoint.Y ||
                sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y == targetPoint.Y ||
                sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y ||
                sourcePoint.X == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y ||
                sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y
            )
                return true;

            return false;
        }

        private async Task playCombatAnimation(Bitmap previousBitmap)
        {
            gameEngine.GetTargetField.Field.Image = Resources.combat;
            await Task.Delay(550);
            gameEngine.GetTargetField.Field.Image = previousBitmap;
        }

    }
}

using System;
using System.Drawing;
using System.Threading.Tasks;
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
            var ocuppant = (Monster) source.GetOccupant();
            var sourceCoords = source.GetCoordinates();
            var targetCoords = target.GetCoordinates();
            if (isActionLegal(sourceCoords, targetCoords) && ocuppant.MovesRemaining > 0
                && isMonsterAround(sourceCoords))
            {
                source.SetOccupant();
                target.SetOccupant(ocuppant);
                ocuppant.MovesRemaining--;
                SoundEngine.PlaySound("MovementSound");
                return true;
            }

            return false;
        }

        public async Task<bool> Attack(Monster attacker, Monster defender)
        {
            var prevSprite = gameEngine.GetTargetField.GetOccupant().Sprite;

            if (defender.isUndead && !attacker.isUndead)
            {
                SoundEngine.PlaySound("wrongTarget");
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
                SoundEngine.PlaySound("fighting");
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
            SoundEngine.PlaySound("combatMove");
            await playCombatAnimation(prevBitmap);
            gameEngine.GetTargetField.SetOccupant(); // Set target field occupant as Nothing
            gameEngine.GetSourceField.SetOccupant(); // Set source field occupant as Nothing
            gameEngine.GetTargetField.SetOccupant(attacker); // Put previous source field occupant into target field

            attacker.Owner.Points +=
                CalculatePointsForKilling(defender); // Add points for killing a monster or a wizard.

            if (defender.Name.Contains("Wizard"))
            {
                gameEngine.RemovePlayer(defender.Owner);

                if (gameEngine.Players.Count == 1)
                {
                    gameEngine.postGamePlayersList.Add(attacker.Owner);
                    gameEngine.ShowGameOverScreen();
                }
            }
        }

        public int CalculatePointsForKilling(Monster killedMonster)
        {
            if (killedMonster.Name == "Wizard") return 100;
            return killedMonster.MaxHealth / 2 + killedMonster.Attack + killedMonster.MagicResistance;
        }

        public static bool isActionLegal(Point sourcePoint, Point targetPoint)
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

        private bool
            isMonsterAround(
                Point sourcePoint) //if player is near the monster of opponent, player has to kill this monster befor he change location
        {
            var monster = getTestedObject(sourcePoint) as Monster;
            if (monster != null &&
                (
                    getTestedObject(sourcePoint, 1, 0) is Monster &&
                    getTestedObject(sourcePoint, 1, 0).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, 1, 1) is Monster &&
                    getTestedObject(sourcePoint, 1, 1).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, 0, 1) is Monster &&
                    getTestedObject(sourcePoint, 0, 1).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, -1, 1) is Monster &&
                    getTestedObject(sourcePoint, -1, 1).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, -1, 0) is Monster &&
                    getTestedObject(sourcePoint, -1, 0).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, -1, -1) is Monster &&
                    getTestedObject(sourcePoint, -1, -1).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, 0, -1) is Monster &&
                    getTestedObject(sourcePoint, 0, -1).Owner != monster.Owner ||
                    getTestedObject(sourcePoint, 1, -1) is Monster &&
                    getTestedObject(sourcePoint, 1, -1).Owner != monster.Owner
                )
            )
                return false;

            return true;
        }

        private GameObject getTestedObject(Point Point, int X = 0, int Y = 0)
        {
            GameObject occupantOfTarget;
            try
            {
                occupantOfTarget = gameboard.GetElement(new Point(Point.X + X, Point.Y + Y)).GetOccupant();
            }
            catch (IndexOutOfRangeException)
            {
                occupantOfTarget = gameboard.GetElement(new Point(Point.X, Point.Y)).GetOccupant();
            }

            return occupantOfTarget;
        }

        private async Task playCombatAnimation(Bitmap previousBitmap)
        {
            gameEngine.GetTargetField.Field.Image = Resources.combat;
            await Task.Delay(550);
            gameEngine.GetTargetField.Field.Image = previousBitmap;
        }
    }
}
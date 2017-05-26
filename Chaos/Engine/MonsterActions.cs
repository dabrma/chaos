using System;
using System.Drawing;
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
            var ocuppant = (Monster) source.GetOccupant();
            var sourceCoords = source.GetCoordinates();
            var targetCoords = target.GetCoordinates();
            if (isActionLegal(sourceCoords, targetCoords) && ocuppant.MovesRemaining > 0 && isNotMonsterAround(sourceCoords)) // added isNotMonsterAround... && isNotMonsterAround(sourceCoords)
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

            attacker.Owner.Points += CalculatePointsForKilling(defender); // Add points for killing a monster or a wizard.

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
            else
                return ((killedMonster.MaxHealth / 2) + killedMonster.Attack + killedMonster.MagicResistance);
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

        private bool isNotMonsterAround(Point sourcePoint) //if player is near the monster of opponent, player has to kill this monster befor he change location
        {
            Monster wizard = getTestedObject(sourcePoint) as Monster;
            bool iswizard = wizard.Name.Contains("Wizard") ? true : false;
            
            if (    (iswizard &&
                        (
                        (getTestedObject(sourcePoint, 1, 0) is Monster && getTestedObject(sourcePoint, 1 ,0).Owner != wizard.Owner)||
                        (getTestedObject(sourcePoint, 1, 1) is Monster && getTestedObject(sourcePoint, 1, 1).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, 0, 1) is Monster && getTestedObject(sourcePoint, 0, 1).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, -1, 1) is Monster && getTestedObject(sourcePoint, -1, 1).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, -1, 0) is Monster && getTestedObject(sourcePoint, -1, 0).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, -1, -1) is Monster && getTestedObject(sourcePoint, -1, -1).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, 0, -1) is Monster && getTestedObject(sourcePoint, 0, -1).Owner != wizard.Owner) ||
                        (getTestedObject(sourcePoint, 1, -1) is Monster && getTestedObject(sourcePoint, 1, -1).Owner != wizard.Owner)
                        )
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
                occupantOfTarget = this.gameboard.GetElement(new Point(Point.X + X, Point.Y + Y)).GetOccupant();
            }
            catch (IndexOutOfRangeException)
            {
                occupantOfTarget = this.gameboard.GetElement(new Point(Point.X, Point.Y)).GetOccupant();
            }

            return occupantOfTarget;
        }

        private async Task playCombatAnimation(Bitmap previousBitmap)
        {
            gameEngine.GetTargetField.Field.Image = Resources.combat;
            await Task.Delay(550);
            gameEngine.GetTargetField.Field.Image = previousBitmap;
        }
        

        //TODO: Implement ranged attack mechanics - NOT GOING TO BE IMPLEMENTED IN VERSION 1.0
        //private async Task rangedAttack(Tile attackerTile, Tile defenderTile)
        //{
        //    var attacker = attackerTile.GetOccupant() as Monster;
        //    var defender = defenderTile.GetOccupant() as Monster;

        //    isDefenderInRange(attackerTile.GetCoordinates(), defenderTile.GetCoordinates(), attacker.Attack);
        //}

        //public bool isDefenderInRange(Point attackerCoordinates, Point defenderCoordinates, int attackRange)
        //{
        //    //double distance = Math.Sqrt(Math.Pow((defenderCoordinates.Y - attackerCoordinates.Y), 2) +
        //    //    Math.Pow((defenderCoordinates.X - attackerCoordinates.X), 2));
        //    var distance = Math.Max(Math.Abs(attackerCoordinates.X - defenderCoordinates.X),
        //        Math.Abs(attackerCoordinates.Y - defenderCoordinates.Y));
        //    if (distance <= attackRange)
        //        return true;

        //    return false;
        //}
    }
}
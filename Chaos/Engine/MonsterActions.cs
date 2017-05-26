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
            var occuppant = (Monster)source.GetOccupant();
            var sourceCoords = source.GetCoordinates();
            var targetCoords = target.GetCoordinates();
            if (isActionLegal(sourceCoords, targetCoords) && occuppant.MovesRemaining > 0&&
                IsMoveLegal(gameboard,sourceCoords,gameEngine))
            {
                source.SetOccupant();
                target.SetOccupant(occuppant);
                occuppant.MovesRemaining--;
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
            if
                (sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y ||
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

        public static bool IsMoveLegal(Gameboard gameboard, Point sourcePoint, GameEngine gameengine)
        {
            if ((!(gameboard.GetRawTilesData[sourcePoint.X-1, sourcePoint.Y].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X - 1, sourcePoint.Y].GetOccupant().Owner != gameengine.CurrentPlayer)||
               (!(gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y].GetOccupant().Owner != gameengine.CurrentPlayer)||
                (!(gameboard.GetRawTilesData[sourcePoint.X, sourcePoint.Y-1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X, sourcePoint.Y-1].GetOccupant().Owner != gameengine.CurrentPlayer)||
                 (!(gameboard.GetRawTilesData[sourcePoint.X, sourcePoint.Y+1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X, sourcePoint.Y+1].GetOccupant().Owner != gameengine.CurrentPlayer)||
               (!(gameboard.GetRawTilesData[sourcePoint.X- 1, sourcePoint.Y-1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X - 1, sourcePoint.Y-1].GetOccupant().Owner != gameengine.CurrentPlayer)||
               (!(gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y+1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y+1].GetOccupant().Owner != gameengine.CurrentPlayer)||
                 (!(gameboard.GetRawTilesData[sourcePoint.X- 1, sourcePoint.Y+1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X - 1, sourcePoint.Y+1].GetOccupant().Owner != gameengine.CurrentPlayer)||
                 (!(gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y-1].GetOccupant() is Nothing) &&
              gameboard.GetRawTilesData[sourcePoint.X + 1, sourcePoint.Y-1].GetOccupant().Owner != gameengine.CurrentPlayer))
              return false;
           
                return true;


        }
        /* public static bool IsMoveLegal(Gameboard gameboard, Point Sourcepoint, GameEngine gameengine)
        {
           
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++) 
                {
              
                    if ((Math.Abs(Sourcepoint.X-i) == 1) && (Math.Abs(Sourcepoint.Y-j) == 1))
                    {
                        if (
                            !(gameboard.GetRawTilesData[j,i].GetOccupant() is Nothing) &&
                            gameboard.GetRawTilesData[j,i].GetOccupant().Owner != gameengine.CurrentPlayer)
                            return false;
                    }
                      
                       
                }

            }
         
            return true;
        }*/
        
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
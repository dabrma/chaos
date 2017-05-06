using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos.Engine
{
    internal enum GamePhase
    {
        Casting,
        Moving,

    }
    internal class GameEngine
    {
        private bool firstClick = true;
        private readonly MonsterGenerator monsterGenerator;
        private Monster selectedMonster;
        private Tile sourceField;
        private Tile targetField;
        private GamePhase gamePhase;

        public GameEngine(int NumberOfPlayers, Gameboard gameboard)
        {
            this.gameboard = gameboard;
            SetTileEvents();
            monsterGenerator = new MonsterGenerator();
            GenerateWizards(NumberOfPlayers);
            gameboard.players = GetPlayers;
            GetCurrentPlayer = GetPlayers[0];
            gamePhase = GamePhase.Casting;
        }

        public Gameboard gameboard { get; set; }
        public SpellBoard spellboard { get; set; }
        public Player GetCurrentPlayer { get; private set; }

        public List<Player> GetPlayers { get; } = new List<Player>();


        public void AddMonster(int posX, int posY)
        {
            var monster = monsterGenerator.Monsters[2];
            monster.Owner = GetPlayers[0];
            gameboard.tiles[posX, posY].OcupantEnter(monster);
        }

        private void UpdateSpellboard()
        {
            spellboard.UpdateSpellboard(GetCurrentPlayer);
        }

        public void AddMonster(Monster monster, Player owner, int posX, int posY)
        {
            monster.Owner = owner;
            gameboard.tiles[posX, posY].OcupantEnter(monster);
        }

        public void TurnChange()
        {
            gameboard.currentPlayer = gameboard.currentPlayer == GetPlayers[0] ? GetPlayers[1] : GetPlayers[0];
            GetCurrentPlayer = gameboard.currentPlayer;
            resetEventData();
            ResetMonsterMovement();
            SoundEngine.say(GetCurrentPlayer.Name);
            UpdateSpellboard();
        }

        private void ResetMonsterMovement()
        {
            foreach (var tile in gameboard.tiles)
                if (tile.Occupant.Owner == GetCurrentPlayer && GetCurrentPlayer != null)
                {
                    var monster = tile.Occupant as Monster;
                    monster.MovesRemaining = monster.Moves;
                }
        }

        private void GenerateWizards(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player("Player" + (i + 1), i + 1);
                GetPlayers.Add(player);
            }

            var wizard1 = monsterGenerator.Monsters[3];
            wizard1.Name = "Wizard";
            wizard1.Caption = wizard1.Name;
            var wizard2 = monsterGenerator.Monsters[1];
            wizard2.Name = "Wizard";
            wizard2.Caption = wizard1.Name;

            AddMonster(wizard1, GetPlayers[0], 0, 0);
            AddMonster(wizard2, GetPlayers[1], 11, 11);
        }

        private void SetTileEvents()
        {
            foreach (var field in gameboard.tiles)
            {
                var pictureBox = field.Field;
                pictureBox.Click += (sender, args) => TileClicked(sender, args, field);
            }
        }


        public void TileClicked(object sender, EventArgs e, Tile clickSource)
        {
            // Checks whether Tile we are clicking is occupied by entity with type other than "Nothing",
            // we set the clicked Tile to be a context for our further operations (eg. decision making
            // on what happens on second mouse click)
            if (firstClick && clickSource.Occupant.GetType() != typeof(Nothing) &&
                clickSource.Occupant.Owner == GetCurrentPlayer)
            {
                sourceField = clickSource;
                selectedMonster = sourceField.Occupant as Monster;
                gameboard.MovesLeftLabel.Text = string.Format("Moves: {0}/{1}", selectedMonster.MovesRemaining,
                    selectedMonster.Moves);
                firstClick = false;
                SoundEngine.say((Monster) clickSource.Occupant);
            }
            // If we click the same tile twice, raise resetEventDataMethod to clean information
            else if (sourceField == clickSource)
            {
                resetEventData();
            }

            // Gets the source of second mouse click, then decides what to do based on types of clicked objects
            else if (!firstClick)
            {
                targetField = clickSource;
                if (targetField.Occupant.GetType() != typeof(Monster))
                {
                    if (Move(sourceField, targetField))
                    {
                        sourceField = targetField;
                        gameboard.MovesLeftLabel.Text = string.Format("Moves: {0}/{1}", selectedMonster.MovesRemaining,
                            selectedMonster.Moves);
                    }
                }

                else if (targetField.Occupant.GetType() == typeof(Monster) &&
                         targetField.Occupant.Owner != sourceField.Occupant.Owner &&
                         isMoveLegal(sourceField.FieldLocalization, targetField.FieldLocalization))
                {
                    Attack((Monster) sourceField.Occupant, (Monster) targetField.Occupant);
                }

                else
                {
                    resetEventData();
                }
            }

            else
            {
                resetEventData();
            }
        }


        private void GameOver()
        {
            MessageBox.Show(string.Format("Congratulations {0}, you've won!", GetCurrentPlayer));
        }

        #region Movement and Combat

        private bool Move(Tile source, Tile target)
        {
            var ocuppant = (Monster) source.Occupant;
            var sourceCoords = findCoordinatesInMatrix(source);
            var targetCoords = findCoordinatesInMatrix(target);
            if (isMoveLegal(sourceCoords, targetCoords) && ocuppant.MovesRemaining > 0)
            {
                source.OcuppantLeave();
                target.OcupantEnter(ocuppant);
                selectedMonster.MovesRemaining--;
                SoundEngine.playStepSound();
                return true;
            }

            return false;
        }

        private async Task<bool> Attack(Monster attacker, Monster defender)
        {
            var prevSprite = targetField.Occupant.Sprite;
            var damage = attacker.Attack - defender.Defense;
            defender.Health = defender.Health - damage > 0 ? damage : 0;

            if (defender.Health >= 0)
            {
                Die(attacker, defender, prevSprite);
            }

            else
            {
                SoundEngine.playAttackSound();
                await playCombatAnimation(prevSprite);
                resetEventData();
            }

            attacker.MovesRemaining = 0;

            return true;
        }

        private async void Die(Monster attacker, Monster defender, Bitmap prevBitmap)
        {
            SoundEngine.playAttackMoveSound();
            await playCombatAnimation(prevBitmap);

            targetField.OcuppantLeave();
            sourceField.OcuppantLeave();
            targetField.OcupantEnter(attacker);

            if (defender.Name == "Wizard")
                MessageBox.Show("Game Over!");
        }

        #endregion

        #region Private Helper Methods

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

        private bool isMoveLegal(Point sourcePoint, Point targetPoint)
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
            targetField.Field.Image = Resources.combat;
            await Task.Delay(550);
            targetField.Field.Image = previousBitmap;
        }

        public void resetEventData()
        {
            firstClick = true;
            targetField = null;
            selectedMonster = null;
            sourceField = null;
            gameboard.MovesLeftLabel.Text = "";
        }

        #endregion
    }
}
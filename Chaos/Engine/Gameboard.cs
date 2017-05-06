using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaos.Engine;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Chaos.Model;
using Chaos.Properties;
using Chaos.Utility;

namespace Chaos.Engine
{
    public class Gameboard
    {

        #region Fields and Properties
        public Panel GameboardPanel
        {
            get { return gameboardPanel; }
            set { gameboardPanel = value; }
        }
        private const int GAMEBOARD_SIZE = 12;
        public Tile[,] tiles = new Tile[GAMEBOARD_SIZE, GAMEBOARD_SIZE];
        private Panel gameboardPanel;
        private Label fieldName;
        private Label movesLeftLabel;     
        public List<Player> players = new List<Player>();
        public Player currentPlayer = null;
        #endregion
        #region Constructors and Initializers
        /// <summary>
        /// A simple gameboard constructor
        /// </summary>
        /// <param name="gamePanel">Panel control that will contain Tiles</param>
        /// <param name="fieldName">Label that displays name of field that our mouse hovers over</param>
        /// <param name="movesLeftLabel">Label that displays remaining moves of our monster</param>
        public Gameboard(Panel gamePanel, Label fieldName, Label movesLeftLabel)
        {
            //players.Add(new Player("Player 1", 1));
            //players.Add(new Player("Player 2", 2));

            this.gameboardPanel = gamePanel;
            this.movesLeftLabel = movesLeftLabel;
            this.fieldName = fieldName;

            this.movesLeftLabel.Text = "";
            this.fieldName.Text = "";


            //currentPlayer = players[0];
            InitializeTiles();
            InitializeGameboard();
        }
        /// <summary>
        /// Initializes Tile objects in a loop (size, location, events etc.)
        /// </summary>
        private void InitializeTiles()
        {
            for (int row = 0; row < GAMEBOARD_SIZE; row++)
            {
                for (int col = 0; col < GAMEBOARD_SIZE; col++)
                {
                    Tile tile = new Tile(new Point(row, col));
                    tile.Field.Click += (obj, ev) => TileClicked(obj, ev, tile);
                    tile.Field.MouseEnter += (obj, ev) => OnMouseOver(obj, ev, tile);
                    tile.Field.MouseLeave += OnMouseLeave;
                    tile.Occupant = new Nothing();
                    tiles[row, col] = tile;

                }
            }
        }
        /// <summary>
        /// Places Tiles from tiles[] array on a gameboard (also a loop)
        /// </summary>
        public void InitializeGameboard()
        {
            for (int row = 0; row < GAMEBOARD_SIZE; row++)
            {
                for (int col = 0; col < GAMEBOARD_SIZE; col++)
                {
                    gameboardPanel.Controls.Add(tiles[row, col].Field);
                }
            }
        }
        #endregion

        #region Field Related Methods and Fields

        private bool firstClick = true;
        private Tile sourceField = null;
        private Tile targetField = null;
        private Monster selectedMonster;
        /// <summary>
        /// Main logic for mouseclicks on Tiles.
        /// </summary>
        /// <param name="sender">Sender of an event</param>
        /// <param name="e"></param>
        /// <param name="clickSource">Since our EventArgs comes from a PictureBox, this is needed to define source the Tile</param>
        private void TileClicked(object sender, EventArgs e, Tile clickSource)
        {
            // Checks whether Tile we are clicking is occupied by entity with type other than "Nothing",
            // we set the clicked Tile to be a context for our further operations (eg. decision making
            // on what happens on second mouse click)
            if (firstClick && clickSource.Occupant.GetType() != typeof(Nothing) && clickSource.Occupant.Owner == currentPlayer)
            {
                sourceField = clickSource;
                selectedMonster = sourceField.Occupant as Monster;
                movesLeftLabel.Text = string.Format("Moves: {0}/{1}", selectedMonster.MovesRemaining,
                selectedMonster.Moves);
                firstClick = false;
                SoundEngine.say((Monster) clickSource.Occupant);
                return;
            }
            // If we click the same tile twice, raise resetEventDataMethod to clean information
            else if (sourceField == clickSource)
            {
                resetEventData();
                return;
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
                        movesLeftLabel.Text = string.Format("Moves: {0}/{1}", selectedMonster.MovesRemaining,
                            selectedMonster.Moves);
                    }
                }

                else if (targetField.Occupant.GetType() == typeof(Monster) &&
                         targetField.Occupant.Owner != sourceField.Occupant.Owner &&
                         isMoveLegal(sourceField.FieldLocalization, targetField.FieldLocalization))
                {
                    Attack((Monster)sourceField.Occupant, (Monster)targetField.Occupant);
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

        public void SwitchEvents(bool off = true)
        {
            foreach (Tile field in tiles)
            {
                if (off)
                {
                    field.Field.Click += (o, ev) => GetFieldData(o, ev, field);
                }

                else
                {
                    field.Field.Click += (obj, ev) => TileClicked(obj, ev, field);
                }
            }
        }

        public string GetFieldData(object sender, EventArgs e, Tile fld)
        {
            string occ = fld.Occupant == null ? "Empty" : fld.Occupant.Caption;
            // returns data for purpose of spellcasting
            return string.Format("{0} {1}", fld.Occupant.GetType(), occ);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            var tile = sender as PictureBox;
            fieldName.Text = "";
            tile.BorderStyle = BorderStyle.FixedSingle;
        }

        private void OnMouseOver(object sender, EventArgs e, Tile source)
        {
            var tile = sender as PictureBox;
            fieldName.Text = source.Occupant.Caption;
            tile.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Helper method, raise this when turn ends to reset movement points of current players monsters
        /// </summary>
        

        #endregion
        #region Movement and Combat
        private bool Move(Tile source, Tile target)
        {
            var ocuppant = (Monster)source.Occupant;
            Point sourceCoords = findCoordinatesInMatrix(source);
            Point targetCoords = findCoordinatesInMatrix(target);
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
            int damage = attacker.Attack - defender.Defense;
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
            {
                MessageBox.Show("Game Over!");
            }
        }
        #endregion
        #region Private Helper Methods

        private Point findCoordinatesInMatrix(Tile searchTarget)
        {
            Point itemPosition = new Point();
            int h = tiles.GetLength(0);
            int w = tiles.GetLength(1);

            for (int row = 0; row < h; row++)
            {
                for (int col = 0; col < w; col++)
                {
                    if (tiles[row, col].Equals(searchTarget))
                    {
                        return new Point(row, col);
                    }
                }
            }
            return itemPosition;
        }
        private bool isMoveLegal(Point sourcePoint, Point targetPoint)
        {
            if (
                (sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y) ||
                (sourcePoint.X == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y) ||
                (sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y - 1 == targetPoint.Y) ||
                (sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y == targetPoint.Y) ||
                (sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y == targetPoint.Y) ||
                (sourcePoint.X - 1 == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y) ||
                (sourcePoint.X == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y) ||
                (sourcePoint.X + 1 == targetPoint.X && sourcePoint.Y + 1 == targetPoint.Y)
            )
            {
                return true;
            }

            return false;
        }
        private async Task playCombatAnimation(Bitmap previousBitmap)
        {
            targetField.Field.Image = Properties.Resources.combat;
            await Task.Delay(550);
            targetField.Field.Image = previousBitmap;
        }
        public void resetEventData()
        {
            firstClick = true;
            targetField = null;
            selectedMonster = null;
            sourceField = null;
            movesLeftLabel.Text = "";
        }

        #endregion
    }

}

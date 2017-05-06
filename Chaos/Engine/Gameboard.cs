using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.Engine
{
    public class Gameboard
    {
        #region Fields and Properties

        public Panel GameboardPanel { get; set; }

        public Label FieldName { get; set; }

        public Label MovesLeftLabel { get; set; }

        private const int GAMEBOARD_SIZE = 12;
        public Tile[,] tiles = new Tile[GAMEBOARD_SIZE, GAMEBOARD_SIZE];
        public List<Player> players = new List<Player>();
        public Player currentPlayer = null;

        #endregion

        #region Constructors and Initializers

        /// <summary>
        ///     A simple gameboard constructor
        /// </summary>
        /// <param name="gamePanel">Panel control that will contain Tiles</param>
        /// <param name="fieldName">Label that displays name of field that our mouse hovers over</param>
        /// <param name="movesLeftLabel">Label that displays remaining moves of our monster</param>
        public Gameboard(Panel gamePanel, Label fieldName, Label movesLeftLabel)
        {
            //players.Add(new Player("Player 1", 1));
            //players.Add(new Player("Player 2", 2));

            GameboardPanel = gamePanel;
            MovesLeftLabel = movesLeftLabel;
            FieldName = fieldName;

            MovesLeftLabel.Text = "";
            FieldName.Text = "";


            //currentPlayer = players[0];
            InitializeTiles();
            InitializeGameboard();
        }

        /// <summary>
        ///     Initializes Tile objects in a loop (size, location, events etc.)
        /// </summary>
        private void InitializeTiles()
        {
            for (var row = 0; row < GAMEBOARD_SIZE; row++)
            for (var col = 0; col < GAMEBOARD_SIZE; col++)
            {
                var tile = new Tile(new Point(row, col));
                tile.Field.MouseEnter += (obj, ev) => OnMouseOver(obj, ev, tile);
                tile.Field.MouseLeave += OnMouseLeave;
                tile.Occupant = new Nothing();
                tiles[row, col] = tile;
            }
        }

        /// <summary>
        ///     Places Tiles from tiles[] array on a gameboard (also a loop)
        /// </summary>
        public void InitializeGameboard()
        {
            for (var row = 0; row < GAMEBOARD_SIZE; row++)
            for (var col = 0; col < GAMEBOARD_SIZE; col++)
                GameboardPanel.Controls.Add(tiles[row, col].Field);
        }

        #endregion

        #region Field Related Methods and Fields

        /// <summary>
        ///     Main logic for mouseclicks on Tiles.
        /// </summary>
        /// <param name="sender">Sender of an event</param>
        /// <param name="e"></param>
        /// <param name="clickSource">Since our EventArgs comes from a PictureBox, this is needed to define source the Tile</param>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            var tile = sender as PictureBox;
            FieldName.Text = "";
            tile.BorderStyle = BorderStyle.FixedSingle;
        }

        private void OnMouseOver(object sender, EventArgs e, Tile source)
        {
            var tile = sender as PictureBox;
            FieldName.Text = source.Occupant.Caption;
            tile.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Helper method, raise this when turn ends to reset movement points of current players monsters
        /// </summary>

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Interfaces;
using ExtendedXmlSerialization;

namespace Chaos.Engine
{
    public class Gameboard : ILookupable<Tile>
    {
        #region Fields and Properties
        private Panel GameboardPanel { get; set; }
        public Label FieldName { get; set; }
        public Label MovesLeftLabel { get; set; }

        private int gameboardSize;
        private Tile[,] tiles;
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
        public Gameboard(Panel gamePanel, Label fieldName, Label movesLeftLabel, int gameboardSize = 14)
        {
            this.gameboardSize = gameboardSize;
            tiles = new Tile[gameboardSize, gameboardSize];
            GameboardPanel = gamePanel;
            MovesLeftLabel = movesLeftLabel;
            FieldName = fieldName;

            MovesLeftLabel.Text = "";
            FieldName.Text = "";


            InitializeTiles();
            InitializeGameboard();
        }

        /// <summary>
        ///     Initializes Tile objects in a loop (size, location, events etc.)
        /// </summary>
        private void InitializeTiles()
        {
            for (var row = 0; row < gameboardSize; row++)
            for (var col = 0; col < gameboardSize; col++)
            {
                var tile = new Tile(new Point(row, col));
                tile.Field.MouseEnter += (obj, ev) => OnMouseOver(obj, ev, tile);
                tile.Field.MouseLeave += OnMouseLeave;
                tile.SetOccupant(new Nothing());
                tiles[row, col] = tile;
            }
        }

        /// <summary>
        ///     Places Tiles from tiles[] array on a gameboard (also a loop)
        /// </summary>
        public void InitializeGameboard()
        {
            for (var row = 0; row < gameboardSize; row++)
            for (var col = 0; col < gameboardSize; col++)
                GameboardPanel.Controls.Add(tiles[row, col].Field);
        }

        #endregion

        #region Field Related Methods and Fields

        private void OnMouseLeave(object sender, EventArgs e)
        {
            var tile = sender as PictureBox;
            FieldName.Text = "";
         //   tile.BorderStyle = BorderStyle.FixedSingle;
        }

        private void OnMouseOver(object sender, EventArgs e, Tile source)
        {
            var tile = sender as PictureBox;
            FieldName.Text = source.GetOccupant().Caption;
         //   tile.BorderStyle = BorderStyle.None;
        }
        public IEnumerable<Tile> GetElementsCollection()
        {
            List<Tile> tilesList = new List<Tile>();
            foreach (Tile element in tiles)
                tilesList.Add(element);

            return tilesList.ToArray();
        }

        public Tile GetElement(Tile element)
        {
            foreach(Tile e in tiles)
            {
                if (e.Equals(element))
                    return e;
            }
           throw new NullReferenceException();
        }
        public Tile GetElement(Point cooridnates)
        {
            return tiles[cooridnates.X, cooridnates.Y];
        }

        #endregion
    }
}
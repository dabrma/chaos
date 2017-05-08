using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Utility;

namespace Chaos.Engine
{
    public class SpellBoard
    {
        private const int SPELLBOARD_WIDTH = 2;
        private const int SPELLBOARD_HEIGHT = 10;
        private const int SPELLS_AMOUNT = 98;


        private bool firstClick = true;
        private readonly List<Player> players;
        private Tile sourceField;

        /// <summary>
        ///     Panel that contains spell Tiles
        /// </summary>
        private readonly Panel spellboardPanel;

        private readonly SpellsGenerator spellsGenerator = new SpellsGenerator();

        private readonly Dictionary<Player, List<Spell>> spellsPool = new Dictionary<Player, List<Spell>>();
        private readonly SpellTile[,] spellTiles = new SpellTile[SPELLBOARD_WIDTH, SPELLBOARD_HEIGHT];
        private Tile targetField;


        public SpellBoard(Panel spellboardPanel, List<Player> players)
        {
            this.spellboardPanel = spellboardPanel;
            this.players = players;
            populateSpellsArray();
        }

        private void populateSpellsArray()
        {
            var spells = new List<Spell>[players.Count];
            for (var ii = 0; ii < players.Count; ii++)
            {
                spells[ii] = new List<Spell>();
                for (var jj = 0; jj < SPELLS_AMOUNT; jj++)
                    spells[ii].Add(spellsGenerator.GenerateSpellFromText(players[ii]));

                spellsPool.Add(players[ii], spells[ii]);
            }
        }

        internal void UpdateSpellboard(Player currentPlayer)
        {
            InitializeSpellTiles(currentPlayer);
        }

        private void InitializeSpellTiles(Player currentPlayer)
        {
            ClearSpellBoard();

            for (var col = 0; col < SPELLBOARD_WIDTH; col++)
            for (var row = 0; row < SPELLBOARD_HEIGHT; row++)
            {
                var spellTile = new SpellTile(new Point(col, row));
                spellTile.Field.Click += (obj, ev) => OnSpellClick(obj, ev, spellTile);
                // tile.Field.MouseEnter += (obj, ev) => OnMouseOver(obj, ev, tile);
                // tile.Field.MouseLeave += OnMouseLeave;                   
                spellTile.Occupant = spellsPool[currentPlayer].ElementAt(col + 1 * row);

                spellTile.OcupantEnter(spellTile.Occupant);
                spellTiles[col, row] = spellTile;
            }

            InitializeSpellBoard();
        }

        private void InitializeSpellBoard()
        {
            for (var col = 0; col < SPELLBOARD_WIDTH; col++)
            for (var row = 0; row < SPELLBOARD_HEIGHT; row++)
                spellboardPanel.Controls.Add(spellTiles[col, row].Field);
        }

        private void ClearSpellBoard()
        {
            if (spellboardPanel.Controls.Count > 0)
                for (var col = 0; col < SPELLBOARD_WIDTH; col++)
                for (var row = 0; row < SPELLBOARD_HEIGHT; row++)
                    spellboardPanel.Controls.Remove(spellTiles[col, row].Field);
        }

        public void OnSpellClick(object sender, EventArgs e, Tile source)
        {
            if (firstClick)
            {
                sourceField = source;
                SoundEngine.say(source.Occupant.Caption);
                firstClick = false;
            }

            else
            {
                if (source == sourceField)
                {
                    firstClick = true;
                    return;
                } // do nothing

                targetField = source;
                EventLogger.WriteLog(source.FieldLocalization.ToString());
            }
        }

        public void HideSpellBoard()
        {
            spellboardPanel.Visible = false;
        }
    }
}
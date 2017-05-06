using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Utility;

namespace Chaos.Engine
{
    class SpellBoard
    {
        /// <summary>
        /// Panel that contains spell Tiles
        /// </summary>
        private Panel spellboardPanel;
        private SpellsGenerator spellsGenerator = new SpellsGenerator();
        private const int SPELLBOARD_WIDTH = 2;
        private const int SPELLBOARD_HEIGHT = 10;
        private const int SPELLS_AMOUNT = 98;
        private List<Player> players;
        private SpellTile[,] spellTiles = new SpellTile[SPELLBOARD_WIDTH, SPELLBOARD_HEIGHT];

        private Dictionary<Player, List<Spell>> spellsPool = new Dictionary<Player, List<Spell>>();

        private void populateSpellsArray()
        {
            List<Spell>[] spells = new List<Spell>[players.Count];
            for (int ii = 0; ii < players.Count; ii++)
            {
                spells[ii] = new List<Spell>();
                for (int jj = 0; jj < SPELLS_AMOUNT; jj++)
                {
                    spells[ii].Add(spellsGenerator.GenerateSpellFromText(players[ii]));
                }

                spellsPool.Add(players[ii], spells[ii]);
            }
        }

        internal void UpdateSpellboard(Player currentPlayer)
        {
            InitializeSpellTiles(currentPlayer);
        }

        public SpellBoard(Panel spellboardPanel, List<Player> players)
        {
            this.spellboardPanel = spellboardPanel;
            this.players = players;
            populateSpellsArray();     
        }       

        private void InitializeSpellTiles(Player currentPlayer)
        {
            ClearSpellBoard();

            for (int col = 0; col < SPELLBOARD_WIDTH; col++)
            {
                for (int row = 0; row < SPELLBOARD_HEIGHT; row++)
                {
                    SpellTile spellTile = new SpellTile(new Point(col, row));
                    spellTile.Field.Click += (obj, ev) => OnSpellClick(obj, ev, spellTile);
                    // tile.Field.MouseEnter += (obj, ev) => OnMouseOver(obj, ev, tile);
                    // tile.Field.MouseLeave += OnMouseLeave;                   
                    spellTile.Occupant = spellsPool[currentPlayer].ElementAt(col + 1 * row);
   
                    spellTile.OcupantEnter(spellTile.Occupant);
                    spellTiles[col, row] = spellTile;
                }
            }

            InitializeSpellBoard();
        }
        private void InitializeSpellBoard()
        {
            for (int col = 0; col < SPELLBOARD_WIDTH; col++)
            {
                for (int row = 0; row < SPELLBOARD_HEIGHT; row++)
                {
                   spellboardPanel.Controls.Add(spellTiles[col, row].Field);
                }
            }
        }
        private void ClearSpellBoard()
        {
            if (spellboardPanel.Controls.Count > 0)
            {
                for (int col = 0; col < SPELLBOARD_WIDTH; col++)
                {
                    for (int row = 0; row < SPELLBOARD_HEIGHT; row++)
                    {
                        spellboardPanel.Controls.Remove(spellTiles[col, row].Field);
                    }
                }
            }
        }


        private bool firstClick = true;
        private Tile sourceField = null;
        private Tile targetField = null;
        
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
                if(source == sourceField) { firstClick = true; return; } // do nothing

                targetField = source;
                EventLogger.WriteLog(source.FieldLocalization.ToString());
            }
        }

    }
}

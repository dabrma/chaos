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
        public Player currentPlayer { get; set; }
        private Tile sourceField;

        /// <summary>
        ///     Panel that contains spell Tiles
        /// </summary>
        private readonly Panel spellboardPanel;
        private readonly GameEngine engine;
        private readonly SpellsGenerator spellsGenerator = new SpellsGenerator();
        private readonly SpellTile[,] spellTiles = new SpellTile[SPELLBOARD_WIDTH, SPELLBOARD_HEIGHT];
        private Tile targetField;


        public SpellBoard(Panel spellboardPanel, List<Player> players, GameEngine engine)
        {
            this.engine = engine;
            this.spellboardPanel = spellboardPanel;
            this.players = players;
            populateSpellsArray();
        }

        private void populateSpellsArray()
        {
            for (var ii = 0; ii < players.Count; ii++)
            {
               while(players[ii].AvailableSpells.Count < SPELLS_AMOUNT)
                {
                    players[ii].AvailableSpells.Add(spellsGenerator.GenerateSpellFromText());
                }
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
                var currentPlayerIndex = players.IndexOf(currentPlayer);             
                spellTile.Occupant = players[currentPlayerIndex].AvailableSpells.ElementAt(col + 1 * row);

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
            var currentPlayerIndex = players.IndexOf(currentPlayer);
            bool finishedPicking = currentPlayerIndex +1 == players.Count;

            var spell = source.Occupant as Spell;
            SoundEngine.playClickSound();
            currentPlayer.SelectedSpell = spell;

            currentPlayer = engine.SwitchPlayer();
            UpdateSpellboard(engine.CurrentPlayer);


            if(finishedPicking)
            {
                engine.ChangePhase(GamePhase.Casting);
            }
        }

        public void IsSpellboardVisible(bool visible)
        {
            spellboardPanel.Visible = visible;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Chaos.Interfaces;
using Chaos.Model;

namespace Chaos.Engine
{
    public class SpellBoard : ILookupable<SpellTile>
    {
        private const int SPELLBOARD_WIDTH = 2;
        private const int SPELLBOARD_HEIGHT = 10;
        private readonly GameEngine engine;
        private readonly List<Player> players;

        /// <summary>
        ///     Panel that contains spell Tiles
        /// </summary>
        private readonly Panel spellboardPanel;

        private readonly SpellsGenerator spellsGenerator = new SpellsGenerator();
        private readonly SpellTile[,] spellTiles = new SpellTile[SPELLBOARD_WIDTH, SPELLBOARD_HEIGHT];


        private bool firstClick = true;
        private Tile sourceField;
        private Tile targetField;


        public SpellBoard(Panel spellboardPanel, List<Player> players, GameEngine engine, int spellsAmount,
            bool generateSpells = true)
        {
            this.engine = engine;
            SPELLS_AMOUNT = spellsAmount;
            this.spellboardPanel = spellboardPanel;
            this.players = players;
            // this.currentPlayer = players[0];

            if (generateSpells)
                populateSpellsArray();
        }

        public int SPELLS_AMOUNT { get; set; }
        public Player currentPlayer { get; set; }

        public IEnumerable<SpellTile> GetElementsCollection()
        {
            var spellsList = new List<SpellTile>();
            foreach (var spell in spellTiles)
                spellsList.Add(spell);

            return spellsList.ToArray();
        }

        public SpellTile GetElement(SpellTile elementReference)
        {
            throw new NotImplementedException();
        }

        public SpellTile GetElement(Point cooridnates)
        {
            throw new NotImplementedException();
        }

        private void populateSpellsArray()
        {
            for (var ii = 0; ii < players.Count; ii++)
                while (players[ii].AvailableSpells.Count < SPELLS_AMOUNT)
                    players[ii].AvailableSpells.Add(spellsGenerator.GenerateRandomSpell());
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
                var currentPlayerIndex = players.IndexOf(currentPlayer);
                if (players[currentPlayerIndex].AvailableSpells.Count > col + 1 * row)
                    spellTile.SetOccupant(players[currentPlayerIndex].AvailableSpells.ElementAt(col + 1 * row));
                else
                    spellTile.SetOccupant();

                spellTile.SetOccupant(spellTile.GetOccupant());
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
            var finishedPicking = currentPlayerIndex + 1 == players.Count;

            var spell = source.GetOccupant() as Spell;
            SoundEngine.playClickSound();
            currentPlayer.SelectedSpell = spell;
            currentPlayer.AvailableSpells.Remove(spell);

            currentPlayer = engine.SwitchPlayer();
            UpdateSpellboard(engine.CurrentPlayer);


            if (finishedPicking)
                engine.ChangePhase(GamePhase.Casting);
        }

        public void IsSpellboardVisible(bool visible)
        {
            spellboardPanel.Visible = visible;
        }
    }
}
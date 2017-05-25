using System;
using System.Diagnostics;
using System.Windows.Forms;
using Chaos.Engine;
using Chaos.Misc;
using Chaos.Model;
using Chaos.Properties;

namespace Chaos
{
    public partial class GameForm : Form
    {
        public GameEngine engine;
        public Gameboard gameboard;
        public SpellBoard spellboard;
        private readonly int NumberOfTurns;

        public GameForm(int numberOfPlayers, int numberOfTurns, int numberOfSpells)
        {
            InitializeComponent();
            NumberOfTurns = numberOfTurns;

            DescriptionPanel.Visible = false;
            gameboard = new Gameboard(gamePanel, fieldName, movesLeftLabel);
            engine = new GameEngine(numberOfPlayers, gameboard, this, numberOfTurns);
            spellboard = new SpellBoard(spellPanel, engine.Players, engine, numberOfSpells);
            engine.spellboard = spellboard;
            engine.InitializeEngineElements();
        }

        public GameForm()
        {
            InitializeComponent();
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            engine.TurnChange();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            engine.DescriptionMode = engine.DescriptionMode == false
                ? engine.DescriptionMode = true
                : engine.DescriptionMode = false;
            if (engine.DescriptionMode)
                helpButton.BorderStyle = BorderStyle.Fixed3D;

            else helpButton.BorderStyle = BorderStyle.None;
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            var gameSaver = new GameSaver(gameboard.GetElementsCollection(), engine.Players, engine.CurrentPlayer, NumberOfTurns);
            gameSaver.SaveGame();

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
using System;
using System.Windows.Forms;
using Chaos.Engine;
using Chaos.Model;

namespace Chaos.UI
{
    public partial class GameForm : Form
    {
        private readonly int NumberOfTurns;
        public GameEngine engine;
        public Gameboard gameboard;
        public SpellBoard spellboard;

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

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(-1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameSaver = new GameSaver(gameboard.GetElementsCollection(), engine.Players, engine.CurrentPlayer,
                NumberOfTurns);
            gameSaver.SaveGame();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameLoader = new GameLoader();
            try
            {
                gameLoader.LoadGame();
                Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An error has occured during game loading {exception.Message}");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStart newGameForm = new FormStart();
            newGameForm.Show();
            this.Dispose();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var aboutPopup = new About();
            aboutPopup.ShowDialog();
        }
    }
}
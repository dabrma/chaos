using System;
using System.Windows.Forms;
using Chaos.Engine;
using Chaos.Misc;
using Chaos.Properties;

namespace Chaos
{
    public partial class GameForm : Form
    {
        public GameEngine engine;
        public Gameboard gameboard;
        public SpellBoard spellboard;

        public GameForm(int numberOfPlayers, int numberOfTurns, int numberOfSpells)
        {
            InitializeComponent();

            UseWaitCursor = false;
            Cursor = CreateCursorFromStream.CreateCursor(Resources.wand_mc_style_a_nightmare);
            GetDescriptionPanel.Visible = false;
            gameboard = new Gameboard(gamePanel, fieldName, movesLeftLabel);
            engine = new GameEngine(numberOfPlayers, gameboard, this);
            spellboard = new SpellBoard(spellPanel, engine.Players, engine, numberOfSpells);
            engine.spellboard = spellboard;
            engine.InitializeEngineElements();
        }

        public GameForm()
        {
            InitializeComponent();
        }

        public Panel GetDescriptionPanel { get; set; }

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
            engine.gameSaver.SaveGame();
        }
    }
}
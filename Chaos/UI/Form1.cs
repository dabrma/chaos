using System;
using System.Windows.Forms;
using Chaos.Engine;
using Chaos.Utility;
using Chaos.Misc;
using Chaos.Properties;

namespace Chaos
{
    public partial class Form1 : Form
    {
        private readonly GameEngine engine;
        private readonly Gameboard gameboard;
        private readonly SpellBoard spellboard;

        public Panel GetDescriptionPanel { get { return descPanel; } set { descPanel = value; } }

        public Form1()
        {
            InitializeComponent();
            this.UseWaitCursor = false;
            this.Cursor = CreateCursorFromStream.CreateCursor(Resources.wand_mc_style_a_nightmare);
            descPanel.Visible = false;
            gameboard = new Gameboard(gamePanel, fieldName, movesLeftLabel);
            engine = new GameEngine(2, gameboard, this);
            spellboard = new SpellBoard(spellPanel, engine.GetPlayers, engine, 98);
            engine.spellboard = spellboard;
            engine.InitializeEngineElements();
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            engine.TurnChange();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            engine.DescriptionMode = engine.DescriptionMode == false ? engine.DescriptionMode = true : engine.DescriptionMode = false;
            if (engine.DescriptionMode)
            {
                helpButton.BorderStyle = BorderStyle.Fixed3D;
            }

            else { helpButton.BorderStyle = BorderStyle.None;}
        }
    }
}
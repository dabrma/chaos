using System;
using System.Windows.Forms;
using Chaos.Engine;

namespace Chaos
{
    public partial class Form1 : Form
    {
        private readonly GameEngine engine;
        private readonly Gameboard gameboard;
        private readonly SpellBoard spellboard;

        public Form1()
        {
            InitializeComponent();
            gameboard = new Gameboard(gamePanel, fieldName, movesLeftLabel);
            engine = new GameEngine(2, gameboard);
            spellboard = new SpellBoard(spellPanel, engine.GetPlayers);
            engine.spellboard = spellboard;
            engine.InitializeEngineElements();

            engine.AddMonster(1, 1);
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            engine.TurnChange();
        }
    }
}
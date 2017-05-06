using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaos.Engine;
using Chaos.Model;
using System.Windows.Forms;

namespace Chaos
{
    public partial class Form1 : Form
    {
        private GameEngine engine;
        private Gameboard gameboard;
        private SpellBoard spellboard;

        public Form1()
        {
            InitializeComponent();
            gameboard = new Gameboard(gamePanel, fieldName, movesLeftLabel);
            engine = new GameEngine(2, gameboard);
            spellboard = new SpellBoard(spellPanel, engine.GetPlayers);
            engine.spellboard = spellboard;

            // test dodawania z poziomu game engine
            engine.AddMonster(1, 1);

        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
             engine.TurnChange();
        }
    }
}

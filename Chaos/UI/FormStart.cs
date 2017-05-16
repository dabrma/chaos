using Chaos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaos
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            this.SetingsPanel.Show();
        }

        private void buttonsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bExitGame_Click(object sender, EventArgs e)
        {

        }

        private void bLoadGame_Click(object sender, EventArgs e)
        {
            GameLoader gameLoader = new GameLoader();
            gameLoader.LoadGame();
        }

        private void lNumberOfPlayers_Click(object sender, EventArgs e)
        {

        }

        private void bStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tNameOfPlayer_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

    }
}

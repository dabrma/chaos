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

namespace Chaos.UI
{
    public partial class GameOver : Form
    {
        private List<Player> Players;
        public GameOver(List<Player> players)
        {
            this.Players = players;

            //Player mock = new Player("Player1");
            //mock.Points = 100;
            //Player mock2 = new Player("Player2");
            //mock2.Points = 80;
            //Player mock3 = new Player("Player3");
            //mock3.Points = 20;
            //Player mock4 = new Player("Player4");
            //mock4.Points = 60;

            //Players.Add(mock);
            //Players.Add(mock2);
            //Players.Add(mock3);
            //Players.Add(mock4);
            Players = new List<Player>(Players.OrderByDescending(p => p.Points));
            InitializeComponent();
            DisplayScore();
        }

        public void DisplayScore()
        {
            Point location = new Point(0, 120);
            foreach (Player player in Players) {

                CreateControlsGroup(player, location);
                location.Y += 50;

            }

        }

        private void CreateControlsGroup(Player player, Point position)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(48, 48);
            var wizardSprite = (Bitmap)Properties.Resources.ResourceManager.GetObject("Wizard" + player.Name.Last());
            pb.Image = wizardSprite;
            pb.Location = position;

            Label playerName = new Label();
            playerName.AutoSize = true;
            playerName.ForeColor = Color.White;
            playerName.Size = new Size(76, 18);
            playerName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            playerName.Text = player.Name;
            playerName.Location = new Point(150, position.Y + 16);

            Label pointsLabel = new Label();
            pointsLabel.AutoSize = true;
            pointsLabel.ForeColor = Color.White;
            pointsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pointsLabel.Text = player.Points.ToString();
            pointsLabel.Location = new Point((290), position.Y + 16);

            this.Controls.Add(pb);
            this.Controls.Add(playerName);
            this.Controls.Add(pointsLabel);
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

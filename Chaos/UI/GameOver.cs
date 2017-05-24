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
            Players.OrderByDescending(p => p.Points);
            Player mock = new Player("Player1");
            mock.Points = 100;
            Player mock2 = new Player("Player2");
            mock.Points = 30;

            Players.Add(mock);
            Players.Add(mock2);

            InitializeComponent();
            DisplayScore();
        }

        public void DisplayScore()
        {
            Point location = new Point(0, 150);
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
            playerName.Location = new Point((position.X + 50), position.Y + 16);

            Label pointsLabel = new Label();
            pointsLabel.AutoSize = true;
            pointsLabel.ForeColor = Color.White;
            pointsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pointsLabel.Text = player.Points.ToString();
            pointsLabel.Location = new Point((position.X + 60 + 80), position.Y + 16);

            this.Controls.Add(pb);
            this.Controls.Add(playerName);
            this.Controls.Add(pointsLabel);
        }
    }
}

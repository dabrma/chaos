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
        private int numberOfPlayers = 2;
        private int numberOfSpells = 0;
        private int numberOfTurns = 0;

        public int NumberOfPlayers { get;}
        public int NumberOfSpells { get; }
        public int NumberOfTurns { get; }


        public FormStart()
        {
            InitializeComponent();
        }

        #region StartPanel
        private void bNewGame_Click(object sender, EventArgs e)
        {
            this.SettingsPanel.Show();
        }

        private void bExitGame_Click(object sender, EventArgs e)
        {

        }

        private void bLoadGame_Click(object sender, EventArgs e)
        {

        }

        private void bStart_Click(object sender, EventArgs e)
        {
        /*

            this.Close();
        }
        #endregion

        #region SettingsPanel
        private void tNumberOfPlayer_Scroll(object sender, EventArgs e)
        {
            numberOfPlayers = tNumberOfPlayer.Value;
            this.lNumberOfPlayersValue.Text = Convert.ToString(tNumberOfPlayer.Value);

            GameLoader gameLoader = new GameLoader();
            gameLoader.LoadGame();
*/
        }

        #region Entering the number of spells and turns

        private void bNoOfSpellsLeft_Click(object sender, EventArgs e)
        {
            String value = this.tNumberOfSpells.Text;
            this.tNumberOfSpells.Text = ChangeValue(value, "-");
        }

        private void bNoOfSpellsRight_Click(object sender, EventArgs e)
        {
            String value = this.tNumberOfSpells.Text;
            this.tNumberOfSpells.Text = ChangeValue(value, "+");
        }

        private void bNoOfTurnsLeft_Click(object sender, EventArgs e)
        {
            String value = this.tNumberOfTurns.Text;
            this.tNumberOfTurns.Text = ChangeValue(value, "-");
        }

        private void bNoOfTurnsRight_Click(object sender, EventArgs e)
        {
            String value = this.tNumberOfTurns.Text;
            this.tNumberOfTurns.Text = ChangeValue(value, "+");
        }


        private String ChangeValue(String value, String direction)
        {
            int number = Int32.Parse(value);

            if (number == 0 && direction=="-")
            {
                number = 99;
            }
            else if (number == 99 && direction=="+")
            {
                number = 0;
            }
            else
            {
                switch (direction)
                {
                    case "+":
                        number++;
                        break;
                    case "-":
                        number--;
                        break;
                    default:
                        number = -1; //flag to debugging
                        break;

                }
            }

            return Convert.ToString(number);
        }

        private void tNumberOfSpells_TextChanged(object sender, EventArgs e)
        {
            numberOfSpells = ParseTextToValue(this.tNumberOfSpells);

        }

        private void tNumberOfTurns_TextChanged(object sender, EventArgs e)
        {
            numberOfTurns = ParseTextToValue(this.tNumberOfTurns);
        }

        private int ParseTextToValue(TextBox box)
        {
            int value=0;
            try
            {
                value = Int32.Parse(box.Text);
                //Console.WriteLine("spells: " + value);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine(ex.Message);
                value = 0;
            }
            finally
            {
                box.Text = Convert.ToString(value);
            }

            return value;
        }
        #endregion
        #endregion

    }
}

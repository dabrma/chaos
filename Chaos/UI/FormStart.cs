using Chaos.Model;
using System;
using System.Windows.Forms;

namespace Chaos
{
    public partial class FormStart : Form
    {
        private int numberOfPlayers = 2;
        private int numberOfSpells;
        private int numberOfTurns;


        public FormStart()
        {
            InitializeComponent();
        }

        public int NumberOfPlayers { get; }
        public int NumberOfSpells { get; }
        public int NumberOfTurns { get; }

        #region StartPanel

        private void bNewGame_Click(object sender, EventArgs e)
        {
            SettingsPanel.Show();
        }

        private void bExitGame_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bLoadGame_Click(object sender, EventArgs e)
        {

             GameLoader gameLoader = new GameLoader();
             gameLoader.StartMenu = this;
             gameLoader.LoadGame();
             SettingsPanel.Hide();

        }

        private void bStart_Click(object sender, EventArgs e)
        {
            var newGame = new GameForm(numberOfPlayers, numberOfTurns, numberOfSpells);
            newGame.engine.startForm = this;
            newGame.Show();
            this.Visible = false;
            SettingsPanel.Hide();
        }

        #endregion

        #region SettingsPanel

        private void tNumberOfPlayer_Scroll(object sender, EventArgs e)
        {
            numberOfPlayers = tNumberOfPlayer.Value;
            lNumberOfPlayersValue.Text = Convert.ToString(tNumberOfPlayer.Value);
        }

        #region Entering the number of spells and turns

        private void bNoOfSpellsLeft_Click(object sender, EventArgs e)
        {
            var value = tNumberOfSpells.Text;
            tNumberOfSpells.Text = ChangeValue(value, "-");
        }

        private void bNoOfSpellsRight_Click(object sender, EventArgs e)
        {
            var value = tNumberOfSpells.Text;
            tNumberOfSpells.Text = ChangeValue(value, "+");
        }

        private void bNoOfTurnsLeft_Click(object sender, EventArgs e)
        {
            var value = tNumberOfTurns.Text;
            tNumberOfTurns.Text = ChangeValue(value, "-");
        }

        private void bNoOfTurnsRight_Click(object sender, EventArgs e)
        {
            var value = tNumberOfTurns.Text;
            tNumberOfTurns.Text = ChangeValue(value, "+");
        }


        private string ChangeValue(string value, string direction)
        {
            var number = int.Parse(value);

            if (number == 0 && direction == "-")
                number = 99;
            else if (number == 99 && direction == "+")
                number = 0;
            else
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

            return Convert.ToString(number);
        }

        private void tNumberOfSpells_TextChanged(object sender, EventArgs e)
        {
            numberOfSpells = ParseTextToValue(tNumberOfSpells);
        }

        private void tNumberOfTurns_TextChanged(object sender, EventArgs e)
        {
            numberOfTurns = ParseTextToValue(tNumberOfTurns);
        }

        private int ParseTextToValue(TextBox box)
        {
            var value = 0;
            try
            {
                value = int.Parse(box.Text);
                //Console.WriteLine("spells: " + value);
            }
            catch (FormatException ex)
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
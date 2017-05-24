using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.UI;
using System.Linq;

namespace Chaos.Engine
{
    public enum GamePhase
    {
        Picking,
        Casting,
        Moving
    }

    public class GameEngine
    {
        private readonly MonsterActions actions;
        private readonly GameForm gameForm;
        private readonly Spellcasting spellcasting;
        public FormStart startForm;
        private bool firstClick = true;
        private int TurnsPassed = 0;
        private int turnsLimit = 0;
        private GamePhase gamePhase;
        private SoundEngine eng = new SoundEngine();

        public GameSaver gameSaver;
        public readonly MonsterGenerator monsterGenerator = new MonsterGenerator();
        public bool DescriptionMode = false;

        public Tile GetSourceField { get; private set; }
        public Monster GetSelectedMonster { get; private set; }
        public Tile GetTargetField { get; private set; }
        public Gameboard gameboard { get; set; }
        public SpellBoard spellboard { get; set; }
        public Player CurrentPlayer { get; set; }

        public List<Player> Players = new List<Player>();
        private DescriptionPanel monsterDescriptionPanel;

        public GameEngine(int NumberOfPlayers, Gameboard gameboard, GameForm gameForm, int turnsLimit, bool autogenerate = true)
        {
            this.gameboard = gameboard;
            this.turnsLimit = turnsLimit * NumberOfPlayers;
            actions = new MonsterActions(gameboard, this);
            SetTileEvents();
            if (autogenerate)
            {
                GenerateWizards(NumberOfPlayers);
                CurrentPlayer = Players[0];
            }
            gameboard.players = Players;
            spellcasting = new Spellcasting(gameboard, this);
            this.gameForm = gameForm;
            gameForm.GetDescriptionPanel.Click += HideDescriptionPanel;
            gameSaver = new GameSaver(gameboard.GetElementsCollection(), Players);
        }


        private void HideDescriptionPanel(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.Hide();
        }

        public void InitializeEngineElements(bool isGameLoaded = false)
        {
            if (!isGameLoaded)
            {
                gamePhase = GamePhase.Picking;
                spellboard.currentPlayer = CurrentPlayer;
                gameboard.currentPlayer = CurrentPlayer;
                UpdateSpellboard();
            }

            else
            {
                gamePhase = GamePhase.Moving;
                spellboard.IsSpellboardVisible(false);
                spellboard.currentPlayer = CurrentPlayer;
                gameboard.currentPlayer = CurrentPlayer;
            }
        }

        public void ChangePhase(GamePhase phase)
        {
            gamePhase = phase;
            OnPhaseChange();
        }

        /// <summary>
        /// Calls methods to perform depending on game phase.
        /// </summary>
        public void OnPhaseChange()
        {
            switch (gamePhase)
            {
                case GamePhase.Picking:
                    spellcasting.finishedCasting = false;
                    CurrentPlayer = Players[0];
                    spellboard.currentPlayer = CurrentPlayer;
                    spellboard.UpdateSpellboard(CurrentPlayer);
                    spellboard.IsSpellboardVisible(true);
                    break;
                case GamePhase.Casting:
                    CurrentPlayer = Players[0];
                    spellboard.IsSpellboardVisible(false);
                    break;
                case GamePhase.Moving:
                    resetEventData();
                    break;
            }
        }

        public Spell GetCurrentSpell()
        {
            return CurrentPlayer.SelectedSpell;
        }

        private void UpdateSpellboard()
        {
            spellboard.UpdateSpellboard(CurrentPlayer);
        }

        /// <summary>
        /// Adds a monster to a Tile and gives it an owner
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="owner"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public void AddMonster(Monster monster, Player owner, int posX, int posY)
        {
            monster.Owner = owner;
            gameboard.GetElement(new Point(posX, posY)).SetOccupant(monster);
        }

        public Player SwitchPlayer()
        {
            var currentPlayerIndex = Players.IndexOf(CurrentPlayer);

            if (currentPlayerIndex + 1 < Players.Count)
                CurrentPlayer = Players[currentPlayerIndex + 1];
            else if (currentPlayerIndex + 1 == Players.Count)
                CurrentPlayer = Players[currentPlayerIndex];

            else
                CurrentPlayer = Players[0];

            return CurrentPlayer;
        }

        public async Task TurnChange()
        {

            if (!IsGameOver())
            {
                TurnsPassed++;

                if (gamePhase == GamePhase.Moving && Players.IndexOf(CurrentPlayer) == Players.Count - 1)
                {
                    ChangePhase(GamePhase.Picking);
                    OnPhaseChange();
                }

                else if (gamePhase == GamePhase.Moving && Players.IndexOf(CurrentPlayer) < Players.Count - 1)
                {
                    OnPhaseChange();
                    CurrentPlayer = SwitchPlayer();
                    await gameboard.HighlightMonstersOfPlayer(CurrentPlayer);
                }
            }

            else
            {
                GameOver gameOverScreen = new GameOver(Players);
                gameOverScreen.ShowDialog();
                startForm.Visible = true;
                gameForm.Dispose();
            }
        }

        private void ResetMonsterMovement()
        {
            foreach (var tile in gameboard.GetElementsCollection())
            {
                var monster = tile.GetOccupant() as Monster;
                if (monster != null)
                {
                    monster.MovesRemaining = monster.Moves;
                    monster.canAttack = true;
                }
            }
        }

        private void GenerateWizards(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player("Player" + (i + 1));
                Players.Add(player);
                var wizard = monsterGenerator.GetMonsterByName("Wizard" + (i + 1), player);
                wizard.Name = "Wizard";
                wizard.Caption = wizard.Name;

                if (i == 0)                
                    AddMonster(wizard, player, 0, 0);
                
                if (i == 1)
                    AddMonster(wizard, player, 13, 13);
                
                if (i == 2)
                    AddMonster(wizard, player, 0, 13);

                if (i == 3)
                    AddMonster(wizard, player, 13, 0);
            }
        }

        private void SetTileEvents()
        {
            foreach (var field in gameboard.GetElementsCollection())
            {
                var pictureBox = field.Field;
                pictureBox.MouseClick += async (sender, args) => TileClicked(field, args);
            }
        }


        private async Task TileClicked(Tile clickSource, MouseEventArgs e)
        {
            if (DescriptionMode)
            {
                if (clickSource.GetOccupant() is Monster)
                {
                    gameForm.GetDescriptionPanel.Controls.Clear();
                    gameForm.GetDescriptionPanel.Controls.AddRange(
                        new DescriptionPanel((Monster) clickSource.GetOccupant())
                            .GetControls());
                    gameForm.GetDescriptionPanel.Visible = true;
                    gameForm.GetDescriptionPanel.BringToFront();
                    return;
                }
            }

            if (gamePhase == GamePhase.Casting && await spellcasting.CastSpell(clickSource, e))
            {
                CurrentPlayer = Players[0];
                ResetMonsterMovement();
                ChangePhase(GamePhase.Moving);
                await gameboard.HighlightMonstersOfPlayer(CurrentPlayer);
                return;
            }

            // Checks whether Tile we are clicking is occupied by entity with type other than "Nothing",
            // we set the clicked Tile to be a context for our further operations (eg. decision making
            // on what happens on second mouse click)

            if (gamePhase == GamePhase.Moving &&
                firstClick &&
                clickSource.GetOccupant().Owner == CurrentPlayer)
            {
                GetSourceField = clickSource;
                GetSelectedMonster = GetSourceField.GetOccupant() as Monster;
                gameboard.MovesLeftLabel.Text =
                    $"Moves: {GetSelectedMonster.MovesRemaining}/{GetSelectedMonster.Moves}";
                firstClick = false;
                SoundEngine.say(GetSelectedMonster);
            }
            // If we click the same tile twice, raise resetEventDataMethod to clean information
            else if (GetSourceField == clickSource)
            {
                resetEventData();
            }
            // Gets the source of second mouse click, then decides what to do based on types of clicked objects
            else if (!firstClick)
            {
                GetTargetField = clickSource;
                if (!(GetTargetField.GetOccupant() is Monster))
                {
                    if (actions.Move(GetSourceField, GetTargetField))
                    {
                        GetSourceField = GetTargetField;
                        gameboard.MovesLeftLabel.Text =
                            $@"Moves: {GetSelectedMonster.MovesRemaining}/{GetSelectedMonster.Moves}";
                    }
                }

                // Check if target tile is an enemy Monster, if so call Attack() on it
                else if (GetTargetField.GetOccupant() is Monster &&
                         GetTargetField.GetOccupant().Owner != GetSourceField.GetOccupant().Owner &&
                         MonsterActions.isActionLegal(GetSourceField.GetCoordinates(),
                             GetTargetField.GetCoordinates()) &&
                         GetSelectedMonster.canAttack)
                {
                    await actions.Attack((Monster) GetSourceField.GetOccupant(),
                        (Monster) GetTargetField.GetOccupant());
                    resetEventData();
                }

                else
                {
                    resetEventData();
                }
            }
        }

        /// <summary>
        /// If max turns parameter has been specified - check if turns has passed, if so, pick a Player with the most points as a winner
        /// </summary>
        private bool IsGameOver()
        {
            if(turnsLimit != 0)
            {
                if(turnsLimit == TurnsPassed)
                {
                    var winner = Players.OrderByDescending(p => p.Points).First();
                    return true;
                }
            }

            return false;
        }

        public void RemovePlayer(Player playerToRemove)
        {
            Players.Remove(playerToRemove);

            foreach(Tile tile in gameboard.GetElementsCollection())
            {
                if (tile.GetOccupant() is Monster && tile.GetOccupant().Owner == playerToRemove)
                {
                    var monsterToRemove = tile.GetOccupant() as Monster;
                    tile.SetOccupant();
                }
            }
        }

        // Reset selection data.
        public void resetEventData()
        {
            firstClick = true;
            GetTargetField = null;
            GetSelectedMonster = null;
            GetSourceField = null;
            gameboard.MovesLeftLabel.Text = "";
        }

        // Get Y, Z coordinates of a wizard in a grid
        public Point GetWizardCoordinates()
        {
            foreach (var tile in gameboard.GetElementsCollection())
                if (tile.GetOccupant().Caption.Contains("Wizard") && tile.GetOccupant().Owner == CurrentPlayer)
                    return tile.GetCoordinates();

            throw new NullReferenceException();
        }
    }
}
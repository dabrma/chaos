using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.UI;
using Chaos.Utility;
using System.Drawing;

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
        private readonly Form1 gameForm;
        public readonly MonsterGenerator monsterGenerator;
        private readonly MonsterActions actions;
        public bool DescriptionMode = false;
        private SoundEngine eng = new SoundEngine();

        private bool firstClick = true;
        private GamePhase gamePhase;
        private DescriptionPanel monsterDescriptionPanel;
        private readonly Spellcasting spellcasting;

        public GameEngine(int NumberOfPlayers, Gameboard gameboard, Form1 gameForm)
        {
            this.gameboard = gameboard;
            actions = new MonsterActions(gameboard, this);
            SetTileEvents();
            monsterGenerator = new MonsterGenerator();
            GenerateWizards(NumberOfPlayers);
            gameboard.players = GetPlayers;
            CurrentPlayer = GetPlayers[0];
            spellcasting = new Spellcasting(gameboard, this);
            this.gameForm = gameForm;
            gameForm.GetDescriptionPanel.Click += HideDescriptionPanel;
        }

        public Tile GetSourceField { get; private set; }

        public Monster GetSelectedMonster { get; private set; }

        public Tile GetTargetField { get; private set; }

        public Gameboard gameboard { get; set; }
        public SpellBoard spellboard { get; set; }
        public Player CurrentPlayer { get; set; }

        public List<Player> GetPlayers { get; } = new List<Player>();

        private void HideDescriptionPanel(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.Dispose();
        }

        public void InitializeEngineElements()
        {
            gamePhase = GamePhase.Picking;
            spellboard.currentPlayer = CurrentPlayer;
            gameboard.currentPlayer = CurrentPlayer;
            UpdateSpellboard();
        }

        public void ChangePhase(GamePhase phase)
        {
            gamePhase = phase;
            OnPhaseChange();
        }

        public void OnPhaseChange()
        {
            switch (gamePhase)
            {
                case GamePhase.Picking:
                    spellcasting.finishedCasting = false;
                    CurrentPlayer = GetPlayers[0];
                    spellboard.currentPlayer = CurrentPlayer;
                    spellboard.UpdateSpellboard(CurrentPlayer);
                    spellboard.IsSpellboardVisible(true);
                    break;
                case GamePhase.Casting:
                    CurrentPlayer = GetPlayers[0];
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

        public void AddMonster(int posX, int posY)
        {
            //     var monster = monsterGenerator.GetMonsterByName("Wraith");
            //     monster.Owner = GetPlayers[0];
            //     gameboard.tiles[posX, posY].OcupantEnter(monster);
        }

        private void UpdateSpellboard()
        {
            spellboard.UpdateSpellboard(CurrentPlayer);
        }

        public void AddMonster(Monster monster, Player owner, int posX, int posY)
        {
            monster.Owner = owner;
            gameboard.tiles[posX, posY].OcupantEnter(monster);
        }

        public Player SwitchPlayer()
        {
            var currentPlayerIndex = GetPlayers.IndexOf(CurrentPlayer);

            if (currentPlayerIndex + 1 < GetPlayers.Count)
            {
                CurrentPlayer = GetPlayers[currentPlayerIndex + 1];
            }
            else if (currentPlayerIndex +  1 == GetPlayers.Count)
            {
                CurrentPlayer = GetPlayers[currentPlayerIndex];
            }

            else
                CurrentPlayer = GetPlayers[0];

            return CurrentPlayer;
        }

        public void TurnChange()
        {
            if (gamePhase == GamePhase.Moving && GetPlayers.IndexOf(CurrentPlayer) == GetPlayers.Count - 1)
            {
                ChangePhase(GamePhase.Picking);
                OnPhaseChange();
            }

            else if (gamePhase == GamePhase.Moving && GetPlayers.IndexOf(CurrentPlayer) < GetPlayers.Count - 1)
            {
                OnPhaseChange();
                CurrentPlayer = SwitchPlayer();
                SoundEngine.say(CurrentPlayer.Name);
            }

            // Uncomment for logging purposes
            //foreach (var tile in gameboard.tiles)
            //    if (tile.Occupant.GetType() == typeof(Monster))
            //        EventLogger.WriteLog(tile.Occupant.Owner.Name + " " + tile.Occupant.Caption);
        }

        private void ResetMonsterMovement()
        {
            foreach (var tile in gameboard.tiles)
            {
                var monster = tile.Occupant as Monster;
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
                var player = new Player("Player" + (i + 1), i + 1);
                GetPlayers.Add(player);
                var wizard = monsterGenerator.GetMonsterByName("Wizard" + (i + 1), player);
                wizard.Name = "Wizard";
                wizard.Caption = wizard.Name;
                if(i == 0)
                {
                    AddMonster(wizard, player, 0, 0);
                }
                else if(i == 1) {
                    AddMonster(wizard, player, 13, 13); }
                else
                {
                    AddMonster(wizard, player, 0, 13);
                }
            }
        }

        private void SetTileEvents()
        {
            foreach (var field in gameboard.tiles)
            {
                var pictureBox = field.Field;
                pictureBox.Click += (sender, args) => TileClicked(field);
            }
        }


        private async Task TileClicked(Tile clickSource)
        {
            var target = clickSource as Tile;
            if (DescriptionMode)
            {
                if (clickSource.Occupant.GetType() != typeof(Monster)) return;
                gameForm.GetDescriptionPanel.Controls.AddRange(new DescriptionPanel((Monster) clickSource.Occupant)
                    .GetControls());
                gameForm.GetDescriptionPanel.Visible = true;
                gameForm.GetDescriptionPanel.BringToFront();
                return;
            }

            if (gamePhase == GamePhase.Casting && await spellcasting.CastSpell(target))
            {
                CurrentPlayer = GetPlayers[0];
                ResetMonsterMovement();
                ChangePhase(GamePhase.Moving);
                return;
            }


            // Checks whether Tile we are clicking is occupied by entity with type other than "Nothing",
            // we set the clicked Tile to be a context for our further operations (eg. decision making
            // on what happens on second mouse click)
          //  if (gamePhase == GamePhase.Moving)
                if (gamePhase == GamePhase.Moving && firstClick && clickSource.Occupant.GetType() != typeof(Nothing) &&
                    clickSource.Occupant.Owner == CurrentPlayer)
                {
                    GetSourceField = clickSource;
                    GetSelectedMonster = GetSourceField.Occupant as Monster;
                    gameboard.MovesLeftLabel.Text = string.Format("Moves: {0}/{1}", GetSelectedMonster.MovesRemaining,
                        GetSelectedMonster.Moves);
                    firstClick = false;
                    SoundEngine.say((Monster) clickSource.Occupant);
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
                    if (GetTargetField.Occupant.GetType() != typeof(Monster))
                    {
                        if (actions.Move(GetSourceField, GetTargetField))
                        {
                            GetSourceField = GetTargetField;
                            gameboard.MovesLeftLabel.Text =
                                $@"Moves: {GetSelectedMonster.MovesRemaining}/{GetSelectedMonster.Moves}";
                        }
                    }

                    else if (GetTargetField.Occupant.GetType() == typeof(Monster) &&
                             GetTargetField.Occupant.Owner != GetSourceField.Occupant.Owner &&
                             MonsterActions.isActionLegal(GetSourceField.FieldLocalization, GetTargetField.FieldLocalization) &&
                             GetSelectedMonster.canAttack)
                    {
                        await actions.Attack((Monster) GetSourceField.Occupant, (Monster) GetTargetField.Occupant);
                        resetEventData();
                    }

                    else
                    {
                        resetEventData();
                    }
                }
        }


        private void GameOver()
        {
            MessageBox.Show(string.Format("Congratulations {0}, you've won!", CurrentPlayer));
        }

        public void resetEventData()
        {
            firstClick = true;
            GetTargetField = null;
            GetSelectedMonster = null;
            GetSourceField = null;
            gameboard.MovesLeftLabel.Text = "";
        }

        public Point GetWizardCoordinates()
        {
            foreach(Tile tile in gameboard.tiles)
            {
                if(tile.Occupant.Caption.Contains("Wizard") && tile.Occupant.Owner == CurrentPlayer)
                {
                    return tile.FieldLocalization;
                }
            }

            throw new NullReferenceException();
        }
    }
}
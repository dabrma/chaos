using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;
using Chaos.Properties;
using Chaos.Utility;

namespace Chaos.Engine
{
    public enum GamePhase
    {
        Picking,
        Casting,
        Moving,

    }
    public class GameEngine
    {
        private MonsterActions actions;

        private bool firstClick = true;
        private readonly MonsterGenerator monsterGenerator;
        private Monster selectedMonster;
        private Tile sourceField;
        private Tile targetField;
        private GamePhase gamePhase;

        public Tile GetSourceField { get { return sourceField; } }
        public Monster GetSelectedMonster { get { return selectedMonster; } }
        public Tile GetTargetField { get { return targetField; } }

        public GameEngine(int NumberOfPlayers, Gameboard gameboard)
        {
            this.gameboard = gameboard;
            actions = new MonsterActions(gameboard, this);
            SetTileEvents();
            monsterGenerator = new MonsterGenerator();
            GenerateWizards(NumberOfPlayers);
            gameboard.players = GetPlayers;
            CurrentPlayer = GetPlayers[0];
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
                    CurrentPlayer = GetPlayers[0];
                    spellboard.IsSpellboardVisible(true);
                    break;
                case GamePhase.Casting:
                    SoundEngine.say(CurrentPlayer.Name);
                    SoundEngine.say(CurrentPlayer.SelectedSpell.Caption);
                    CurrentPlayer = GetPlayers[0];
                    spellboard.IsSpellboardVisible(false);
                    break;
               case GamePhase.Moving:
                   resetEventData();
                   break;
            }
        }

        public Gameboard gameboard { get; set; }
        public SpellBoard spellboard { get; set; }
        public Player CurrentPlayer { get; private set; }

        public List<Player> GetPlayers { get; } = new List<Player>();

        public Spell GetCurrentSpell()
        {
            return CurrentPlayer.SelectedSpell;
        }

        public bool CastSpell(Tile target)
        {
            var currentPlayerIndex = GetPlayers.IndexOf(CurrentPlayer);
            var finishedCasting = currentPlayerIndex + 1 == GetPlayers.Count;

            var spell = GetCurrentSpell();
            var monsterFromSpell = monsterGenerator.GetMonsterByName(spell.Caption, CurrentPlayer);
            monsterFromSpell.Owner = CurrentPlayer;
            target.OcupantEnter(monsterFromSpell);
            CurrentPlayer = SwitchPlayer();
            
            if(finishedCasting)
            return true;

            else
            {
                return false;
            }
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
            if(currentPlayerIndex + 1 < GetPlayers.Count)
            {
                CurrentPlayer = GetPlayers[currentPlayerIndex + 1];
            }
            else
            {
                CurrentPlayer = GetPlayers[0];
            }

            return CurrentPlayer;
        }

        public void TurnChange()
        {
            if (gamePhase == GamePhase.Moving && GetPlayers.IndexOf(CurrentPlayer) == GetPlayers.Count - 1)
            {
                ChangePhase(GamePhase.Picking);
                OnPhaseChange();
            }

            else if(gamePhase == GamePhase.Moving && GetPlayers.IndexOf(CurrentPlayer) < GetPlayers.Count - 1)
            {
                OnPhaseChange();
                CurrentPlayer = SwitchPlayer();
                SoundEngine.say(CurrentPlayer.Name);
            }

            foreach (Tile tile in gameboard.tiles)
            {
                if (tile.Occupant.GetType() == typeof(Monster))
                {
                    EventLogger.WriteLog(tile.Occupant.Owner.Name + " " + tile.Occupant.Caption);
                }
            }
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
            }

            var wizard1 = monsterGenerator.GetMonsterByName("Wizard1", GetPlayers[0]);
            wizard1.Name = "Wizard";
            wizard1.Caption = wizard1.Name;
            var wizard2 = monsterGenerator.GetMonsterByName("Wizard2", GetPlayers[1]);
            wizard2.Name = "Wizard";
            wizard2.Caption = wizard1.Name;

            AddMonster(wizard1, GetPlayers[0], 0, 0);
            AddMonster(wizard2, GetPlayers[1], 11, 11);
        }

        private void SetTileEvents()
        {
            foreach (var field in gameboard.tiles)
            {
                var pictureBox = field.Field;
                pictureBox.Click += (sender, args) => TileClicked(sender, args, field);
            }
        }


        public void TileClicked(object sender, EventArgs e, Tile clickSource)
        {
            if (gamePhase == GamePhase.Casting)
            {
                if (CastSpell(clickSource))
                {
                    ResetMonsterMovement();
                    ChangePhase(GamePhase.Moving);
                }
            }


            // Checks whether Tile we are clicking is occupied by entity with type other than "Nothing",
            // we set the clicked Tile to be a context for our further operations (eg. decision making
            // on what happens on second mouse click)
            if (gamePhase == GamePhase.Moving)
            {
                if (firstClick && clickSource.Occupant.GetType() != typeof(Nothing) &&
                    clickSource.Occupant.Owner == CurrentPlayer)
                {
                    sourceField = clickSource;
                    selectedMonster = sourceField.Occupant as Monster;
                    gameboard.MovesLeftLabel.Text = string.Format("Moves: {0}/{1}", selectedMonster.MovesRemaining,
                        selectedMonster.Moves);
                    firstClick = false;
                    SoundEngine.say((Monster) clickSource.Occupant);
                }
                // If we click the same tile twice, raise resetEventDataMethod to clean information
                else if (sourceField == clickSource)
                {
                    resetEventData();
                }

                // Gets the source of second mouse click, then decides what to do based on types of clicked objects
                else if (!firstClick)
                {
                    targetField = clickSource;
                    if (targetField.Occupant.GetType() != typeof(Monster))
                    {
                        if (actions.Move(sourceField, targetField))
                        {
                            sourceField = targetField;
                            gameboard.MovesLeftLabel.Text = string.Format("Moves: {0}/{1}",
                                selectedMonster.MovesRemaining,
                                selectedMonster.Moves);
                        }
                    }

                    else if (targetField.Occupant.GetType() == typeof(Monster) &&
                             targetField.Occupant.Owner != sourceField.Occupant.Owner &&
                             actions.isMoveLegal(sourceField.FieldLocalization, targetField.FieldLocalization) &&
                             selectedMonster.canAttack)
                    {
                        actions.Attack((Monster) sourceField.Occupant, (Monster) targetField.Occupant);
                        // resetEventData();
                    }

                    else
                    {
                        resetEventData();
                    }
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

        #region Movement and Combat

        

        public void resetEventData()
        {
            firstClick = true;
            targetField = null;
            selectedMonster = null;
            sourceField = null;
            gameboard.MovesLeftLabel.Text = "";
        }

        #endregion
    }
}
namespace Chaos
{
    partial class FormStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.bExitGame = new System.Windows.Forms.Button();
            this.bLoadGame = new System.Windows.Forms.Button();
            this.bNewGame = new System.Windows.Forms.Button();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.lNumberOfPlayersValue = new System.Windows.Forms.Label();
            this.bNoOfTurnsRight = new System.Windows.Forms.Button();
            this.bNoOfSpellsRight = new System.Windows.Forms.Button();
            this.bNoOfTurnsLeft = new System.Windows.Forms.Button();
            this.bNoOfSpellsLeft = new System.Windows.Forms.Button();
            this.tNumberOfTurns = new System.Windows.Forms.TextBox();
            this.tNumberOfSpells = new System.Windows.Forms.TextBox();
            this.lNumberOfTurns = new System.Windows.Forms.Label();
            this.lNumberOfSpells = new System.Windows.Forms.Label();
            this.tNumberOfPlayer = new System.Windows.Forms.TrackBar();
            this.lNumberOfPlayers = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonsPanel.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.bExitGame);
            this.buttonsPanel.Controls.Add(this.bLoadGame);
            this.buttonsPanel.Controls.Add(this.bNewGame);
            this.buttonsPanel.Location = new System.Drawing.Point(184, 2);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(185, 524);
            this.buttonsPanel.TabIndex = 0;
            // 
            // bExitGame
            // 
            this.bExitGame.BackColor = System.Drawing.Color.DarkBlue;
            this.bExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExitGame.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bExitGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bExitGame.Location = new System.Drawing.Point(0, 390);
            this.bExitGame.Margin = new System.Windows.Forms.Padding(2);
            this.bExitGame.Name = "bExitGame";
            this.bExitGame.Size = new System.Drawing.Size(185, 65);
            this.bExitGame.TabIndex = 2;
            this.bExitGame.Text = "EXIT GAME";
            this.bExitGame.UseVisualStyleBackColor = false;
            this.bExitGame.Click += new System.EventHandler(this.bExitGame_Click);
            // 
            // bLoadGame
            // 
            this.bLoadGame.BackColor = System.Drawing.Color.DarkBlue;
            this.bLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bLoadGame.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLoadGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bLoadGame.Location = new System.Drawing.Point(0, 228);
            this.bLoadGame.Margin = new System.Windows.Forms.Padding(2);
            this.bLoadGame.Name = "bLoadGame";
            this.bLoadGame.Size = new System.Drawing.Size(185, 65);
            this.bLoadGame.TabIndex = 1;
            this.bLoadGame.Text = "LOAD GAME";
            this.bLoadGame.UseVisualStyleBackColor = false;
            this.bLoadGame.Click += new System.EventHandler(this.bLoadGame_Click);
            // 
            // bNewGame
            // 
            this.bNewGame.BackColor = System.Drawing.Color.DarkBlue;
            this.bNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNewGame.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bNewGame.Location = new System.Drawing.Point(0, 81);
            this.bNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(185, 65);
            this.bNewGame.TabIndex = 0;
            this.bNewGame.Text = "NEW GAME";
            this.bNewGame.UseVisualStyleBackColor = false;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.button1);
            this.SettingsPanel.Controls.Add(this.lNumberOfPlayersValue);
            this.SettingsPanel.Controls.Add(this.bNoOfTurnsRight);
            this.SettingsPanel.Controls.Add(this.bNoOfSpellsRight);
            this.SettingsPanel.Controls.Add(this.bNoOfTurnsLeft);
            this.SettingsPanel.Controls.Add(this.bNoOfSpellsLeft);
            this.SettingsPanel.Controls.Add(this.tNumberOfTurns);
            this.SettingsPanel.Controls.Add(this.tNumberOfSpells);
            this.SettingsPanel.Controls.Add(this.lNumberOfTurns);
            this.SettingsPanel.Controls.Add(this.lNumberOfSpells);
            this.SettingsPanel.Controls.Add(this.tNumberOfPlayer);
            this.SettingsPanel.Controls.Add(this.lNumberOfPlayers);
            this.SettingsPanel.Controls.Add(this.bStart);
            this.SettingsPanel.Location = new System.Drawing.Point(2, 2);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(542, 526);
            this.SettingsPanel.TabIndex = 1;
            this.SettingsPanel.Visible = false;
            // 
            // lNumberOfPlayersValue
            // 
            this.lNumberOfPlayersValue.AutoSize = true;
            this.lNumberOfPlayersValue.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfPlayersValue.ForeColor = System.Drawing.Color.Fuchsia;
            this.lNumberOfPlayersValue.Location = new System.Drawing.Point(348, 43);
            this.lNumberOfPlayersValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNumberOfPlayersValue.Name = "lNumberOfPlayersValue";
            this.lNumberOfPlayersValue.Size = new System.Drawing.Size(28, 26);
            this.lNumberOfPlayersValue.TabIndex = 14;
            this.lNumberOfPlayersValue.Text = "2";
            // 
            // bNoOfTurnsRight
            // 
            this.bNoOfTurnsRight.BackColor = System.Drawing.Color.DarkBlue;
            this.bNoOfTurnsRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNoOfTurnsRight.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNoOfTurnsRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bNoOfTurnsRight.Location = new System.Drawing.Point(386, 243);
            this.bNoOfTurnsRight.Margin = new System.Windows.Forms.Padding(2);
            this.bNoOfTurnsRight.Name = "bNoOfTurnsRight";
            this.bNoOfTurnsRight.Size = new System.Drawing.Size(24, 28);
            this.bNoOfTurnsRight.TabIndex = 13;
            this.bNoOfTurnsRight.Text = ">";
            this.bNoOfTurnsRight.UseVisualStyleBackColor = false;
            this.bNoOfTurnsRight.Click += new System.EventHandler(this.bNoOfTurnsRight_Click);
            // 
            // bNoOfSpellsRight
            // 
            this.bNoOfSpellsRight.BackColor = System.Drawing.Color.DarkBlue;
            this.bNoOfSpellsRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNoOfSpellsRight.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNoOfSpellsRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bNoOfSpellsRight.Location = new System.Drawing.Point(386, 162);
            this.bNoOfSpellsRight.Margin = new System.Windows.Forms.Padding(2);
            this.bNoOfSpellsRight.Name = "bNoOfSpellsRight";
            this.bNoOfSpellsRight.Size = new System.Drawing.Size(24, 28);
            this.bNoOfSpellsRight.TabIndex = 12;
            this.bNoOfSpellsRight.Text = ">";
            this.bNoOfSpellsRight.UseVisualStyleBackColor = false;
            this.bNoOfSpellsRight.Click += new System.EventHandler(this.bNoOfSpellsRight_Click);
            // 
            // bNoOfTurnsLeft
            // 
            this.bNoOfTurnsLeft.BackColor = System.Drawing.Color.DarkBlue;
            this.bNoOfTurnsLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNoOfTurnsLeft.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNoOfTurnsLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bNoOfTurnsLeft.Location = new System.Drawing.Point(308, 242);
            this.bNoOfTurnsLeft.Margin = new System.Windows.Forms.Padding(2);
            this.bNoOfTurnsLeft.Name = "bNoOfTurnsLeft";
            this.bNoOfTurnsLeft.Size = new System.Drawing.Size(24, 28);
            this.bNoOfTurnsLeft.TabIndex = 11;
            this.bNoOfTurnsLeft.Text = "<";
            this.bNoOfTurnsLeft.UseVisualStyleBackColor = false;
            this.bNoOfTurnsLeft.Click += new System.EventHandler(this.bNoOfTurnsLeft_Click);
            // 
            // bNoOfSpellsLeft
            // 
            this.bNoOfSpellsLeft.BackColor = System.Drawing.Color.DarkBlue;
            this.bNoOfSpellsLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNoOfSpellsLeft.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNoOfSpellsLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bNoOfSpellsLeft.Location = new System.Drawing.Point(308, 162);
            this.bNoOfSpellsLeft.Margin = new System.Windows.Forms.Padding(2);
            this.bNoOfSpellsLeft.Name = "bNoOfSpellsLeft";
            this.bNoOfSpellsLeft.Size = new System.Drawing.Size(24, 28);
            this.bNoOfSpellsLeft.TabIndex = 10;
            this.bNoOfSpellsLeft.Text = "<";
            this.bNoOfSpellsLeft.UseVisualStyleBackColor = false;
            this.bNoOfSpellsLeft.Click += new System.EventHandler(this.bNoOfSpellsLeft_Click);
            // 
            // tNumberOfTurns
            // 
            this.tNumberOfTurns.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tNumberOfTurns.ForeColor = System.Drawing.Color.Fuchsia;
            this.tNumberOfTurns.Location = new System.Drawing.Point(336, 243);
            this.tNumberOfTurns.Margin = new System.Windows.Forms.Padding(2);
            this.tNumberOfTurns.MaxLength = 2;
            this.tNumberOfTurns.Name = "tNumberOfTurns";
            this.tNumberOfTurns.Size = new System.Drawing.Size(46, 27);
            this.tNumberOfTurns.TabIndex = 9;
            this.tNumberOfTurns.Text = "0";
            this.tNumberOfTurns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tNumberOfTurns.TextChanged += new System.EventHandler(this.tNumberOfTurns_TextChanged);
            // 
            // tNumberOfSpells
            // 
            this.tNumberOfSpells.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tNumberOfSpells.ForeColor = System.Drawing.Color.Fuchsia;
            this.tNumberOfSpells.Location = new System.Drawing.Point(336, 162);
            this.tNumberOfSpells.Margin = new System.Windows.Forms.Padding(2);
            this.tNumberOfSpells.MaxLength = 2;
            this.tNumberOfSpells.Name = "tNumberOfSpells";
            this.tNumberOfSpells.Size = new System.Drawing.Size(46, 27);
            this.tNumberOfSpells.TabIndex = 8;
            this.tNumberOfSpells.Text = "99";
            this.tNumberOfSpells.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tNumberOfSpells.TextChanged += new System.EventHandler(this.tNumberOfSpells_TextChanged);
            // 
            // lNumberOfTurns
            // 
            this.lNumberOfTurns.AutoSize = true;
            this.lNumberOfTurns.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfTurns.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lNumberOfTurns.Location = new System.Drawing.Point(30, 252);
            this.lNumberOfTurns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNumberOfTurns.Name = "lNumberOfTurns";
            this.lNumberOfTurns.Size = new System.Drawing.Size(152, 18);
            this.lNumberOfTurns.TabIndex = 7;
            this.lNumberOfTurns.Text = "Number of turns";
            // 
            // lNumberOfSpells
            // 
            this.lNumberOfSpells.AutoSize = true;
            this.lNumberOfSpells.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfSpells.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lNumberOfSpells.Location = new System.Drawing.Point(30, 162);
            this.lNumberOfSpells.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNumberOfSpells.Name = "lNumberOfSpells";
            this.lNumberOfSpells.Size = new System.Drawing.Size(154, 18);
            this.lNumberOfSpells.TabIndex = 4;
            this.lNumberOfSpells.Text = "Number of spells";
            // 
            // tNumberOfPlayer
            // 
            this.tNumberOfPlayer.AccessibleDescription = "";
            this.tNumberOfPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.tNumberOfPlayer.LargeChange = 1;
            this.tNumberOfPlayer.Location = new System.Drawing.Point(300, 73);
            this.tNumberOfPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.tNumberOfPlayer.Maximum = 4;
            this.tNumberOfPlayer.Minimum = 2;
            this.tNumberOfPlayer.Name = "tNumberOfPlayer";
            this.tNumberOfPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tNumberOfPlayer.RightToLeftLayout = true;
            this.tNumberOfPlayer.Size = new System.Drawing.Size(118, 45);
            this.tNumberOfPlayer.TabIndex = 2;
            this.tNumberOfPlayer.Value = 2;
            this.tNumberOfPlayer.Scroll += new System.EventHandler(this.tNumberOfPlayer_Scroll);
            // 
            // lNumberOfPlayers
            // 
            this.lNumberOfPlayers.AutoSize = true;
            this.lNumberOfPlayers.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfPlayers.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lNumberOfPlayers.Location = new System.Drawing.Point(30, 73);
            this.lNumberOfPlayers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNumberOfPlayers.Name = "lNumberOfPlayers";
            this.lNumberOfPlayers.Size = new System.Drawing.Size(170, 18);
            this.lNumberOfPlayers.TabIndex = 1;
            this.lNumberOfPlayers.Text = "Number of players";
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.DarkBlue;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bStart.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bStart.Location = new System.Drawing.Point(164, 321);
            this.bStart.Margin = new System.Windows.Forms.Padding(2);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(185, 65);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "START";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(164, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 65);
            this.button1.TabIndex = 15;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(542, 525);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStart";
            this.Text = "Chaos: The Battle of the Wizards";
            this.buttonsPanel.ResumeLayout(false);
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button bExitGame;
        private System.Windows.Forms.Button bLoadGame;
        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Label lNumberOfPlayers;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar tNumberOfPlayer;
        private System.Windows.Forms.Label lNumberOfSpells;
        private System.Windows.Forms.Label lNumberOfTurns;
        private System.Windows.Forms.TextBox tNumberOfTurns;
        private System.Windows.Forms.TextBox tNumberOfSpells;
        private System.Windows.Forms.Button bNoOfSpellsLeft;
        private System.Windows.Forms.Button bNoOfTurnsRight;
        private System.Windows.Forms.Button bNoOfSpellsRight;
        private System.Windows.Forms.Button bNoOfTurnsLeft;
        private System.Windows.Forms.Label lNumberOfPlayersValue;
        private System.Windows.Forms.Button button1;
    }
}
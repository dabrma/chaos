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
            this.SetingsPanel = new System.Windows.Forms.Panel();
            this.lNumberOfSpells = new System.Windows.Forms.Label();
            this.lNamesOfPlayers = new System.Windows.Forms.Label();
            this.tNumberOfPlayer = new System.Windows.Forms.TrackBar();
            this.lNumberOfPlayers = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.tNameOfPlayer = new System.Windows.Forms.TextBox();
            this.tNumberOfSpells = new System.Windows.Forms.TrackBar();
            this.lNumberOfTurns = new System.Windows.Forms.Label();
            this.tNumberOfTurns = new System.Windows.Forms.TrackBar();
            this.buttonsPanel.SuspendLayout();
            this.SetingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfSpells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfTurns)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.bExitGame);
            this.buttonsPanel.Controls.Add(this.bLoadGame);
            this.buttonsPanel.Controls.Add(this.bNewGame);
            this.buttonsPanel.Location = new System.Drawing.Point(247, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(247, 693);
            this.buttonsPanel.TabIndex = 0;
            this.buttonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonsPanel_Paint);
            // 
            // bExitGame
            // 
            this.bExitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bExitGame.Location = new System.Drawing.Point(0, 460);
            this.bExitGame.Name = "bExitGame";
            this.bExitGame.Size = new System.Drawing.Size(247, 150);
            this.bExitGame.TabIndex = 2;
            this.bExitGame.Text = "EXIT GAME";
            this.bExitGame.UseVisualStyleBackColor = true;
            this.bExitGame.Click += new System.EventHandler(this.bExitGame_Click);
            // 
            // bLoadGame
            // 
            this.bLoadGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLoadGame.Location = new System.Drawing.Point(0, 250);
            this.bLoadGame.Name = "bLoadGame";
            this.bLoadGame.Size = new System.Drawing.Size(247, 150);
            this.bLoadGame.TabIndex = 1;
            this.bLoadGame.Text = "LOAD GAME";
            this.bLoadGame.UseVisualStyleBackColor = true;
            this.bLoadGame.Click += new System.EventHandler(this.bLoadGame_Click);
            // 
            // bNewGame
            // 
            this.bNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bNewGame.Location = new System.Drawing.Point(0, 40);
            this.bNewGame.Name = "bNewGame";
            this.bNewGame.Size = new System.Drawing.Size(247, 150);
            this.bNewGame.TabIndex = 0;
            this.bNewGame.Text = "NEW GAME";
            this.bNewGame.UseVisualStyleBackColor = true;
            this.bNewGame.Click += new System.EventHandler(this.bNewGame_Click);
            // 
            // SetingsPanel
            // 
            this.SetingsPanel.Controls.Add(this.tNumberOfTurns);
            this.SetingsPanel.Controls.Add(this.lNumberOfTurns);
            this.SetingsPanel.Controls.Add(this.tNumberOfSpells);
            this.SetingsPanel.Controls.Add(this.tNameOfPlayer);
            this.SetingsPanel.Controls.Add(this.lNumberOfSpells);
            this.SetingsPanel.Controls.Add(this.lNamesOfPlayers);
            this.SetingsPanel.Controls.Add(this.tNumberOfPlayer);
            this.SetingsPanel.Controls.Add(this.lNumberOfPlayers);
            this.SetingsPanel.Controls.Add(this.bStart);
            this.SetingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SetingsPanel.Name = "SetingsPanel";
            this.SetingsPanel.Size = new System.Drawing.Size(723, 648);
            this.SetingsPanel.TabIndex = 1;
            this.SetingsPanel.Hide();
            // 
            // lNumberOfSpells
            // 
            this.lNumberOfSpells.AutoSize = true;
            this.lNumberOfSpells.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfSpells.ForeColor = System.Drawing.SystemColors.Control;
            this.lNumberOfSpells.Location = new System.Drawing.Point(269, 250);
            this.lNumberOfSpells.Name = "lNumberOfSpells";
            this.lNumberOfSpells.Size = new System.Drawing.Size(146, 17);
            this.lNumberOfSpells.TabIndex = 4;
            this.lNumberOfSpells.Text = "NUMBER OF SPELLS";
            this.lNumberOfSpells.Click += new System.EventHandler(this.label1_Click);
            // 
            // lNamesOfPlayers
            // 
            this.lNamesOfPlayers.AutoSize = true;
            this.lNamesOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNamesOfPlayers.ForeColor = System.Drawing.SystemColors.Control;
            this.lNamesOfPlayers.Location = new System.Drawing.Point(275, 159);
            this.lNamesOfPlayers.Name = "lNamesOfPlayers";
            this.lNamesOfPlayers.Size = new System.Drawing.Size(146, 17);
            this.lNamesOfPlayers.TabIndex = 3;
            this.lNamesOfPlayers.Text = "NAMES OF PLAYERS";
            // 
            // tNumberOfPlayer
            // 
            this.tNumberOfPlayer.Location = new System.Drawing.Point(272, 89);
            this.tNumberOfPlayer.Maximum = 4;
            this.tNumberOfPlayer.Minimum = 2;
            this.tNumberOfPlayer.Name = "tNumberOfPlayer";
            this.tNumberOfPlayer.Size = new System.Drawing.Size(157, 56);
            this.tNumberOfPlayer.TabIndex = 2;
            this.tNumberOfPlayer.Value = 2;
            // 
            // lNumberOfPlayers
            // 
            this.lNumberOfPlayers.AutoSize = true;
            this.lNumberOfPlayers.ForeColor = System.Drawing.SystemColors.Control;
            this.lNumberOfPlayers.Location = new System.Drawing.Point(272, 53);
            this.lNumberOfPlayers.Name = "lNumberOfPlayers";
            this.lNumberOfPlayers.Size = new System.Drawing.Size(157, 17);
            this.lNumberOfPlayers.TabIndex = 1;
            this.lNumberOfPlayers.Text = "NUMBER OF PLAYERS";
            this.lNumberOfPlayers.Click += new System.EventHandler(this.lNumberOfPlayers_Click);
            // 
            // bStart
            // 
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bStart.Location = new System.Drawing.Point(241, 450);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(247, 150);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "START";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tNameOfPlayer
            // 
            this.tNameOfPlayer.Location = new System.Drawing.Point(295, 196);
            this.tNameOfPlayer.Name = "tNameOfPlayer";
            this.tNameOfPlayer.Size = new System.Drawing.Size(100, 22);
            this.tNameOfPlayer.TabIndex = 5;
            this.tNameOfPlayer.TextChanged += new System.EventHandler(this.tNameOfPlayer_TextChanged);
            // 
            // tNumberOfSpells
            // 
            this.tNumberOfSpells.Location = new System.Drawing.Point(114, 282);
            this.tNumberOfSpells.Maximum = 99;
            this.tNumberOfSpells.Name = "tNumberOfSpells";
            this.tNumberOfSpells.Size = new System.Drawing.Size(471, 56);
            this.tNumberOfSpells.TabIndex = 6;
            this.tNumberOfSpells.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lNumberOfTurns
            // 
            this.lNumberOfTurns.AutoSize = true;
            this.lNumberOfTurns.ForeColor = System.Drawing.SystemColors.Control;
            this.lNumberOfTurns.Location = new System.Drawing.Point(278, 331);
            this.lNumberOfTurns.Name = "lNumberOfTurns";
            this.lNumberOfTurns.Size = new System.Drawing.Size(142, 17);
            this.lNumberOfTurns.TabIndex = 7;
            this.lNumberOfTurns.Text = "NUMBER OF TURNS";
            // 
            // tNumberOfTurns
            // 
            this.tNumberOfTurns.Location = new System.Drawing.Point(114, 363);
            this.tNumberOfTurns.Maximum = 99;
            this.tNumberOfTurns.Name = "tNumberOfTurns";
            this.tNumberOfTurns.Size = new System.Drawing.Size(471, 56);
            this.tNumberOfTurns.TabIndex = 8;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(723, 646);
            this.Controls.Add(this.SetingsPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "FormStart";
            this.Text = "FormStart";
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.SetingsPanel.ResumeLayout(false);
            this.SetingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfSpells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNumberOfTurns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button bExitGame;
        private System.Windows.Forms.Button bLoadGame;
        private System.Windows.Forms.Button bNewGame;
        private System.Windows.Forms.Panel SetingsPanel;
        private System.Windows.Forms.Label lNumberOfPlayers;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar tNumberOfPlayer;
        private System.Windows.Forms.Label lNamesOfPlayers;
        private System.Windows.Forms.Label lNumberOfSpells;
        private System.Windows.Forms.TextBox tNameOfPlayer;
        private System.Windows.Forms.TrackBar tNumberOfSpells;
        private System.Windows.Forms.TrackBar tNumberOfTurns;
        private System.Windows.Forms.Label lNumberOfTurns;
    }
}
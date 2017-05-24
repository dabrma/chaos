using System.Windows.Forms;
namespace Chaos
{
    partial class GameForm
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
            this.gamePanel = new System.Windows.Forms.Panel();
            this.fieldName = new System.Windows.Forms.Label();
            this.movesLeftLabel = new System.Windows.Forms.Label();
            this.spellPanel = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.PictureBox();
            this.endTurnButton = new System.Windows.Forms.Button();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.btnSaveGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(13, 13);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(672, 672);
            this.gamePanel.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.AutoSize = true;
            this.fieldName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fieldName.Location = new System.Drawing.Point(12, 697);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(52, 16);
            this.fieldName.TabIndex = 1;
            this.fieldName.Text = "label1";
            // 
            // movesLeftLabel
            // 
            this.movesLeftLabel.AutoSize = true;
            this.movesLeftLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movesLeftLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.movesLeftLabel.Location = new System.Drawing.Point(12, 723);
            this.movesLeftLabel.Name = "movesLeftLabel";
            this.movesLeftLabel.Size = new System.Drawing.Size(52, 16);
            this.movesLeftLabel.TabIndex = 2;
            this.movesLeftLabel.Text = "label1";
            // 
            // spellPanel
            // 
            this.spellPanel.Location = new System.Drawing.Point(691, 67);
            this.spellPanel.Name = "spellPanel";
            this.spellPanel.Size = new System.Drawing.Size(98, 481);
            this.spellPanel.TabIndex = 3;
            // 
            // helpButton
            // 
            this.helpButton.Image = global::Chaos.Properties.Resources.Question_mark;
            this.helpButton.Location = new System.Drawing.Point(691, 13);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(48, 48);
            this.helpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.helpButton.TabIndex = 4;
            this.helpButton.TabStop = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // endTurnButton
            // 
            this.endTurnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.endTurnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTurnButton.ForeColor = System.Drawing.SystemColors.Info;
            this.endTurnButton.Location = new System.Drawing.Point(691, 554);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(98, 35);
            this.endTurnButton.TabIndex = 6;
            this.endTurnButton.Text = "End Turn";
            this.endTurnButton.UseVisualStyleBackColor = false;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Location = new System.Drawing.Point(12, 12);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(778, 727);
            this.DescriptionPanel.TabIndex = 7;
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGame.ForeColor = System.Drawing.SystemColors.Info;
            this.btnSaveGame.Location = new System.Drawing.Point(691, 651);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(98, 35);
            this.btnSaveGame.TabIndex = 8;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = false;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(802, 752);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.spellPanel);
            this.Controls.Add(this.movesLeftLabel);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.DescriptionPanel);
            this.Name = "GameForm";
            this.Text = "GameForm";
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel DescriptionPanel;
        public Panel GetDescriptionPanel { get { return DescriptionPanel; } set { DescriptionPanel = value; } }
        public Panel GetGamePanel { get { return gamePanel; } }
        private System.Windows.Forms.Label fieldName;
        public Label GetNameField { get { return fieldName; } }
        private System.Windows.Forms.Label movesLeftLabel;
        public Label GetMovesLeftLabel { get { return movesLeftLabel; } }
        private System.Windows.Forms.Panel spellPanel;
        public Panel GetSpellPanel { get { return spellPanel; } }
        private System.Windows.Forms.PictureBox helpButton;
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.Button btnSaveGame;
    }
}


using System.Windows.Forms;

namespace Chaos.UI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePanel.Location = new System.Drawing.Point(12, 40);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(672, 672);
            this.gamePanel.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.AutoSize = true;
            this.fieldName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fieldName.Location = new System.Drawing.Point(11, 724);
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
            this.movesLeftLabel.Location = new System.Drawing.Point(11, 750);
            this.movesLeftLabel.Name = "movesLeftLabel";
            this.movesLeftLabel.Size = new System.Drawing.Size(52, 16);
            this.movesLeftLabel.TabIndex = 2;
            this.movesLeftLabel.Text = "label1";
            // 
            // spellPanel
            // 
            this.spellPanel.Location = new System.Drawing.Point(690, 88);
            this.spellPanel.Name = "spellPanel";
            this.spellPanel.Size = new System.Drawing.Size(98, 481);
            this.spellPanel.TabIndex = 3;
            // 
            // helpButton
            // 
            this.helpButton.Image = global::Chaos.Properties.Resources.Question_mark;
            this.helpButton.Location = new System.Drawing.Point(690, 38);
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
            this.endTurnButton.Location = new System.Drawing.Point(690, 581);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(98, 35);
            this.endTurnButton.TabIndex = 6;
            this.endTurnButton.Text = "End Turn";
            this.endTurnButton.UseVisualStyleBackColor = false;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Location = new System.Drawing.Point(11, 27);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(786, 739);
            this.DescriptionPanel.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(802, 23);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 19);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 19);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(802, 784);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.spellPanel);
            this.Controls.Add(this.movesLeftLabel);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "Chaos: The Battle of the Wizards";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
    }
}


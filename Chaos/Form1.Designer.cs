namespace Chaos
{
    partial class Form1
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
            this.discardButton = new System.Windows.Forms.PictureBox();
            this.endTurnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardButton)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(13, 13);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(576, 576);
            this.gamePanel.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.AutoSize = true;
            this.fieldName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fieldName.Location = new System.Drawing.Point(12, 603);
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
            this.movesLeftLabel.Location = new System.Drawing.Point(12, 629);
            this.movesLeftLabel.Name = "movesLeftLabel";
            this.movesLeftLabel.Size = new System.Drawing.Size(52, 16);
            this.movesLeftLabel.TabIndex = 2;
            this.movesLeftLabel.Text = "label1";
            // 
            // spellPanel
            // 
            this.spellPanel.Location = new System.Drawing.Point(605, 67);
            this.spellPanel.Name = "spellPanel";
            this.spellPanel.Size = new System.Drawing.Size(98, 481);
            this.spellPanel.TabIndex = 3;
            // 
            // helpButton
            // 
            this.helpButton.Image = global::Chaos.Properties.Resources.Question_mark;
            this.helpButton.Location = new System.Drawing.Point(605, 13);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(48, 48);
            this.helpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.helpButton.TabIndex = 4;
            this.helpButton.TabStop = false;
            // 
            // discardButton
            // 
            this.discardButton.Image = global::Chaos.Properties.Resources.red_letter_d_512;
            this.discardButton.Location = new System.Drawing.Point(655, 15);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(48, 46);
            this.discardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.discardButton.TabIndex = 5;
            this.discardButton.TabStop = false;
            // 
            // endTurnButton
            // 
            this.endTurnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.endTurnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTurnButton.ForeColor = System.Drawing.SystemColors.Info;
            this.endTurnButton.Location = new System.Drawing.Point(605, 554);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(98, 35);
            this.endTurnButton.TabIndex = 6;
            this.endTurnButton.Text = "End Turn";
            this.endTurnButton.UseVisualStyleBackColor = false;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(725, 655);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.spellPanel);
            this.Controls.Add(this.movesLeftLabel);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.gamePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.helpButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discardButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label fieldName;
        private System.Windows.Forms.Label movesLeftLabel;
        private System.Windows.Forms.Panel spellPanel;
        private System.Windows.Forms.PictureBox helpButton;
        private System.Windows.Forms.PictureBox discardButton;
        private System.Windows.Forms.Button endTurnButton;
    }
}


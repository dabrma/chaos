namespace Chaos.UI
{
    partial class Form2
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
            this.lblHealth = new System.Windows.Forms.Panel();
            this.CombatBar = new System.Windows.Forms.ProgressBar();
            this.MresBar = new System.Windows.Forms.ProgressBar();
            this.LifeBar = new System.Windows.Forms.ProgressBar();
            this.lblCanAttackUndead = new System.Windows.Forms.Label();
            this.lblIsUndead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCombat = new System.Windows.Forms.Label();
            this.lblMRes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHealth.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHealth
            // 
            this.lblHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))));
            this.lblHealth.Controls.Add(this.CombatBar);
            this.lblHealth.Controls.Add(this.MresBar);
            this.lblHealth.Controls.Add(this.LifeBar);
            this.lblHealth.Controls.Add(this.lblCanAttackUndead);
            this.lblHealth.Controls.Add(this.lblIsUndead);
            this.lblHealth.Controls.Add(this.label2);
            this.lblHealth.Controls.Add(this.lblCombat);
            this.lblHealth.Controls.Add(this.lblMRes);
            this.lblHealth.Controls.Add(this.label1);
            this.lblHealth.Controls.Add(this.lblName);
            this.lblHealth.Location = new System.Drawing.Point(29, 12);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(794, 727);
            this.lblHealth.TabIndex = 0;
            // 
            // CombatBar
            // 
            this.CombatBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CombatBar.Location = new System.Drawing.Point(229, 279);
            this.CombatBar.Name = "CombatBar";
            this.CombatBar.Size = new System.Drawing.Size(131, 18);
            this.CombatBar.TabIndex = 9;
            // 
            // MresBar
            // 
            this.MresBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MresBar.Location = new System.Drawing.Point(229, 245);
            this.MresBar.Name = "MresBar";
            this.MresBar.Size = new System.Drawing.Size(131, 18);
            this.MresBar.TabIndex = 8;
            // 
            // LifeBar
            // 
            this.LifeBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LifeBar.Location = new System.Drawing.Point(229, 213);
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(131, 18);
            this.LifeBar.TabIndex = 7;
            // 
            // lblCanAttackUndead
            // 
            this.lblCanAttackUndead.AutoSize = true;
            this.lblCanAttackUndead.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanAttackUndead.ForeColor = System.Drawing.Color.Red;
            this.lblCanAttackUndead.Location = new System.Drawing.Point(17, 568);
            this.lblCanAttackUndead.Name = "lblCanAttackUndead";
            this.lblCanAttackUndead.Size = new System.Drawing.Size(176, 18);
            this.lblCanAttackUndead.TabIndex = 6;
            this.lblCanAttackUndead.Text = "Can Attack Undead";
            // 
            // lblIsUndead
            // 
            this.lblIsUndead.AutoSize = true;
            this.lblIsUndead.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsUndead.ForeColor = System.Drawing.Color.Red;
            this.lblIsUndead.Location = new System.Drawing.Point(17, 540);
            this.lblIsUndead.Name = "lblIsUndead";
            this.lblIsUndead.Size = new System.Drawing.Size(76, 18);
            this.lblIsUndead.TabIndex = 5;
            this.lblIsUndead.Text = "Undead";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label2.Location = new System.Drawing.Point(17, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Movement";
            // 
            // lblCombat
            // 
            this.lblCombat.AutoSize = true;
            this.lblCombat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombat.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCombat.Location = new System.Drawing.Point(17, 279);
            this.lblCombat.Name = "lblCombat";
            this.lblCombat.Size = new System.Drawing.Size(76, 18);
            this.lblCombat.TabIndex = 3;
            this.lblCombat.Text = "Combat";
            // 
            // lblMRes
            // 
            this.lblMRes.AutoSize = true;
            this.lblMRes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRes.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblMRes.Location = new System.Drawing.Point(17, 245);
            this.lblMRes.Name = "lblMRes";
            this.lblMRes.Size = new System.Drawing.Size(158, 18);
            this.lblMRes.TabIndex = 2;
            this.lblMRes.Text = "Magic Resistance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Location = new System.Drawing.Point(17, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Life Force";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(95, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(322, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "MonsterName (WizardName)";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 823);
            this.Controls.Add(this.lblHealth);
            this.Name = "Form2";
            this.Text = "Form2";
            this.lblHealth.ResumeLayout(false);
            this.lblHealth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lblHealth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCombat;
        private System.Windows.Forms.Label lblMRes;
        private System.Windows.Forms.Label lblCanAttackUndead;
        private System.Windows.Forms.Label lblIsUndead;
        private System.Windows.Forms.ProgressBar CombatBar;
        private System.Windows.Forms.ProgressBar MresBar;
        private System.Windows.Forms.ProgressBar LifeBar;
    }
}
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
            this.lblHealth.Controls.Add(this.lblCanAttackUndead);
            this.lblHealth.Controls.Add(this.lblIsUndead);
            this.lblHealth.Controls.Add(this.label2);
            this.lblHealth.Controls.Add(this.lblCombat);
            this.lblHealth.Controls.Add(this.lblMRes);
            this.lblHealth.Controls.Add(this.label1);
            this.lblHealth.Controls.Add(this.lblName);
            this.lblHealth.Location = new System.Drawing.Point(39, 15);
            this.lblHealth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(1059, 895);
            this.lblHealth.TabIndex = 0;
            // 
            // lblCanAttackUndead
            // 
            this.lblCanAttackUndead.AutoSize = true;
            this.lblCanAttackUndead.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanAttackUndead.ForeColor = System.Drawing.Color.Red;
            this.lblCanAttackUndead.Location = new System.Drawing.Point(23, 699);
            this.lblCanAttackUndead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCanAttackUndead.Name = "lblCanAttackUndead";
            this.lblCanAttackUndead.Size = new System.Drawing.Size(223, 25);
            this.lblCanAttackUndead.TabIndex = 6;
            this.lblCanAttackUndead.Text = "Can Attack Undead";
            // 
            // lblIsUndead
            // 
            this.lblIsUndead.AutoSize = true;
            this.lblIsUndead.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsUndead.ForeColor = System.Drawing.Color.Red;
            this.lblIsUndead.Location = new System.Drawing.Point(23, 665);
            this.lblIsUndead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsUndead.Name = "lblIsUndead";
            this.lblIsUndead.Size = new System.Drawing.Size(96, 25);
            this.lblIsUndead.TabIndex = 5;
            this.lblIsUndead.Text = "Undead";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label2.Location = new System.Drawing.Point(23, 433);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Movement";
            // 
            // lblCombat
            // 
            this.lblCombat.AutoSize = true;
            this.lblCombat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombat.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblCombat.Location = new System.Drawing.Point(23, 343);
            this.lblCombat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCombat.Name = "lblCombat";
            this.lblCombat.Size = new System.Drawing.Size(97, 25);
            this.lblCombat.TabIndex = 3;
            this.lblCombat.Text = "Combat";
            // 
            // lblMRes
            // 
            this.lblMRes.AutoSize = true;
            this.lblMRes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRes.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblMRes.Location = new System.Drawing.Point(23, 302);
            this.lblMRes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMRes.Name = "lblMRes";
            this.lblMRes.Size = new System.Drawing.Size(205, 25);
            this.lblMRes.TabIndex = 2;
            this.lblMRes.Text = "Magic Resistance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Location = new System.Drawing.Point(23, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Life Force";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(127, 98);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(404, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "MonsterName (WizardName)";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 733);
            this.Controls.Add(this.lblHealth);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}
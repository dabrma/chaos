using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.UI
{
    class DescriptionPanel
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCombat;
        private System.Windows.Forms.Label lblMRes;
        private System.Windows.Forms.Label lblCanAttackUndead;
        private System.Windows.Forms.Label lblIsUndead;
        private SimpleProgressBar CombatBar;
        private SimpleProgressBar MresBar;
        private SimpleProgressBar LifeBar;
        List<Control> ListOfControls = new List<Control>();


        public DescriptionPanel(Monster monster)
        {
            InitializeComponent();
            LifeBar.Maximum = monster.MaxHealth;
            LifeBar.Step = 1;
            LifeBar.Value = monster.Health;
            CombatBar.Maximum = monster.Attack;
            CombatBar.Value = monster.Attack;
            lblName.Text = monster.Name + string.Format("({0})", monster.Owner.Name);
            lblCanAttackUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;
            lblIsUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;
        }

        public Control[] GetControls()
        {
            return ListOfControls.ToArray();
        }



        private void InitializeComponent()
        {
            this.CombatBar = new SimpleProgressBar();
            this.MresBar = new SimpleProgressBar();
            this.LifeBar = new SimpleProgressBar();
            this.lblCanAttackUndead = new System.Windows.Forms.Label();
            this.lblIsUndead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCombat = new System.Windows.Forms.Label();
            this.lblMRes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            // 
            // CombatBar
            // 
            this.CombatBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CombatBar.Location = new System.Drawing.Point(229, 279);
            this.CombatBar.Name = "CombatBar";
            this.CombatBar.Size = new System.Drawing.Size(131, 18);
            this.CombatBar.TabIndex = 9;
            ListOfControls.Add(CombatBar);
            // 
            // MresBar
            // 
            this.MresBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MresBar.Location = new System.Drawing.Point(229, 245);
            this.MresBar.Name = "MresBar";
            this.MresBar.Size = new System.Drawing.Size(131, 18);
            this.MresBar.TabIndex = 8;
            ListOfControls.Add(MresBar);
            // 
            // LifeBar
            // 
            
            this.LifeBar.Location = new System.Drawing.Point(229, 213);
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(131, 18);
            this.LifeBar.TabIndex = 7;
            ListOfControls.Add(LifeBar);
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
            ListOfControls.Add(lblCanAttackUndead);
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
            ListOfControls.Add(lblIsUndead);
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
            ListOfControls.Add(label2);
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
            ListOfControls.Add(lblCombat);
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
            ListOfControls.Add(lblMRes);
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
            ListOfControls.Add(label1);
            // 
            // lblName
            // 
            lblName.BringToFront();
            this.lblName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(322, 23);
            this.lblName.Text = "MonsterName (WizardName)";
            ListOfControls.Add(lblName);
        }

    }
}

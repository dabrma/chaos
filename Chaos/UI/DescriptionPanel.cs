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
        private System.Windows.Forms.Label HPlabel;
        private System.Windows.Forms.Label HPMAXlabel;
        private System.Windows.Forms.Label MRlabel;
        private System.Windows.Forms.Label MRMAXlabel;
        private System.Windows.Forms.Label CMBlabel;
        private System.Windows.Forms.Label CMAXlabel;
        private string HPvalue;
        private string HPMAXvalue;
        private string MRvalue;
        private string MRMAXvalue;
        private string CMBvalue;
        private string CMAXvalue;

        private SimpleProgressBar CombatBar;
        private SimpleProgressBar MresBar;
        private SimpleProgressBar LifeBar;
        private int NumOfMoves;
        List<Control> ListOfControls = new List<Control>();


        public DescriptionPanel(Monster monster)
        {


            HPvalue = monster.Health.ToString();
            HPMAXvalue = monster.MaxHealth.ToString();
            MRvalue = monster.MagicResistance.ToString();
            MRMAXvalue = monster.MaxMagicResistance.ToString();
            CMAXvalue = monster.MaxAttack.ToString();
            CMBvalue = monster.Attack.ToString();
            NumOfMoves = monster.MovesRemaining;

            InitializeComponent();

            CombatBar.Maximum = monster.Attack;
            CombatBar.Value = monster.Attack;
            CombatBar.Step = 1;
            
            lblName.Text = monster.Name + string.Format("({0})", monster.Owner.Name);

            lblCanAttackUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;

            lblIsUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;
           
            HPlabel.Text = monster.Health.ToString();
            HPMAXlabel.Text = monster.MaxHealth.ToString();
            MRlabel.Text = monster.MagicResistance.ToString();
            CMBlabel.Text = monster.Attack.ToString();

            LifeBar.Maximum = monster.MaxHealth;
            LifeBar.Step = 1;
            LifeBar.Value = monster.Health;

            MresBar.Maximum = monster.MaxMagicResistance;
            MresBar.Value = monster.MagicResistance;
            MresBar.Step = 1;

        }

        public Control[] GetControls()
        {
            return ListOfControls.ToArray();
        }


        private void DrawMovementBar()
        {
            int BarLocationX = 150;
            for (int i = 0; i < NumOfMoves; i++)
            {
                SimpleProgressBar move = new SimpleProgressBar();
                move.Maximum = 1;
                move.Value = 1;
                move.ForeColor = Color.FromArgb(255, 0, 0);
                move.Location = new System.Drawing.Point(BarLocationX, 355);
                move.Size = new System.Drawing.Size(18, 18);
                ListOfControls.Add(move);
                BarLocationX += 20;
            }
        }

        private void InitializeComponent()
        {
            DrawMovementBar();

            this.LifeBar = new SimpleProgressBar();
            this.MresBar = new SimpleProgressBar();
            this.CombatBar = new SimpleProgressBar();
            this.lblCanAttackUndead = new System.Windows.Forms.Label();
            this.lblIsUndead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCombat = new System.Windows.Forms.Label();
            this.lblMRes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.HPlabel = new System.Windows.Forms.Label();
            this.HPMAXlabel = new System.Windows.Forms.Label();
            this.MRlabel = new System.Windows.Forms.Label();
            this.MRMAXlabel = new System.Windows.Forms.Label();
            this.CMBlabel = new System.Windows.Forms.Label();
            this.CMAXlabel = new System.Windows.Forms.Label();
            // 
            // CombatBar
            // 
            this.CombatBar.Location = new System.Drawing.Point(270, 282);
            this.CombatBar.Size = new System.Drawing.Size(131, 18);
            this.CombatBar.BackColor = Color.FromArgb(255, 0, 0);
            this.CombatBar.ForeColor = Color.FromArgb(0, 255, 0);
            ListOfControls.Add(CombatBar);
            // 
            // MresBar
            // 

            this.MresBar.Location = new System.Drawing.Point(270, 248);
            this.MresBar.Size = new System.Drawing.Size(131, 18);
            this.MresBar.BackColor = Color.FromArgb(255, 0, 0);
            this.MresBar.ForeColor = Color.FromArgb(0, 255, 0);
            ListOfControls.Add(MresBar);
            // 
            // LifeBar
            // 

            this.LifeBar.Location = new System.Drawing.Point(270, 216);
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(131, 18);
            this.LifeBar.BackColor = Color.FromArgb(255, 0, 0);
            this.LifeBar.ForeColor = Color.FromArgb(0, 255, 0);
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
            //
            //HPlabel
            //
            this.HPlabel.AutoSize = true;
            this.HPlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.HPlabel.Location = new System.Drawing.Point(230, 213);
            this.HPlabel.Name = "HPlabel";
            this.HPlabel.Size = new System.Drawing.Size(94, 18);
            this.HPlabel.TabIndex = 1;
            this.HPlabel.Text.Equals(HPvalue);
            ListOfControls.Add(HPlabel);
            //
            //HPMAXlabel
            //
            this.HPMAXlabel.AutoSize = true;
            this.HPMAXlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPMAXlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.HPMAXlabel.Location = new System.Drawing.Point(400, 213);
            this.HPMAXlabel.Name = "HPMAXlabel";
            this.HPMAXlabel.Size = new System.Drawing.Size(94, 18);
            this.HPMAXlabel.TabIndex = 1;
            this.HPMAXlabel.Text.Equals(HPMAXvalue);
            ListOfControls.Add(HPMAXlabel);
            //
            //MRlabel
            //
            this.MRlabel.AutoSize = true;
            this.MRlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MRlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.MRlabel.Location = new System.Drawing.Point(230, 245);
            this.MRlabel.Name = "MRlabel";
            this.MRlabel.Size = new System.Drawing.Size(94, 18);
            this.MRlabel.TabIndex = 1;
            this.MRlabel.Text.Equals(MRvalue);
            ListOfControls.Add(MRlabel);
            //
            //MRMAXlabel
            //
            this.MRMAXlabel.AutoSize = true;
            this.MRMAXlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MRMAXlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.MRMAXlabel.Location = new System.Drawing.Point(400, 245);
            this.MRMAXlabel.Name = "MRMAXlabel";
            this.MRMAXlabel.Size = new System.Drawing.Size(94, 18);
            this.MRMAXlabel.TabIndex = 1;
            this.MRMAXlabel.Text.Equals(MRMAXvalue);
            ListOfControls.Add(MRMAXlabel);
            //
            //CMBlabel
            //
            this.CMBlabel.AutoSize = true;
            this.CMBlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.CMBlabel.Location = new System.Drawing.Point(230, 279);
            this.CMBlabel.Name = "CMBlabel";
            this.CMBlabel.Size = new System.Drawing.Size(94, 18);
            this.CMBlabel.TabIndex = 1;
            this.CMBlabel.Text.Equals(CMBvalue);
            ListOfControls.Add(CMBlabel);
            //
            //CMAXlabel
            //
            this.CMAXlabel.AutoSize = true;
            this.CMAXlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMAXlabel.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.CMAXlabel.Location = new System.Drawing.Point(400, 279);
            this.CMAXlabel.Name = "CMAXlabel";
            this.CMAXlabel.Size = new System.Drawing.Size(94, 18);
            this.CMAXlabel.TabIndex = 1;
            this.CMAXlabel.Text.Equals(CMAXvalue);
            ListOfControls.Add(CMAXlabel);
        }

    }
}
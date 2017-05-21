using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.UI
{
    internal class DescriptionPanel
    {
        private SimpleProgressBar CombatBar;
        private Label label1;
        private Label label2;
        private Label lblCanAttackUndead;
        private Label lblCombat;
        private Label lblIsUndead;
        private Label lblMRes;
        private Label lblName;
        private SimpleProgressBar LifeBar;
        private readonly List<Control> ListOfControls = new List<Control>();
        private SimpleProgressBar MresBar;


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
            CombatBar = new SimpleProgressBar();
            MresBar = new SimpleProgressBar();
            LifeBar = new SimpleProgressBar();
            lblCanAttackUndead = new Label();
            lblIsUndead = new Label();
            label2 = new Label();
            lblCombat = new Label();
            lblMRes = new Label();
            label1 = new Label();
            lblName = new Label();
            // 
            // CombatBar
            // 
            CombatBar.ForeColor = Color.FromArgb(0, 192, 0);
            CombatBar.Location = new Point(229, 279);
            CombatBar.Name = "CombatBar";
            CombatBar.Size = new Size(131, 18);
            CombatBar.TabIndex = 9;
            ListOfControls.Add(CombatBar);
            // 
            // MresBar
            // 
            MresBar.ForeColor = Color.FromArgb(0, 192, 0);
            MresBar.Location = new Point(229, 245);
            MresBar.Name = "MresBar";
            MresBar.Size = new Size(131, 18);
            MresBar.TabIndex = 8;
            ListOfControls.Add(MresBar);
            // 
            // LifeBar
            // 

            LifeBar.Location = new Point(229, 213);
            LifeBar.Name = "LifeBar";
            LifeBar.Size = new Size(131, 18);
            LifeBar.TabIndex = 7;
            ListOfControls.Add(LifeBar);
            // 
            // lblCanAttackUndead
            // 
            lblCanAttackUndead.AutoSize = true;
            lblCanAttackUndead.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCanAttackUndead.ForeColor = Color.Red;
            lblCanAttackUndead.Location = new Point(17, 568);
            lblCanAttackUndead.Name = "lblCanAttackUndead";
            lblCanAttackUndead.Size = new Size(176, 18);
            lblCanAttackUndead.TabIndex = 6;
            lblCanAttackUndead.Text = "Can Attack Undead";
            ListOfControls.Add(lblCanAttackUndead);
            // 
            // lblIsUndead
            // 
            lblIsUndead.AutoSize = true;
            lblIsUndead.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIsUndead.ForeColor = Color.Red;
            lblIsUndead.Location = new Point(17, 540);
            lblIsUndead.Name = "lblIsUndead";
            lblIsUndead.Size = new Size(76, 18);
            lblIsUndead.TabIndex = 5;
            lblIsUndead.Text = "Undead";
            ListOfControls.Add(lblIsUndead);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MediumTurquoise;
            label2.Location = new Point(17, 352);
            label2.Name = "label2";
            label2.Size = new Size(100, 18);
            label2.TabIndex = 4;
            label2.Text = "Movement";
            ListOfControls.Add(label2);
            // 
            // lblCombat
            // 
            lblCombat.AutoSize = true;
            lblCombat.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCombat.ForeColor = Color.Fuchsia;
            lblCombat.Location = new Point(17, 279);
            lblCombat.Name = "lblCombat";
            lblCombat.Size = new Size(76, 18);
            lblCombat.TabIndex = 3;
            lblCombat.Text = "Combat";
            ListOfControls.Add(lblCombat);
            // 
            // lblMRes
            // 
            lblMRes.AutoSize = true;
            lblMRes.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMRes.ForeColor = Color.MediumTurquoise;
            lblMRes.Location = new Point(17, 245);
            lblMRes.Name = "lblMRes";
            lblMRes.Size = new Size(158, 18);
            lblMRes.TabIndex = 2;
            lblMRes.Text = "Magic Resistance";
            ListOfControls.Add(lblMRes);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MediumTurquoise;
            label1.Location = new Point(17, 213);
            label1.Name = "label1";
            label1.Size = new Size(94, 18);
            label1.TabIndex = 1;
            label1.Text = "Life Force";
            ListOfControls.Add(label1);
            // 
            // lblName
            // 
            lblName.BringToFront();
            lblName.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(192, 192, 0);
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(322, 23);
            lblName.Text = "MonsterName (WizardName)";
            ListOfControls.Add(lblName);
        }
    }
}
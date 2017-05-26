using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chaos.Model;

namespace Chaos.UI
{
    internal class DescriptionPanel
    {
        private Button btn;
        private Label CMAXlabel;
        private Label CMBlabel;

        private SimpleProgressBar CombatBar;
        private Label HPlabel;
        private Label HPMAXlabel;
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
        private Label MRlabel;
        private Label MRMAXlabel;
        private readonly int NumOfMoves;


        public DescriptionPanel(Monster monster)
        {
            NumOfMoves = monster.MovesRemaining;

            InitializeComponent();

            CombatBar.Maximum = monster.MaxAttack;
            CombatBar.Value = monster.Attack;
            CombatBar.Step = 1;

            lblName.Text = monster.Name + string.Format("({0})", monster.Owner.Name);

            lblCanAttackUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;

            lblIsUndead.ForeColor = monster.isUndead ? Color.Green : Color.Red;

            HPlabel.Text = monster.Health.ToString();
            HPMAXlabel.Text = monster.MaxHealth.ToString();
            MRlabel.Text = monster.MagicResistance.ToString();
            MRMAXlabel.Text = monster.MagicResistance.ToString();
            CMBlabel.Text = monster.Attack.ToString();
            CMAXlabel.Text = monster.MagicResistance.ToString();

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
            var BarLocationX = 150;
            for (var i = 0; i < NumOfMoves; i++)
            {
                var move = new SimpleProgressBar();
                move.Maximum = 1;
                move.Value = 1;
                move.ForeColor = Color.FromArgb(255, 0, 0);
                move.Location = new Point(BarLocationX, 355);
                move.Size = new Size(18, 18);
                ListOfControls.Add(move);
                BarLocationX += 20;
            }
        }

        private void InitializeComponent()
        {
            DrawMovementBar();
            btn = new Button();
            btn.Location = new Point(200, 200);
            LifeBar = new SimpleProgressBar();
            MresBar = new SimpleProgressBar();
            CombatBar = new SimpleProgressBar();

            LifeBar = new SimpleProgressBar();
            MresBar = new SimpleProgressBar();
            CombatBar = new SimpleProgressBar();
            lblCanAttackUndead = new Label();
            lblIsUndead = new Label();
            label2 = new Label();
            lblCombat = new Label();
            lblMRes = new Label();
            label1 = new Label();
            lblName = new Label();
            HPlabel = new Label();
            HPMAXlabel = new Label();
            MRlabel = new Label();
            MRMAXlabel = new Label();
            CMBlabel = new Label();
            CMAXlabel = new Label();
// 
// CombatBar
// 
            CombatBar.Location = new Point(270, 282);
            CombatBar.Size = new Size(131, 18);
            CombatBar.BackColor = Color.FromArgb(255, 0, 0);
            CombatBar.ForeColor = Color.FromArgb(0, 255, 0);
            ListOfControls.Add(CombatBar);
// 
// MresBar
// 

            MresBar.Location = new Point(270, 248);
            MresBar.Size = new Size(131, 18);
            MresBar.BackColor = Color.FromArgb(255, 0, 0);
            MresBar.ForeColor = Color.FromArgb(0, 255, 0);
            ListOfControls.Add(MresBar);
// 
// LifeBar
// 

            LifeBar.Location = new Point(270, 216);
            LifeBar.Name = "LifeBar";
            LifeBar.Size = new Size(131, 18);
            LifeBar.BackColor = Color.FromArgb(255, 0, 0);
            LifeBar.ForeColor = Color.FromArgb(0, 255, 0);
            ListOfControls.Add(LifeBar);
// 
// lblCanAttackUndead
// 
            lblCanAttackUndead.AutoSize = true;
            lblCanAttackUndead.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            lblIsUndead.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            label2.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            lblCombat.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            lblMRes.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
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
            lblName.Font = new Font("Verdana", 14.25F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(192, 192,
                0);
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(322, 23);
            lblName.Text = "MonsterName (WizardName)";
            ListOfControls.Add(lblName);
//
//HPlabel
//
            HPlabel.AutoSize = true;
            HPlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            HPlabel.ForeColor = Color.MediumTurquoise;
            HPlabel.Location = new Point(230, 213);
            HPlabel.Name = "HPlabel";
            HPlabel.Size = new Size(94, 18);
            HPlabel.TabIndex = 1;
            ListOfControls.Add(HPlabel);
//
//HPMAXlabel
//
            HPMAXlabel.AutoSize = true;
            HPMAXlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            HPMAXlabel.ForeColor = Color.MediumTurquoise;
            HPMAXlabel.Location = new Point(400, 213);
            HPMAXlabel.Name = "HPMAXlabel";
            HPMAXlabel.Size = new Size(94, 18);
            HPMAXlabel.TabIndex = 1;
            ListOfControls.Add(HPMAXlabel);
//
//MRlabel
//
            MRlabel.AutoSize = true;
            MRlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            MRlabel.ForeColor = Color.MediumTurquoise;
            MRlabel.Location = new Point(230, 245);
            MRlabel.Name = "MRlabel";
            MRlabel.Size = new Size(94, 18);
            MRlabel.TabIndex = 1;
            ListOfControls.Add(MRlabel);
//
//MRMAXlabel
//
            MRMAXlabel.AutoSize = true;
            MRMAXlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            MRMAXlabel.ForeColor = Color.MediumTurquoise;
            MRMAXlabel.Location = new Point(400, 245);
            MRMAXlabel.Name = "MRMAXlabel";
            MRMAXlabel.Size = new Size(94, 18);
            MRMAXlabel.TabIndex = 1;
            ListOfControls.Add(MRMAXlabel);
//
//CMBlabel
//
            CMBlabel.AutoSize = true;
            CMBlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            CMBlabel.ForeColor = Color.MediumTurquoise;
            CMBlabel.Location = new Point(230, 279);
            CMBlabel.Name = "CMBlabel";
            CMBlabel.Size = new Size(94, 18);
            CMBlabel.TabIndex = 1;
            ListOfControls.Add(CMBlabel);
//
//CMAXlabel
//
            CMAXlabel.AutoSize = true;
            CMAXlabel.Font = new Font("Verdana", 12F, FontStyle.Bold,
                GraphicsUnit.Point, 0);
            CMAXlabel.ForeColor = Color.MediumTurquoise;
            CMAXlabel.Location = new Point(400, 279);
            CMAXlabel.Name = "CMAXlabel";
            CMAXlabel.Size = new Size(94, 18);
            CMAXlabel.TabIndex = 1;

            ListOfControls.Add(CMAXlabel);
        }
    }
}
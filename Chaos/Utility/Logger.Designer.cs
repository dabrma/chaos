namespace Chaos.Utility
{
    partial class Logger
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
            this.logField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logField
            // 
            this.logField.Location = new System.Drawing.Point(12, 12);
            this.logField.Multiline = true;
            this.logField.Name = "logField";
            this.logField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logField.Size = new System.Drawing.Size(672, 367);
            this.logField.TabIndex = 0;
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 391);
            this.Controls.Add(this.logField);
            this.Name = "Logger";
            this.Text = "Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox logField;
    }
}
namespace HerbaLife
{
    partial class AddOp
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
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.mtb2 = new System.Windows.Forms.MaskedTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.mtb1 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(14, 57);
            this.metroDateTime1.Margin = new System.Windows.Forms.Padding(4);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(252, 30);
            this.metroDateTime1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroDateTime1.TabIndex = 0;
            // 
            // mtb2
            // 
            this.mtb2.Location = new System.Drawing.Point(14, 115);
            this.mtb2.Margin = new System.Windows.Forms.Padding(4);
            this.mtb2.Mask = "000.00";
            this.mtb2.Name = "mtb2";
            this.mtb2.Size = new System.Drawing.Size(252, 30);
            this.mtb2.TabIndex = 2;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(14, 193);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(252, 42);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Добавить";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 91);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(107, 20);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Введите сумму";
            // 
            // mtb1
            // 
            // 
            // 
            // 
            this.mtb1.CustomButton.Image = null;
            this.mtb1.CustomButton.Location = new System.Drawing.Point(224, 2);
            this.mtb1.CustomButton.Name = "";
            this.mtb1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.mtb1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtb1.CustomButton.TabIndex = 1;
            this.mtb1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtb1.CustomButton.UseSelectable = true;
            this.mtb1.CustomButton.Visible = false;
            this.mtb1.Lines = new string[0];
            this.mtb1.Location = new System.Drawing.Point(12, 153);
            this.mtb1.Margin = new System.Windows.Forms.Padding(4);
            this.mtb1.MaxLength = 32767;
            this.mtb1.Name = "mtb1";
            this.mtb1.PasswordChar = '\0';
            this.mtb1.PromptText = "Введите количество посещений";
            this.mtb1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtb1.SelectedText = "";
            this.mtb1.SelectionLength = 0;
            this.mtb1.SelectionStart = 0;
            this.mtb1.ShortcutsEnabled = true;
            this.mtb1.Size = new System.Drawing.Size(254, 32);
            this.mtb1.Style = MetroFramework.MetroColorStyle.Green;
            this.mtb1.TabIndex = 5;
            this.mtb1.UseSelectable = true;
            this.mtb1.WaterMark = "Введите количество посещений";
            this.mtb1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtb1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // AddOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 250);
            this.Controls.Add(this.mtb1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.mtb2);
            this.Controls.Add(this.metroDateTime1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddOp";
            this.Padding = new System.Windows.Forms.Padding(28, 82, 28, 28);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Оплата";
            this.Load += new System.EventHandler(this.AddOp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private System.Windows.Forms.MaskedTextBox mtb2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox mtb1;
        public MetroFramework.Controls.MetroButton metroButton1;
    }
}
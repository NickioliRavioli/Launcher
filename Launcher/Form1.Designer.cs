namespace Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Run_Button = new System.Windows.Forms.Button();
            this.VersionComboBox = new System.Windows.Forms.ComboBox();
            this.SafemodeCheckBox = new System.Windows.Forms.CheckBox();
            this.VerbosemodeCheckBox = new System.Windows.Forms.CheckBox();
            this.FlavourComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Settings_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(297, 47);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(75, 23);
            this.Run_Button.TabIndex = 1;
            this.Run_Button.Text = "Run";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // VersionComboBox
            // 
            this.VersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionComboBox.FormattingEnabled = true;
            this.VersionComboBox.Location = new System.Drawing.Point(12, 12);
            this.VersionComboBox.Name = "VersionComboBox";
            this.VersionComboBox.Size = new System.Drawing.Size(170, 21);
            this.VersionComboBox.TabIndex = 3;
            this.VersionComboBox.SelectedIndexChanged += new System.EventHandler(this.VersionComboBox_SelectedIndexChanged);
            // 
            // SafemodeCheckBox
            // 
            this.SafemodeCheckBox.AutoSize = true;
            this.SafemodeCheckBox.Location = new System.Drawing.Point(12, 51);
            this.SafemodeCheckBox.Name = "SafemodeCheckBox";
            this.SafemodeCheckBox.Size = new System.Drawing.Size(78, 17);
            this.SafemodeCheckBox.TabIndex = 5;
            this.SafemodeCheckBox.Text = "Safe Mode";
            this.SafemodeCheckBox.UseVisualStyleBackColor = true;
            this.SafemodeCheckBox.CheckedChanged += new System.EventHandler(this.SafemodeCheckBox_CheckedChanged);
            // 
            // VerbosemodeCheckBox
            // 
            this.VerbosemodeCheckBox.AutoSize = true;
            this.VerbosemodeCheckBox.Location = new System.Drawing.Point(96, 51);
            this.VerbosemodeCheckBox.Name = "VerbosemodeCheckBox";
            this.VerbosemodeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.VerbosemodeCheckBox.TabIndex = 6;
            this.VerbosemodeCheckBox.Text = "Verbose Mode";
            this.VerbosemodeCheckBox.UseVisualStyleBackColor = true;
            this.VerbosemodeCheckBox.CheckedChanged += new System.EventHandler(this.VerbosemodeCheckBox_CheckedChanged);
            // 
            // FlavourComboBox
            // 
            this.FlavourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlavourComboBox.FormattingEnabled = true;
            this.FlavourComboBox.Items.AddRange(new object[] {
            "nuke",
            "nukex",
            "studio",
            "hiero"});
            this.FlavourComboBox.Location = new System.Drawing.Point(202, 12);
            this.FlavourComboBox.Name = "FlavourComboBox";
            this.FlavourComboBox.Size = new System.Drawing.Size(170, 21);
            this.FlavourComboBox.TabIndex = 7;
            this.FlavourComboBox.SelectedIndexChanged += new System.EventHandler(this.FlavourComboBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 20);
            this.textBox1.TabIndex = 9;
            // 
            // Settings_button
            // 
            this.Settings_button.Location = new System.Drawing.Point(216, 47);
            this.Settings_button.Name = "Settings_button";
            this.Settings_button.Size = new System.Drawing.Size(75, 23);
            this.Settings_button.TabIndex = 10;
            this.Settings_button.Text = "Settings";
            this.Settings_button.UseVisualStyleBackColor = true;
            this.Settings_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Run_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 116);
            this.Controls.Add(this.Settings_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FlavourComboBox);
            this.Controls.Add(this.VerbosemodeCheckBox);
            this.Controls.Add(this.SafemodeCheckBox);
            this.Controls.Add(this.VersionComboBox);
            this.Controls.Add(this.Run_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(399, 155);
            this.MinimumSize = new System.Drawing.Size(399, 155);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuke Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.ComboBox VersionComboBox;
        private System.Windows.Forms.CheckBox SafemodeCheckBox;
        private System.Windows.Forms.CheckBox VerbosemodeCheckBox;
        private System.Windows.Forms.ComboBox FlavourComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Settings_button;
    }
}


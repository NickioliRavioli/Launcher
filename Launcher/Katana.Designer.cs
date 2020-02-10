namespace Launcher
{
    partial class KatanaLauncherForm
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
			this.Settings_button = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.VersionComboBox = new System.Windows.Forms.ComboBox();
			this.Run_Button = new System.Windows.Forms.Button();
			this.BatchScriptCheckListBox = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Settings_button
			// 
			this.Settings_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Settings_button.Location = new System.Drawing.Point(221, 289);
			this.Settings_button.Name = "Settings_button";
			this.Settings_button.Size = new System.Drawing.Size(75, 23);
			this.Settings_button.TabIndex = 17;
			this.Settings_button.Text = "Settings";
			this.Settings_button.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(17, 263);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(360, 20);
			this.textBox1.TabIndex = 16;
			// 
			// VersionComboBox
			// 
			this.VersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.VersionComboBox.FormattingEnabled = true;
			this.VersionComboBox.Location = new System.Drawing.Point(5, 35);
			this.VersionComboBox.Name = "VersionComboBox";
			this.VersionComboBox.Size = new System.Drawing.Size(170, 21);
			this.VersionComboBox.TabIndex = 12;
			// 
			// Run_Button
			// 
			this.Run_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Run_Button.Location = new System.Drawing.Point(302, 289);
			this.Run_Button.Name = "Run_Button";
			this.Run_Button.Size = new System.Drawing.Size(75, 23);
			this.Run_Button.TabIndex = 11;
			this.Run_Button.Text = "Run";
			this.Run_Button.UseVisualStyleBackColor = true;
			this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
			// 
			// BatchScriptCheckListBox
			// 
			this.BatchScriptCheckListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BatchScriptCheckListBox.CheckOnClick = true;
			this.BatchScriptCheckListBox.FormattingEnabled = true;
			this.BatchScriptCheckListBox.Location = new System.Drawing.Point(5, 85);
			this.BatchScriptCheckListBox.Name = "BatchScriptCheckListBox";
			this.BatchScriptCheckListBox.Size = new System.Drawing.Size(360, 154);
			this.BatchScriptCheckListBox.TabIndex = 18;
			this.BatchScriptCheckListBox.SelectedIndexChanged += new System.EventHandler(this.BatchScriptCheckListBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Version";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.BatchScriptCheckListBox);
			this.groupBox1.Controls.Add(this.VersionComboBox);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(369, 245);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Katana";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Batch Scripts";
			// 
			// KatanaLauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 325);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Run_Button);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Settings_button);
			this.Name = "KatanaLauncherForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KatanaLauncher";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Settings_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox VersionComboBox;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.CheckedListBox BatchScriptCheckListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
    }
}
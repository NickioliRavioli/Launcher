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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KatanaLauncherForm));
            this.Settings_button = new System.Windows.Forms.Button();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.VersionComboBox = new System.Windows.Forms.ComboBox();
            this.Run_Button = new System.Windows.Forms.Button();
            this.BatchScriptCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.profilingDirTextBox = new System.Windows.Forms.TextBox();
            this.forceProfilingCheckbox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.batchScriptLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Settings_button
            // 
            this.Settings_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings_button.Location = new System.Drawing.Point(219, 384);
            this.Settings_button.Name = "Settings_button";
            this.Settings_button.Size = new System.Drawing.Size(75, 23);
            this.Settings_button.TabIndex = 17;
            this.Settings_button.Text = "Settings";
            this.Settings_button.UseVisualStyleBackColor = true;
            this.Settings_button.Click += new System.EventHandler(this.Settings_button_Click);
            // 
            // commandTextBox
            // 
            this.commandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandTextBox.Location = new System.Drawing.Point(12, 358);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(363, 20);
            this.commandTextBox.TabIndex = 16;
            // 
            // VersionComboBox
            // 
            this.VersionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionComboBox.FormattingEnabled = true;
            this.VersionComboBox.Location = new System.Drawing.Point(6, 32);
            this.VersionComboBox.Name = "VersionComboBox";
            this.VersionComboBox.Size = new System.Drawing.Size(170, 21);
            this.VersionComboBox.TabIndex = 12;
            this.VersionComboBox.SelectedIndexChanged += new System.EventHandler(this.VersionComboBox_SelectedIndexChanged);
            // 
            // Run_Button
            // 
            this.Run_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Run_Button.Location = new System.Drawing.Point(300, 384);
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
            this.BatchScriptCheckListBox.IntegralHeight = false;
            this.BatchScriptCheckListBox.Location = new System.Drawing.Point(6, 123);
            this.BatchScriptCheckListBox.Name = "BatchScriptCheckListBox";
            this.BatchScriptCheckListBox.Size = new System.Drawing.Size(351, 211);
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
            this.groupBox1.Controls.Add(this.profilingDirTextBox);
            this.groupBox1.Controls.Add(this.forceProfilingCheckbox);
            this.groupBox1.Controls.Add(this.BatchScriptCheckListBox);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.batchScriptLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.VersionComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 340);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Katana";
            // 
            // profilingDirTextBox
            // 
            this.profilingDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilingDirTextBox.Location = new System.Drawing.Point(6, 83);
            this.profilingDirTextBox.Name = "profilingDirTextBox";
            this.profilingDirTextBox.Size = new System.Drawing.Size(170, 20);
            this.profilingDirTextBox.TabIndex = 24;
            this.profilingDirTextBox.Visible = false;
            this.profilingDirTextBox.TextChanged += new System.EventHandler(this.profilingDirTextBox_TextChanged);
            // 
            // forceProfilingCheckbox
            // 
            this.forceProfilingCheckbox.AutoSize = true;
            this.forceProfilingCheckbox.Location = new System.Drawing.Point(6, 60);
            this.forceProfilingCheckbox.Name = "forceProfilingCheckbox";
            this.forceProfilingCheckbox.Size = new System.Drawing.Size(93, 17);
            this.forceProfilingCheckbox.TabIndex = 23;
            this.forceProfilingCheckbox.Text = "Force Profiling";
            this.forceProfilingCheckbox.UseVisualStyleBackColor = true;
            this.forceProfilingCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(182, -43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // batchScriptLabel
            // 
            this.batchScriptLabel.AutoSize = true;
            this.batchScriptLabel.Location = new System.Drawing.Point(6, 107);
            this.batchScriptLabel.Name = "batchScriptLabel";
            this.batchScriptLabel.Size = new System.Drawing.Size(70, 13);
            this.batchScriptLabel.TabIndex = 20;
            this.batchScriptLabel.Text = "Batch Scripts";
            // 
            // KatanaLauncherForm
            // 
            this.AcceptButton = this.Run_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Run_Button);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.Settings_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "KatanaLauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KatanaLauncher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Settings_button;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.ComboBox VersionComboBox;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.CheckedListBox BatchScriptCheckListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label batchScriptLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox forceProfilingCheckbox;
        private System.Windows.Forms.TextBox profilingDirTextBox;
    }
}
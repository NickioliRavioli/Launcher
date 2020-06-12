using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*!!! If you cancel out of this window, next time you open it. it will still be be old settings.
implement something to revert variables back to what they were before the window was edited*/

namespace Launcher
{
    public partial class SettingsForm : Form
    {
        Launcher mainLauncher;
        public SettingsForm(Launcher obj)
        {
            InitializeComponent();
            mainLauncher = obj;
        }

        public void SetTextboxes(string ApplicationInstallDir, string BatchScriptDir)
        {
            textbox_ApplicationDir.Text = ApplicationInstallDir;
            textbox_BatchScriptDir.Text = BatchScriptDir;
        }



        private void button_OK_Click(object sender, EventArgs e)
        {
            mainLauncher.UpdateRegistryKeys(textbox_ApplicationDir.Text, textbox_BatchScriptDir.Text);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox_ApplicationDir_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

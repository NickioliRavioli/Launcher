using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Launcher
{
    public partial class Form2 : Form
    {
        private Form1 mainWindow;
        



        public Form2(Form1 form1)
        {
            InitializeComponent();
            mainWindow = form1;
        }

        public void SetTextboxes(string ApplicationInstallDir, string BatchScriptDir)
        {
            textbox_ApplicationDir.Text = ApplicationInstallDir;
            textbox_BatchScriptDir.Text = BatchScriptDir;
        }



        private void button_OK_Click(object sender, EventArgs e)
        {
            mainWindow.UpdateRegistryKeys(textbox_ApplicationDir.Text, textbox_BatchScriptDir.Text);
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

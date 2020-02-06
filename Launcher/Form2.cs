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
        private bool InitialiseRegistryKeysFinished = false;

        private string ApplicationInstallDir_KeyName = "ApplicationInstallDir";
        private string BatchScriptDir_KeyName = "BatchScriptDir";

        public Form2(Form1 form1)
        {
            InitializeComponent();
            mainWindow = form1;
            InitialiseRegistryKeysFinished = InitialiseRegistryKeys();

        }

        public bool InitialiseRegistryKeys()
        {
            string ApplicationInstallDir = ReadRegistryKey(ApplicationInstallDir_KeyName);
            if (ApplicationInstallDir == null)
            {
                string defaultPath = @"C:\Program Files;C:\Program Files (x86)";
                CreateRegistryKey(ApplicationInstallDir_KeyName, defaultPath);
                ApplicationInstallDir = defaultPath;
            }
            string BatchScriptDir = ReadRegistryKey(BatchScriptDir_KeyName);
            if (BatchScriptDir == null)
            {
                CreateRegistryKey(BatchScriptDir_KeyName, "hello");
                BatchScriptDir = "";
            }

            textbox_ApplicationDir.Text = ApplicationInstallDir;
            textbox_BatchScriptDir.Text = BatchScriptDir;
            return true;
        }

        public void UpdateRegistryKeys()
        {
            CreateRegistryKey(ApplicationInstallDir_KeyName, textbox_ApplicationDir.Text);
            CreateRegistryKey(BatchScriptDir_KeyName, textbox_BatchScriptDir.Text);
        }

        public string ReadRegistryKey(string name)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NicksLauncher");
            if (key != null)
                if (key.GetValue(name) != null)
                    return key.GetValue(name).ToString();
            return null;
            
        }

        public void CreateRegistryKey(string name, string value)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\NicksLauncher");
            key.SetValue(name, value);
            key.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            UpdateRegistryKeys();

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

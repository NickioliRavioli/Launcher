using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace Launcher
{
    public partial class Form1 : Form
    {
        private Form2 f2;
        private System.Diagnostics.Process process = new System.Diagnostics.Process();
        
        private Dictionary<string, string> listOfVersions = new Dictionary<string, string>();
        
        private string mainApplication = "Nuke";

        private string ApplicationInstallDir_KeyName = "ApplicationInstallDir";
        public string ApplicationInstallDir_KeyValue;
        private string ApplicationInstallDir_defaultValue = @"C:\Program Files;C:\Program Files (x86)";

        private string BatchScriptDir_KeyName = "BatchScriptDir";
        public string BatchScriptDir_KeyValue;
        private string BatchScriptDir_defaultValue = "";

        private bool InitializeFinished = false;
        private bool InitialiseRegistryKeysFinished = false;

        List<string> ApplicationInstallDirs_List = new List<string>();

        public Form1()
        {
            InitializeComponent();
            f2 = new Form2(this);
            InitialiseRegistryKeys();


            //UpdateListOfVersions();

            FlavourComboBox.SelectedIndex = 0;
            InitializeFinished = true;
            UpdateCommandLabel();
            
        }

        private bool InitialiseRegistryKeys()
        {
            string ApplicationInstallDir = ReadRegistryKey(ApplicationInstallDir_KeyName);
            if (ApplicationInstallDir == null)
            {
                CreateRegistryKey(ApplicationInstallDir_KeyName, ApplicationInstallDir_defaultValue);
                ApplicationInstallDir = ApplicationInstallDir_defaultValue;
            }
            string BatchScriptDir = ReadRegistryKey(BatchScriptDir_KeyName);
            if (BatchScriptDir == null)
            {
                CreateRegistryKey(BatchScriptDir_KeyName, BatchScriptDir_defaultValue);
                BatchScriptDir = BatchScriptDir_defaultValue;
            }

            ApplicationInstallDir_KeyValue = ApplicationInstallDir;
            BatchScriptDir_KeyValue = BatchScriptDir;

            //update form2 textboxs
            f2.SetTextboxes(ApplicationInstallDir_KeyValue, BatchScriptDir_KeyValue);

            ApplicationInstallDirs_List = RegistryKeyToListString(ApplicationInstallDir_KeyValue);
            UpdateListOfVersions(ApplicationInstallDirs_List);

            return true;
        }

        //update called from form2, trigged when the ok button is clicked.
        public void UpdateRegistryKeys(string ApplicationInstallDir, string BatchScriptDir)
        {
            ApplicationInstallDir_KeyValue = ApplicationInstallDir;
            BatchScriptDir_KeyValue = BatchScriptDir;

            CreateRegistryKey(ApplicationInstallDir_KeyName, ApplicationInstallDir_KeyValue);
            CreateRegistryKey(BatchScriptDir_KeyName, BatchScriptDir_KeyValue);

            ApplicationInstallDirs_List = RegistryKeyToListString(ApplicationInstallDir_KeyValue);
            UpdateListOfVersions(ApplicationInstallDirs_List);
        }

        private List<string> RegistryKeyToListString(string RegistryKeyValue)
        {

            string[] dirs = RegistryKeyValue.Split(';');
            List<string> outputDirs = new List<string>();
            //MessageBox.Show(temp);
            foreach (string item in dirs)
            {
                outputDirs.Add(item);
            }

            return outputDirs;
        }


        private string ReadRegistryKey(string name)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NicksLauncher");
            if (key != null && key.GetValue(name) != null)
            {
                string temp = key.GetValue(name).ToString();
                return temp;
            }
            return null;

        }

        private void CreateRegistryKey(string name, string value)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\NicksLauncher");
            key.SetValue(name, value);
            key.Close();
        }


        private string findVersion(string value, string programName)
        {
            int posA = value.LastIndexOf(programName);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + programName.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }

        private bool UpdateListOfVersions(List<string> Directories)
        {
            listOfVersions.Clear();

            if (Directories.Count == 0)
            {
                return false;
            }

            List<string> singleDigit = new List<string>();
            List<string> doubleDigit = new List<string>();
            List<string> SortedOrder = new List<string>();
            var map = new Dictionary<string, string>();

            foreach (string path in Directories)
            {
                if (path == "")
                {
                    continue;
                }
                string[] array1 = Directory.GetDirectories(path);

                foreach (string name in array1)
                {
                    //this.checkedListBox1.Items.AddRange(new object[] { name });
                    if (name.Contains(mainApplication))
                    {

                        string version = findVersion(name, mainApplication);
                        string exePath = name + '\\' + mainApplication + version.Split('v').First();
                        exePath += ".exe";
                        map.Add(version, exePath);

                        string input = version.Split('.').First();
                        if (Int32.Parse(input) < 10)
                            singleDigit.Add(version);
                        else
                            doubleDigit.Add(version);
                    }
                }
            }

            for (int i = doubleDigit.Count; i >= 1; i--)
                SortedOrder.Add(doubleDigit[i - 1]);

            for (int i = singleDigit.Count; i >= 1; i--)
                SortedOrder.Add(singleDigit[i - 1]);

            bool VersionSet = false;
            VersionComboBox.Items.Clear();
            foreach (string item in SortedOrder)
            {
                VersionComboBox.Items.AddRange(new object[] { item });

                if (!VersionSet && !item.Contains("Beta") && !item.Contains("Alpha"))
                {
                    VersionComboBox.Text = item;
                    VersionComboBox.SelectedItem = item;
                    VersionSet = true;
                }
                
            }

            listOfVersions = map;
            UpdateCommandLabel();
            return true;
        }

        private void RunCommand(string command)
        {
            if (command == "")
            {
                MessageBox.Show("ERROR: There is no command to run");
                return;
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c " + command;
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            
            process.Start();

        }

        private string GetCommand()
        {
            if (listOfVersions.Count == 0)
                return null;
            
            string strCmdText;
            string endingtext = "";
            listOfVersions.TryGetValue(VersionComboBox.SelectedItem.ToString(), out strCmdText);

            //MessageBox.Show(FlavourComboBox.SelectedIndex.ToString());
            if (FlavourComboBox.SelectedIndex > 0)
            {
                endingtext += " --" + FlavourComboBox.SelectedItem.ToString();
            }

            if (SafemodeCheckBox.Checked)
            {
                endingtext += " --safe";
            }

            if (VerbosemodeCheckBox.Checked)
            {
                endingtext += " -V";
            }

            return '\"' + strCmdText + '\"' + endingtext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunCommand(textBox1.Text);
        }

        private void UpdateCommandLabel()
        {
            if (InitializeFinished && listOfVersions!=null)
            {
                textBox1.Text = GetCommand();
            }
        }

        private void VersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandLabel();
        }

        private void FlavourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandLabel();
        }

        private void SafemodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCommandLabel();
        }

        private void VerbosemodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCommandLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
        }
    }
}

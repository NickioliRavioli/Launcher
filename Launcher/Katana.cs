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


/*
 Bug: Spam clicking a BatchScriptCheckListBox item increase memory usage (memory leak?)
     
     
*/


namespace Launcher
{
    public partial class KatanaLauncherForm : Form
    {
        
        private Launcher mainLauncher;
        private string programName = "Katana";
        public Dictionary<string, string> listOfVersions = new Dictionary<string, string>();
        public Dictionary<string, string> listOfBatchScripts = new Dictionary<string, string>();

        public KatanaLauncherForm(Launcher obj)
        {
            InitializeComponent();
            mainLauncher = obj;

        }


        public void UpdateBatchScripts(List<string> Directories)
        {
            if (Directories == null || Directories.Count == 0)
            {
                return;
            }

            listOfBatchScripts.Clear();
            BatchScriptCheckListBox.Items.Clear();
            foreach (string path in Directories)
            {
                if (path == "")
                {
                    continue;
                }
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("Warning: Path doesn't exists " + path);
                    continue;
                }

                string[] array1 = Directory.GetFiles(path);

                foreach (string batPath in array1)
                {
                    string name = batPath.Replace(path + '\\', "");
                    listOfBatchScripts.Add(name, batPath);
                    BatchScriptCheckListBox.Items.AddRange(new object[] { name });
                }
            }

            
            // listOfVersions = map;
        }

        public void UpdateListOfVersions(List<string> Directories)
        {
            listOfVersions.Clear();

            if (Directories.Count == 0)
            {
                return;
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
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("Warning: Path doesn't exists " + path);
                    continue;
                }

                string[] array1 = Directory.GetDirectories(path);

                foreach (string name in array1)
                {
                    //this.checkedListBox1.Items.AddRange(new object[] { name });
                    if (name.Contains(programName))
                    {

                        string version = mainLauncher.findVersion(name, programName);
                        string exePath = name + '\\' + "bin\\katanabin.exe";
                        map.Add(version, exePath);

                        string input = version.Split('.').First();
                        if (Int32.Parse(input) < 10)
                            singleDigit.Add(version);
                        else
                            doubleDigit.Add(version);
                    }
                }
            }

            listOfVersions = map;

            //accending/deccending order
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

            UpdateCommandLabel();
        }

        private string GetBatchScriptsCommands()
        {
            string batscripts = ""; 
            string batscriptitem;
            if (BatchScriptCheckListBox.CheckedItems.Count != 0)
            {
                foreach (string item in BatchScriptCheckListBox.CheckedItems)
                {
                    listOfBatchScripts.TryGetValue(item.ToString(), out batscriptitem);
                    batscripts += batscriptitem + "\"&\""; //Add "&&" to not run the following commands if the first command fails
                }
            }
            return batscripts;
        }

        private string GetCommand()
        {
            if (listOfVersions.Count == 0)
                return null;

            string strCmdText;
            string endingtext = ""; //TODO: Residual code from nuke, probably could be removed as this does not apply to Katana
            listOfVersions.TryGetValue(VersionComboBox.SelectedItem.ToString(), out strCmdText);
            
            //return '\"' + strCmdText + '\"' + endingtext;
            return strCmdText;
    }

        private void UpdateCommandLabel()
        {
            if (listOfVersions != null)
            {
                textBox1.Text = GetCommand();
            }
        }

        private void BatchScriptCheckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BatchScriptCheckListBox.ClearSelected();
            UpdateCommandLabel();
        }

        private void Run_Button_Click(object sender, EventArgs e)
        {
            string batCommands = GetBatchScriptsCommands();
            mainLauncher.RunCommand(batCommands + textBox1.Text);
        }

        private void VersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommandLabel();
        }

        private void Settings_button_Click(object sender, EventArgs e)
        {
            mainLauncher.settingsForm.ShowDialog();
        }
    }
}

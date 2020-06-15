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
    public partial class NukeLauncherForm : Form
    {
        private Launcher mainLauncher;
        private bool InitializeFinished = false;
        static string programName = "Nuke";
        public Dictionary<string, string> listOfVersions = new Dictionary<string, string>();


        public NukeLauncherForm(Launcher obj)
        {
            InitializeComponent();
            mainLauncher = obj;

            FlavourComboBox.SelectedIndex = 0;
            InitializeFinished = true;
            UpdateCommandLabel();

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
                        string exePath = name + '\\' + programName + version.Split('v').First();
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


        protected string GetCommand()
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
            mainLauncher.RunCommand(textBox1.Text);
        }

        private void UpdateCommandLabel()
        {
            if (InitializeFinished && listOfVersions != null)
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
            mainLauncher.settingsForm.ShowDialog();
        }
    }
}

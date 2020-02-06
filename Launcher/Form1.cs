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

        Dictionary<string, string> listOfVersions;
        bool InitializeFinished = false;
        private System.Diagnostics.Process process = new System.Diagnostics.Process();
        Form2 f2;
        string mainApplication = "Nuke";

        public Form1()
        {
            InitializeComponent();
            f2 = new Form2(this);
            //MessageBox.Show("Form1");
            listOfVersions = UpdateListOfVersions("Nuke");
            FlavourComboBox.SelectedIndex = 0;
            InitializeFinished = true;
            UpdateCommandLabel();
            
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

        private Dictionary<string, string> UpdateListOfVersions(string programName)
        {
            string[] array1 = Directory.GetDirectories(@"C:\Program Files\");
            var map = new Dictionary<string, string>();

            List<string> singleDigit = new List<string>();
            List<string> DoubleDigit = new List<string>();
            List<string> SortedOrder = new List<string>();

            foreach (string name in array1)
            {
                //this.checkedListBox1.Items.AddRange(new object[] { name });
                if (name.Contains(programName))
                {

                    string version = findVersion(name, programName);
                    string exePath = name + '\\' + programName + version.Split('v').First();
                    exePath += ".exe";
                    map.Add(version, exePath);

                    string input = version.Split('.').First();
                    if (Int32.Parse(input) <10)
                        singleDigit.Add(version);
                    else
                        DoubleDigit.Add(version);
                }
            }

            for (int i = DoubleDigit.Count; i >= 1; i--)
                SortedOrder.Add(DoubleDigit[i - 1]);
            
            for (int i = singleDigit.Count; i >= 1; i--)
                SortedOrder.Add(singleDigit[i - 1]);

            bool VersionSet = false;
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

            return map;
        }

        private void RunCommand(string command)
        {
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
            if (InitializeFinished)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace Launcher
{
    public class Launcher
    {
        public NukeLauncherForm nukeForm;
        public KatanaLauncherForm katanaForm;
        public SettingsForm settingsForm;

        //public Form currentApplicationForm;

        private System.Diagnostics.Process process = new System.Diagnostics.Process();

        

        public enum Applications {Nuke, Katana};
        public Applications currentApplication;

        private string ApplicationInstallDir_KeyName = "ApplicationInstallDir";
        public string ApplicationInstallDir_KeyValue;
        private string ApplicationInstallDir_defaultValue = @"C:\Program Files;C:\Program Files (x86)";
        public List<string> ApplicationInstallDirs_List = new List<string>();

        private string BatchScriptDir_KeyName = "BatchScriptDir";
        public string BatchScriptDir_KeyValue;
        private string BatchScriptDir_defaultValue = "";
        public List<string> BatchScriptDir_List = new List<string>();

        private bool InitializeFinished = false;

        


        public Launcher()
        {
            currentApplication = Applications.Nuke;

            settingsForm = new SettingsForm(this);
            
            nukeForm = new NukeLauncherForm(this);
            katanaForm = new KatanaLauncherForm(this);
            //currentApplicationForm = nukeForm;

            InitialiseRegistryKeys();
        }

        // If the keys dont exsits then create them, else use them.
        private void InitialiseRegistryKeys()
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

            ApplicationInstallDirs_List = RegistryKeyToListString(ApplicationInstallDir_KeyValue);
            BatchScriptDir_List = RegistryKeyToListString(BatchScriptDir_KeyValue);
            //update form2 textboxs
            settingsForm.SetTextboxes(ApplicationInstallDir_KeyValue, BatchScriptDir_KeyValue);
            if (currentApplication == Applications.Nuke)
            {
                nukeForm.UpdateListOfVersions(ApplicationInstallDirs_List);
            }
            else if (currentApplication == Applications.Katana)
            {
                katanaForm.UpdateListOfVersions(ApplicationInstallDirs_List);
                katanaForm.UpdateBatchScripts(BatchScriptDir_List);
            }
            

        }

        //update called from Settings, trigged when the ok button is clicked.
        public void UpdateRegistryKeys(string ApplicationInstallDir, string BatchScriptDir)
        {
            ApplicationInstallDir_KeyValue = ApplicationInstallDir;
            BatchScriptDir_KeyValue = BatchScriptDir;

            CreateRegistryKey(ApplicationInstallDir_KeyName, ApplicationInstallDir_KeyValue);
            CreateRegistryKey(BatchScriptDir_KeyName, BatchScriptDir_KeyValue);

            ApplicationInstallDirs_List = RegistryKeyToListString(ApplicationInstallDir_KeyValue);
            BatchScriptDir_List = RegistryKeyToListString(BatchScriptDir_KeyValue);

            if (currentApplication == Applications.Nuke)
            {
                nukeForm.UpdateListOfVersions(ApplicationInstallDirs_List);
            }
            else if (currentApplication == Applications.Katana)
            {
                katanaForm.UpdateListOfVersions(ApplicationInstallDirs_List);
                katanaForm.UpdateBatchScripts(BatchScriptDir_List);
            }
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

        public System.Collections.ObjectModel.Collection<string> ArgumentList { get; }

        /*
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
                if (!Directory.Exists(path))
                {
                    //MessageBox.Show("Warning: Path doesn't exists " + path);
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
        }
        */
        public bool RunCommand(string command)
        {
            if (command == "")
            {
                MessageBox.Show("ERROR: There is no command to run");
                return false;
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";

            string args = "/c " + command;// + "&pause"; //Stops cmd closing when failing to launch
            startInfo.Arguments = args;

            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Start();

            return true;
        }


        public string findVersion(string value, string programName)
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

       

    }
}
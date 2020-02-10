using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Launcher mainLauncher = new Launcher();

            if (mainLauncher.currentApplication == Launcher.Applications.Nuke)
            {
                Application.Run(mainLauncher.nukeForm);
            }
            else if (mainLauncher.currentApplication == Launcher.Applications.Katana)
            {
                Application.Run(mainLauncher.katanaForm);
            }

        }
    }
}

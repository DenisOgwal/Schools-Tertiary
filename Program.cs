using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace College_Management_System
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
            string conconfig = Properties.Settings.Default.connectionsuccess;
            if (conconfig == "y")
            {
                Application.Run(new frmSplash());
            }
            else
            {
                Application.Run(new frmConnectionLoad());
            }
        }
    }
}
using System;
using System.Windows.Forms;
using RiotPls.Tools;

namespace RiotPls
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Program.Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.Views.formMain());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            GeneralSettings.Save();
            return;
        }
    }
}

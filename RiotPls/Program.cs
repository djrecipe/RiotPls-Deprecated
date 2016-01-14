using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!RiotPls.API.Engine.LoadKey())
            {
                MessageBox.Show("Unable to load API key.", "API Key");
                return;
            }
            Application.Run(new formMenu());
        }
    }
}

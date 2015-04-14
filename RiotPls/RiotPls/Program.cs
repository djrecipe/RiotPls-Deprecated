using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (!RiotAPI.LoadKey())
            {
                MessageBox.Show("Unable to load API key.", "API Key");
                return;
            }
            Application.Run(new formMenu());
        }
    }
}

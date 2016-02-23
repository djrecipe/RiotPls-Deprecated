using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.Tools
{
    public abstract class Paths
    {
        public static string AppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RiotPls");

        static Paths()
        {
            try
            {
                string directory = Paths.AppData;
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            catch
            {
                // ignored
            }
            return;
        }
    }
}

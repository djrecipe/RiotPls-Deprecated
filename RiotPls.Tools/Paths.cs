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
        public static readonly string AppData = null;
        public static readonly string Documents = null;

        static Paths()
        {
            Paths.AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RiotPls");
            Paths.Documents = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RiotPls");
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
            try
            {
                string directory = Paths.Documents;
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

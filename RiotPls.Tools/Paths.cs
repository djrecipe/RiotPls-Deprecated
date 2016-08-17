using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.Tools
{
    /// <summary>
    /// Static, commonly used paths
    /// </summary>
    public abstract class Paths
    {
        #region Static Members
        /// <summary>
        /// User application data directory for RiotPls
        /// </summary>
        public static readonly string AppData = null;
        /// <summary>
        /// User documents directory for RiotPls
        /// </summary>
        public static readonly string Documents = null;
        #endregion
        #region Static Methods
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
            catch(Exception e)
            {
                // TODO 08/16/16: handle exception
            }
            try
            {
                string directory = Paths.Documents;
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            catch (Exception e)
            {
                // TODO 08/16/16: handle exception
            }
            return;
        }
        #endregion
    }
}

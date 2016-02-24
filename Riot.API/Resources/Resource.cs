using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.General;

namespace RiotPls.API.Resources
{
    public class Resource
    {
        protected const string URL = "http://ddragon.leagueoflegends.com/cdn/";
        protected const string DIRECTORY = "Resources";
        protected const string FILENAME_IGNORE = "Ignore.csv";
        protected static List<string> ignore = new List<string>();
        public static int IgnoreCount => Resource.ignore.Count;
        public static string IgnoreListFilePath => Path.Combine(Resource.DIRECTORY, Resource.FILENAME_IGNORE);

        static Resource()
        {
            if (File.Exists(Resource.IgnoreListFilePath))
            {
                Resource.ignore.Clear();
                string text = null;
                try
                {
                    text = File.ReadAllText(Resource.IgnoreListFilePath);
                }
                catch
                {
                    text = null;
                }
                if (text != null)
                    Resource.ignore.AddRange(text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            }
            return;
        }

        public static void UpdateVersions(RealmInfo info)
        {
            
        }

        public static void ClearIgnored()
        {
            Resource.ignore.Clear();
            try
            {
                if (File.Exists(Resource.IgnoreListFilePath))
                    File.Delete(Resource.IgnoreListFilePath);
            }
            catch
            {
                // ignored
            }
            return;
        }

        public readonly string FileName = null;
        public string FullLocalPath => Path.Combine(Resource.DIRECTORY, this.SubPath);
        public readonly string Group = null;
        public bool Ignored => Resource.ignore.Contains(this.SubPath);
        protected string SubPath => Path.Combine(this.Version, this.Group, this.FileName);
        public readonly string Version = null;
        public Resource(string group, string file_name, string version)
        {
            if(string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Cannot be a null or empty string", "Group");
            this.Group = group;
            if (string.IsNullOrWhiteSpace(file_name))
                throw new ArgumentException("Cannot be a null or empty string", "FileName");
            this.FileName = file_name;
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentException("Cannot be a null or empty string", "Version");
            this.Version = version;
            return;
        }
        protected void Ignore()
        {
            try
            {
                if (File.Exists(this.FullLocalPath))
                    File.Delete(this.FullLocalPath);
            }
            catch
            {
                // ignored
            }
            if (!Resource.ignore.Contains(this.SubPath))
            {
                Resource.ignore.Add(this.SubPath);
                File.AppendAllText(Resource.IgnoreListFilePath, this.SubPath + "\r\n");
            }
            return;
        }
    }
}

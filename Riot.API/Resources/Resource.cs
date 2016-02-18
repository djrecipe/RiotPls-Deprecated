using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API.Resources
{
    public class Resource
    {
        protected const string URL = "http://ddragon.leagueoflegends.com/cdn/";
        protected const string DIRECTORY = "Images";
        protected const string FILENAME_IGNORE = "IgnoreImages.csv";
        protected const string VERSION = "6.1.1";
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
        public string FileName
        {
            get;
            set;
        }
        public string FullLocalPath => Path.Combine(Resource.DIRECTORY, this.SubPath);
        public string Group
        {
            get;
            set;
        }
        public bool Ignored => Resource.ignore.Contains(this.SubPath);
        protected string SubPath => Path.Combine(Resource.VERSION, this.Group, this.FileName);
        public Resource(string group, string file_name)
        {
            this.Group = group;
            this.FileName = file_name;
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
                File.AppendAllText(Resource.IgnoreListFilePath, this.FullLocalPath + "\r\n");
            }
            return;
        }
    }
}

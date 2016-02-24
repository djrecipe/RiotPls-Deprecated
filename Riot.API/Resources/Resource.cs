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
        private const string DEFAULT_CONTENT_URL = "http://ddragon.leagueoflegends.com/cdn/";
        private const string DEFAULT_CONTENT_VERSION = "6.3.1";
        protected const string DIRECTORY = "Resources";
        protected const string FILENAME_IGNORE = "Ignore.csv";
        protected static List<string> ignore = new List<string>();
        public static string ContentDirectory => Path.Combine(Path.GetFullPath(Resource.DIRECTORY), Resource.ContentVersion);
        public static string ContentURL { get; private set; } = Resource.DEFAULT_CONTENT_URL;
        public static string ContentVersion { get; private set; } = Resource.DEFAULT_CONTENT_VERSION;
        public static int IgnoreCount => Resource.ignore.Count;
        public static string IgnoreListFilePath => Path.Combine(Resource.ContentDirectory, Resource.FILENAME_IGNORE);

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
            else
            {
                try
                {
                    using (FileStream stream = File.Create(Resource.IgnoreListFilePath))
                    {
                        stream.Close();
                    }
                }
                catch
                {
                    // ignored
                }
            }
            return;
        }

        public static void UpdateVersions(RealmInfo info)
        {
            Resource.ContentURL = info.BaseURL;
            Resource.ContentVersion = info.ContentVersion;
            Resource.Validate();
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

        private static void Validate()
        {
            if (!Resource.ContentURL.EndsWith("/"))
                Resource.ContentURL += "/";
            if (Resource.ContentVersion.Split('.').Length != 3)
                Resource.ContentVersion = Resource.DEFAULT_CONTENT_VERSION;
            return;
        }

        public readonly string FileName = null;
        public string FullLocalPath => Path.Combine(Resource.ContentDirectory, this.SubPath);
        public readonly string Group = null;
        public bool Ignored => Resource.ignore.Contains(this.SubPath);
        protected string SubPath => Path.Combine(this.Group, this.FileName);
        public Resource(string group, string file_name)
        {
            if(string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Cannot be a null or empty string", "Group");
            this.Group = group;
            if (string.IsNullOrWhiteSpace(file_name))
                throw new ArgumentException("Cannot be a null or empty string", "FileName");
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
                File.AppendAllText(Resource.IgnoreListFilePath, this.SubPath + "\r\n");
            }
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.General;

namespace RiotPls.API.Resources
{
    /// <summary>
    /// Represents a generic, potentially downloadable resource
    /// </summary>
    public class Resource
    {
        #region Static Members
        #region Constants
        private const string DEFAULT_CONTENT_URL = "http://ddragon.leagueoflegends.com/cdn/";
        private const string DEFAULT_CONTENT_VERSION = "6.16.2";
        protected const string DIRECTORY = "Resources";
        protected const string FILENAME_IGNORE = "Ignore.csv";
        #endregion
        protected static List<string> ignore = new List<string>();
        #endregion
        #region Static Properties
        public static string ContentDirectory => Path.Combine(Path.GetFullPath(Resource.DIRECTORY), Resource.ContentVersion);
        public static string ContentURL { get; private set; } = Resource.DEFAULT_CONTENT_URL;
        public static string ContentVersion { get; private set; } = Resource.DEFAULT_CONTENT_VERSION;
        public static int IgnoreCount => Resource.ignore.Count;
        public static string IgnoreListFilePath => Path.Combine(Resource.ContentDirectory, Resource.FILENAME_IGNORE);
        #endregion
        #region Static Methods
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
        /// <summary>
        /// Updates resource and content versions using the specified version information
        /// </summary>
        /// <param name="info">Version information obtained via the Riot API</param>
        public static void UpdateVersions(RealmInfo info)
        {
            Resource.ContentURL = info.BaseURL;
            Resource.ContentVersion = info.ContentVersion;
            Resource.Validate();
            return;
        }
        /// <summary>
        /// Removes all items from the ignore list
        /// </summary>
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
            if (string.IsNullOrWhiteSpace(Resource.ContentURL) || !Resource.ContentURL.EndsWith("/"))
                Resource.ContentURL += "/";
            if (string.IsNullOrWhiteSpace(Resource.ContentVersion) || Resource.ContentVersion.Split('.').Length != 3)
                Resource.ContentVersion = Resource.DEFAULT_CONTENT_VERSION;
            return;
        }
        #endregion
        #region Instance Members
        /// <summary>
        /// Resource file name
        /// </summary>
        public readonly string FileName = null;
        /// <summary>
        /// Resource group
        /// </summary>
        /// <remarks>Used when determining remote and local paths for the resource</remarks>
        public readonly string Group = null;
        #endregion
        #region Instance Properties
        /// <summary>
        /// Local disk path where the content resides
        /// </summary>
        public string FullLocalPath => Path.Combine(Resource.ContentDirectory, this.SubPath);
        /// <summary>
        /// True if the resource is ignored, false otherwise
        /// </summary>
        /// <remarks>Ignored resources are excluded from download attempts</remarks>
        public bool Ignored => Resource.ignore.Contains(this.SubPath);
        protected string SubPath => Path.Combine(this.Group, this.FileName);
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="group">Resource group (sub path)</param>
        /// <param name="file_name">Resource file name</param>
        #endregion
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
        /// <summary>
        /// Add the resource to the global ignore list
        /// </summary>
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

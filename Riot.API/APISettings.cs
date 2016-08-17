using System;
using System.IO;

namespace RiotPls.API
{
    partial class APISettings
    {
        #region Types
        /// <summary>
        /// API regions
        /// </summary>
        public enum Regions : int { NorthAmerica = 0 };
        #endregion
        #region Static Members
        /// <summary>
        /// Default API version
        /// </summary>
        public const double DEFAULT_API_VER = 1.2;
        private const string FILENAME = "APISettings.rpxml";
        private static APISettings settings = null;
        #endregion
        #region Static Properties
        /// <summary>
        /// Current API version
        /// </summary>
        public static double APIVersion
        {
            get
            {
                double value = APISettings.DEFAULT_API_VER;
                try
                {
                    string text = APISettings.settings?.Versions[0]["APIVersion"]?.ToString();
                    double.TryParse(text, out value);
                }
                catch
                {
                    // ignored
                }
                return value;
            }
        }
        /// <summary>
        /// API settings file path
        /// </summary>
        public static string Path => System.IO.Path.Combine(Tools.Paths.AppData, APISettings.FILENAME);
        /// <summary>
        /// Current region
        /// </summary>
        public static Regions Region
        {
            get
            {
                try
                {
                    int region = (int)APISettings.settings.Miscellaneous[0]["Region"];
                    return (Regions)region;
                }
                catch
                {
                    // ignored
                }
                return Regions.NorthAmerica;
            }
        }
        #endregion
        #region Static Methods
        private static void Create()
        {
            try
            {
                APISettings.settings = new APISettings();
                // add versions
                APISettings.settings.Versions.AddVersionsRow(APISettings.settings.Versions.NewVersionsRow());
                // add miscellaneous
                APISettings.settings.Miscellaneous.AddMiscellaneousRow(APISettings.settings.Miscellaneous.NewMiscellaneousRow());
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// Attempt to load settings from the optionally specified file path
        /// </summary>
        /// <param name="path">Optional path to settings file to load</param>
        public static void Load(string path = null)
        {
            path = path ?? APISettings.Path;
            try
            {
                APISettings.Create();
                if (File.Exists(path))
                    APISettings.settings.ReadXml(path);
            }
            catch
            {
                // ignored
            }
            return;
        }
        /// <summary>
        /// Save settings to the optionally specified file path
        /// </summary>                                       
        /// <param name="path">Optional path to save settings to</param>
        public static void Save(string path = null)
        {
            path = path ?? APISettings.Path;
            try
            {
                APISettings.settings.WriteXml(path);
            }
            catch
            {
                // ignored
            }
            return;
        }
        #endregion
    }
}

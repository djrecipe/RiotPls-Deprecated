using System;
using System.IO;

namespace RiotPls.API
{

    partial class APISettings
    {
        private const string FILENAME = "APISettings.rpxml";
        private static APISettings settings = null;
        public static string APIVersion => APISettings.settings.Versions[0]["APIVersion"].ToString();
        public static string Path => System.IO.Path.Combine(Tools.Paths.AppData, APISettings.FILENAME);
        static APISettings()
        {
            APISettings.Load();
        }

        public static void Create()
        {
            try
            {
                APISettings.settings = new APISettings();
                // add versions
                APISettings.settings.Versions.AddVersionsRow(APISettings.settings.Versions.NewVersionsRow());
            }
            catch
            {
                // ignored
            }
        }
        public static void Load()
        {
            try
            {
                APISettings.Create();
                if (File.Exists(APISettings.Path))
                    APISettings.settings.ReadXml(APISettings.Path);
            }
            catch
            {
                // ignored
            }
            return;
        }
        public static void Save()
        {
            try
            {

                APISettings.settings.WriteXml(APISettings.Path);
            }
            catch
            {
                // ignored
            }
            return;
        }
    }
}

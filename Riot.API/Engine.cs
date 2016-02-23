using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotPls.API.Serialization;
using RiotPls.API.Serialization.Transport;

[assembly: InternalsVisibleTo("RiotPls.Test")]

namespace RiotPls.API
{
    public abstract class Engine
    {
        #region Types
        public enum Regions : int { NorthAmerica = 0 };
        #endregion
        #region Static Members
        #region Constants
        private const string REGION_NA = "na";
        private const string BASE_URL = "https://na.api.pvp.net/";
        private const string APIURL_LIVE = "api/lol/";
        private const string APIURL_STATIC = "api/lol/static-data/";
        private const string FILE_APIKEY = "key.txt";
        private const string FILE_CHAMPIONINFO = "ChampionInfo.json";
        private const string FILE_LIVECHAMPIONINFO = "LiveChampionInfo.json";
        private const string FILE_ITEMINFO = "ItemInfo.json";
        private const string FILE_MAPINFO = "MapInfo.json";
        private const string PARAM_ALLITEMDATA = "itemListData=all";
        private const string PARAM_ALLCHAMPDATA = "champData=all";
        private const string STR_APIKEY = "api_key=";
        #endregion
        private static List<LiveChampionInfo> live_champion_info = new List<LiveChampionInfo>();
        private static string region_string = "na";
        #endregion
        #region Static Properties
        private static string APIKey => Engine.STR_APIKEY + Engine.APIKeyRaw;
        public static string APIKeyRaw { get; private set;} = null;
        public static string APIVersion { get; set; } = "1.2";
        public static string APIVersionString => string.Format("v{0}", Engine.APIVersion);
        private static Dictionary<string, Serialization.Champion.ChampionInfo> _ChampionInfos = new Dictionary<string, Serialization.Champion.ChampionInfo>();
        public static Dictionary<string, Serialization.Champion.ChampionInfo> ChampionInfos
        {
            get
            {
                return Engine._ChampionInfos;
            }
        }

        public static string ContentVersion { get; set; } = "6.3.1";
        private static Dictionary<string, ItemInfo> _ItemInfos = new Dictionary<string, ItemInfo>();
        public static Dictionary<string, ItemInfo> ItemInfos
        {
            get
            {
                return Engine._ItemInfos;
            }
        }
        private static string LiveChampionDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_LIVE + Engine.region_string + "/" + Engine.APIVersionString + "/champion?" + Engine.APIKey;
            }
        }
        private static Dictionary<string, MapInfo> _MapInfos = new Dictionary<string, MapInfo>();
        public static Dictionary<string, MapInfo> MapInfos
        {
            get
            {
                return Engine._MapInfos;
            }
        }
        private static Regions _Region = Regions.NorthAmerica;
        public static Regions Region
        {
            get
            {
                return Engine._Region;
            }
            set
            {
                Engine._Region = value;
                switch (Engine.Region)
                {
                    case Regions.NorthAmerica:
                        Engine.region_string = Engine.REGION_NA;
                        break;
                    default:
                        break;
                }
                return;
            }
        }
        private static string StaticChampionDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/champion?" + Engine.PARAM_ALLCHAMPDATA + "&" + Engine.APIKey;
            }
        }
        private static string StaticItemDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/item?" + Engine.PARAM_ALLITEMDATA + "&" + Engine.APIKey;
            }
        }
        private static string StaticMapDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/map?&" + Engine.APIKey;
            }
        }
        #endregion
        #region Static Methods
        static Engine()
        {
            try
            {
                Engine.APIVersion = APISettings.APIVersion;
                Engine.ContentVersion = APISettings.ContentVersion;
            }
            catch
            { 
                // ignored
            }
            return;
        }
        public static string CleanseChampionName(Dictionary<string, Serialization.Champion.ChampionInfo> info, string name)
        {
            KeyValuePair<string, Serialization.Champion.ChampionInfo> pair = info.FirstOrDefault(i => i.Value.Name == name);
            return pair.Equals(default(KeyValuePair<string, Serialization.Champion.ChampionInfo>)) ? null : pair.Key;
        }
        public static Serialization.Champion.ChampionInfo GetChampion(string name)
        {
            return Engine.ChampionInfos.ContainsKey(name) ? Engine.ChampionInfos[name] : null;
        }
        public static Dictionary<string, Serialization.Champion.ChampionInfo> GetChampionInfo()
        {
            //
            JsonPayload<Dictionary<string, Serialization.Champion.ChampionInfo>> payload = new JsonPayload<Dictionary<string, Serialization.Champion.ChampionInfo>>(Engine.StaticChampionDataURL, Engine.FILE_CHAMPIONINFO, "data");
            Engine._ChampionInfos = payload.Get();

            Engine.UpdateLiveChampionInfo();
            return Engine.ChampionInfos;
        }
        public static Dictionary<string, ItemInfo> GetItemInfo()
        {
            // retrieve & deserialize json
            JsonPayload<Dictionary<string, ItemInfo>> payload = new JsonPayload<Dictionary<string, ItemInfo>>(
                Engine.StaticItemDataURL, Engine.FILE_ITEMINFO, "data");
            Engine._ItemInfos = payload.Get();
            return Engine.ItemInfos;
        }
        public static Dictionary<string, MapInfo> GetMapInfo()
        {
            // retrieve & deserialize json
            JsonPayload<Dictionary<string, MapInfo>> payload = new JsonPayload<Dictionary<string, MapInfo>>(
                Engine.StaticMapDataURL, Engine.FILE_MAPINFO, "data");
            Engine._MapInfos = payload.Get();
            return Engine.MapInfos;
        }
        public static bool LoadKey(string path = null)
        {
            Engine.APIKeyRaw = "0";
            string desired_path = path ?? Engine.FILE_APIKEY;
            if (!File.Exists(desired_path))
                return false;
            try
            {
                string text = File.ReadAllText(desired_path);
                Engine.APIKeyRaw = Engine.SanitizeKey(text);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error While Loading Key:\n'{0}'", e.Message);
            }
            return false;
        }
        public static string SanitizeKey(string text)
        {
            try
            {
                string clean = text.Replace("-", "").Trim();
                Assert.IsFalse(clean.ToCharArray().Any(c => !char.IsLetterOrDigit(c)), "Invalid Character");
                Assert.IsTrue(clean.Length == 32, "Invalid Length");
            }
            catch(Exception e)
            {
                text = null;
                throw e;
            }
            return text;
        }
        public static bool SaveKey(string key, string path = null)
        {
            try
            {
                key = API.Engine.SanitizeKey(key);
                Engine.APIKeyRaw = key;
                File.WriteAllText(path ?? Engine.FILE_APIKEY, key ?? "");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error While Saving Key:\n'{0}'", e.Message);
            }
            return false;
        }
        private static void UpdateLiveChampionInfo()
        {
            JsonPayload<List<LiveChampionInfo>> payload = new JsonPayload<List<LiveChampionInfo>>(Engine.LiveChampionDataURL, Engine.FILE_LIVECHAMPIONINFO, "champions");
            Engine.live_champion_info = payload.Get();
            foreach(string s in Engine.ChampionInfos.Keys)
            {
                Serialization.Champion.ChampionInfo current_champion_info = Engine.ChampionInfos[s];
                current_champion_info.LiveInfo = Engine.live_champion_info.FirstOrDefault(info => info.ID == current_champion_info.ID);
            }
            return;
        }
        #endregion
    }
}

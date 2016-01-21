using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RiotPls.API.Serialization;

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
        private const string FILE_ITEMINFO = "ItemInfo.json";
        private const string FILE_MAPINFO = "MapInfo.json";
        private const string PARAM_ALLITEMDATA = "itemListData=all";
        private const string PARAM_ALLCHAMPDATA = "champData=all";
        public const string IMGURL = "http://ddragon.leagueoflegends.com/cdn/5.1.1/img/";
        private const string STR_APIKEY = "api_key=";
        #endregion
        private static List<LiveChampionInfo> live_champion_info = new List<LiveChampionInfo>();
        private static string region_string = "na";
        private static string version_string = "v1.2";
        #endregion
        #region Static Properties
        private static string APIKey => Engine.STR_APIKEY + Engine.APIKeyRaw;
        public static string APIKeyRaw { get; private set;} = null;
        private static Dictionary<string, Serialization.Champion.Info> _ChampionInfos = new Dictionary<string, Serialization.Champion.Info>();
        public static Dictionary<string, Serialization.Champion.Info> ChampionInfos
        {
            get
            {
                return Engine._ChampionInfos;
            }
        }
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
                return Engine.BASE_URL + Engine.APIURL_LIVE + Engine.region_string + "/" + Engine.version_string + "/champion?" + Engine.APIKey;
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
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.version_string + "/champion?" + Engine.PARAM_ALLCHAMPDATA + "&" + Engine.APIKey;
            }
        }
        private static string StaticItemDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.version_string + "/item?" + Engine.PARAM_ALLITEMDATA + "&" + Engine.APIKey;
            }
        }
        private static string StaticMapDataURL
        {
            get
            {
                return Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.version_string + "/map?&" + Engine.APIKey;
            }
        }
        #endregion
        #region Static Methods
        public static string CleanseChampionName(Dictionary<string, Serialization.Champion.Info> info, string name)
        {
            KeyValuePair<string, Serialization.Champion.Info> pair = info.FirstOrDefault(i => i.Value.Name == name);
            return pair.Equals(default(KeyValuePair<string, Serialization.Champion.Info>)) ? null : pair.Key;
        }
        public static Dictionary<string, Serialization.Champion.Info> GetChampionInfo()
        {
            //
            bool attempt_download = !File.Exists(Engine.FILE_CHAMPIONINFO);
            string json_string = attempt_download ? Engine.GetChampionInfo_Download() : File.ReadAllText(Engine.FILE_CHAMPIONINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }    
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = Engine.GetChampionInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }  
            }
            if (!parsing_error)
            {                          
                if(attempt_download)
                    File.WriteAllText(Engine.FILE_CHAMPIONINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Engine._ChampionInfos = JsonConvert.DeserializeObject<Dictionary<string, Serialization.Champion.Info>>(result.ToString(), settings);
                //
                Engine.UpdateLiveChampionInfo();
            }
            //
            return Engine.ChampionInfos;
        }
        private static string GetChampionInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(Engine.StaticChampionDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
        }
        public static Dictionary<string, ItemInfo> GetItemInfo()
        {
            //
            bool attempt_download = !File.Exists(Engine.FILE_ITEMINFO);
            string json_string = attempt_download ? Engine.GetItemInfo_Download() : File.ReadAllText(Engine.FILE_ITEMINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = Engine.GetItemInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }
            }
            if (!parsing_error)
            {
                if (attempt_download)
                    File.WriteAllText(Engine.FILE_ITEMINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Engine._ItemInfos = JsonConvert.DeserializeObject<Dictionary<string, ItemInfo>>(result.ToString(), settings);
            }
            //
            return Engine.ItemInfos;
        }
        private static string GetItemInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(Engine.StaticItemDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
        }
        public static Dictionary<string, MapInfo> GetMapInfo()
        {
            //
            bool attempt_download = !File.Exists(Engine.FILE_MAPINFO);
            string json_string = attempt_download ? Engine.GetMapInfo_Download() : File.ReadAllText(Engine.FILE_MAPINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = Engine.GetMapInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }
            }
            if (!parsing_error)
            {
                if (attempt_download)
                    File.WriteAllText(Engine.FILE_MAPINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Engine._MapInfos = JsonConvert.DeserializeObject<Dictionary<string, MapInfo>>(result.ToString(), settings);
            }
            //
            return Engine.MapInfos;
        }
        private static string GetMapInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(Engine.StaticMapDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
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
            HttpWebRequest request = HttpWebRequest.Create(Engine.LiveChampionDataURL) as HttpWebRequest;
            StreamReader stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            JObject data = JObject.Parse(stream_reader.ReadToEnd());
            stream_reader.Close();
            //
            JToken result = data.SelectToken("champions");
            Engine.live_champion_info = JsonConvert.DeserializeObject<List<LiveChampionInfo>>(result.ToString());
            foreach(string s in Engine.ChampionInfos.Keys)
            {
                Serialization.Champion.Info current_info = Engine.ChampionInfos[s];
                current_info.LiveInfo = Engine.live_champion_info.FirstOrDefault(info => info.ID == current_info.ID);
            }
            return;
        }
        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;
using RiotPls.API.Serialization.Maps;
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
        private const string FILE_CHAMPIONINFO = "ChampionInfo.json";
        private const string FILE_LIVECHAMPIONINFO = "LiveChampionInfo.json";
        private const string FILE_ITEMINFO = "ItemInfo.json";
        private const string FILE_MAPINFO = "MapInfo.json";
        private const string PARAM_ALLITEMDATA = "itemListData=all";
        private const string PARAM_ALLCHAMPDATA = "champData=all";
        #endregion
        private static List<LiveChampionInfo> live_champion_info = new List<LiveChampionInfo>();
        private static string region_string = "na";
        #endregion
        #region Static Properties
        public static string APIVersion { get; set; } = "1.2";
        public static string APIVersionString => string.Format("v{0}", Engine.APIVersion);
        public static APIKey Key { get; private set; } = new APIKey("key.txt");
        private static Dictionary<string, ChampionInfo> _ChampionInfos = new Dictionary<string, ChampionInfo>();
        public static Dictionary<string, ChampionInfo> ChampionInfos
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
                return Engine.BASE_URL + Engine.APIURL_LIVE + Engine.region_string + "/" + Engine.APIVersionString + "/champion?" + Engine.Key.ToString();
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
        private static string StaticChampionDataURL =>
            Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/champion?" + Engine.PARAM_ALLCHAMPDATA + Engine.Key.ToString(true);

        private static string StaticItemDataURL =>
            Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/item?" + Engine.PARAM_ALLITEMDATA + Engine.Key.ToString(true);

        private static string StaticMapDataURL =>
            Engine.BASE_URL + Engine.APIURL_STATIC + Engine.region_string + "/" + Engine.APIVersionString + "/map?" + Engine.Key.ToString(true);

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
            Engine.Key.Load();
            return;
        }
        public static string CleanseChampionName(Dictionary<string, ChampionInfo> info, string name)
        {
            KeyValuePair<string, ChampionInfo> pair = info.FirstOrDefault(i => i.Value.Name == name);
            return pair.Equals(default(KeyValuePair<string, ChampionInfo>)) ? null : pair.Key;
        }
        public static ChampionInfo GetChampion(string name)
        {
            return Engine.ChampionInfos.ContainsKey(name) ? Engine.ChampionInfos[name] : null;
        }
        public static Dictionary<string, ChampionInfo> GetChampionInfo()
        {
            //
            JsonPayload<Dictionary<string, ChampionInfo>> payload = new JsonPayload<Dictionary<string, ChampionInfo>>(Engine.StaticChampionDataURL, Engine.FILE_CHAMPIONINFO, "data");
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
        private static void UpdateLiveChampionInfo()
        {
            JsonPayload<List<LiveChampionInfo>> payload = new JsonPayload<List<LiveChampionInfo>>(Engine.LiveChampionDataURL, Engine.FILE_LIVECHAMPIONINFO, "champions");
            Engine.live_champion_info = payload.Get();
            foreach(string s in Engine.ChampionInfos.Keys)
            {
                ChampionInfo current_champion_info = Engine.ChampionInfos[s];
                current_champion_info.LiveInfo = Engine.live_champion_info.FirstOrDefault(info => info.ID == current_champion_info.ID);
            }
            return;
        }
        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
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

        private static Dictionary<string, ItemInfo> _ItemInfos = new Dictionary<string, ItemInfo>();
        public static Dictionary<string, ItemInfo> ItemInfos
        {
            get
            {
                return Engine._ItemInfos;
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
                    default:
                    case Regions.NorthAmerica:
                        Engine.region_string = Engine.REGION_NA;
                        break;
                }
                return;
            }
        }

        #endregion
        #region Static Methods
        static Engine()
        {
            Engine.Key.Loaded += Engine.APIKey_Loaded;
            try
            {
                Engine.APIVersion = APISettings.APIVersion;
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
            ChampionInfoSet data = new ChampionInfoSet();
            Engine._ChampionInfos = data.Get();
            Engine.UpdateLiveChampionInfo();
            return Engine.ChampionInfos;
        }
        public static Dictionary<string, ItemInfo> GetItemInfo()
        {
            ItemInfoSet data = new ItemInfoSet();
            Engine._ItemInfos = data.Get();
            return Engine.ItemInfos;
        }
        public static Dictionary<string, MapInfo> GetMapInfo()
        {
            MapInfoSet data = new MapInfoSet();
            Engine._MapInfos = data.Get();
            return Engine.MapInfos;
        }
        private static void UpdateLiveChampionInfo()
        {
            LiveChampionInfoSet data = new LiveChampionInfoSet();
            Engine.live_champion_info = data.Get();
            foreach(string s in Engine.ChampionInfos.Keys)
            {
                ChampionInfo current_champion_info = Engine.ChampionInfos[s];
                current_champion_info.LiveInfo = Engine.live_champion_info.FirstOrDefault(info => info.ID == current_champion_info.ID);
            }
            return;
        }
        private static void UpdateRealmsInfo()
        {
            RealmInfoSet data = new RealmInfoSet();
            Resources.Resource.UpdateVersions(data.Get());
            return;
        }
        #endregion
        #region Static Event Methods
        private static void APIKey_Loaded(object sender, System.EventArgs e)
        {
            Engine.UpdateRealmsInfo();
            return;
        }
        #endregion
    }
}

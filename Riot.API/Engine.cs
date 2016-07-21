﻿using System.Collections.Generic;
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
        private static Dictionary<string, ChampionInfo> ChampionInfos { get; set; }
        private static Dictionary<string, ItemInfo> ItemInfos { get; set; } 
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
        public static ChampionInfo GetChampion(string name)
        {
            return Engine.ChampionInfos.FirstOrDefault(c => c.Value.Name == name).Value;
        }
        public static Dictionary<string, ChampionInfo> GetChampionInfo()
        {
            ChampionInfoSet data = new ChampionInfoSet();
            Engine.ChampionInfos = data.Get();
            Engine.UpdateLiveChampionInfo();
            return Engine.ChampionInfos;
        }

        public static ItemInfo GetItem(string name)
        {
            ItemInfo item = Engine.ItemInfos.Values.FirstOrDefault(i => i.Name == name);
            return item;
        }
        public static Dictionary<string, ItemInfo> GetItemInfo()
        {
            ItemInfoSet data = new ItemInfoSet();
            Engine.ItemInfos = data.Get();
            return Engine.ItemInfos;
        }

        public static List<ItemInfo> GetItemComponents(string name)
        {
            List<ItemInfo> components = new List<ItemInfo>();
            ItemInfo item = Engine.ItemInfos.Values.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                foreach (string component_id in item.ComponentIDs.Where(id => Engine.ItemInfos.ContainsKey(id)))
                {
                    ItemInfo item_component = Engine.ItemInfos[component_id];
                    if (item_component != null)
                        components.Add(item_component);
                }
            }
            return components;

        } 
        public static Dictionary<string, MapInfo> GetMapInfo()
        {
            MapInfoSet data = new MapInfoSet();
            return data.Get();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RiotPls.API.DataManagers;
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
        private static string region_string = "na";
        private static APIKey apiKey = new APIKey("key.txt");
        #endregion
        #region Static Properties
        public static string APIVersion { get; set; } = "1.2";
        public static string APIVersionString => string.Format("v{0}", Engine.APIVersion);
        public static ChampionDataManager Champions { get; private set; } = null;
        public static ItemDataManager Items { get; private set; } = null;
        public static MapDataManager Maps { get; private set; } = null;
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
            // try to load API key
            Engine.TryLoadKey();
            // update version info
            Engine.UpdateRealmsInfo();
            try
            {
                Engine.APIVersion = APISettings.APIVersion;
            }
            catch
            {
                // ignored
            }
            // load data
            Engine.Champions = new ChampionDataManager(Engine.apiKey);
            Engine.Items = new ItemDataManager(Engine.apiKey);
            Engine.Maps = new MapDataManager(Engine.apiKey);
            // handle key load event (in case key is updated later)
            Engine.apiKey.Loaded += Engine.APIKey_Loaded;
            return;
        }

        public static void Initialize()
        {
            // invoke static constructor    
        }

        private static void UpdateRealmsInfo()
        {
            try
            {
                bool remote_retrieval = false;
                RealmInfoSet data = new RealmInfoSet(Engine.apiKey);
                Resources.Resource.UpdateVersions(data.Get(out remote_retrieval));
            }
            catch (Exception e)
            {
                // TODO 08/16/16: handle exception - this should be fatal or produce an obvious warning
            }
            return;
        }

        public static void SetAPIKey(string text)
        {
            Engine.apiKey.Save(text);
            return;
        }

        public static string TryLoadKey()
        {
            API.Engine.apiKey.Load();
            return API.Engine.apiKey.ToString();
        }
        #endregion
        #region Static Event Methods
        private static void APIKey_Loaded(object sender, System.EventArgs e)
        {
            Engine.UpdateRealmsInfo();
            Engine.Champions.Update();
            Engine.Items.Update();
            Engine.Maps.Update();
            return;
        }
        #endregion
    }
}

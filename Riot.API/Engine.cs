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
        #region Static Members
        private static APIKey apiKey = new APIKey("key.txt");
        #endregion
        #region Static Properties
        /// <summary>
        /// All available champion information
        /// </summary>
        public static ChampionDataManager Champions { get; private set; } = null;
        /// <summary>
        /// All available item information
        /// </summary>
        public static ItemDataManager Items { get; private set; } = null;
        /// <summary>
        /// All available map information
        /// </summary>
        public static MapDataManager Maps { get; private set; } = null;
        #endregion
        #region Static Methods
        static Engine()
        {
            // load user settings
            APISettings.Load();
            // try to load API key
            Engine.TryLoadKey();
            // update version info
            Engine.UpdateRealmsInfo();
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
            // TODO 08/16/16: move static constructor code into this method?
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

using System;
using System.Collections.Generic;
using RiotPls.API.Serialization.Maps;

namespace RiotPls.API.DataManagers
{
    public class MapDataManager : DataManagerBase<MapInfo>
    {
        #region Instance Methods
        public MapDataManager(APIKey key) : base(key)
        {
        }
        #endregion
        #region Override Methods    
        /// <summary>
        /// Background worker data update implementation
        /// </summary>
        /// <returns>Data update result</returns>
        protected override Tuple<Dictionary<string, MapInfo>, States> DoWork()
        {
            Dictionary<string, MapInfo> map_infos = new Dictionary<string, MapInfo>();
            States state = States.Invalid;
            try
            {
                MapInfoSet maps = new MapInfoSet(this.apiKey);
                bool remote_retrieval = false;
                map_infos = maps.Get(out remote_retrieval);
                state = remote_retrieval ? States.Live : States.Cached;
            }
            catch (Exception e)
            {
                state = States.Invalid;
            }
            // maps
            return new Tuple< Dictionary<string, MapInfo>, States > (map_infos, state);
        }
        #endregion
    }
}

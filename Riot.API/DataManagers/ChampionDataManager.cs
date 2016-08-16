using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Champions;

namespace RiotPls.API.DataManagers
{
    public class ChampionDataManager : DataManagerBase<ChampionInfo>
    {
        #region Instance Members  
        #endregion
        #region Instance Methods
        public ChampionDataManager(APIKey key) : base(key)
        {
        }

        private void UpdateLiveChampionInfo(Dictionary<string, ChampionInfo> champions)
        {
            List<LiveChampionInfo> live_infos = new List<LiveChampionInfo>();
            LiveChampionInfoSet data = new LiveChampionInfoSet(this.apiKey);
            bool remote_retrieval = false;
            live_infos = data.Get(out remote_retrieval);
            // TODO 08/16/16: do we care about remote retrieval status here?
            foreach (string s in champions.Keys)
            {
                ChampionInfo champion_info = champions[s];
                champion_info.LiveInfo = live_infos.FirstOrDefault(info => info.ID == champion_info.ID);
            }
            return;
        }
        #endregion
        #region Override Methods          
        /// <summary>
        /// Background worker data update implementation
        /// </summary>
        /// <returns>Data update result</returns>
        protected override Tuple<Dictionary<string, ChampionInfo>, States> DoWork()
        {
            Dictionary<string, ChampionInfo> champion_infos = new Dictionary<string, ChampionInfo>();
            States state = States.Invalid;
            try
            {
                ChampionInfoSet champions = new ChampionInfoSet(this.apiKey);
                bool remote_retrieval = false;
                champion_infos = champions.Get(out remote_retrieval);
                this.UpdateLiveChampionInfo(champion_infos);
                state = remote_retrieval ? States.Live : States.Cached;
            }
            catch (Exception ex)
            {
                state = States.Invalid;
            }
            return new Tuple<Dictionary<string, ChampionInfo>, States>(champion_infos, state);
        }
        #endregion
    }
}

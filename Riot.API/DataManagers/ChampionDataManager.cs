using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Champions;

namespace RiotPls.API.DataManagers
{
    public class ChampionDataManager : DataManagerBase<ChampionInfo>
    {
        private List<LiveChampionInfo> liveChampionInfos = new List<LiveChampionInfo>();
        public ChampionDataManager(APIKey key) : base(key)
        {
        }
        public override void Update()
        {
            // champions
            ChampionInfoSet champions = new ChampionInfoSet(this.apiKey);
            this.infos = champions.Get();
            this.UpdateLiveChampionInfo();
            return;
        }
        private void UpdateLiveChampionInfo()
        {
            LiveChampionInfoSet data = new LiveChampionInfoSet(this.apiKey);
            this.liveChampionInfos = data.Get();
            foreach (string s in this.infos.Keys)
            {
                ChampionInfo current_champion_info = this.infos[s];
                current_champion_info.LiveInfo = this.liveChampionInfos.FirstOrDefault(info => info.ID == current_champion_info.ID);
            }
            return;
        }
    }
}

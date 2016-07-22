using RiotPls.API.Serialization.Maps;

namespace RiotPls.API.DataManagers
{
    public class MapDataManager : DataManagerBase<MapInfo>
    {
        public MapDataManager(APIKey key) : base(key)
        {
        }

        public override void Update()
        {
            // champions
            MapInfoSet items = new MapInfoSet(this.apiKey);
            this.infos = items.Get();
            return;
        }

    }
}

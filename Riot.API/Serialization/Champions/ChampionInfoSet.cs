using System.Collections.Generic;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Champions
{
    internal class ChampionInfoSet : RiotSerializable<Dictionary<string, ChampionInfo>>
    {
        public override string LocalFileName => "ChampionInfo.json";
        public override string RootToken => "data";
        public override RiotURL URL => new RiotURL(this.apiKey, true, "champion?champData=all");

        public ChampionInfoSet(APIKey key) : base(key)
        {
        }
    }
}

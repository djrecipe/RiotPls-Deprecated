using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Champions
{
    class ChampionInfoSet : RiotSerializable<Dictionary<string, ChampionInfo>>
    {
        public override string LocalFileName => "ChampionInfo.json";
        public override string RootToken => "data";
        public override RiotURL URL => new RiotURL(true, "champion?champData=all");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Maps
{
    class MapInfoSet : RiotSerializable<Dictionary<string, MapInfo>>
    {
        public override string LocalFileName => "MapInfo.json";
        public override string RootToken => "data";
        public override RiotURL URL => new RiotURL(true, "map?");
    }
}

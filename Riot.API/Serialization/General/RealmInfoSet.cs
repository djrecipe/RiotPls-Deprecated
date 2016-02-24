using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    class RealmInfoSet : RiotSerializable<RealmInfo>
    {
        public override string LocalFileName => "RealmInfo.json";
        public override string RootToken => null;
        public override RiotURL URL => new RiotURL(true, "realm?");
    }
}

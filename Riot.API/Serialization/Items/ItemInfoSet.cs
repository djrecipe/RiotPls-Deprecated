using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Items
{
    class ItemInfoSet : RiotSerializable<Dictionary<string, ItemInfo>>
    {
        public override string LocalFileName => "ItemInfo.json";
        public override string RootToken => "data";
        public override RiotURL URL => new RiotURL(this.apiKey, true, "item?itemListData=all");

        public ItemInfoSet(APIKey key) : base(key)
        {
        }
    }
}

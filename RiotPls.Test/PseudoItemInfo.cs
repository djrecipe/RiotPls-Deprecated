using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Test
{
    public class PseudoItemInfo : ItemInfo
    {
        public PseudoItemInfo(string Name)
        {
            this.Name = Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Champions;

namespace RiotPls.Test
{
    public class PseudoChampionInfo : ChampionInfo
    {
        public PseudoChampionInfo(string Name)
        {
            this.Name = Name;
        }
    }
}

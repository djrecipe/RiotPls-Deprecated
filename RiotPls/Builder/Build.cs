using System.Collections.Generic;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Builder
{
    public class Build
    {
        private List<ItemInfo> items = new List<ItemInfo>();
        public ChampionInfo Champion
        {
            get;
            set;
        }
        public int Index
        {
            get;
            private set;
        }
        public Build(int index)
        {
            this.Index = index;
        }
        public void AddItem(ItemInfo item)
        {
            if (!this.items.Contains(item))
                this.items.Add(item);
            return;
        }
        public void RemoveItem(ItemInfo item)
        {
            if (this.items.Contains(item))
                this.items.Remove(item);
            return;
        }
    }
}

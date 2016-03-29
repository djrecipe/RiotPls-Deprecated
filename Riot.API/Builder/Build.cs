using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Items;

namespace RiotPls.API.Builder
{
    public class Build
    {
        public delegate void BuildChangedDelegate(int index);
        public static BuildChangedDelegate BuildChanged;
        private static List<Build> builds = new List<Build>(); 

        public static Build GetBuild(int index)
        {
            Build build = Build.builds.FirstOrDefault(b => b.Index == index);
            if (build == null)
            {
                build = new Build(index);
                Build.builds.Add(build);
            }
            return build;
        }

        public static void RemoveBuild(int index)
        {
            Build build = Build.builds.FirstOrDefault(b => b.Index == index);
            if (build != null)
                Build.builds.Remove(build);
            return;
        }

        private ItemInfo[] items = new ItemInfo[6];
        private ChampionInfo champion = new ChampionInfo();
        private GeneralStatsInfo stats = new GeneralStatsInfo();
        public int Index
        {
            get;
            private set;
        }
        private Build(int index)
        {
            this.Index = index;
        }

        private void FireUpdate(int index)
        {
            this.stats = new GeneralStatsInfo();
            this.stats += this.champion.Stats;
            foreach (ItemInfo item in this.items.Where(i => i != null))
            {
                this.stats += item.Stats;
            }
            if (Build.BuildChanged != null)
                Build.BuildChanged(index);
            return;
        }

        public ChampionInfo GetChampion()
        {
            return this.champion;
        }

        public int GetItemIndex(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Item name must be valid", "name");
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i]?.Name == name)
                    return i;
            }
            return -1;
        }

        public ItemInfo GetItem(int index)
        {
            return index >= 0 && index < this.items.Length ? this.items[index] : null;
        }

        public List<ItemInfo> GetItems()
        {
            return this.items.ToList();
        }

        public void SetChampion(ChampionInfo champion_in)
        {
            if(champion == null)
                throw new ArgumentNullException("Champion cannot be null", "champion");
            if (this.champion != champion_in)
            {
                this.champion = champion_in;
                this.FireUpdate(this.Index);
            }
            return;
        }

        public void SetItem(int index, ItemInfo item)
        {
            if(index < 0 || index >=6)
                throw new ArgumentOutOfRangeException("Item index must be 0 or greater and less than six", "index");
            this.items[index] = item;
            this.FireUpdate(this.Index);
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Builder
{
    public class Build
    {
        public delegate void BuildChangedDelegate(int index);
        public static BuildChangedDelegate BuildChanged;
        private static List<Build> builds = new List<Build>(); 
        private static void FireUpdate(int index)
        {
            if (Build.BuildChanged != null)
                Build.BuildChanged(index);
            return;
        }

        public static Build GetBuild(int index)
        {
            return Build.builds.FirstOrDefault(b => b.Index == index) ?? new Build(index);
        }

        public static void RemoveBuild(int index)
        {
            Build build = Build.builds.FirstOrDefault(b => b.Index == index);
            if (build != null)
                Build.builds.Remove(build);
            return;
        }

        private List<ItemInfo> items = new List<ItemInfo>();
        private ChampionInfo champion = new ChampionInfo();
        public int Index
        {
            get;
            private set;
        }
        private Build(int index)
        {
            this.Index = index;
        }
        public void AddItem(ItemInfo item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                Build.FireUpdate(this.Index);
            }
            return;
        }

        public ChampionInfo GetChampion()
        {
            return this.champion;
        }

        public ItemInfo GetItem(string name)
        {
            return this.items.FirstOrDefault(i => i.Name == name);
        }

        public void RemoveItem(ItemInfo item)
        {
            if (this.items.Contains(item))
            {
                this.items.Remove(item);
                Build.FireUpdate(this.Index);
            }
            return;
        }

        public void SetChampion(ChampionInfo champion_in)
        {
            if(champion == null)
                throw new ArgumentNullException("Champion cannot be null", "champion");
            if (this.champion != champion_in)
            {
                this.champion = champion_in;
                Build.FireUpdate(this.Index);
            }
            return;
        }
    }
}

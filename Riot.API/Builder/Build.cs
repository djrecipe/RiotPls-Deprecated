using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Items;
using RiotPls.Tools;

namespace RiotPls.API.Builder
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Build
    {
        #region Types
        public delegate void BuildChangedDelegate(int index);
        #endregion
        #region Static Members
        public static BuildChangedDelegate BuildChanged;
        private static List<Build> builds = new List<Build>();
        #endregion
        #region Static Properties
        #endregion
        #region Static Methods
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
        #endregion
        #region Instance Members
        private GeneralStatsInfo stats = new GeneralStatsInfo();
        #endregion
        #region Instance Properties  
        [JsonProperty("Champion")]
        public ChampionInfo Champion { get; private set; }    
        [JsonProperty("Index")]
        public int Index
        {
            get;
            private set;
        }
        [JsonProperty("Items")]
        private ItemInfo[] Items { get; set; } = new ItemInfo[6];
        public StatsTable Table => this.stats.Table;
        #endregion
        #region Instance Methods
        [JsonConstructor]
        private Build()
        {
            
        }
        private Build(int index)
        {
            this.Index = index;
        }

        private void FireUpdate(int index)
        {
            this.stats = new GeneralStatsInfo();
            this.stats += this.Champion.Stats;
            foreach (ItemInfo item in this.Items.Where(i => i != null))
            {
                this.stats += item.Stats;
            }
            if (Build.BuildChanged != null)
                Build.BuildChanged(index);
            return;
        }
        public int GetItemIndex(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Item name must be valid", "name");
            for (int i = 0; i < this.Items.Length; i++)
            {
                if (this.Items[i]?.Name == name)
                    return i;
            }
            return -1;
        }

        public ItemInfo GetItem(int index)
        {
            return index >= 0 && index < this.Items.Length ? this.Items[index] : null;
        }

        public List<ItemInfo> GetItems()
        {
            return this.Items.ToList();
        }

        public void Save(string path)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Reuse,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                string text = JsonConvert.SerializeObject(this, settings);
                File.WriteAllText(path, text);
            }
            catch (Exception e)
            {
            }
            return;
        }

        public void SetChampion(ChampionInfo champion_in)
        {
            if (this.Champion != champion_in)
            {
                this.Champion = champion_in;
                this.FireUpdate(this.Index);
            }
            return;
        }

        public void SetItem(int index, ItemInfo item)
        {
            if(index < 0 || index >=6)
                throw new ArgumentOutOfRangeException("Item index must be 0 or greater and less than six", "index");
            this.Items[index] = item;
            this.FireUpdate(this.Index);
            return;
        }
        #endregion
    }
}

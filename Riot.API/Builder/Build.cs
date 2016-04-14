using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Items;

namespace RiotPls.API.Builder
{
    /// <summary>
    /// Serializable collection of entities which describe an in-game build
    /// </summary>
    /// <remarks>Instantiation is accomplished via the <see cref="BuildManager"/> class</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class Build
    {
        #region Types
        public delegate void BuildChangedDelegate(string name);
        #endregion
        #region Instance Members
        private CombinedStatsInfo stats = new CombinedStatsInfo();
        public BuildChangedDelegate BuildChanged;
        #endregion
        #region Instance Properties  
        [JsonProperty("Champion")]
        public ChampionInfo Champion { get; private set; }    
        [JsonProperty("Items")]
        private ItemInfo[] Items { get; set; } = new ItemInfo[6];
        [JsonProperty("Name")]
        public string Name { get; set; } = null; 
        public StatsTable Table => this.stats.Table;
        #endregion
        #region Instance Methods
        [JsonConstructor]
        private Build()
        {
            
        }
        internal Build(string name)
        {
            this.Name = name;
            return;
        }
        private void FireUpdate(string name)
        {
            this.stats = new CombinedStatsInfo();
            if(this.Champion != null)
                this.stats += this.Champion.Stats;
            foreach (ItemInfo item in this.Items.Where(i => i != null))
            {
                this.stats += item.Stats;
            }
            if (this.BuildChanged != null)
                this.BuildChanged(name);
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
                this.FireUpdate(this.Name);
            }
            return;
        }

        public void SetItem(int index, ItemInfo item)
        {
            if(index < 0 || index >=6)
                throw new ArgumentOutOfRangeException("Item index must be 0 or greater and less than six", "index");
            this.Items[index] = item;
            this.FireUpdate(this.Name);
            return;
        }
        #endregion
    }
}

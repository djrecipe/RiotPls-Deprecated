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
        public delegate void SelectedRowChangedDelegate(int row);
        #endregion
        #region Instance Members
        private CombinedStatsInfo stats = new CombinedStatsInfo();
        /// <summary>
        /// Notifies when build details change (i.e. champion or item changes)
        /// </summary>
        public event BuildChangedDelegate BuildChanged;
        /// <summary>
        /// Notifies when the SelectRow property value changes
        /// </summary>
        public event SelectedRowChangedDelegate SelectedRowChanged;
        #endregion
        #region Instance Properties  
        /// <summary>
        /// Champion associated with this build
        /// </summary>
        [JsonProperty("Champion")]
        public ChampionInfo Champion { get; private set; } 
        /// <summary>
        /// Six items associated with this build
        /// </summary>
        [JsonProperty("Items")]
        private ItemInfo[] Items { get; set; } = new ItemInfo[6];
        /// <summary>
        /// Build name
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; } = null;
        private int _SelectedRow = 0; 
        /// <summary>
        /// Currently selected row in the stats table
        /// </summary>
        public int SelectedRow
        {
            get { return this._SelectedRow; }
            set
            {
                if (this.SelectedRow != value)
                {
                    this._SelectedRow = value;
                    if (this.SelectedRowChanged != null)
                        this.SelectedRowChanged(value);
                }
            }
        }
        /// <summary>
        /// Table of combined champion & item stats from champion levels 1 to 18
        /// </summary>
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
        /// <summary>
        /// Find and retrieve the item index of a given item name
        /// </summary>
        /// <param name="name">Name of the item to search for</param>
        /// <returns>Index of item in the build, or -1 if the item is not a part of this build</returns>
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
        /// <summary>
        /// Retrieve the item at a specified index
        /// </summary>
        /// <param name="index">Item index to check</param>
        /// <returns>Item at the specified index, if any</returns>
        public ItemInfo GetItem(int index)
        {
            return index >= 0 && index < this.Items.Length ? this.Items[index] : null;
        }
        /// <summary>
        /// Assign a champion to this build
        /// </summary>
        /// <param name="champion_in">Champion to assign to this build</param>
        public void SetChampion(ChampionInfo champion_in)
        {
            if (this.Champion != champion_in)
            {
                this.Champion = champion_in;
                this.FireUpdate(this.Name);
            }
            return;
        }
        /// <summary>
        /// Assign an item to this build
        /// </summary>
        /// <param name="index">Index at which the item will be assigned (0-5)</param>
        /// <param name="item">Item to assign at the specified index</param>
        public void SetItem(int index, ItemInfo item)
        {
            if (index < 0 || index >= 6)
                throw new ArgumentOutOfRangeException("Item index must be 0 or greater and less than six", "index");
            this.Items[index] = item;
            this.FireUpdate(this.Name);
            return;
        }
        /// <summary>
        /// Assign a level to the item at the specified index
        /// </summary>
        /// <remarks>The item's stats will only be applied to stat rows at or above the specified level</remarks>
        /// <param name="index">Index of the item to be affected</param>
        /// <param name="level">Desired level (1-18)</param>
        public void SetItemLevel(int index, int level)
        {
            if (index < 0 || index >= 6)
                throw new ArgumentOutOfRangeException("Item index must be 0 or greater and less than six", "index");
            if (this.Items[index] == null)
                return;
            this.Items[index].LevelObtained = level;
            this.FireUpdate(this.Name);
            return;
        }
        #endregion
    }
}

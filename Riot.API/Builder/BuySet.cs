using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Items;

namespace RiotPls.API.Builder
{
    /// <summary>
    /// Serializable collection of entities which describe a shop purchase
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BuySet
    {
        #region Instance Properties
        /// <summary>
        /// Items associated with the buy
        /// </summary>             
        [JsonProperty("Items", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private List<ItemInfo> Items { get; set; } = new List<ItemInfo>();
        /// <summary>
        /// Name associated with the buy
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Total cost of all items in the set
        /// </summary>
        public int TotalCost => this.Items.Select(i => i.Cost).Sum();
        #endregion
        #region Instance Methods
        /// <summary>
        /// Add an item to the buy set
        /// </summary>
        /// <param name="item">Item to add</param>
        public void AddItem(ItemInfo item)
        {
            if (!this.ContainsItem(item))
                this.Items.Add(item);
            return;
        }

        /// <summary>
        /// Indicates whether the buy set contains a specific item
        /// </summary>
        /// <param name="item">Item to check for</param>
        /// <returns>True if the item is already in the buy set, false otherwise</returns>
        public bool ContainsItem(ItemInfo item)
        {
            return this.Items.Contains(item);
        }
        /// <summary>
        /// Remove an item from the buy set
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void RemoveItem(ItemInfo item)
        {
            if (this.ContainsItem(item))
                this.Items.Remove(item);
            return;
        }
        /// <summary>
        /// Remove an item from the buy set
        /// </summary>
        /// <param name="index">Index of the item to remove</param>
        public void RemoveItemAt(int index)
        {
            if(index > -1 && index < this.Items.Count)
                this.Items.RemoveAt(index);
            return;
        }
        #endregion
    }

}

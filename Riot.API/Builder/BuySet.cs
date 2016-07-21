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
        #region Types
        public delegate void BuySetDelegate(BuySet set);
        #endregion
        #region Instance Members
        #region Events
        public event BuySetDelegate Changed;
        #endregion
        #endregion
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
            if (item == null)
                throw new ArgumentNullException("item", "You must provide a valid ItemInfo");
            this.Items.Add(item);
            item.PricingStyleChanged += this.ItemInfo_PricingStyleChanged;
            if (this.Changed != null)
                this.Changed(this);
            return;
        }

        /// <summary>
        /// Indicates whether the buy set contains a specific item
        /// </summary>
        /// <param name="item">Item to check for</param>
        /// <returns>True if the item is already in the buy set, false otherwise</returns>
        public bool ContainsItem(ItemInfo item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "You must provide a valid ItemInfo");
            return this.Items.Contains(item);
        }
        /// <summary>
        /// Retrieve an item from the buy set
        /// </summary>
        /// <param name="index">Index of the item to retrieve</param>
        /// <returns>Item at the specified index, if any</returns>
        public ItemInfo GetItemAt(int index)
        {
            if (index > -1 && index < this.Items.Count)
            {
                return this.Items[index];
            }
            return null;
        }
        /// <summary>
        /// Remove an item from the buy set
        /// </summary>
        /// <param name="index">Index of the item to remove</param>
        public void RemoveItemAt(int index)
        {
            if (index > -1 && index < this.Items.Count)
            {
                this.Items.RemoveAt(index);
                if (this.Changed != null)
                    this.Changed(this);
            }
            return;
        }
        #endregion
        #region Instance Events
        private void ItemInfo_PricingStyleChanged(ItemInfo item, ItemInfo.PricingStyles pricing_style)
        {
            if (this.Changed != null)
                this.Changed(this);
        }
        #endregion
    }

}

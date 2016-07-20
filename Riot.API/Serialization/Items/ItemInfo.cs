using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Attributes;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Items
{
    /// <summary>
    /// Full item description, metadata, stats, etc.
    /// </summary>
    /// <remarks>Serializable to/from JSON</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemInfo : IRiotDroppable
    {
        #region Types
        /// <summary>
        /// Techniques for deriving item cost
        /// </summary>
        public enum PricingStyles : uint
        {
            /// <summary>
            /// Full item price, including price of components
            /// </summary>
            Full = 0,
            /// <summary>
            /// Item upgrade price, not including price of components
            /// </summary>
            Upgrade = 1
        }
        #endregion
        #region Static Members
        private static readonly List<ItemInfo> consumables = new List<ItemInfo>();
        private static readonly List<ItemInfo> nonConsumables = new List<ItemInfo>();
        #endregion
        #region Static Methods
        private static void RemoveReference(ItemInfo info)
        {
            if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                consumables.Remove(info);
            if (nonConsumables.FirstOrDefault(x => x.Name == info.Name) != null)
                nonConsumables.Remove(info);
            return;
        }
        private static void UpdateConsumableStatus(ItemInfo info)
        {
            if (info.Consumable)
            {
                if (nonConsumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    nonConsumables.Remove(info);
                if (consumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    consumables.Add(info);
            }
            else
            {
                if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    consumables.Remove(info);
                if (nonConsumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    nonConsumables.Add(info);
            }
            return;
        }
        #endregion
        #region Instance Members
        private ItemStatsInfo descriptionStats = new ItemStatsInfo();
        #endregion
        #region Instance Properties
        /// <summary>
        /// Informal name
        /// </summary>
        [JsonProperty("colloq")]
        public string ColloquialName { get; private set; }
        private bool _Consumable = false;
        /// <summary>
        /// Item is consumed on use
        /// </summary>
        [JsonProperty("consumed")]
        public bool Consumable
        {
            get
            {
                return this._Consumable;
            }
            set
            {
                this._Consumable = value;
                ItemInfo.UpdateConsumableStatus(this);
                return;
            }
        }
        /// <summary>
        /// Cost of the item using in-game gold
        /// </summary>
        /// <remarks>Influenced by PricingStyle</remarks>
        public int Cost => this.PricingStyle == PricingStyles.Full ? this.CostInfo.TotalCost : this.CostInfo.UpgradeCost;
        /// <summary>
        /// Information regarding cost and purchasing of the item
        /// </summary>                            
        [JsonProperty("gold", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ItemCost CostInfo { get; private set; }
        /// <summary>
        /// Item description, not including markdown/formatting characters
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public string Description { get; private set; } = null;
        private string _FullDescription = null;
        /// <summary>
        /// Full item description, including markdown/formatting characters
        /// </summary>
        [JsonProperty("description")]
        public string FullDescription
        {
            get { return this._FullDescription; }
            internal set
            {
                this._FullDescription = value;
                this.RemoveDescriptionStats();
                this.ParseDescription(this.FullDescription);
                this.AddDescriptionStats();
            }
        }
        /// <summary>
        /// Item is disabled/hidden
        /// </summary>
        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; private set; } = false;
        /// <summary>
        /// Unique item identifier
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; private set; }
        /// <summary>
        /// Item image
        /// </summary>
        public Bitmap Image => this.ImageData?.Image;
        /// <summary>
        /// Image data
        /// </summary>
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData { get; private set; } = null;
        /// <summary>
        /// Item is purchasable from the in-game store
        /// </summary>
        [JsonProperty("inStore")]
        public bool IsInStore { get; private set; } = false;
        /// <summary>
        /// Level at which item stats are taken into account
        /// </summary>
        public int LevelObtained
        {
            get { return this.Stats.RequiredLevel; }
            set { this.Stats.RequiredLevel = value; }
        }
        /// <summary>
        /// Maps which the item is available on
        /// </summary>
        [JsonProperty("maps", ItemIsReference = true)]
        public Dictionary<string, bool> Maps { get; private set; } = new Dictionary<string, bool>();
        /// <summary>
        /// Item name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; protected set; } = null;
        /// <summary>
        /// Pricing style for the item
        /// </summary>
        /// <remarks>Determines whether item componenets are included in the price</remarks>
        [JsonProperty("pricingstyle")]
        public PricingStyles PricingStyle { get; set; } = PricingStyles.Upgrade;
        /// <summary>
        /// Champion required in order to use the item
        /// </summary>
        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; private set; } = null;
        private ItemStatsInfo _Stats = new ItemStatsInfo();
        /// <summary>
        /// Collection of stats which describe the item's combat effectiveness and impact on the game
        /// </summary>
        [JsonProperty("stats", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Order = 0)]
        public ItemStatsInfo Stats
        {   // must be deserialized first, since deserialization does not invoke this setter
            get { return this._Stats; }
            private set
            {
                this._Stats = value;
                this.AddDescriptionStats();
            }
        }
        #endregion
        #region Instance Methods
        /// <summary>
        /// This class cannot be directly instantiated
        /// </summary>
        protected ItemInfo()
        {
            ItemInfo.UpdateConsumableStatus(this);
            return;
        }
        ~ItemInfo()
        {
            ItemInfo.RemoveReference(this);
        }
        private void AddDescriptionStats()
        {
            List<PropertyInfo> properties = this.Stats.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(Statistic))).ToList();
            foreach (PropertyInfo property in properties)
            {
                Statistic statistic = property.GetCustomAttribute(typeof (Statistic)) as Statistic;
                if (!statistic.IsFromDescription)
                    continue;
                double old_value = (double)property.GetValue(this.Stats);
                double add_value = (double)property.GetValue(this.descriptionStats);
                this.Stats.SetValue(statistic.Name, old_value + add_value);
            }
            return;
        }
        /// <summary>
        /// Performs a deep clone via JSON serialization
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string text = JsonConvert.SerializeObject(this, settings);
            ItemInfo item = JsonConvert.DeserializeObject<ItemInfo>(text, settings);
            return item;
        }
        private ItemStatsInfo ParseDescription(string description)
        {
            this.descriptionStats = ItemDescriptionParser.Parse(description);
            return this.descriptionStats;
        }
        private void RemoveDescriptionStats()
        {
            List<PropertyInfo> properties = this.Stats.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(Statistic))).ToList();
            foreach (PropertyInfo property in properties)
            {
                Statistic statistic = property.GetCustomAttribute(typeof(Statistic)) as Statistic;
                if (!statistic.IsFromDescription)
                    continue;
                double old_value = (double)property.GetValue(this.Stats);
                double sub_value = (double)property.GetValue(this.descriptionStats);
                this.Stats.SetValue(statistic.Name, old_value - sub_value);
            }
            return;
        }
        #endregion
    }
}

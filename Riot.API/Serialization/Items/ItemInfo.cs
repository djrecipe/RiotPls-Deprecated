using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Attributes;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Items
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemInfo : IRiotDroppable
    {
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
        [JsonProperty("colloq")]
        public string ColloquialName { get; private set; }
        private bool _Consumable = false;
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
        [JsonProperty("sanitizedDescription")]
        public string Description { get; private set; } = null;
        private string _FullDescription = null;
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
        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; private set; } = false;
        [JsonProperty("id")]
        public int ID { get; private set; }
        public Bitmap Image => this.ImageData?.Image;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData { get; private set; } = null;
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
        [JsonProperty("maps", ItemIsReference = true)]
        public Dictionary<string, bool> Maps { get; private set; } = new Dictionary<string, bool>();
        [JsonProperty("name")]
        public string Name { get; protected set; } = null;
        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; private set; } = null;
        private ItemStatsInfo _Stats = new ItemStatsInfo();
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

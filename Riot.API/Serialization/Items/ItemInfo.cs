using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Items
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemInfo : IRiotDroppable
    {
        private static List<ItemInfo> consumables = new List<ItemInfo>();
        private static List<ItemInfo> non_consumables = new List<ItemInfo>();
        private static void RemoveReference(ItemInfo info)
        {
            if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                consumables.Remove(info);
            if (non_consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                non_consumables.Remove(info);
            return;
        }
        private static void UpdateConsumableStatus(ItemInfo info)
        {
            if (info.Consumable)
            {
                if (non_consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    non_consumables.Remove(info);
                if (consumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    consumables.Add(info);
            }
            else
            {
                if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    consumables.Remove(info);
                if (non_consumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    non_consumables.Add(info);
            }
            return;
        }
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
        public DataType Type => DataType.Item;
        [JsonProperty("sanitizedDescription")]
        public string Description { get; private set; } = null;
        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; private set; } = false;
        [JsonProperty("id")]
        public int ID { get; private set; }
        public Bitmap Image => this.ImageData?.Image;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData { get; private set; } = null;
        [JsonProperty("inStore")]
        public bool IsInStore { get; private set; } = false;
        [JsonProperty("maps", ItemIsReference = true)]
        public Dictionary<string, bool> Maps { get; private set; } = new Dictionary<string, bool>();
        [JsonProperty("name")]
        public string Name { get; private set; } = null;
        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; private set; } = null;
        [JsonProperty("stats", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ItemStatsInfo Stats { get; private set; } = new ItemStatsInfo();
        public ItemInfo()
        {
            ItemInfo.UpdateConsumableStatus(this);
            return;
        }
        ~ItemInfo()
        {
            ItemInfo.RemoveReference(this);
        }
    }
}

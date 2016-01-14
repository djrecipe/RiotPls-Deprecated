using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemInfo
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
        private string _ColloquialName = null;
        [JsonProperty("colloq")]
        public string ColloquialName
        {
            get
            {
                return this._ColloquialName;
            }
            private set
            {
                this._ColloquialName = value;
                return;
            }
        }
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
        private string _Description = null;
        [JsonProperty("sanitizedDescription")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            private set
            {
                this._Description = value;
                return;
            }
        }
        private bool _HideFromAll = false;
        [JsonProperty("hideFromAll")]
        public bool HideFromAll
        {
            get
            {
                return this._HideFromAll;
            }
            private set
            {
                this._HideFromAll = value;
                return;
            }
        }
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
                return;
            }
        }
        public Bitmap Image
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private bool _IsInStore = false;
        [JsonProperty("inStore")]
        public bool IsInStore
        {
            get
            {
                return this._IsInStore;
            }
            private set
            {
                this._IsInStore = value;
                return;
            }
        }
        private Dictionary<string, bool> _Maps = new Dictionary<string, bool>();
        [JsonProperty("maps", ItemIsReference = true)]
        public Dictionary<string, bool> Maps
        {
            get
            {
                return this._Maps;
            }
            private set
            {
                this._Maps = value;
                return;
            }
        }
        private string _Name = null;
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
                return;
            }
        }
        private string _RequiredChampion = null;
        [JsonProperty("requiredChampion")]
        public string RequiredChampion
        {
            get
            {
                return this._RequiredChampion;
            }
            private set
            {
                this._RequiredChampion = value;
                return;
            }
        }
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

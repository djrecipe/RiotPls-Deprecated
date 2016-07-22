using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Maps
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MapInfo : INameable
    {
        private long _ID = -1;
        [JsonProperty("mapId")]
        public long ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
                return;
            }
        }
        public Bitmap Image
        {
            get
            {
                switch (this.Name)
                {
                    case "Howling Abyss":
                        return Properties.Resources.HowlingAbyss;
                    case "Summoner's Rift":
                        return Properties.Resources.SummonersRift;
                    case "Twisted Treeline":
                        return Properties.Resources.TwistedTreeline;
                    default:
                        break;
                }
                return null;

            }
        }
        public Bitmap InternalImage
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
        private string _InternalName = null;
        [JsonProperty("mapName")]
        public string InternalName
        {
            get
            {
                return this._InternalName;
            }
            private set
            {
                this._InternalName = value;
                switch (this.InternalName)
                {
                    case "NewTwistedTreeline":
                        this.Name = "Twisted Treeline";
                        break;
                    case "SummonersRift":
                        this.Name = "Old Summoner's Rift";
                        break;
                    case "SummonersRiftNew":
                        this.Name = "Summoner's Rift";
                        break;
                    case "ProvingGroundsNew":
                        this.Name = "Howling Abyss";
                        break;
                    default:
                        this.Name = "Unknown";
                        break;
                }
                return;
            }
        }
        private string _Name = null;
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
        private List<long> _ProhibitedItems = new List<long>();
        [JsonProperty("unpurchasableItemList")]
        public List<long> ProhibitedItems
        {
            get
            {
                return new List<long>(this._ProhibitedItems);
            }
            private set
            {
                this._ProhibitedItems = value;
                return;
            }
        }
    }
}

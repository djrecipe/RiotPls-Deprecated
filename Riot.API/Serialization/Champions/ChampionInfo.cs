using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Champions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionInfo
    {
        public Bitmap AttackBitmap => this.RatingInfo.AttackBitmap;
        public Bitmap DefenseBitmap => this.RatingInfo.DefenseBitmap;
        public Bitmap DifficultyBitmap => this.RatingInfo.DifficultyBitmap;
        public bool FreeToPlay => this.LiveInfo.FreeToPlay;
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
            }
        }
        public Bitmap Image => this.ImageData?.Image;
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
        private LiveChampionInfo _LiveInfo = null;
        public LiveChampionInfo LiveInfo
        {
            get
            {
                return this._LiveInfo;
            }
            set
            {
                this._LiveInfo = value;
            }
        }
        private string _Lore = null;
        [JsonProperty("lore")]
        public string Lore
        {
            get
            {
                return this._Lore;
            }
            private set
            {
                this._Lore = value;
            }
        }
        private string _LoreSummary = null;
        [JsonProperty("blurb")]
        public string LoreSummary
        {
            get
            {
                return this._LoreSummary;
            }
            private set
            {
                this._LoreSummary = value;
            }
        }
        public Bitmap MagicBitmap
        {
            get
            {
                return this.RatingInfo.MagicBitmap;
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
            }
        }
        public string PassiveDescription
        {
            get
            {
                return this.PassiveInfo.Description;
            }
        }
        private PassiveInfo _PassiveInfo = new PassiveInfo();
        [JsonProperty("passive", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public PassiveInfo PassiveInfo
        {
            get
            {
                return this._PassiveInfo;
            }
            set
            {
                this._PassiveInfo = value;
            }
        }
        public Bitmap PassiveImage
        {
            get
            {
                return this.PassiveInfo.Image;
            }
        }
        public string PassiveName
        {
            get
            {
                return this.PassiveInfo.Name;
            }
        }
        private RatingInfo _RatingInfo = new RatingInfo();
        [JsonProperty("info", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public RatingInfo RatingInfo
        {
            get
            {
                return this._RatingInfo;
            }
            private set
            {
                this._RatingInfo = value;
            }
        }
        public string SkinList
        {
            get
            {
                string value = this.Name;
                for (int i = 1; i < this.Skins.Count; i++)
                    value += ",   " + this.Skins[i].Name;
                return value;
            }
        }
        private List<SkinInfo> _Skins = new List<SkinInfo>();
        [JsonProperty("skins", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<SkinInfo> Skins
        {
            get
            {
                return this._Skins;
            }
            private set
            {
                this._Skins = value;
            }
        }
        public string SpellDescriptionQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Description : null;
            }
        }
        public string SpellDescriptionW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Description : null;
            }
        }
        public string SpellDescriptionE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Description : null;
            }
        }
        public string SpellDescriptionR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Description : null;
            }
        }
        public Bitmap SpellImageQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Image : null;
            }
        }
        public Bitmap SpellImageW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Image : null;
            }
        }
        public Bitmap SpellImageE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Image : null;
            }
        }
        public Bitmap SpellImageR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Image : null;
            }
        }
        public string SpellNameQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Name : null;
            }
        }
        public string SpellNameW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Name : null;
            }
        }
        public string SpellNameE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Name : null;
            }
        }
        public string SpellNameR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Name : null;
            }
        }
        private List<SpellInfo> _Spells = new List<SpellInfo>();
        [JsonProperty("spells", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<SpellInfo> Spells
        {
            get
            {
                return this._Spells;
            }
            private set
            {
                this._Spells = value;
            }
        }
        private StatsInfo _Stats = new StatsInfo();
        [JsonProperty("stats", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public StatsInfo Stats
        {
            get
            {
                return this._Stats;
            }
            private set
            {
                this._Stats = value;
                return;
            }
        }
        public string TagList
        {
            get
            {
                return String.Join(", ", this.Tags.ToArray());
            }
        }
        private List<string> _Tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get
            {
                return this._Tags;
            }
            private set
            {
                this._Tags = value;
            }
        }
        private string _Title = null;
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            private set
            {
                this._Title = value;
            }
        }

    }
}

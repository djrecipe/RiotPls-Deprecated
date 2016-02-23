using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageInfo
    {
        private string _Group = null;
        [JsonProperty("group")]
        private string Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
                if(this.Group != null && this.ImagePath != null)
                    this._Image = new CachedImage(this.Group, this.ImagePath, Engine.ContentVersion);
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
            private set
            {
                this._ID = value;
            }
        }
        private CachedImage _Image = null;
        public CachedImage Image
        {
            get
            {
                return this._Image;
            }
        }
        private string _ImagePath = null;
        [JsonProperty("full")]
        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            private set
            {
                this._ImagePath = value;
                if (this.Group != null && this.ImagePath != null)
                    this._Image = new CachedImage(this.Group, this.ImagePath, Engine.ContentVersion);
                return;
            }
        }
        [JsonProperty("h")]
        public int Height
        {
            get
            {
                return this.Rect.Height;
            }
            set
            {
                this._Rect.Height = value;
                return;
            }
        }
        private Rectangle _Rect = Rectangle.Empty;
        public Rectangle Rect
        {
            get
            {
                return this._Rect;
            }
        }
        private CachedImage _Sprite = null;
        public CachedImage Sprite
        {
            get
            {
                return this._Sprite;
            }
        }
        private string _SpritePath = null;
        [JsonProperty("sprite")]
        public string SpritePath
        {
            get
            {
                return this._SpritePath;
            }
            private set
            {
                this._SpritePath = value;
                //this.Image.UpdateImage(this.SpritePath, this.Group);
                return;
            }
        }
        [JsonProperty("w")]
        public int Width
        {
            get
            {
                return this.Rect.Width;
            }
            set
            {
                this._Rect.Width = value;
                return;
            }
        }
        [JsonProperty("x")]
        public int X
        {
            get
            {
                return this.Rect.X;
            }
            set
            {
                this._Rect.X = value;
                return;
            }
        }
        [JsonProperty("y")]
        public int Y
        {
            get
            {
                return this.Rect.Y;
            }
            set
            {
                this._Rect.Y = value;
                return;
            }
        }
    }
}

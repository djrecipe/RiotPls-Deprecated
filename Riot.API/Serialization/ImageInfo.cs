using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageInfo
    {
        private const string PATH = "IgnoreImages.csv";
        private static bool initialized = false;
        private static List<string> ignore = new List<string>();
        private static void Initialize()
        {
            if (ImageInfo.initialized)
                return;
            if (File.Exists(ImageInfo.PATH))
            {
                ImageInfo.ignore.Clear();
                string text = null;
                try
                {
                    text = File.ReadAllText(ImageInfo.PATH);
                }
                catch
                {
                    text = null;
                }
                if (text != null)
                    ImageInfo.ignore.AddRange(text.Split('\n'));
            }
            ImageInfo.initialized = true;
            return;
        }
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
                this.InitializeImage(this.ImagePath, ref this._Image);
                //this.InitializeImage(this.SpritePath, this.Sprite);
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
        private Bitmap _Image = null;
        public Bitmap Image
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
                this.InitializeImage(this.ImagePath, ref this._Image);
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
        private Bitmap _Sprite = null;
        public Bitmap Sprite
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
                //this.InitializeImage(this.SpritePath, this.Sprite);
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
        private void InitializeImage(string path, ref Bitmap image)
        {
            if (this.Group == null || ImageInfo.ignore.Contains(path))
                return;
            if (path == null)
                image = null;
            else if (image == null || image.Tag.ToString() != path)
            {
                ImageInfo.Initialize();
                try
                {
                    if (!File.Exists(path))
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(Engine.IMGURL + this.Group + "/" + path, path);
                        }
                    }
                    if (File.Exists(path))
                    {
                        image = new Bitmap(path)
                        {
                            Tag = path
                        };
                    }
                }
                catch
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    if (!ImageInfo.ignore.Contains(path))
                    {
                        ImageInfo.ignore.Add(path);
                        File.AppendAllText(ImageInfo.PATH, path + "\n");
                    }
                }
            }
            return;
        }
    }
}

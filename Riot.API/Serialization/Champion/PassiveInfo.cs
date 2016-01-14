using System.Drawing;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champion
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PassiveInfo
    {
        private string _Description = null;
        [JsonProperty("sanitizedDescription", Order = 2)]
        public string Description
        {
            get
            {
                return this._Description;
            }
            private set
            {
                this._Description = value;
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
        [JsonProperty("image", Order = 3, ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
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
        private string _Name = null;
        [JsonProperty("name", Order = 1)]
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
    }
}

using System.Drawing;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champion
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SpellInfo
    {
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
        private string _StyledDescription = null;
        [JsonProperty("description")]
        public string StyledDescription
        {
            get
            {
                return this._StyledDescription;
            }
            private set
            {
                this._StyledDescription = value;
            }
        }

    }
}

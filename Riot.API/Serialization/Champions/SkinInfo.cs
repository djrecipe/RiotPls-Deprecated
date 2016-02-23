using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SkinInfo
    {
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
        private int _Number = -1;
        [JsonProperty("num")]
        public int Number
        {
            get
            {
                return this._Number;
            }
            private set
            {
                this._Number = value;
            }
        }
    }
}

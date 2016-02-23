using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LiveChampionInfo
    {
        [JsonProperty("active")]
        private bool _Active = false;
        public bool Active
        {
            get
            {
                return this._Active;
            }
        }
        [JsonProperty("botEnabled")]
        private bool _CustomBotEnabled = false;
        public bool CustomBotEnabled
        {
            get
            {
                return this._CustomBotEnabled;
            }
        }
        [JsonProperty("freeToPlay")]
        private bool _FreeToPlay = false;
        public bool FreeToPlay
        {
            get
            {
                return this._FreeToPlay;
            }
        }
        [JsonProperty("botMmEnabled")]
        private bool _PublicBotEnabled = false;
        public bool PublicBotEnabled
        {
            get
            {
                return this._PublicBotEnabled;
            }
        }
        [JsonProperty("id")]
        private long _ID = 0;
        public long ID
        {
            get
            {
                return this._ID;
            }
        }
        [JsonProperty("rankedPlayEnabled")]
        private bool _RankedPlayEnabled = false;
        public bool RankedPlayEnabled
        {
            get
            {
                return this._RankedPlayEnabled;
            }
        }
    }
}

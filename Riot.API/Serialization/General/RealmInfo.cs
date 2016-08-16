using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RealmInfo
    {
        private string _BaseURL = null;
        /// <summary>
        /// The base CDN url
        /// </summary>
        [JsonProperty("cdn")]
        public string BaseURL
        {
            get
            {
                return this._BaseURL;
            }
            set
            {
                this._BaseURL = value;
                return;
            }
        }
        private string _ContentVersion = null;
        /// <summary>
        /// Latest changed version of Dragon Magic
        /// </summary>
        [JsonProperty("dd")]
        public string ContentVersion
        {
            get
            {
                return this._ContentVersion;
            }
            set
            {
                this._ContentVersion = value;
                return;
            }
        }
        private string _RealmVersion = null;
        /// <summary>
        /// Content version of this file for this realm
        /// </summary>
        [JsonProperty("v")]
        public string RealmVersion
        {
            get
            {
                return this._RealmVersion;
            }
            set
            {
                this._RealmVersion = value;
                return;
            }
        }
    }
}

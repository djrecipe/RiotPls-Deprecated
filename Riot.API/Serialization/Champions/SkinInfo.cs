using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Champion skin information
    /// </summary>
    /// <remarks>JSON serializable</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class SkinInfo
    {
        #region Instance Properties
        private int _ID = -1;
        /// <summary>
        /// Unique identification number
        /// </summary>
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
        /// <summary>
        /// Skin name
        /// </summary>
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
        /// <summary>
        /// Skin order number
        /// </summary>
        /// <remarks>Skin order in comparison to other skins from the same champion</remarks>
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
        #endregion
    }
}

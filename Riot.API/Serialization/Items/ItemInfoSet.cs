using System.Collections.Generic;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Items
{
    /// <summary>
    /// Implementation of a serializable collection of item information, cached locally
    /// </summary>
    /// <seealso cref="RiotSerializable{T}"/>
    internal class ItemInfoSet : RiotSerializable<Dictionary<string, ItemInfo>>
    {
        #region Instance Properties
        /// <summary>
        /// Local filename where cache is stored
        /// </summary>
        public override string LocalFileName => "ItemInfo.json";
        /// <summary>
        /// Root JSON token from which the serializable data will be extracted
        /// </summary>
        public override string RootToken => "data";
        /// <summary>
        /// A Riot URL from which the data is originally obtained
        /// </summary>
        public override RiotURL URL => new RiotURL(this.apiKey, APISettings.APIVersion, true, "item?itemListData=all");
        #endregion     
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">API key to use for remote connections</param>
        public ItemInfoSet(APIKey key) : base(key)
        {
        }
        #endregion
    }
}

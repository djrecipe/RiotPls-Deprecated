using System.Collections.Generic;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Implementation of a serializable collection of champion information, cached locally
    /// </summary>
    /// <seealso cref="RiotSerializable{T}"/>
    internal class ChampionInfoSet : RiotSerializable<Dictionary<string, ChampionInfo>>
    {
        #region Instance Properties
        /// <summary>
        /// Local filename where cache is stored
        /// </summary>
        public override string LocalFileName => "ChampionInfo.json";
        /// <summary>
        /// Root JSON token from which the serializable data will be extracted
        /// </summary>
        public override string RootToken => "data";
        /// <summary>
        /// A Riot URL from which the data is originally obtained
        /// </summary>
        public override RiotURL URL => new RiotURL(this.apiKey, APISettings.APIVersion, true, "champion?champData=all");
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">API key to use for remote connections</param>
        public ChampionInfoSet(APIKey key) : base(key)
        {
        }
        #endregion
    }
}

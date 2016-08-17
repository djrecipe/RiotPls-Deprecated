using System;

namespace RiotPls.API.Serialization.Transport
{
    /// <summary>
    /// Riot-specific URL
    /// </summary>
    public class RiotURL
    {
        #region Static Members
        private const string URL_LIVE = "api/lol/";
        private const string URL_ROOT = "https://na.api.pvp.net/";
        private const string URL_STATIC = "api/lol/static-data/";
        #endregion
        #region Instance Members
        /// <summary>
        /// Base URL for making queries
        /// </summary>
        public readonly string BaseURL;
        /// <summary>
        /// Region URL string
        /// </summary>
        public readonly string Region;
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">Valid API key</param>
        /// <param name="api_version">Desired API version</param></para>
        /// <param name="static_data">True if accessing static data, false otherwise</param>
        /// <param name="sub_url">Sub-URL to be appended onto the root URL</param>
        public RiotURL(APIKey key, double api_version, bool static_data, string sub_url)
        {
            if (key == null)
                throw new ArgumentNullException("key", "Invalid API key");
            this.Region = "na";
            this.BaseURL = RiotURL.URL_ROOT + (static_data ? RiotURL.URL_STATIC : RiotURL.URL_LIVE) +
                this.Region + "/" + string.Format("v{0}", api_version) + "/" + sub_url + key.ToString(true);
            return;
        }
        /// <summary>
        /// Returns the Riot URL string
        /// </summary>
        /// <param name="obj">An instance of RiotURL object</param>
        public static implicit operator string(RiotURL obj)
        {
            return obj.BaseURL;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API.Serialization.Transport
{
    public class RiotURL
    {
        private const string URL_LIVE = "api/lol/";
        private const string URL_ROOT = "https://na.api.pvp.net/";
        private const string URL_STATIC = "api/lol/static-data/";
        public readonly string BaseURL;
        public readonly string Region;
        public RiotURL(APIKey key, bool static_data, string sub_url)
        {
            this.Region = "na";
            this.BaseURL = RiotURL.URL_ROOT + (static_data ? RiotURL.URL_STATIC : RiotURL.URL_LIVE) +
                this.Region + "/" + Engine.APIVersionString + "/" + sub_url + key.ToString(true);
            return;
        }
        public static implicit operator string(RiotURL obj)
        {
            return obj.BaseURL;
        }
    }
}

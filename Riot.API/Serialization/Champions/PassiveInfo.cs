using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Champion passive ability information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PassiveInfo
    {
        /// <summary>
        /// Champion passive ability description
        /// </summary>
        /// <remarks>Pre-sanitized</remarks>
        [JsonProperty("sanitizedDescription", Order = 2)]
        public string Description { get; private set; }
        /// <summary>
        /// Champion passive ability toolbar image
        /// </summary>
        public Bitmap Image => this.ImageData.Image;
        /// <summary>
        /// Serializable image information
        /// </summary>
        [JsonProperty("image", Order = 3, ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private ImageInfo ImageData { get; set; } = null;
        /// <summary>
        /// Champion passive ability name
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; private set; } = null;
    }
}

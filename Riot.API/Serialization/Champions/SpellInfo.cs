using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Champion spell information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SpellInfo
    {
        /// <summary>
        /// Spell toolbar image
        /// </summary>
        public Bitmap Image => this.ImageData.Image;
        /// <summary>
        /// Serializable image information
        /// </summary>
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private ImageInfo ImageData { get; set; }
        /// <summary>
        /// Spell description
        /// </summary>
        /// <remarks>Pre-sanitized</remarks>
        [JsonProperty("sanitizedDescription")]
        public string Description { get; private set; } = null;
        /// <summary>
        /// Spell name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; } = null;
        /// <summary>
        /// Spell description, with text styles
        /// </summary>
        [JsonProperty("description")]
        public string StyledDescription { get; private set; } = null;

    }
}

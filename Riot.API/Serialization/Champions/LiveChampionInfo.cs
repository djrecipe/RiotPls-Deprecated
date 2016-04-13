using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Non-static champion information, primarily regarding champion availability
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LiveChampionInfo
    {
        /// <summary>
        /// True if the champion is enabled for play, False otherwise
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; protected set; } = false;
        /// <summary>
        /// True if the champion is enabled for play in a custom bot match, False otherwise
        /// </summary>
        [JsonProperty("botEnabled")]
        public bool CustomBotEnabled { get; protected set; } = false;
        /// <summary>
        /// True if the champion is free-to-play for the week, False otherwise
        /// </summary>
        [JsonProperty("freeToPlay")]
        public bool FreeToPlay { get; protected set; } = false;
        /// <summary>
        /// True if the champion is enabled for play in a public bot match, False otherwise
        /// </summary>
        [JsonProperty("botMmEnabled")]
        public bool PublicBotEnabled { get; protected set; } = false;
        /// <summary>
        /// Unique champion ID
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; protected set; } = 0;
        /// <summary>
        /// True if the champion is enabled for play in a ranked match, False otherwise
        /// </summary>
        [JsonProperty("rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; protected set; } = false;
    }
}

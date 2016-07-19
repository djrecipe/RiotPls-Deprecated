using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Items
{
    /// <summary>
    /// Serializable container describing the cost parameters of an item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemCost
    {
        #region Instance Properties
        /// <summary>
        /// Item is purchasable from a shop in-game
        /// </summary>
        [JsonProperty("purchasable")]
        public bool Purchasable { get; private set; }
        /// <summary>
        /// Amount refunded if item is sold
        /// </summary>
        [JsonProperty("sell")]
        public int SellPrice { get; private set; }
        /// <summary>
        /// Total cost of the item, including any components
        /// </summary>
        [JsonProperty("total")]
        public int TotalCost { get; private set; }
        /// <summary>
        /// Cost of item, not including components
        /// </summary>
        [JsonProperty("base")]
        public int UpgradeCost { get; private set; }
        #endregion
    }
}

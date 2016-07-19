using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Items
{
    /// <summary>
    /// Serializable container describing the cost parameters of an item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemCost
    {
        [JsonProperty("purchasable")]
        public bool Purchasable { get; private set; }
        [JsonProperty("sell")]
        public int SellPrice { get; private set; }
        [JsonProperty("total")]
        public int TotalCost { get; private set; }
        [JsonProperty("base")]
        public int UpgradeCost { get; private set; }
    }
}

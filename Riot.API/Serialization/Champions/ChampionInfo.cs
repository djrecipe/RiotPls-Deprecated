using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using RiotPls.API.Serialization.ExtensionMethods;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Champions
{
    /// <summary>
    /// Champion description, stats, capabilities, etc.
    /// </summary>           
    /// <remarks>Serializable to/from JSON</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionInfo : IRiotDroppable
    {
        #region Instance Properties
        /// <summary>
        /// An image depicting the champion's emphasis on physical attacks
        /// </summary>
        public Bitmap AttackBitmap => this.RatingInfo?.AttackBitmap;
        /// <summary>
        /// An image depicting the champion's emphasis on defense
        /// </summary>
        public Bitmap DefenseBitmap => this.RatingInfo?.DefenseBitmap;
        /// <summary>
        /// An image depicting the champion's difficulty
        /// </summary>
        public Bitmap DifficultyBitmap => this.RatingInfo?.DifficultyBitmap;
        /// <summary>
        /// True if the champion is free-to-play for the week, False otherwise
        /// </summary>
        public bool FreeToPlay => this.LiveInfo?.FreeToPlay ?? false;
        /// <summary>
        /// Unique champion ID
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; private set; } = -1;
        /// <summary>
        /// Champion mugshot
        /// </summary>
        public Bitmap Image => this.ImageData?.Image;
        /// <summary>
        /// Image data for champion's portrait
        /// </summary>
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private ImageInfo ImageData { get; set; } = null;

        /// <summary>
        /// Level at which champion stats are taken into account
        /// </summary>
        public int LevelObtained
        {
            get { return this.Stats.RequiredLevel; }
            set { this.Stats.RequiredLevel = value; }
        }
        /// <summary>
        /// Collection of non-static data, primarily in regards to champion availability
        /// </summary>
        public LiveChampionInfo LiveInfo { get; set; } = null;
        /// <summary>
        /// Full champion lore
        /// </summary>
        [JsonProperty("lore")]
        public string Lore { get; private set; } = null;
        /// <summary>
        /// Excerpt of champion lore
        /// </summary>
        [JsonProperty("blurb")]
        public string LoreSummary { get; private set; } = null;
        /// <summary>
        /// An image depicting the champion's emphasis on magic attacks
        /// </summary>
        public Bitmap MagicBitmap => this.RatingInfo?.MagicBitmap;
        /// <summary>
        /// Unique champion name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; protected set; } = null;
        /// <summary>
        /// Description of champion's passive ability
        /// </summary>
        public string PassiveDescription => this.PassiveInfo?.Description;
        /// <summary>
        /// Data for the champion's passive ability
        /// </summary>
        [JsonProperty("passive", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private PassiveInfo PassiveInfo { get; set; } = new PassiveInfo();
        /// <summary>
        /// Icon for champion's passive ability
        /// </summary>
        public Bitmap PassiveImage => this.PassiveInfo?.Image;
        /// <summary>
        /// Name of champion's passive ability
        /// </summary>
        public string PassiveName => this.PassiveInfo?.Name;
        /// <summary>
        /// Data for champion's ratings (attack, difficulty, etc.)
        /// </summary>
        [JsonProperty("info", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public RatingInfo RatingInfo { get; private set; } = new RatingInfo();
        /// <summary>
        /// List of champion's skin names, flattened to a single string
        /// </summary>
        public string SkinList
        {
            get
            {
                string value = this.Name;
                for (int i = 1; i < this.Skins.Count; i++)
                    value += ",   " + this.Skins[i].Name;
                return value;
            }
        }
        /// <summary>
        /// List of champion's skin data
        /// </summary>
        [JsonProperty("skins", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<SkinInfo> Skins { get; private set; } = new List<SkinInfo>();
        /// <summary>
        /// Description of champion's 'Q' ability
        /// </summary>
        public string SpellDescriptionQ => this.Spells.Count > 0 ? this.Spells[0].Description : null;
        /// <summary>
        /// Description of champion's 'W' ability
        /// </summary>
        public string SpellDescriptionW => this.Spells.Count > 1 ? this.Spells[1].Description : null;
        /// <summary>
        /// Description of champion's 'E' ability
        /// </summary>
        public string SpellDescriptionE => this.Spells.Count > 2 ? this.Spells[2].Description : null;
        /// <summary>
        /// Description of champion's 'R' ability
        /// </summary>
        public string SpellDescriptionR => this.Spells.Count > 3 ? this.Spells[3].Description : null;
        /// <summary>
        /// Icon for champion's 'Q' ability
        /// </summary>
        public Bitmap SpellImageQ => this.Spells.Count > 0 ? this.Spells[0].Image : null;
        /// <summary>
        /// Icon for champion's 'W' ability
        /// </summary>
        public Bitmap SpellImageW => this.Spells.Count > 1 ? this.Spells[1].Image : null;
        /// <summary>
        /// Icon for champion's 'E' ability
        /// </summary>
        public Bitmap SpellImageE => this.Spells.Count > 2 ? this.Spells[2].Image : null;
        /// <summary>
        /// Icon for champion's 'R' ability
        /// </summary>
        public Bitmap SpellImageR => this.Spells.Count > 3 ? this.Spells[3].Image : null;
        /// <summary>
        /// Name of champion's 'Q' ability
        /// </summary>
        public string SpellNameQ => this.Spells.Count > 0 ? this.Spells[0].Name : null;
        /// <summary>
        /// Name of champion's 'W' ability
        /// </summary>
        public string SpellNameW => this.Spells.Count > 1 ? this.Spells[1].Name : null;
        /// <summary>
        /// Name of champion's 'E' ability
        /// </summary>
        public string SpellNameE => this.Spells.Count > 2 ? this.Spells[2].Name : null;
        /// <summary>
        /// Name of champion's 'R' ability
        /// </summary>
        public string SpellNameR => this.Spells.Count > 3 ? this.Spells[3].Name : null;
        /// <summary>
        /// List of champion's spell data
        /// </summary>
        [JsonProperty("spells", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<SpellInfo> Spells { get; private set; } = new List<SpellInfo>();
        /// <summary>
        /// Description of basic champion stats (armor, movement speed, etc.)
        /// </summary>
        [JsonProperty("stats", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ChampionStatsInfo Stats { get; private set; } = new ChampionStatsInfo();
        /// <summary>
        /// List of champion's tags, flattened to a single string
        /// </summary>
        public string TagList => string.Join(", ", this.Tags.ToArray());
        /// <summary>
        /// List of champion's tags
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; private set; } = new List<string>();
        /// <summary>
        /// Champion's lore-related title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; } = null;
        #endregion
        #region Instance Methods
        /// <summary>
        /// This class cannot be directly instantiated
        /// </summary>
        protected ChampionInfo()
        {
            
        }
        /// <summary>
        /// Performs a deep clone via JSON serialization
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return JsonSaveEngine.CloneJsonObject(this);
        }
        #endregion
    }
}

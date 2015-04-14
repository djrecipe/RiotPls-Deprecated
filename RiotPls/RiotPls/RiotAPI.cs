using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotPls
{
    [JsonObject(MemberSerialization.OptIn)]
    public class LiveChampionInfo
    {
        [JsonProperty("active")]
        private bool _Active = false;
        public bool Active
        {
            get
            {
                return this._Active;
            }
        }
        [JsonProperty("botEnabled")]
        private bool _CustomBotEnabled = false;
        public bool CustomBotEnabled
        {
            get
            {
                return this._CustomBotEnabled;
            }
        }
        [JsonProperty("freeToPlay")]
        private bool _FreeToPlay = false;
        public bool FreeToPlay
        {
            get
            {
                return this._FreeToPlay;
            }
        }
        [JsonProperty("botMmEnabled")]
        private bool _PublicBotEnabled = false;
        public bool PublicBotEnabled
        {
            get
            {
                return this._PublicBotEnabled;
            }
        }
        [JsonProperty("id")]
        private long _ID = 0;
        public long ID
        {
            get
            {
                return this._ID;
            }
        }
        [JsonProperty("rankedPlayEnabled")]
        private bool _RankedPlayEnabled = false;
        public bool RankedPlayEnabled
        {
            get
            {
                return this._RankedPlayEnabled;
            }
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionInfo
    {
        public Bitmap AttackBitmap
        {
            get
            {
                return this.RatingInfo.AttackBitmap;
            }
        }
        public Bitmap DefenseBitmap
        {
            get
            {
                return this.RatingInfo.DefenseBitmap;
            }
        }
        public Bitmap DifficultyBitmap
        {
            get
            {
                return this.RatingInfo.DifficultyBitmap;
            }
        }
        public bool FreeToPlay
        {
            get
            {
                return this.LiveInfo.FreeToPlay;
            }
        }
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
            }
        }
        public Bitmap Image
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private LiveChampionInfo _LiveInfo = null;
        public LiveChampionInfo LiveInfo
        {
            get
            {
                return this._LiveInfo;
            }
            set
            {
                this._LiveInfo = value;
            }
        }
        private string _Lore = null;
        [JsonProperty("lore")]
        public string Lore
        {
            get
            {
                return this._Lore;
            }
            private set
            {
                this._Lore = value;
            }
        }
        private string _LoreSummary = null;
        [JsonProperty("blurb")]
        public string LoreSummary
        {
            get
            {
                return this._LoreSummary;
            }
            private set
            {
                this._LoreSummary = value;
            }
        }
        public Bitmap MagicBitmap
        {
            get
            {
                return this.RatingInfo.MagicBitmap;
            }
        }
        private string _Name = null;
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
            }
        }
        public string PassiveDescription
        {
            get
            {
                return this.PassiveInfo.Description;
            }
        }
        private ChampionPassiveInfo _PassiveInfo = new ChampionPassiveInfo();
        [JsonProperty("passive", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ChampionPassiveInfo PassiveInfo
        {
            get
            {
                return this._PassiveInfo;
            }
            set
            {
                this._PassiveInfo = value;
            }
        }
        public Bitmap PassiveImage
        {
            get
            {
                return this.PassiveInfo.Image;
            }
        }
        public string PassiveName
        {
            get
            {
                return this.PassiveInfo.Name;
            }
        }
        private ChampionRatingInfo _RatingInfo = new ChampionRatingInfo();   
        [JsonProperty("info", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ChampionRatingInfo RatingInfo
        {
            get
            {
                return this._RatingInfo;
            }
            private set
            {
                this._RatingInfo = value;
            }
        }
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
        private List<ChampionSkinInfo> _Skins = new List<ChampionSkinInfo>();
        [JsonProperty("skins", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<ChampionSkinInfo> Skins
        {
            get
            {
                return this._Skins;
            }
            private set
            {
                this._Skins = value;
            }
        }
        public string SpellDescriptionQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Description : null;
            }
        }
        public string SpellDescriptionW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Description : null;
            }
        }
        public string SpellDescriptionE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Description : null;
            }
        }
        public string SpellDescriptionR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Description : null;
            }
        }
        public Bitmap SpellImageQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Image : null;
            }
        }
        public Bitmap SpellImageW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Image : null;
            }
        }
        public Bitmap SpellImageE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Image : null;
            }
        }
        public Bitmap SpellImageR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Image : null;
            }
        }
        public string SpellNameQ
        {
            get
            {
                return this.Spells.Count > 0 ? this.Spells[0].Name : null;
            }
        }
        public string SpellNameW
        {
            get
            {
                return this.Spells.Count > 1 ? this.Spells[1].Name : null;
            }
        }
        public string SpellNameE
        {
            get
            {
                return this.Spells.Count > 2 ? this.Spells[2].Name : null;
            }
        }
        public string SpellNameR
        {
            get
            {
                return this.Spells.Count > 3 ? this.Spells[3].Name : null;
            }
        }
        private List<ChampionSpellInfo> _Spells = new List<ChampionSpellInfo>();
        [JsonProperty("spells", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public List<ChampionSpellInfo> Spells
        {
            get
            {
                return this._Spells;
            }
            private set
            {
                this._Spells = value;
            }
        }
        private ChampionStatsInfo _Stats = new ChampionStatsInfo();
        [JsonProperty("stats", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ChampionStatsInfo Stats
        {
            get
            {
                return this._Stats;
            }
            private set
            {
                this._Stats = value;
                return;
            }
        }
        public string TagList
        {
            get
            {
                return String.Join(", ", this.Tags.ToArray());
            }
        }
        private List<string> _Tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get
            {
                return this._Tags;
            }
            private set
            {
                this._Tags = value;
            }
        }
        private string _Title = null;
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            private set
            {
                this._Title = value;
            }
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionPassiveInfo
    {
        private string _Description = null;
        [JsonProperty("sanitizedDescription", Order = 2)]
        public string Description
        {
            get
            {
                return this._Description;
            }
            private set
            {
                this._Description = value;
            }
        }
        public Bitmap Image
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", Order = 3, ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private string _Name = null;
        [JsonProperty("name",Order=1)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
            }
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionRatingInfo
    {                                   
        private int _Attack = -1;
        [JsonProperty("attack", Order = 1)]
        public int Attack
        {
            get
            {
                return this._Attack;
            }
            private set
            {
                this._Attack = value;
                this.AttackBitmap = this.CreateBitmap(this.Attack, Color.Red);
                return;
            }
        }
        private Bitmap _AttackBitmap = null;
        public Bitmap AttackBitmap
        {
            get
            {
                return this._AttackBitmap;
            }
            private set
            {
                this._AttackBitmap = value;
            }
        }
        private int _Defense = -1;
        [JsonProperty("defense", Order = 2)]
        public int Defense
        {
            get
            {
                return this._Defense;
            }
            private set
            {
                this._Defense = value;
                this.DefenseBitmap = this.CreateBitmap(this.Defense, Color.Green);
                return;
            }
        }
        private Bitmap _DefenseBitmap = null;
        public Bitmap DefenseBitmap
        {
            get
            {
                return this._DefenseBitmap;
            }
            private set
            {
                this._DefenseBitmap = value;
            }
        }
        private int _Difficulty = -1;
        [JsonProperty("difficulty", Order = 3)]
        public int Difficulty
        {
            get
            {
                return this._Difficulty;
            }
            private set
            {
                this._Difficulty = value;
                this.DifficultyBitmap = this.CreateBitmap(this.Difficulty, Color.Purple);
                return;
            }
        }
        private Bitmap _DifficultyBitmap = null;
        public Bitmap DifficultyBitmap
        {
            get
            {
                return this._DifficultyBitmap;
            }
            private set
            {
                this._DifficultyBitmap = value;
            }
        }
        private int _Magic = -1;
        [JsonProperty("magic", Order = 4)]
        public int Magic
        {
            get
            {
                return this._Magic;
            }
            private set
            {
                this._Magic = value;
                this.MagicBitmap = this.CreateBitmap(this.Magic, Color.Blue);
                return;
            }
        }
        private Bitmap _MagicBitmap = null;
        public Bitmap MagicBitmap
        {
            get
            {
                return this._MagicBitmap;
            }
            private set
            {
                this._MagicBitmap = value;
            }
        }
        private Bitmap CreateBitmap(int value, Color color)
        {
            Bitmap bitmap = null;
            Image image = Image.FromFile("Rating.bmp");
            double ratio = (double)value / 10.0;
            int fill_bottom = (int)(ratio * (double)image.Height);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Color.FromArgb(46,46,46)), 0, 0, image.Width, image.Height);
            g.FillRectangle(new SolidBrush(color), new Rectangle(0, image.Height - fill_bottom, image.Width, fill_bottom));
            g.DrawRectangle(new Pen(Brushes.Black, 3.0f), new Rectangle(0, 0, image.Width - 1, image.Height - 1));
            bitmap = new Bitmap(image);
            image.Dispose();
            return bitmap;
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionSkinInfo
    {
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
            }
        }
        private string _Name = null;
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
            }
        }
        private int _Number = -1;
        [JsonProperty("num")]
        public int Number
        {
            get
            {
                return this._Number;
            }
            private set
            {
                this._Number = value;
            }
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionSpellInfo
    {
        public Bitmap Image
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private string _Description = null;
        [JsonProperty("sanitizedDescription")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            private set
            {
                this._Description = value;
            }
        }
        private string _Name = null;
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
            }
        }
        private string _StyledDescription = null;
        [JsonProperty("description")]
        public string StyledDescription
        {
            get
            {
                return this._StyledDescription;
            }
            private set
            {
                this._StyledDescription = value;
            }
        }

    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionStatsInfo
    {
        private double _Armor = -1;
        [JsonProperty("armor")]
        public double Armor
        {
            get
            {
                return this._Armor;
            }
            private set
            {
                this._Armor = value;
                this.Stats.Rows[0]["Armor"] = value;
                this.InitializeArmorRows();
                return;
            }
        }
        private double _ArmorPerLevel = -1;
        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel
        {
            get
            {
                return this._ArmorPerLevel;
            }
            private set
            {
                this._ArmorPerLevel = value;
                this.Stats.Rows[1]["Armor"] = value;
                this.InitializeArmorRows();
                return;
            }
        }
        private double _AttackDamage = -1;
        [JsonProperty("attackdamage")]
        public double AttackDamage
        {
            get
            {
                return this._AttackDamage;
            }
            private set
            {
                this._AttackDamage = value;
                this.Stats.Rows[0]["AttackDamage"] = value;
                this.InitializeAttackDamageRows();
                return;
            }
        }
        private double _AttackDamagePerLevel = -1;
        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel
        {
            get
            {
                return this._AttackDamagePerLevel;
            }
            private set
            {
                this._AttackDamagePerLevel = value;
                this.Stats.Rows[1]["AttackDamage"] = value;
                this.InitializeAttackDamageRows();
            }
        }
        private double _AttackRange = -1;
        [JsonProperty("attackrange")]
        public double AttackRange
        {
            get
            {
                return this._AttackRange;
            }
            private set
            {
                this._AttackRange = value;
                this.Stats.Rows[0]["AttackRange"] = value;
                this.Stats.Rows[1]["AttackRange"] = 0.0;
                this.InitializeAttackRangeRows();
                return;
            }
        }
        private double _AttackSpeed = -1;
        public double AttackSpeed
        {
            get
            {
                return this._AttackSpeed;
            }
            private set
            {
                this._AttackSpeed = value;
                this.Stats.Rows[0]["AttackSpeed"] = value;
                this.InitializeAttackSpeedRows();
                return;
            }
        }
        private double _AttackSpeedOffset = -1;
        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedOffset
        {
            get
            {
                return this._AttackSpeedOffset;
            }
            private set
            {
                this._AttackSpeedOffset = value;
                this.AttackSpeed = 0.625 / (1.0 + value);
                return;
            }
        }
        private double _AttackSpeedPerLevel = -1;
        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel
        {
            get
            {
                return this._AttackSpeedPerLevel;
            }
            private set
            {
                this._AttackSpeedPerLevel = value;
                this.Stats.Rows[1]["AttackSpeed"] = value;
                this.InitializeAttackSpeedRows();
                return;
            }
        }
        private double _CriticalStrike = -1;
        [JsonProperty("crit")]
        public double CriticalStrike
        {
            get
            {
                return this._CriticalStrike;
            }
            private set
            {
                this._CriticalStrike = value;
                this.Stats.Rows[0]["CriticalStrike"] = value;
                this.InitializeCriticalStrikeRows();
                return;
            }
        }
        private double _CriticalStrikePerLevel = -1;
        [JsonProperty("critperlevel")]
        public double CriticalStrikePerLevel
        {
            get
            {
                return this._CriticalStrikePerLevel;
            }
            private set
            {
                this._CriticalStrikePerLevel = value;
                this.Stats.Rows[1]["CriticalStrike"] = value;
                this.InitializeCriticalStrikeRows();
                return;
            }
        }
        private double _Health = -1;
        [JsonProperty("hp")]
        public double Health
        {
            get
            {
                return this._Health;
            }
            private set
            {
                this._Health = value;
                this.Stats.Rows[0]["Health"] = value;
                this.InitializeHealthRows();
                return;
            }
        }
        private double _HealthPerLevel = -1;
        [JsonProperty("hpperlevel")]
        public double HealthPerLevel
        {
            get
            {
                return this._HealthPerLevel;
            }
            private set
            {
                this._HealthPerLevel = value;
                this.Stats.Rows[1]["Health"] = value;
                this.InitializeHealthRows();
                return;
            }
        }
        private double _HealthRegen = -1;
        [JsonProperty("hpregen")]
        public double HealthRegen
        {
            get
            {
                return this._HealthRegen;
            }
            private set
            {
                this._HealthRegen = value;
                this.Stats.Rows[0]["HealthRegen"] = value;
                this.InitializeHealthRegenRows();
                return;
            }
        }
        private double _HealthRegenPerLevel = -1;
        [JsonProperty("hpregenperlevel")]
        public double HealthRegenPerLevel
        {
            get
            {
                return this._HealthRegenPerLevel;
            }
            private set
            {
                this._HealthRegenPerLevel = value;
                this.Stats.Rows[1]["HealthRegen"] = value;
                this.InitializeHealthRegenRows();
                return;
            }
        }
        private double _MovementSpeed = -1;
        [JsonProperty("movespeed")]
        public double MovementSpeed
        {
            get
            {
                return this._MovementSpeed;
            }
            private set
            {
                this._MovementSpeed = value;
                this.Stats.Rows[0]["MovementSpeed"] = value;
                this.Stats.Rows[1]["MovementSpeed"] = 0.0;
                this.InitializeMovementSpeedRows();
                return;
            }
        }
        private double _Resource = -1;
        [JsonProperty("mp")]
        public double Resource
        {
            get
            {
                return this._Resource;
            }
            private set
            {
                this._Resource = value;
                this.Stats.Rows[0]["Resource"] = value;
                this.InitializeResourceRows();
                return;
            }
        }
        private double _ResourcePerLevel = -1;
        [JsonProperty("mpperlevel")]
        public double ResourcePerLevel
        {
            get
            {
                return this._ResourcePerLevel;
            }
            private set
            {
                this._ResourcePerLevel = value;
                this.Stats.Rows[1]["Resource"] = value;
                this.InitializeResourceRows();
                return;
            }
        }
        private double _ResourceRegen = -1;
        [JsonProperty("mpregen")]
        public double ResourceRegen
        {
            get
            {
                return this._ResourceRegen;
            }
            private set
            {
                this._ResourceRegen = value;
                this.Stats.Rows[0]["ResourceRegen"] = value;
                this.InitializeResourceRegenRows();
                return;
            }
        }
        private double _ResourceRegenPerLevel = -1;
        [JsonProperty("mpregenperlevel")]
        public double ResourceRegenPerLevel
        {
            get
            {
                return this._ResourceRegenPerLevel;
            }
            private set
            {
                this._ResourceRegenPerLevel = value;
                this.Stats.Rows[1]["ResourceRegen"] = value;
                this.InitializeResourceRegenRows();
                return;
            }
        }
        public StatsTable.StatsDataTable Stats
        {
            get
            {
                return this.Table.Stats;
            }
        }
        private double _MagicResist = -1;
        [JsonProperty("spellblock")]
        public double MagicResist
        {
            get
            {
                return this._MagicResist;
            }
            private set
            {
                this._MagicResist = value;
                this.Stats.Rows[0]["MagicResist"] = value;
                this.InitializeMagicResistRows();
                return;
            }
        }
        private double _MagicResistPerLevel = -1;
        [JsonProperty("spellblockperlevel")]
        public double MagicResistPerLevel
        {
            get
            {
                return this._MagicResistPerLevel;
            }
            private set
            {
                this._MagicResistPerLevel = value;
                this.Stats.Rows[1]["MagicResist"] = value;
                this.InitializeMagicResistRows();
                return;
            }
        }
        private StatsTable _Table = new StatsTable();
        public StatsTable Table
        {
            get
            {
                return this._Table;
            }
        }
        public ChampionStatsInfo()
        {
            this.Stats.AddStatsRow(-1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0);
            this.Stats.AddStatsRow(-1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0);
            for (int i = 0; i < 17; i++)
                this.Stats.AddStatsRow(-1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0);
            return;
        }
        private void InitializeArmorRows()
        {
            if ((double)this.Stats[0]["Armor"] == -1.0 || (double)this.Stats[1]["Armor"] == -1.0 || (double)this.Stats[2]["Armor"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Armor"] = (double)this.Stats[0]["Armor"] + (double)this.Stats[1]["Armor"] * (double)i;
            return;
        }
        private void InitializeAttackDamageRows()
        {
            if ((double)this.Stats[0]["AttackDamage"] == -1.0 || (double)this.Stats[1]["AttackDamage"] == -1.0 || (double)this.Stats[2]["AttackDamage"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackDamage"] = (double)this.Stats[0]["AttackDamage"] + (double)this.Stats[1]["AttackDamage"] * (double)i;
            return;
        }
        private void InitializeAttackRangeRows()
        {
            if ((double)this.Stats[0]["AttackRange"] == -1.0 || (double)this.Stats[1]["AttackRange"] == -1.0 || (double)this.Stats[2]["AttackRange"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackRange"] = (double)this.Stats[0]["AttackRange"] + (double)this.Stats[1]["AttackRange"] * (double)i;
            return;
        }
        private void InitializeAttackSpeedRows()
        {
            if ((double)this.Stats[0]["AttackSpeed"] == -1.0 || (double)this.Stats[1]["AttackSpeed"] == -1.0 || (double)this.Stats[2]["AttackSpeed"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackSpeed"] = (double)this.Stats[0]["AttackSpeed"] + (double)this.Stats[1]["AttackSpeed"] * (double)i;
            return;
        }
        private void InitializeCriticalStrikeRows()
        {
            if ((double)this.Stats[0]["CriticalStrike"] == -1.0 || (double)this.Stats[1]["CriticalStrike"] == -1.0 || (double)this.Stats[2]["CriticalStrike"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["CriticalStrike"] = (double)this.Stats[0]["CriticalStrike"] + (double)this.Stats[1]["CriticalStrike"] * (double)i;
            return;
        }
        private void InitializeHealthRows()
        {
            if ((double)this.Stats[0]["Health"] == -1.0 || (double)this.Stats[1]["Health"] == -1.0 || (double)this.Stats[2]["Health"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Health"] = (double)this.Stats[0]["Health"] + (double)this.Stats[1]["Health"] * (double)i;
            return;
        }
        private void InitializeHealthRegenRows()
        {
            if ((double)this.Stats[0]["HealthRegen"] == -1.0 || (double)this.Stats[1]["HealthRegen"] == -1.0 || (double)this.Stats[2]["HealthRegen"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["HealthRegen"] = (double)this.Stats[0]["HealthRegen"] + (double)this.Stats[1]["HealthRegen"] * (double)i;
            return;
        }
        private void InitializeMagicResistRows()
        {
            if ((double)this.Stats[0]["MagicResist"] == -1.0 || (double)this.Stats[1]["MagicResist"] == -1.0 || (double)this.Stats[2]["MagicResist"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["MagicResist"] = (double)this.Stats[0]["MagicResist"] + (double)this.Stats[1]["MagicResist"] * (double)i;
            return;
        }
        private void InitializeMovementSpeedRows()
        {
            if ((double)this.Stats[0]["MovementSpeed"] == -1.0 || (double)this.Stats[1]["MovementSpeed"] == -1.0 || (double)this.Stats[2]["MovementSpeed"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["MovementSpeed"] = (double)this.Stats[0]["MovementSpeed"] + (double)this.Stats[1]["MovementSpeed"] * (double)i;
            return;
        }
        private void InitializeResourceRows()
        {
            if ((double)this.Stats[0]["Resource"] == -1.0 || (double)this.Stats[1]["Resource"] == -1.0 || (double)this.Stats[2]["Resource"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Resource"] = (double)this.Stats[0]["Resource"] + (double)this.Stats[1]["Resource"] * (double)i;
            return;
        }
        private void InitializeResourceRegenRows()
        {
            if ((double)this.Stats[0]["ResourceRegen"] == -1.0 || (double)this.Stats[1]["ResourceRegen"] == -1.0 || (double)this.Stats[2]["ResourceRegen"] != -1.0)
                return;
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["ResourceRegen"] = (double)this.Stats[0]["ResourceRegen"] + (double)this.Stats[1]["ResourceRegen"] * (double)i;
            return;
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageInfo
    {
        private const string PATH = "IgnoreImages.csv";
        private static bool initialized = false;
        private static List<string> ignore = new List<string>();
        private static void Initialize()
        {
            if (ImageInfo.initialized)
                return;
            if (File.Exists(ImageInfo.PATH))
            {
                ImageInfo.ignore.Clear();
                string text = null;
                try
                {
                    text = File.ReadAllText(ImageInfo.PATH);
                }
                catch
                {
                    text = null;
                }
                if(text!=null)
                    ImageInfo.ignore.AddRange(text.Split('\n'));
            }
            ImageInfo.initialized = true;
            return;
        }
        private string _Group = null;
        [JsonProperty("group")]
        private string Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
                this.InitializeImage(this.ImagePath, ref this._Image);
                //this.InitializeImage(this.SpritePath, this.Sprite);
                return;
            }
        }
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
            }
        }
        private Bitmap _Image = null;
        public Bitmap Image
        {
            get
            {
                return this._Image;
            }
        }
        private string _ImagePath = null;
        [JsonProperty("full")]
        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            private set
            {
                this._ImagePath = value;
                this.InitializeImage(this.ImagePath, ref this._Image);
                return;
            }
        }
        [JsonProperty("h")]
        public int Height
        {
            get
            {
                return this.Rect.Height;
            }
            set
            {
                this._Rect.Height = value;
                return;
            }
        }
        private Rectangle _Rect = Rectangle.Empty;
        public Rectangle Rect
        {
            get
            {
                return this._Rect;
            }
        }
        private Bitmap _Sprite = null;
        public Bitmap Sprite
        {
            get
            {
                return this._Sprite;
            }
        }
        private string _SpritePath = null;
        [JsonProperty("sprite")]
        public string SpritePath
        {
            get
            {
                return this._SpritePath;
            }
            private set
            {
                this._SpritePath = value;
                //this.InitializeImage(this.SpritePath, this.Sprite);
                return;
            }
        }
        [JsonProperty("w")]
        public int Width
        {
            get
            {
                return this.Rect.Width;
            }
            set
            {
                this._Rect.Width = value;
                return;
            }
        }
        [JsonProperty("x")]
        public int X
        {
            get
            {
                return this.Rect.X;
            }
            set
            {
                this._Rect.X = value;
                return;
            }
        }
        [JsonProperty("y")]
        public int Y
        {
            get
            {
                return this.Rect.Y;
            }
            set
            {
                this._Rect.Y = value;
                return;
            }
        }
        private void InitializeImage(string path, ref Bitmap image)
        {
            if (this.Group == null)
                return;
            if (path == null)
                image = null;
            else if (image == null || image.Tag.ToString() != path)
            {
                ImageInfo.Initialize();
                if (!File.Exists(path) && !ImageInfo.ignore.Contains(path))
                {
                    using (WebClient client = new WebClient())
                    {
                        bool error_occurred = false;
                        try
                        {
                            client.DownloadFile(RiotAPI.IMGURL + this.Group + "/" + path, path);
                        }
                        catch
                        {
                            error_occurred = true;
                        }
                        if (error_occurred)
                        {
                            if (File.Exists(path))
                            {
                                try
                                {
                                    File.Delete(path);
                                }
                                catch
                                {
                                }
                            }
                            ImageInfo.ignore.Add(path);
                            try
                            {
                                File.AppendAllText(ImageInfo.PATH, path + "\n");
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                if (File.Exists(path))
                {
                    image = new Bitmap(path);
                    image.Tag = path;
                }
            }
            return;
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemInfo
    {
        private static List<ItemInfo> consumables = new List<ItemInfo>();
        private static List<ItemInfo> non_consumables = new List<ItemInfo>();
        private static void RemoveReference(ItemInfo info)
        {
            if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                consumables.Remove(info);
            if (non_consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                non_consumables.Remove(info);
            return;
        }
        private static void UpdateConsumableStatus(ItemInfo info)
        {
            if (info.Consumable)
            {
                if (non_consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    non_consumables.Remove(info);
                if (consumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    consumables.Add(info);
            }
            else
            {
                if (consumables.FirstOrDefault(x => x.Name == info.Name) != null)
                    consumables.Remove(info);
                if (non_consumables.FirstOrDefault(x => x.Name == info.Name) == null)
                    non_consumables.Add(info);
            }
            return;
        }
        private string _ColloquialName = null;
        [JsonProperty("colloq")]
        public string ColloquialName
        {
            get
            {
                return this._ColloquialName;
            }
            private set
            {
                this._ColloquialName = value;
                return;
            }
        }
        private bool _Consumable = false;
        [JsonProperty("consumed")]
        public bool Consumable
        {
            get
            {
                return this._Consumable;
            }
            set
            {
                this._Consumable = value;
                ItemInfo.UpdateConsumableStatus(this);
                return;
            }
        }
        private string _Description = null;
        [JsonProperty("sanitizedDescription")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            private set
            {
                this._Description = value;
                return;
            }
        }
        private bool _HideFromAll = false;
        [JsonProperty("hideFromAll")]
        public bool HideFromAll
        {
            get
            {
                return this._HideFromAll;
            }
            private set
            {
                this._HideFromAll = value;
                return;
            }
        }
        private int _ID = -1;
        [JsonProperty("id")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
                return;
            }
        }
        public Bitmap Image
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private bool _IsInStore = false;
        [JsonProperty("inStore")]
        public bool IsInStore
        {
            get
            {
                return this._IsInStore;
            }
            private set
            {
                this._IsInStore = value;
                return;
            }
        }
        private Dictionary<string, bool> _Maps = new Dictionary<string, bool>();
        [JsonProperty("maps", ItemIsReference = true)]
        public Dictionary<string, bool> Maps
        {
            get
            {
                return this._Maps;
            }
            private set
            {
                this._Maps = value;
                return;
            }
        }
        private string _Name = null;
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
                return;
            }
        }
        private string _RequiredChampion = null;
        [JsonProperty("requiredChampion")]
        public string RequiredChampion
        {
            get
            {
                return this._RequiredChampion;
            }
            private set
            {
                this._RequiredChampion = value;
                return;
            }
        }
        public ItemInfo()
        {
            ItemInfo.UpdateConsumableStatus(this);
            return;
        }
        ~ItemInfo()
        {
            ItemInfo.RemoveReference(this);
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class MapInfo
    {
        private long _ID = -1;
        [JsonProperty("mapId")]
        public long ID
        {
            get
            {
                return this._ID;
            }
            private set
            {
                this._ID = value;
                return;
            }
        }
        public Bitmap Image
        {
            get
            {
                switch (this.Name)
                {
                    case "Howling Abyss":
                        return RiotPls.Properties.Resources.HowlingAbyss;
                    case "Summoner's Rift":
                        return RiotPls.Properties.Resources.SummonersRift;
                    case "Twisted Treeline":
                        return RiotPls.Properties.Resources.TwistedTreeline;
                    default:
                        break;
                }
                return null;

            }
        }
        public Bitmap InternalImage
        {
            get
            {
                return this.ImageData.Image;
            }
        }
        private ImageInfo _ImageData = null;
        [JsonProperty("image", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public ImageInfo ImageData
        {
            get
            {
                return this._ImageData;
            }
            private set
            {
                this._ImageData = value;
                return;
            }
        }
        private string _InternalName = null;
        [JsonProperty("mapName")]
        public string InternalName
        {
            get
            {
                return this._InternalName;
            }
            private set
            {
                this._InternalName = value;
                switch (this.InternalName)
                {
                    case "NewTwistedTreeline":
                        this.Name = "Twisted Treeline";
                        break;
                    case "SummonersRift":
                        this.Name = "Old Summoner's Rift";
                        break;
                    case "SummonersRiftNew":
                        this.Name = "Summoner's Rift";
                        break;
                    case "ProvingGroundsNew":
                        this.Name = "Howling Abyss";
                        break;
                    default:
                        this.Name = "Unknown";
                        break;
                }
                return;
            }
        }
        private string _Name = null;
        public string Name
        {
            get
            {
                return this._Name;
            }
            private set
            {
                this._Name = value;
                return;
            }
        }
        private List<long> _ProhibitedItems = new List<long>();
        [JsonProperty("unpurchasableItemList")]
        public List<long> ProhibitedItems
        {
            get
            {
                return new List<long>(this._ProhibitedItems);
            }
            private set
            {
                this._ProhibitedItems = value;
                return;
            }
        }
    }
    public abstract class RiotAPI
    {
        #region Types
        public enum Regions : int { NorthAmerica = 0 };
        #endregion
        #region Static Members
        #region Constants
        private const string REGION_NA = "na";
        private const string BASE_URL = "https://na.api.pvp.net/";
        private const string APIURL_LIVE = "api/lol/";
        private const string APIURL_STATIC = "api/lol/static-data/";
        private const string FILE_APIKEY = "key.txt";
        private const string FILE_CHAMPIONINFO = "ChampionInfo.json";
        private const string FILE_ITEMINFO = "ItemInfo.json";
        private const string FILE_MAPINFO = "MapInfo.json";
        private const string PARAM_ALLITEMDATA = "itemListData=all";
        private const string PARAM_ALLCHAMPDATA = "champData=all";
        public const string IMGURL = "http://ddragon.leagueoflegends.com/cdn/5.1.1/img/";
        #endregion
        private static List<LiveChampionInfo> live_champion_info = new List<LiveChampionInfo>();
        private static string region_string = "na";
        private static string version_string = "v1.2";
        #endregion
        #region Static Properties
        private static string _APIKey = "api_key=0";
        public static string APIKey
        {
            get
            {
                return RiotAPI._APIKey;
            }
            set
            {
                RiotAPI._APIKey = value;
            }
        }
        private static Dictionary<string, ChampionInfo> _ChampionInfos = new Dictionary<string, ChampionInfo>();
        public static Dictionary<string, ChampionInfo> ChampionInfos
        {
            get
            {
                return RiotAPI._ChampionInfos;
            }
        }
        private static Dictionary<string, ItemInfo> _ItemInfos = new Dictionary<string, ItemInfo>();
        public static Dictionary<string, ItemInfo> ItemInfos
        {
            get
            {
                return RiotAPI._ItemInfos;
            }
        }
        private static string LiveChampionDataURL
        {
            get
            {
                return RiotAPI.BASE_URL + RiotAPI.APIURL_LIVE + RiotAPI.region_string + "/" + RiotAPI.version_string + "/champion?" + RiotAPI.APIKey;
            }
        }
        private static Dictionary<string, MapInfo> _MapInfos = new Dictionary<string, MapInfo>();
        public static Dictionary<string, MapInfo> MapInfos
        {
            get
            {
                return RiotAPI._MapInfos;
            }
        }
        private static Regions _Region = Regions.NorthAmerica;
        public static Regions Region
        {
            get
            {
                return RiotAPI._Region;
            }
            set
            {
                RiotAPI._Region = value;
                switch (RiotAPI.Region)
                {
                    case Regions.NorthAmerica:
                        RiotAPI.region_string = RiotAPI.REGION_NA;
                        break;
                    default:
                        break;
                }
                return;
            }
        }
        private static string StaticChampionDataURL
        {
            get
            {
                return RiotAPI.BASE_URL + RiotAPI.APIURL_STATIC + RiotAPI.region_string + "/" + RiotAPI.version_string + "/champion?" + RiotAPI.PARAM_ALLCHAMPDATA + "&" + RiotAPI.APIKey;
            }
        }
        private static string StaticItemDataURL
        {
            get
            {
                return RiotAPI.BASE_URL + RiotAPI.APIURL_STATIC + RiotAPI.region_string + "/" + RiotAPI.version_string + "/item?" + RiotAPI.PARAM_ALLITEMDATA + "&" + RiotAPI.APIKey;
            }
        }
        private static string StaticMapDataURL
        {
            get
            {
                return RiotAPI.BASE_URL + RiotAPI.APIURL_STATIC + RiotAPI.region_string + "/" + RiotAPI.version_string + "/map?&" + RiotAPI.APIKey;
            }
        }
        #endregion
        #region Static Methods
        public static string CleanseChampionName(Dictionary<string, ChampionInfo> info, string name)
        {
            KeyValuePair<string, ChampionInfo> pair = info.FirstOrDefault(i => i.Value.Name == name);
            return pair.Equals(default(KeyValuePair<string, ChampionInfo>)) ? null : pair.Key;
        }
        public static Dictionary<string, ChampionInfo> GetChampionInfo()
        {
            //
            bool attempt_download = !File.Exists(RiotAPI.FILE_CHAMPIONINFO);
            string json_string = attempt_download ? RiotAPI.GetChampionInfo_Download() : File.ReadAllText(RiotAPI.FILE_CHAMPIONINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }    
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = RiotAPI.GetChampionInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }  
            }
            if (!parsing_error)
            {                          
                if(attempt_download)
                    File.WriteAllText(RiotAPI.FILE_CHAMPIONINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                RiotAPI._ChampionInfos = JsonConvert.DeserializeObject<Dictionary<string, ChampionInfo>>(result.ToString(), settings);
                //
                RiotAPI.UpdateLiveChampionInfo();
            }
            //
            return RiotAPI.ChampionInfos;
        }
        private static string GetChampionInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(RiotAPI.StaticChampionDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
        }
        public static Dictionary<string, ItemInfo> GetItemInfo()
        {
            //
            bool attempt_download = !File.Exists(RiotAPI.FILE_ITEMINFO);
            string json_string = attempt_download ? RiotAPI.GetItemInfo_Download() : File.ReadAllText(RiotAPI.FILE_ITEMINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = RiotAPI.GetItemInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }
            }
            if (!parsing_error)
            {
                if (attempt_download)
                    File.WriteAllText(RiotAPI.FILE_ITEMINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                RiotAPI._ItemInfos = JsonConvert.DeserializeObject<Dictionary<string, ItemInfo>>(result.ToString(), settings);
            }
            //
            return RiotAPI.ItemInfos;
        }
        private static string GetItemInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(RiotAPI.StaticItemDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
        }
        public static Dictionary<string, MapInfo> GetMapInfo()
        {
            //
            bool attempt_download = !File.Exists(RiotAPI.FILE_MAPINFO);
            string json_string = attempt_download ? RiotAPI.GetMapInfo_Download() : File.ReadAllText(RiotAPI.FILE_MAPINFO);
            bool parsing_error = false;
            JObject data = null;
            try
            {
                data = JObject.Parse(json_string);
            }
            catch
            {
                parsing_error = true;
            }
            if (!attempt_download && parsing_error)
            {
                attempt_download = true;
                parsing_error = false;
                json_string = RiotAPI.GetMapInfo_Download();
                try
                {
                    data = JObject.Parse(json_string);
                }
                catch
                {
                    parsing_error = true;
                }
            }
            if (!parsing_error)
            {
                if (attempt_download)
                    File.WriteAllText(RiotAPI.FILE_MAPINFO, json_string);
                //
                JToken result = data.SelectToken("data");
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                RiotAPI._MapInfos = JsonConvert.DeserializeObject<Dictionary<string, MapInfo>>(result.ToString(), settings);
            }
            //
            return RiotAPI.MapInfos;
        }
        private static string GetMapInfo_Download()
        {
            string json_string = null;
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(RiotAPI.StaticMapDataURL) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            try
            {
                json_string = stream_reader.ReadToEnd();
            }
            catch
            {
                json_string = null;
            }
            stream_reader.Close();
            return json_string;
        }
        public static bool LoadKey()
        {
            RiotAPI.APIKey = "api_key=0";
            if (!File.Exists(RiotAPI.FILE_APIKEY))
                return false;
            try
            {
                RiotAPI.APIKey = "api_key=" + File.ReadAllText(RiotAPI.FILE_APIKEY);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private static void UpdateLiveChampionInfo()
        {
            HttpWebRequest request = HttpWebRequest.Create(RiotAPI.LiveChampionDataURL) as HttpWebRequest;
            StreamReader stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            JObject data = JObject.Parse(stream_reader.ReadToEnd());
            stream_reader.Close();
            //
            JToken result = data.SelectToken("champions");
            RiotAPI.live_champion_info = JsonConvert.DeserializeObject<List<LiveChampionInfo>>(result.ToString());
            foreach(string s in RiotAPI.ChampionInfos.Keys)
            {
                ChampionInfo current_info = RiotAPI.ChampionInfos[s];
                current_info.LiveInfo = RiotAPI.live_champion_info.FirstOrDefault(info => info.ID == current_info.ID);
            }
            return;
        }
        #endregion
    }
}

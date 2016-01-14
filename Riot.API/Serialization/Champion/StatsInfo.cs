using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champion
{
    [JsonObject(MemberSerialization.OptIn)]
    public class StatsInfo
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
        public StatsInfo()
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
}

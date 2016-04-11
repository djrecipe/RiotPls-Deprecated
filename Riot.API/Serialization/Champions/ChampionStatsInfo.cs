using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;
                                           
[assembly: InternalsVisibleTo("RiotPls.Test")]
namespace RiotPls.API.Serialization.Champions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChampionStatsInfo : GeneralStatsInfo
    {
        [JsonProperty("armor")]
        public override double Armor
        {
            get
            {
                return base.Armor;
            }
            internal set
            {
                base.Armor = value;
                return;
            }
        }
        [JsonProperty("armorperlevel")]
        public override double ArmorPerLevel
        {
            get
            {
                return base.ArmorPerLevel;
            }
            internal set
            {
                base.ArmorPerLevel = value;
                return;
            }
        }
        [JsonProperty("attackdamage")]
        public override double AttackDamage
        {
            get
            {
                return base.AttackDamage;
            }
            internal set
            {
                base.AttackDamage = value;
                return;
            }
        }
        [JsonProperty("attackdamageperlevel")]
        public override double AttackDamagePerLevel
        {
            get
            {
                return base.AttackDamagePerLevel;
            }
            internal set
            {
                base.AttackDamagePerLevel = value;
            }
        }
        [JsonProperty("attackrange")]
        public override double AttackRange
        {
            get
            {
                return base.AttackRange;
            }
            internal set
            {
                base.AttackRange = value;
                return;
            }
        }
        public override double AttackSpeedBase { get; protected set; } = 0.625;
        [JsonProperty("attackspeedoffset")]
        public override double AttackSpeedOffset
        {
            get
            {
                return base.AttackSpeedOffset;
            }
            internal set
            {
                base.AttackSpeedOffset= value;
                return;
            }
        }
        [JsonProperty("attackspeedperlevel")]
        public override double AttackSpeedPerLevel
        {
            get
            {
                return base.AttackSpeedPerLevel;
            }
            internal set
            {
                base.AttackSpeedPerLevel = value;
                return;
            }
        }
        [JsonProperty("crit")]
        public override double CriticalStrike
        {
            get
            {
                return base.CriticalStrike;
            }
            internal set
            {
                base.CriticalStrike = value;
                return;
            }
        }
        [JsonProperty("critperlevel")]
        public override double CriticalStrikePerLevel
        {
            get
            {
                return base.CriticalStrikePerLevel;
            }
            internal set
            {
                base.CriticalStrikePerLevel = value;
                return;
            }
        }
        [JsonProperty("hp")]
        public override double Health
        {
            get
            {
                return base.Health;
            }
            internal set
            {
                base.Health = value;
                return;
            }
        }
        [JsonProperty("hpperlevel")]
        public override double HealthPerLevel
        {
            get
            {
                return base.HealthPerLevel;
            }
            internal set
            {
                base.HealthPerLevel = value;
                return;
            }
        }
        [JsonProperty("hpregen")]
        public override double HealthRegen
        {
            get
            {
                return base.HealthRegen;
            }
            internal set
            {
                base.HealthRegen = value;
                return;
            }
        }
        [JsonProperty("hpregenperlevel")]
        public override double HealthRegenPerLevel
        {
            get
            {
                return base.HealthRegenPerLevel;
            }
            internal set
            {
                base.HealthRegenPerLevel = value;
                return;
            }
        }
        [JsonProperty("movespeed")]
        public override double MovementSpeed
        {
            get
            {
                return base.MovementSpeed;
            }
            internal set
            {
                base.MovementSpeed = value;
                return;
            }
        }
        [JsonProperty("mp")]
        public override double Resource
        {
            get
            {
                return base.Resource;
            }
            internal set
            {
                base.Resource = value;
                return;
            }
        }
        [JsonProperty("mpperlevel")]
        public override double ResourcePerLevel
        {
            get
            {
                return base.ResourcePerLevel;
            }
            internal set
            {
                base.ResourcePerLevel = value;
                return;
            }
        }
        [JsonProperty("mpregen")]
        public override double ResourceRegen
        {
            get
            {
                return base.ResourceRegen;
            }
            internal set
            {
                base.ResourceRegen = value;
                return;
            }
        }
        [JsonProperty("mpregenperlevel")]
        public override double ResourceRegenPerLevel
        {
            get
            {
                return base.ResourceRegenPerLevel;
            }
            internal set
            {
                base.ResourceRegenPerLevel = value;
                return;
            }
        }
        [JsonProperty("spellblock")]
        public override double MagicResist
        {
            get
            {
                return base.MagicResist;
            }
            internal set
            {
                base.MagicResist = value;
                return;
            }
        }
        [JsonProperty("spellblockperlevel")]
        public override double MagicResistPerLevel
        {
            get
            {
                return base.MagicResistPerLevel;
            }
            internal set
            {
                base.MagicResistPerLevel = value;
                return;
            }
        }
    }
}

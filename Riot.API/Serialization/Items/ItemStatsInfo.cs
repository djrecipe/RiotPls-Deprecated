using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RiotPls.API.Serialization.General;

[assembly: InternalsVisibleTo("RiotPls.Test")]

namespace RiotPls.API.Serialization.Items
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemStatsInfo : GeneralStatsInfo
    {
        [JsonProperty("FlatMagicDamageMod")]
        public override double AbilityPower
        {
            get { return base.AbilityPower; }
            internal set
            {
                base.AbilityPower = value;
                return;
            }
        }
        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public override double AbilityPowerPerLevel
        {
            get { return base.AbilityPowerPerLevel; }
            internal set
            {
                base.AbilityPowerPerLevel = value;
            }
        }
        [JsonProperty("FlatArmorMod")]
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
        [JsonProperty("rFlatArmorPenetrationMod")]
        public override double ArmorPenFlat
        {
            get
            {
                return base.ArmorPenFlat;
            }
            internal set
            {
                base.ArmorPenFlat = value;
                return;
            }
        }
        [JsonProperty("rFlatArmorModPerLevel")]
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
        [JsonProperty("FlatPhysicalDamageMod")]
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
        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
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
        [JsonProperty("FlatAttackSpeedMod")]
        public override double AttackSpeed
        {
            get
            {
                return base.AttackSpeed;
            }
            internal set
            {
                base.AttackSpeed = value;
                return;
            }
        }
        public override double AttackSpeedBase { get; protected set; } = 0.0;
        [JsonProperty("rPercentAttackSpeedModPerLevel")]
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
        [JsonProperty("PercentAttackSpeedMod")]
        public override double AttackSpeedMultiplier
        {
            get
            {
                return base.AttackSpeedMultiplier;
            }
            internal set
            {
                base.AttackSpeedMultiplier = 1.0 + value;
                return;
            }
        }
        [JsonProperty("rPercentCooldownMod")]
        public override double CooldownReduction
        {
            get
            {
                return base.CooldownReduction;
            }
            internal set
            {
                base.CooldownReduction = value;
                return;
            }
        }
        [JsonProperty("FlatCritChanceMod")]
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
        [JsonProperty("rFlatCritChanceModPerLevel")]
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
        [JsonProperty("FlatHPPoolMod")]
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
        [JsonProperty("rFlatHPModPerLevel")]
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
        [JsonProperty("FlatHPRegenMod")]
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
        [JsonProperty("rFlatHPRegenModPerLevel")]
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
        [JsonProperty("rFlatMagicPenetrationMod")]
        public override double MagicPenFlat
        {
            get
            {
                return base.MagicPenFlat;
            }
            internal set
            {
                base.MagicPenFlat = value;
                return;
            }
        }
        [JsonProperty("rPercentMagicPenetrationMod")]
        public override double MagicPenPerc
        {
            get
            {
                return base.MagicPenPerc;
            }
            internal set
            {
                base.MagicPenPerc = value;
                return;
            }
        }
        [JsonProperty("FlatSpellBlockMod")]
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
        [JsonProperty("rFlatSpellBlockModPerLevel")]
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
        [JsonProperty("FlatMovementSpeedMod")]
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
        [JsonProperty("FlatMPPoolMod")]
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
        [JsonProperty("rFlatMPModPerLevel")]
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
        [JsonProperty("FlatMPRegenMod")]
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
        [JsonProperty("rFlatMPRegenModPerLevel")]
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

        internal ItemStatsInfo() : base()
        {
            
        }
    }
}

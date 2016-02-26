using System.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RiotPls.Test")]

namespace RiotPls.API.Serialization.General
{
    public class GeneralStatsInfo
    {
        #region Static Methods
        public static GeneralStatsInfo operator +(GeneralStatsInfo x, GeneralStatsInfo y)
        {
            x.AbilityPower = x.AbilityPower + y.AbilityPower;
            x.AbilityPowerPerLevel = x.AbilityPowerPerLevel + y.AbilityPowerPerLevel;
            x.Armor = x.Armor + y.Armor;
            x.ArmorPerLevel = x.ArmorPerLevel + y.ArmorPerLevel;
            x.AttackDamage = x.AttackDamage + y.AttackDamage;
            x.AttackDamagePerLevel = x.AttackDamagePerLevel + y.AttackDamagePerLevel;
            x.AttackRange = x.AttackRange + y.AttackRange;
            x.AttackSpeed = x.AttackSpeed + y.AttackSpeed;
            x.AttackSpeedOffset = x.AttackSpeedOffset + y.AttackSpeedOffset;
            x.AttackSpeedPerLevel = x.AttackSpeedPerLevel + y.AttackSpeedPerLevel;
            x.CriticalStrike = x.CriticalStrike + y.CriticalStrike;
            x.CriticalStrikePerLevel = x.CriticalStrikePerLevel + y.CriticalStrikePerLevel;
            x.Health = x.Health + y.Health;
            x.HealthPerLevel = x.HealthPerLevel + y.HealthPerLevel;
            x.HealthRegen = x.HealthRegen + y.HealthRegen;
            x.HealthRegenPerLevel = x.HealthRegenPerLevel + y.HealthRegenPerLevel;
            x.MagicResist = x.MagicResist + y.MagicResist;
            x.MagicResistPerLevel = x.MagicResistPerLevel + y.MagicResistPerLevel;
            x.MovementSpeed = x.MovementSpeed + y.MovementSpeed;
            x.Resource = x.Resource + y.Resource;
            x.ResourcePerLevel = x.ResourcePerLevel + y.ResourcePerLevel;
            x.ResourceRegen = x.ResourceRegen + y.ResourceRegen;
            x.ResourceRegenPerLevel = x.ResourceRegenPerLevel + y.ResourceRegenPerLevel;

            return x;
        }

        #endregion
        #region Instance Properties
        public virtual double AbilityPower
        {
            get
            {
                return (double)this.Stats.Rows[0]["AbilityPower"];
            }
            internal set
            {
                this.Stats.Rows[0]["AbilityPower"] = value;
                this.InitializeAbilityPowerRows();
                return;
            }
        }
        public virtual double AbilityPowerPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["AbilityPower"];
            }
            internal set
            {
                this.Stats.Rows[1]["AbilityPower"] = value;
                this.InitializeAbilityPowerRows();
            }
        }
        public virtual double Armor
        {
            get
            {
                return (double)this.Stats.Rows[0]["Armor"];
            }
            internal set
            {
                this.Stats.Rows[0]["Armor"] = value;
                this.InitializeArmorRows();
                return;
            }
        }
        public virtual double ArmorPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Armor"];
            }
            internal set
            {
                this.Stats.Rows[1]["Armor"] = value;
                this.InitializeArmorRows();
                return;
            }
        }
        public virtual double AttackDamage
        {
            get
            {
                return (double)this.Stats.Rows[0]["AttackDamage"];
            }
            internal set
            {
                this.Stats.Rows[0]["AttackDamage"] = value;
                this.InitializeAttackDamageRows();
                return;
            }
        }
        public virtual double AttackDamagePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["AttackDamage"];
            }
            internal set
            {
                this.Stats.Rows[1]["AttackDamage"] = value;
                this.InitializeAttackDamageRows();
            }
        }
        public virtual double AttackRange
        {
            get
            {
                return (double)this.Stats.Rows[0]["AttackRange"];
            }
            internal set
            {
                this.Stats.Rows[0]["AttackRange"] = value;
                this.InitializeAttackRangeRows();
                return;
            }
        }
        public virtual double AttackSpeed
        {
            get
            {
                return (double)this.Stats.Rows[0]["AttackSpeed"];
            }
            internal set
            {
                this.Stats.Rows[0]["AttackSpeed"] = value;
                this.InitializeAttackSpeedRows();
                return;
            }
        }
        private double _AttackSpeedOffset = 0;
        public virtual double AttackSpeedOffset
        {
            get
            {
                return this._AttackSpeedOffset;
            }
            internal set
            {
                this._AttackSpeedOffset = value;
                this.AttackSpeed = 0.625 / (1.0 + value);
                return;
            }
        }
        public virtual double AttackSpeedPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["AttackSpeed"];
            }
            internal set
            {
                this.Stats.Rows[1]["AttackSpeed"] = value;
                this.InitializeAttackSpeedRows();
                return;
            }
        }
        public virtual double CriticalStrike
        {
            get
            {
                return (double)this.Stats.Rows[0]["CriticalStrike"];
            }
            internal set
            {
                this.Stats.Rows[0]["CriticalStrike"] = value;
                this.InitializeCriticalStrikeRows();
                return;
            }
        }
        public virtual double CriticalStrikePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["CriticalStrike"];
            }
            internal set
            {
                this.Stats.Rows[1]["CriticalStrike"] = value;
                this.InitializeCriticalStrikeRows();
                return;
            }
        }
        public virtual double Health
        {
            get
            {
                return (double)this.Stats.Rows[0]["Health"];
            }
            internal set
            {
                this.Stats.Rows[0]["Health"] = value;
                this.InitializeHealthRows();
                return;
            }
        }
        public virtual double HealthPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Health"];
            }
            internal set
            {
                this.Stats.Rows[1]["Health"] = value;
                this.InitializeHealthRows();
                return;
            }
        }
        public virtual double HealthRegen
        {
            get
            {
                return (double)this.Stats.Rows[0]["HealthRegen"];
            }
            internal set
            {
                this.Stats.Rows[0]["HealthRegen"] = value;
                this.InitializeHealthRegenRows();
                return;
            }
        }
        public virtual double HealthRegenPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["HealthRegen"];
            }
            internal set
            {
                this.Stats.Rows[1]["HealthRegen"] = value;
                this.InitializeHealthRegenRows();
                return;
            }
        }
        public virtual double MagicResist
        {
            get
            {
                return (double)this.Stats.Rows[0]["MagicResist"];
            }
            internal set
            {
                this.Stats.Rows[0]["MagicResist"] = value;
                this.InitializeMagicResistRows();
                return;
            }
        }
        public virtual double MagicResistPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["MagicResist"];
            }
            internal set
            {
                this.Stats.Rows[1]["MagicResist"] = value;
                this.InitializeMagicResistRows();
                return;
            }
        }
        public virtual double MovementSpeed
        {
            get
            {
                return (double)this.Stats.Rows[0]["MovementSpeed"];
            }
            internal set
            {
                this.Stats.Rows[0]["MovementSpeed"] = value;
                this.InitializeMovementSpeedRows();
                return;
            }
        }
        public virtual double Resource
        {
            get
            {
                return (double)this.Stats.Rows[0]["Resource"];
            }
            internal set
            {
                this.Stats.Rows[0]["Resource"] = value;
                this.InitializeResourceRows();
                return;
            }
        }
        public virtual double ResourcePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Resource"];
            }
            internal set
            {
                this.Stats.Rows[1]["Resource"] = value;
                this.InitializeResourceRows();
                return;
            }
        }
        public virtual double ResourceRegen
        {
            get
            {
                return (double)this.Stats.Rows[0]["ResourceRegen"];
            }
            internal set
            {
                this.Stats.Rows[0]["ResourceRegen"] = value;
                this.InitializeResourceRegenRows();
                return;
            }
        }
        public virtual double ResourceRegenPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["ResourceRegen"];
            }
            internal set
            {
                this.Stats.Rows[1]["ResourceRegen"] = value;
                this.InitializeResourceRegenRows();
                return;
            }
        }
        public StatsTable.StatsDataTable Stats => this.Table.Stats;
        public StatsTable Table { get; private set; } = new StatsTable();
        #endregion
        #region Instance Methods
        internal GeneralStatsInfo()
        {
            for (int i = 0; i < 19; i++)
                this.Stats.AddStatsRow(this.Stats.NewStatsRow());
            return;
        }
        private void InitializeAbilityPowerRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AbilityPower"] = (double)this.Stats[0]["AbilityPower"] + (double)this.Stats[1]["AbilityPower"] * (double)i;
            return;
        }
        private void InitializeArmorRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Armor"] = (double)this.Stats[0]["Armor"] + (double)this.Stats[1]["Armor"] * (double)i;
            return;
        }
        private void InitializeAttackDamageRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackDamage"] = (double)this.Stats[0]["AttackDamage"] + (double)this.Stats[1]["AttackDamage"] * (double)i;
            return;
        }
        private void InitializeAttackRangeRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackRange"] = (double)this.Stats[0]["AttackRange"] + (double)this.Stats[1]["AttackRange"] * (double)i;
            return;
        }
        private void InitializeAttackSpeedRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["AttackSpeed"] = (double)this.Stats[0]["AttackSpeed"] + (double)this.Stats[1]["AttackSpeed"] * (double)i;
            return;
        }
        private void InitializeCriticalStrikeRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["CriticalStrike"] = (double)this.Stats[0]["CriticalStrike"] + (double)this.Stats[1]["CriticalStrike"] * (double)i;
            return;
        }
        private void InitializeHealthRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Health"] = (double)this.Stats[0]["Health"] + (double)this.Stats[1]["Health"] * (double)i;
            return;
        }
        private void InitializeHealthRegenRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["HealthRegen"] = (double)this.Stats[0]["HealthRegen"] + (double)this.Stats[1]["HealthRegen"] * (double)i;
            return;
        }
        private void InitializeMagicResistRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["MagicResist"] = (double)this.Stats[0]["MagicResist"] + (double)this.Stats[1]["MagicResist"] * (double)i;
            return;
        }
        private void InitializeMovementSpeedRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["MovementSpeed"] = (double)this.Stats[0]["MovementSpeed"] + (double)this.Stats[1]["MovementSpeed"] * (double)i;
            return;
        }
        private void InitializeResourceRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["Resource"] = (double)this.Stats[0]["Resource"] + (double)this.Stats[1]["Resource"] * (double)i;
            return;
        }
        private void InitializeResourceRegenRows()
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i]["ResourceRegen"] = (double)this.Stats[0]["ResourceRegen"] + (double)this.Stats[1]["ResourceRegen"] * (double)i;
            return;
        }
        #endregion
    }
}

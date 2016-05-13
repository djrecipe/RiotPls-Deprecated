using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using RiotPls.API.Serialization.Attributes;
using RiotPls.API.Serialization.Interfaces;

[assembly: InternalsVisibleTo("RiotPls.Test")]

namespace RiotPls.API.Serialization.General
{
    /// <summary>
    /// Generic stat collection for a single game entity
    /// </summary>
    public abstract class GeneralStatsInfo : IStatsInfo
    {
        #region Static Methods
        public static CombinedStatsInfo operator +(GeneralStatsInfo x, GeneralStatsInfo y)
        {
            CombinedStatsInfo info = new CombinedStatsInfo();
            info += x;
            info += y;
            return info;
        }

        #endregion
        #region Instance Properties
        [Statistic("AbilityPower")]
        public virtual double AbilityPower
        {
            get
            {
                return (double)this.Stats.Rows[0]["AbilityPower"];
            }
            internal set
            {
                this.Stats.Rows[0]["AbilityPower"] = value;
                this.InitializeGenericRows("AbilityPower");
                return;
            }
        }
        [Statistic("AbilityPower")]
        public virtual double AbilityPowerPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["AbilityPower"];
            }
            internal set
            {
                this.Stats.Rows[1]["AbilityPower"] = value;
                this.InitializeGenericRows("AbilityPower");
            }
        }
        [Statistic("Armor")]
        public virtual double Armor
        {
            get
            {
                return (double)this.Stats.Rows[0]["Armor"];
            }
            internal set
            {
                this.Stats.Rows[0]["Armor"] = value;
                this.InitializeGenericRows("Armor");
                return;
            }
        }
        [Statistic("Armor")]
        public virtual double ArmorPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Armor"];
            }
            internal set
            {
                this.Stats.Rows[1]["Armor"] = value;
                this.InitializeGenericRows("Armor");
                return;
            }
        }
        [Statistic("ArmorPenFlat", IsFromDescription = true)]
        public virtual double ArmorPenFlat
        {
            get
            {
                return (double)this.Stats.Rows[0]["ArmorPenFlat"];
            }
            internal set
            {
                this.Stats.Rows[0]["ArmorPenFlat"] = value;
                this.InitializeGenericRows("ArmorPenFlat");
                return;
            }
        }
        [Statistic("ArmorPenPerc", IsFromDescription=true)]
        public virtual double ArmorPenPerc
        {
            get
            {
                return (double)this.Stats.Rows[0]["ArmorPenPerc"];
            }
            internal set
            {
                this.Stats.Rows[0]["ArmorPenPerc"] = value;
                this.InitializeGenericRows("ArmorPenPerc");
                return;
            }
        }
        [Statistic("AttackDamage")]
        public virtual double AttackDamage
        {
            get
            {
                return (double)this.Stats.Rows[0]["AttackDamage"];
            }
            internal set
            {
                this.Stats.Rows[0]["AttackDamage"] = value;
                this.InitializeGenericRows("AttackDamage");
                return;
            }
        }
        [Statistic("AttackDamage")]
        public virtual double AttackDamagePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["AttackDamage"];
            }
            internal set
            {
                this.Stats.Rows[1]["AttackDamage"] = value;
                this.InitializeGenericRows("AttackDamage");
            }
        }
        [Statistic("AttackRange")]
        public virtual double AttackRange
        {
            get
            {
                return (double)this.Stats.Rows[0]["AttackRange"];
            }
            internal set
            {
                this.Stats.Rows[0]["AttackRange"] = value;
                this.InitializeGenericRows("AttackRange");
                return;
            }
        }
        [Statistic("AttackSpeed", IsGeneric = false)]
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

        private double _AttackSpeedBase = 0.0;
        [Statistic("AttackSpeed", IsGeneric = false)]
        public virtual double AttackSpeedBase
        {
            get { return this._AttackSpeedBase; }
            internal set
            {
                this._AttackSpeedBase = value;
                this.UpdateAttackSpeed();
            }
        }
        [Statistic("AttackSpeed", IsGeneric = false)]
        public double AttackSpeedCap => 2.5;
        private double _AttackSpeedOffset = 0;
        [Statistic("AttackSpeed", IsGeneric = false)]
        public virtual double AttackSpeedOffset
        {
            get
            {
                return this._AttackSpeedOffset;
            }
            internal set
            {
                this._AttackSpeedOffset = value;
                this.UpdateAttackSpeed();
                return;
            }
        }
        private double _AttackSpeedMultiplier = 1.0;
        [Statistic("AttackSpeed", IsGeneric = false)]
        public virtual double AttackSpeedMultiplier
        {
            get
            {
                return this._AttackSpeedMultiplier;
            }
            internal set
            {
                this._AttackSpeedMultiplier = value;
                this.InitializeAttackSpeedRows();
                return;
            }
        }
        [Statistic("AttackSpeed", IsGeneric = false)]
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
        [Statistic("CooldownReduction", IsFromDescription = true)]
        public virtual double CooldownReduction
        {
            get
            {
                return (double)this.Stats.Rows[0]["CooldownReduction"];
            }
            internal set
            {
                this.Stats.Rows[0]["CooldownReduction"] = value;
                this.InitializeGenericRows("CooldownReduction");
                return;
            }
        }
        [Statistic("CriticalStrike")]
        public virtual double CriticalStrike
        {
            get
            {
                return (double)this.Stats.Rows[0]["CriticalStrike"];
            }
            internal set
            {
                this.Stats.Rows[0]["CriticalStrike"] = value;
                this.InitializeGenericRows("CriticalStrike");
                return;
            }
        }
        [Statistic("CriticalStrike")]
        public virtual double CriticalStrikePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["CriticalStrike"];
            }
            internal set
            {
                this.Stats.Rows[1]["CriticalStrike"] = value;
                this.InitializeGenericRows("CriticalStrike");
                return;
            }
        }
        [Statistic("Health")]
        public virtual double Health
        {
            get
            {
                return (double)this.Stats.Rows[0]["Health"];
            }
            internal set
            {
                this.Stats.Rows[0]["Health"] = value;
                this.InitializeGenericRows("Health");
                return;
            }
        }
        [Statistic("Health")]
        public virtual double HealthPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Health"];
            }
            internal set
            {
                this.Stats.Rows[1]["Health"] = value;
                this.InitializeGenericRows("Health");
                return;
            }
        }
        [Statistic("HealthRegen")]
        public virtual double HealthRegen
        {
            get
            {
                return (double)this.Stats.Rows[0]["HealthRegen"];
            }
            internal set
            {
                this.Stats.Rows[0]["HealthRegen"] = value;
                this.InitializeGenericRows("HealthRegen");
                return;
            }
        }
        [Statistic("HealthRegen")]
        public virtual double HealthRegenPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["HealthRegen"];
            }
            internal set
            {
                this.Stats.Rows[1]["HealthRegen"] = value;
                this.InitializeGenericRows("HealthRegen");
                return;
            }
        }
        [Statistic("MagicPenFlat", IsFromDescription = true)]
        public virtual double MagicPenFlat
        {
            get
            {
                return (double)this.Stats.Rows[0]["MagicPenFlat"];
            }
            internal set
            {
                this.Stats.Rows[0]["MagicPenFlat"] = value;
                this.InitializeGenericRows("MagicPenFlat");
                return;
            }
        }
        [Statistic("MagicPenPerc", IsFromDescription = true)]
        public virtual double MagicPenPerc
        {
            get
            {
                return (double)this.Stats.Rows[0]["MagicPenPerc"];
            }
            internal set
            {
                this.Stats.Rows[0]["MagicPenPerc"] = value;
                this.InitializeGenericRows("MagicPenPerc");
                return;
            }
        }
        [Statistic("MagicResist")]
        public virtual double MagicResist
        {
            get
            {
                return (double)this.Stats.Rows[0]["MagicResist"];
            }
            internal set
            {
                this.Stats.Rows[0]["MagicResist"] = value;
                this.InitializeGenericRows("MagicResist");
                return;
            }
        }
        [Statistic("MagicResist")]
        public virtual double MagicResistPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["MagicResist"];
            }
            internal set
            {
                this.Stats.Rows[1]["MagicResist"] = value;
                this.InitializeGenericRows("MagicResist");
                return;
            }
        }
        [Statistic("MovementSpeed")]
        public virtual double MovementSpeed
        {
            get
            {
                return (double)this.Stats.Rows[0]["MovementSpeed"];
            }
            internal set
            {
                this.Stats.Rows[0]["MovementSpeed"] = value;
                this.InitializeGenericRows("MovementSpeed");
                return;
            }
        }
        public virtual int RequiredLevel { get; set; } = 1;
        [Statistic("Resource")]
        public virtual double Resource
        {
            get
            {
                return (double)this.Stats.Rows[0]["Resource"];
            }
            internal set
            {
                this.Stats.Rows[0]["Resource"] = value;
                this.InitializeGenericRows("Resource");
                return;
            }
        }
        [Statistic("Resource")]
        public virtual double ResourcePerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["Resource"];
            }
            internal set
            {
                this.Stats.Rows[1]["Resource"] = value;
                this.InitializeGenericRows("Resource");
                return;
            }
        }
        [Statistic("ResourceRegen")]
        public virtual double ResourceRegen
        {
            get
            {
                return (double)this.Stats.Rows[0]["ResourceRegen"];
            }
            internal set
            {
                this.Stats.Rows[0]["ResourceRegen"] = value;
                this.InitializeGenericRows("ResourceRegen");
                return;
            }
        }
        [Statistic("ResourceRegen")]
        public virtual double ResourceRegenPerLevel
        {
            get
            {
                return (double)this.Stats.Rows[1]["ResourceRegen"];
            }
            internal set
            {
                this.Stats.Rows[1]["ResourceRegen"] = value;
                this.InitializeGenericRows("ResourceRegen");
                return;
            }
        }
        public StatsTable.StatsDataTable Stats => this.Table.Stats;
        public StatsTable Table { get; private set; } = new StatsTable();
        [Statistic("Tenacity", IsFromDescription = true)]
        public virtual double Tenacity
        {
            get
            {
                return (double)this.Stats.Rows[0]["Tenacity"];
            }
            internal set
            {
                this.Stats.Rows[0]["Tenacity"] = value;
                this.InitializeGenericRows("Tenacity");
                return;
            }
        }
        #endregion
        #region Instance Methods
        internal GeneralStatsInfo()
        {
            for (int i = 0; i < 19; i++)
                this.Stats.AddStatsRow(this.Stats.NewStatsRow());
            return;
        }
        private void InitializeAttackSpeedRows()
        {
            double increment = ((double)this.Stats[1]["AttackSpeed"] / 100.0) * (double)this.Stats[0]["AttackSpeed"];
            for (int i = 2; i <= 18; i++)
            {
                double value = ((double)this.Stats[0]["AttackSpeed"] + increment * (double)i) * this.AttackSpeedMultiplier;
                this.Stats[i]["AttackSpeed"] = Math.Min(value, this.AttackSpeedCap);
            }
            return;
        }
        private void InitializeGenericRows(string name)
        {
            for (int i = 2; i <= 18; i++)
                this.Stats[i][name] = (double)this.Stats[0][name] + (double)this.Stats[1][name] * (double)i;
            return;
        }
        /// <summary>
        /// Uses reflection to attempt to set the property with the specified name to the specified value
        /// </summary>
        /// <param name="name">Property name to set</param>
        /// <param name="value">Value to apply</param>
        /// <returns>True if the property with the specified name was found, False otherwise</returns>
        public bool SetValue(string name, int value)
        {
            PropertyInfo property = this.GetType().GetProperty(name);
            if (property == null)
                return false;
            property.SetValue(this, Convert.ChangeType(value, property.PropertyType), null);
            return true;
        }
        /// <summary>
        /// Uses reflection to attempt to set the property with the specified name to the specified value
        /// </summary>
        /// <param name="name">Property name to set</param>
        /// <param name="value">Value to apply</param>
        /// <returns>True if the property with the specified name was found, False otherwise</returns>
        public bool SetValue(string name, double value)
        {
            PropertyInfo property = this.GetType().GetProperty(name);
            if (property == null)
                return false;
            property.SetValue(this, Convert.ChangeType(value, property.PropertyType), null);
            return true;
        }
        protected void UpdateAttackSpeed()
        {
            this.AttackSpeed = this.AttackSpeedBase / (1.0 + this.AttackSpeedOffset);
            return;
        }
        public void UpdateStats()
        {
            this.UpdateAttackSpeed();
            this.InitializeAttackSpeedRows();
            List<PropertyInfo> properties = this.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(Statistic))).ToList();
            List<Statistic> statistics = properties.Select(p => p.GetCustomAttribute(typeof(Statistic)) as Statistic).Where(s => s.IsGeneric).Distinct().ToList();
            foreach (Statistic statistic in statistics)
                this.InitializeGenericRows(statistic.Name);
        }
        #endregion
    }
}

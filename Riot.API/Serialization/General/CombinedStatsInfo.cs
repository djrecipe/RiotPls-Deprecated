using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.General
{
    /// <summary>
    /// Generic stat collection for a multiple game entity(s)
    /// </summary>
    public class CombinedStatsInfo : IStatsInfo
    {
        #region Static Methods            
        public static CombinedStatsInfo operator +(CombinedStatsInfo x, IStatsInfo y)
        {
            x.components.Add(y);
            x.UpdateStats();
            return x;
        }
        public static CombinedStatsInfo operator -(CombinedStatsInfo x, IStatsInfo y)
        {
            if(x.components.Contains(y))
                x.components.Remove(y);
            x.UpdateStats();
            return x;
        }
        #endregion
        #region Instance Members
        private readonly List<IStatsInfo> components = new List<IStatsInfo>();
        #endregion
        #region Instance Properties
        public double AttackSpeedBase => this.components.Sum(info => (double)info.AttackSpeedBase);
        public double AttackSpeedMultiplier => this.components.Sum(info => (double)info.AttackSpeedMultiplier);
        public double AttackSpeedPerLevel => this.components.Sum(info => (double)info.AttackSpeedPerLevel);
        /// <summary>
        /// The minimum level required to utilize all components
        /// </summary>
        public int RequiredLevel
        {
            get { return this.components.Select(c => c.RequiredLevel).Max(); }
            set { return; }
        }
        public StatsTable.StatsDataTable Stats => this.Table.Stats;
        public StatsTable Table { get; private set; } = new StatsTable();
        #endregion
        #region Instance Methods
        public CombinedStatsInfo()
        {
            for (int i = 0; i < 19; i++)
                this.Stats.AddStatsRow(this.Stats.NewStatsRow());
            return;
        }
        public void UpdateStats()
        {
            for (int i = 0; i <= 18; i++)
            {
                IEnumerable<IStatsInfo> collection = this.components.Where(c => c.RequiredLevel == 1 || c.RequiredLevel >= i);
                this.Stats[i]["AbilityPower"] = collection.Sum(info => (double)info.Stats[i]["AbilityPower"]);
                this.Stats[i]["Armor"] = collection.Sum(info => (double)info.Stats[i]["Armor"]);
                this.Stats[i]["AttackDamage"] = collection.Sum(info => (double)info.Stats[i]["AttackDamage"]);
                this.Stats[i]["AttackRange"] = collection.Sum(info => (double)info.Stats[i]["AttackRange"]);
                if (i == 1)
                {
                    this.Stats[i]["AttackSpeed"] = collection.Sum(info => (double)info.Stats[i]["AttackSpeed"]);
                }
                else
                {
                    double atk_speed_base_sum = collection.Sum(info => (double)info.AttackSpeedBase);
                    double atk_speed_perlvl_sum = collection.Sum(info => (double)info.AttackSpeedPerLevel);
                    double atk_speed_incr_sum = 1.0 + collection.Sum(info => (double)info.AttackSpeedMultiplier - 1.0);
                    double atk_speed_increment = (atk_speed_perlvl_sum / 100.0) * atk_speed_base_sum;
                    double value = (atk_speed_base_sum + atk_speed_increment * (double)i) * atk_speed_incr_sum;
                    this.Stats[i]["AttackSpeed"] = value;
                }
                this.Stats[i]["CriticalStrike"] = collection.Sum(info => (double)info.Stats[i]["CriticalStrike"]);
                this.Stats[i]["Health"] = collection.Sum(info => (double)info.Stats[i]["Health"]);
                this.Stats[i]["HealthRegen"] = collection.Sum(info => (double)info.Stats[i]["HealthRegen"]);
                this.Stats[i]["MagicResist"] = collection.Sum(info => (double)info.Stats[i]["MagicResist"]);
                this.Stats[i]["MagicPenFlat"] = collection.Sum(info => (double)info.Stats[i]["MagicPenFlat"]);
                this.Stats[i]["MagicPenPerc"] = collection.Sum(info => (double)info.Stats[i]["MagicPenPerc"]);
                this.Stats[i]["MovementSpeed"] = collection.Sum(info => (double)info.Stats[i]["MovementSpeed"]);
                this.Stats[i]["Resource"] = collection.Sum(info => (double)info.Stats[i]["Resource"]);
                this.Stats[i]["ResourceRegen"] = collection.Sum(info => (double)info.Stats[i]["ResourceRegen"]);
            }
            return;
        }
        #endregion
    }
}

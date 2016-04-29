using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// Default constructor
        /// </summary>
        public CombinedStatsInfo()
        {
            for (int i = 0; i < 19; i++)
                this.Stats.AddStatsRow(this.Stats.NewStatsRow());
            return;
        }
        /// <summary>
        /// Re-calculate all stat information using the current list of components
        /// </summary>
        public void UpdateStats()
        {
            for (int i = 0; i <= 18; i++)
            {
                IEnumerable<IStatsInfo> collection = this.components.Where(c => c.RequiredLevel == 1 || c.RequiredLevel <= i);
                AttackSpeed attack_speed = new AttackSpeed(collection);
                foreach (DataColumn column in this.Stats.Columns)
                {
                    string name = column.ColumnName;
                    switch (column.ColumnName)
                    {
                        case "AttackSpeed":
                            this.Stats[i][name] = attack_speed.GetAttackSpeed((Level)i);
                            break;
                        default:
                            this.Stats[i][name] = collection.Sum(info => (double)info.Stats[i][name]);
                            break;
                    }
                }
            }
            return;
        }
        #endregion
    }
}

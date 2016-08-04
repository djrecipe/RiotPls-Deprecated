using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.Serialization.Attributes
{
    /// <summary>
    /// Calculates various attack speed variables for given set of entities
    /// </summary>
    public class AttackSpeed
    {
        #region Instance Properties                                     
        /// <summary>
        /// Attack speed before any level growth is applied
        /// </summary>
        public double AttackSpeedBase { get; private set; }
        /// <summary>
        /// Attack speed gained naturally per level
        /// </summary>
        /// <remarks>Represents natural champion attack speed growth</remarks>
        public double AttackSpeedBasePerLevel { get; private set; }
        /// <summary>
        /// Multiplicative modifier to attack speed, applied after level growth
        /// </summary>
        public double AttackSpeedIncrease { get; private set; }
        /// <summary>
        /// Flat amount of attack speed gained per level
        /// </summary>
        public double AttackSpeedPerLevel { get; private set; }
        #endregion
        #region Instance Methods
        #region Initialization Methods
        /// <summary>
        /// Calculates attack speed for a collection of stat entities
        /// </summary>
        /// <param name="stats">Collection of stat entities</param>
        public AttackSpeed(IEnumerable<IStatsInfo> stats)
        {
            this.AttackSpeedBase = stats.Sum(info => (double)info.AttackSpeedBase);
            this.AttackSpeedBasePerLevel = stats.Sum(info => (double)info.Stats[1]["AttackSpeed"]);
            this.AttackSpeedIncrease = 1.0 + stats.Sum(info => (double)info.AttackSpeedMultiplier - 1.0);
            double atk_speed_perlvl_sum = stats.Sum(info => (double)info.AttackSpeedPerLevel);
            this.AttackSpeedPerLevel = (atk_speed_perlvl_sum / 100.0) * this.AttackSpeedBase;
        }
        /// <summary>
        /// Calculates attack speed for a single stat entity
        /// </summary>
        /// <param name="stat">Stat entity</param>
        public AttackSpeed(IStatsInfo stat)
        {
            this.AttackSpeedBase = stat.AttackSpeedBase;
            this.AttackSpeedBasePerLevel = (double)stat.Stats[1]["AttackSpeed"];
            this.AttackSpeedIncrease = stat.AttackSpeedMultiplier;
            double atk_speed_perlvl_sum = stat.AttackSpeedPerLevel;
            this.AttackSpeedPerLevel = (atk_speed_perlvl_sum / 100.0) * this.AttackSpeedBase;
        }
        #endregion
        /// <summary>
        /// Calculate and retrieve the attack speed for a given champion level
        /// </summary>
        /// <param name="level">Champion level</param>
        /// <returns>Attack speed at the specified champion level</returns>
        public double GetAttackSpeed(Level level)
        {
            switch (level)
            {
                case Level.PerLevel:
                    return this.AttackSpeedBasePerLevel;
                default:
                    int level_modifier = Math.Max(0, (int)level - 1);
                    return (this.AttackSpeedBase + this.AttackSpeedPerLevel * (double)level_modifier) * this.AttackSpeedIncrease;
            }
        }
        #endregion
    }
}

namespace RiotPls.API.Serialization.Interfaces
{
    public interface IStatsInfo
    {
        #region Instance Properties
        double AttackSpeedBase { get; }
        double AttackSpeedMultiplier { get; }
        double AttackSpeedPerLevel { get; }
        int RequiredLevel { get; set; }
        StatsTable.StatsDataTable Stats { get; }
        StatsTable Table { get; }
        #endregion
        #region Instance Methods
        void UpdateStats();
        #endregion
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Test
{
    [TestClass]
    public class TestGeneralStatsInfo
    {
        [TestMethod]
        public void Addition()
        {
            ChampionStatsInfo champion = new ChampionStatsInfo();
            champion.Armor = 15;
            ItemStatsInfo item = new ItemStatsInfo();
            item.Armor = 22;
            GeneralStatsInfo info = champion + item;
            Assert.IsTrue(info.Armor == 37, string.Format("Armor addition resulted in '{0}' instead of the expected value of '{1}'", info.Armor, 15+22));
        }
    }
}

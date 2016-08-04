using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API.Serialization.Attributes;
using RiotPls.API.Serialization.Champions;
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
            CombinedStatsInfo info = champion + item;
            Assert.IsTrue(info.Stats[0].Armor == 37, string.Format("Armor addition resulted in '{0}' instead of the expected value of '{1}'", info.Stats[0].Armor, 15+22));
        }
    }
}

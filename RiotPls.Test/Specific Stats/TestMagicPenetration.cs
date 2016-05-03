using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Test.Specific_Stats
{
    [TestClass]
    public class TestMagicPenetration
    {
        private const int EXPECTED = 15;
        [TestMethod]
        public void ParseDescription()
        {
            PseudoItemInfo item = new PseudoItemInfo("TestItem");
            item.FullDescription = "</unique> +15 <a href='FlatMagicPen'>Magic Penetration</a><br><unique>";
            ItemStatsInfo stats = ItemDescriptionParser.Parse(item.FullDescription);
            Assert.IsTrue(stats.MagicPenFlat == TestMagicPenetration.EXPECTED,
                string.Format("Failed to Verify Magic Penetration (Expected: {0}; Actual: {1})",
                TestMagicPenetration.EXPECTED, stats.MagicPenFlat));
        }
    }
}

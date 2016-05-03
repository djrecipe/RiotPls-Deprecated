using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.Test
{
    [TestClass]
    public class TestAttackSpeed
    {
        private const double BASE = 1.5;
        private const double MULTIPLIER = 2.0;
        private const double TOLERANCE = 0.001;
        [TestMethod]
        public void Calculations()
        {
            PseudoItemInfo item = new PseudoItemInfo("TestItem") {Stats = {AttackSpeedMultiplier = 2.0}};
            PseudoChampionInfo champion = new PseudoChampionInfo("TestChampion") {Stats = {AttackSpeedBase = 1.5}};
            List<IStatsInfo> stats = new List<IStatsInfo>() {item.Stats, champion.Stats};
            AttackSpeed attack_speed = new AttackSpeed(stats);
            double expected = TestAttackSpeed.BASE * (1.0 + TestAttackSpeed.MULTIPLIER); // add 1.0 for base multiplier
            double result = attack_speed.GetAttackSpeed(Level.Level18);
            Assert.IsTrue(Math.Abs(result - expected) < TestAttackSpeed.TOLERANCE, "Failed to Verify Attack Speed (Expected: {0}; Result: {1})", expected, result);
        }
    }
}

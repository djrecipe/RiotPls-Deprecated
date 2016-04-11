using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.General;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Test.Serialization
{
    /// <summary>
    /// Tests construction, serialization, and deserialization of champion build information
    /// </summary>
    [TestClass]
    public class TestBuildSave
    {
        private const string PATH = "RiotPls.Test.Serialization.Build.json";
        private readonly JsonSerializerSettings jsonSettings = null;
        public TestBuildSave()
        {
            jsonSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }
        [TestMethod]
        public void SimpleSerialize()
        {
            Build build = Build.GetBuild(0);
            build.SetChampion(new PseudoChampionInfo("Test"));
            for (int i = 0; i < 6; i++)
            {
                ItemInfo item = new ItemInfo();
                build.SetItem(i, item);
            }
            build.Save(TestBuildSave.PATH);
            Assert.IsTrue(File.Exists(TestBuildSave.PATH), "JSON File Was Not Created");
            string text = File.ReadAllText(TestBuildSave.PATH);
            build = null;
            build = JsonConvert.DeserializeObject<Build>(text, this.jsonSettings);
            Assert.IsTrue(build?.Champion?.Name == "Test", "Failed to Verify Champion Name");
        }
    }
}

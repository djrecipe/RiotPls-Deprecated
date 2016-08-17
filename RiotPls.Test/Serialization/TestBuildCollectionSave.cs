using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.ExtensionMethods;
using RiotPls.API.Serialization.Items;
using RiotPls.Test.Items;

namespace RiotPls.Test.Serialization
{
    /// <summary>
    /// Tests construction, serialization, and deserialization of a collection of builds
    /// </summary>
    [TestClass]
    public class TestBuildCollectionSave
    {
        private const string PATH = "RiotPls.Test.Serialization.BuildCollection.json";
        private readonly JsonSerializerSettings jsonSettings = null;
        public TestBuildCollectionSave()
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
            BuildCollection collection = new BuildCollection("Test.BuildCollection");
            Build build = collection[0];
            build.SetChampion(new PseudoChampionInfo("TestChampion"));
            for (int i = 0; i < 6; i++)
            {
                PseudoItemInfo item = new PseudoItemInfo("TestItem");
                build.SetItem(i, item);
            }
            collection.SaveAsJson(TestBuildCollectionSave.PATH);
            Assert.IsTrue(File.Exists(TestBuildCollectionSave.PATH), "JSON File Was Not Created");
            string text = File.ReadAllText(TestBuildCollectionSave.PATH);
            collection = null;
            collection = JsonConvert.DeserializeObject<BuildCollection>(text, this.jsonSettings);
            Assert.IsTrue(collection?[0]?.Champion?.Name == "TestChampion", "Failed to Verify Champion Name");
            Assert.IsTrue(collection?[0]?.GetItem(0)?.Name == "TestItem", "Failed to Verify Item Name");
        }
    }
}

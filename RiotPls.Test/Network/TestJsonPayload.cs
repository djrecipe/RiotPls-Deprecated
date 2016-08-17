using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.Test.Network
{
    [TestClass]
    public class TestJsonPayload
    {
        private const string JSON_CHAMP = "{\n   \"id\": 1,\n   \"name\": \"Tristana\",\n   \"key\": \"Tristana\"\n}";
        [TestMethod]
        public void LocalRetrieval()
        {
            // create dummy json file
            Directory.CreateDirectory("json");
            File.WriteAllText("json/PseudoChampion.json", TestJsonPayload.JSON_CHAMP);
            Assert.IsTrue(File.Exists("json/PseudoChampion.json"), "Missing JSON file");
            // instantiate json payload object
            JsonPayload<PseudoChampionInfo> payload = new JsonPayload<PseudoChampionInfo>(null, "PseudoChampion.json");
            // retrieve
            bool remote_retrieval = false;
            PseudoChampionInfo champion = payload.Get(out remote_retrieval);
            // verify
            Assert.IsNotNull(champion, "Retrieval failed");
            Assert.IsFalse(remote_retrieval, "Remote retrieval detected (only local retrieval should be possible)");
            Assert.AreEqual(champion.Name, "Tristana", "Unexpected champion name");
            return;
        }
    }
}

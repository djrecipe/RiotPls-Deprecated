using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotPls.Test
{
    [TestClass]
    public class TestAPIKey
    {
        private const string Key = "3355Test-Key0-2858-82yy12344321o000";
        [TestMethod]
        public void SaveAndLoad()
        {
            API.APIKey key = new API.APIKey("Test.key");
            Assert.IsTrue(key.Save(TestAPIKey.Key), "Failed to Save API Key");
            Assert.IsTrue(key.Load(), "Failed to Load API Key");
            Assert.IsTrue(key.ToString() == TestAPIKey.Key, "Key Does Not Match Expected Value");
        }
    }
}

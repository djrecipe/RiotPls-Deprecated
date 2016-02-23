using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotPls.Test
{
    [TestClass]
    public class APIKey
    {
        private const string Key = "3355Test-Key0-2858-82yy12344321o000";
        private const string Path = "Test.key";
        [TestMethod]
        public void SaveAndLoad()
        {
            API.APIKey key = new API.APIKey(APIKey.Path);
            Assert.IsTrue(key.Save(APIKey.Key), "Failed to Save API Key");
            Assert.IsTrue(key.Load(), "Failed to Load API Key");
            Assert.IsTrue(key.ToString() == APIKey.Key, "Key Does Not Match Expected Value");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotPls.Test
{
    [TestClass]
    public class APIKey
    {
        private const string Key = "TestKey028-5882";
        private const string Path = "Test.key";
        [TestMethod]
        public void SaveAndLoad()
        {
            Assert.IsTrue(API.Engine.SaveKey(APIKey.Key, APIKey.Path), "Failed to Save API Key");
            Assert.IsTrue(API.Engine.LoadKey(APIKey.Path), "Failed to Load API Key");
            Assert.IsTrue(API.Engine.APIKeyRaw == APIKey.Key, "Key Does Not Match Expected Value");
        }
    }
}

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API;

namespace RiotPls.Test
{
    [TestClass]
    public class TestAPISettings
    {
        [TestMethod]
        public void SaveAndLoad()
        {
            string path = "TestAPISettings.rpxml";
            if(File.Exists(path))
                File.Delete(path);
            APISettings.Load(path);
            Assert.AreEqual(APISettings.APIVersion, APISettings.DEFAULT_API_VER, "API version mismatch");
            APISettings.Save(path);
            Assert.IsTrue(File.Exists(path), "Failed to save settings");
            File.Delete(path);
            return;
        }
    }
}

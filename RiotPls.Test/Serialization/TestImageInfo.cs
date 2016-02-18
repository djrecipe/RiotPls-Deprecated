using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotPls.API.Serialization;

namespace RiotPls.Test.Serialization
{
    /// <summary>
    /// Summary description for TestImageInfo
    /// </summary>
    [TestClass]
    public class TestImageInfo
    {
        private const string PATH = "RiotPls.Test.Serialization.ImageInfo.json";
        private const int HEIGHT = 14;
        private const int WIDTH = 13;
        private readonly JsonSerializerSettings jsonSettings = null;
        public TestImageInfo()
        {
            jsonSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void SimpleSerialize()
        {
            ImageInfo info = new ImageInfo
            {
                Height = HEIGHT,
                Width = WIDTH
            };
            string text = JsonConvert.SerializeObject(info, this.jsonSettings);
            File.WriteAllText(PATH, text);
            Assert.IsTrue(File.Exists(TestImageInfo.PATH), "JSON File Was Not Created");
            text = File.ReadAllText(TestImageInfo.PATH);
            info = null;
            info = JsonConvert.DeserializeObject<ImageInfo>(text, this.jsonSettings);
            Assert.IsTrue(info.Height == HEIGHT, "Height Mistmatch");
            Assert.IsTrue(info.Width == WIDTH, "Width Mistmatch");
        }
    }
}

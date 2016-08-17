using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.Test.Network
{
    [TestClass]
    public class TestRiotURL
    {
        [TestMethod]
        public new void ToString()
        {
            // retrieve API key
            File.WriteAllText("test.key", "0");
            APIKey key = new APIKey("test.key");
            key.Load();
            Console.WriteLine("Key: {0}", key.ToString());
            // create Riot URL
            RiotURL url = new RiotURL(key, 1.2, true, "champion?");
            Console.WriteLine("URL: {0}", (string)url);
            Assert.AreEqual(url, "https://na.api.pvp.net/api/lol/static-data/na/"+ string.Format("v{0}", APISettings.DEFAULT_API_VER) + "/champion?&api_key=" + key);
            return;
        }
        [DeploymentItem("key.txt")]
        [TestMethod, TestCategory("APIKeyRequired")]
        public void Retrieval()
        {
            // retrieve API key
            string full_path = Path.GetFullPath("key.txt");
            Console.WriteLine("Key Path: {0}", full_path);
            APIKey key = new APIKey("key.txt");
            key.Load();
            Console.WriteLine("Key: {0}", key.ToString());
            // create Riot URL
            RiotURL url = new RiotURL(key, APISettings.DEFAULT_API_VER, true, "champion?");
            Console.WriteLine("URL: {0}", (string)url);
            // create web request
            HttpWebRequest request = HttpWebRequest.Create((string)url) as HttpWebRequest;
            StreamReader stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            // validate response
            string text = stream_reader.ReadToEnd();
            Console.WriteLine("Response: {0}", text);
            Assert.IsTrue(text.Contains("Tristana"), "Invalid response");
            return;
        }
    }
}

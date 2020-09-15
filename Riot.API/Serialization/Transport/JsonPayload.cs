using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotPls.API.Serialization.Transport
{
    public class JsonPayload<T>
    {
        #region Static Methods
        static JsonPayload()
        {
            try
            {
                string directory = Path.GetFullPath("json");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
            catch
            {
                // ignored
            }
            return;
        }
        #endregion
        #region Instance Members
        public readonly string LocalFileName;
        public readonly string RemotePath;
        public readonly string Token;
        #endregion
        #region Instance Properties
        public string LocalPath => Path.Combine(Path.GetFullPath("json"), this.LocalFileName);
        public bool RetrievedRemote { get; private set; } = false;
        #endregion
        #region Instance Methods
        public JsonPayload(string remote_url, string local_file, string token = null)
        {
            this.LocalFileName = local_file;
            this.RemotePath = remote_url;
            this.Token = token;
        }

        private void Cache(string text)
        {
            File.WriteAllText(this.LocalPath, text);
            return;
        }

        private JObject Parse(string payload)
        {
            return JObject.Parse(payload);
        }

        public T Get(out bool remote_retreival)
        {
            JObject obj = this.RetrieveRemote();
            if (obj == null)
            {
                obj = this.RetrieveLocal();
                remote_retreival = false;
            }
            else
            {
                remote_retreival = true;
            }
            string result = string.IsNullOrWhiteSpace(this.Token) ? obj?.ToString() : obj?.SelectToken(this.Token).ToString();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(result, settings);
        }

        private JObject RetrieveLocal()
        {
            try
            {
                return File.Exists(this.LocalPath) ? this.Parse(File.ReadAllText(this.LocalPath)) : null;
            }
            catch
            {
                // ignored
            }
            return null;
        }

        private JObject RetrieveRemote()
        {
            HttpWebRequest request = null;
            try
            {
                request = HttpWebRequest.Create(this.RemotePath) as HttpWebRequest;
            }
            catch
            {
                return null;
            }
            StreamReader stream_reader = null;
            try
            {
                stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            }
            catch
            {
                return null;
            }
            JObject obj = null;
            try
            {
                string text = stream_reader.ReadToEnd();
                obj = this.Parse(text);
                if (obj != null)
                {
                    this.Cache(text);
                    this.RetrievedRemote = true;
                }
            }
            catch
            {
                obj = null;
            }
            stream_reader.Close();
            return obj;
        }
        #endregion
    }
}

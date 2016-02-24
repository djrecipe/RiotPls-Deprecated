using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API
{
    public class APIKey
    {
        private const string URL_STR = "&api_key=";
        public readonly string FilePath = null;
        public event EventHandler Loaded;
        public string RawKey { get; private set; } = null;

        public APIKey(string file_path)
        {
            this.FilePath = file_path;
        }
        public bool Load()
        {
            this.RawKey = "0";
            string desired_path = this.FilePath;
            if (!File.Exists(desired_path))
                return false;
            try
            {
                string text = File.ReadAllText(desired_path);
                this.RawKey = this.Sanitize(text);
                if(this.Loaded != null)
                    this.Loaded(this, EventArgs.Empty);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error While Loading Key:\n'{0}'", e.Message);
            }
            return false;
        }
        private string Sanitize(string text)
        {
            try
            {
                string clean = text.Replace("-", "").Trim();
                if(clean.ToCharArray().Any(c => !char.IsLetterOrDigit(c)))
                    throw new ArgumentException("Only alphanumeric characters and the '-' character are allowed", "text");
                if(clean.Length != 32)
                    throw new ArgumentException("Must contain exactly 32 alphanumeric characters", "text");
            }
            catch (Exception e)
            {
                text = null;
                throw e;
            }
            return text;
        }
        public bool Save(string key)
        {
            try
            {
                key = this.Sanitize(key);
                this.RawKey = key;
                File.WriteAllText(this.FilePath, string.IsNullOrWhiteSpace(this.RawKey) ? "" : this.RawKey);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error While Saving Key:\n'{0}'", e.Message);
            }
            return false;
        }

        public override string ToString()
        {
            return this.ToString(false);
        }
        public string ToString(bool include_url)
        {
            string text = include_url ? APIKey.URL_STR : "";
            return text + this.RawKey;
        }

    }
}

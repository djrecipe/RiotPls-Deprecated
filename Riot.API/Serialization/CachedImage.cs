using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.API.Serialization
{
    public class CachedImage
    {
        private const string VERSION = "6.1.1";
        private const string URL = "http://ddragon.leagueoflegends.com/cdn/";
        private const string DIRECTORY = "Images";
        private const string FILENAME_IGNORE = "IgnoreImages.csv";
        private static List<string> ignore = new List<string>();
        private static string IgnorePath => Path.Combine(CachedImage.DIRECTORY, CachedImage.FILENAME_IGNORE);
        public Bitmap Image
        {
            get;
            private set;
        }
        static CachedImage()
        {
            if (File.Exists(CachedImage.IgnorePath))
            {
                CachedImage.ignore.Clear();
                string text = null;
                try
                {
                    text = File.ReadAllText(CachedImage.IgnorePath);
                }
                catch
                {
                    text = null;
                }
                if (text != null)
                    CachedImage.ignore.AddRange(text.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries));
            }
            return;
        }
        public void UpdateImage(string group, string filename)
        {
            if (filename == null || group == null)
            {
                this.Image = null;
                return;
            }
            string image_sub_path = Path.Combine(CachedImage.VERSION, group, filename);
            if (CachedImage.ignore.Contains(image_sub_path))
            {
                this.Image = null;
                return;
            }
            string path_local = Path.Combine(CachedImage.DIRECTORY, image_sub_path);
            if (this.Image == null || this.Image.Tag.ToString() != path_local)
            {
                try
                {
                    if (!File.Exists(path_local))
                    {
                        string directory = Path.GetDirectoryName(Path.GetFullPath(path_local));
                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(CachedImage.URL + VERSION + "/img/" + group + "/" + filename, path_local);
                        }
                    }
                    // don't use else here
                    if (File.Exists(path_local))
                    {
                        this.Image = new Bitmap(path_local) { Tag = path_local };
                    }
                }
                catch
                {
                    if (File.Exists(path_local))
                        File.Delete(path_local);
                    if (!CachedImage.ignore.Contains(path_local))
                    {
                        CachedImage.ignore.Add(path_local);
                        File.AppendAllText(CachedImage.IgnorePath, path_local + "\r\n");
                    }
                }
            }
            return;
        }
        public static implicit operator Bitmap(CachedImage cached_image)
        {
            return cached_image.Image;
        }
    }
}

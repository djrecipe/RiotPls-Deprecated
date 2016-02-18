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
    public class CachedImage : Resources.Resource
    {
        public Bitmap Image
        {
            get;
            private set;
        }
        public CachedImage(string group, string file_name) : base(group, file_name)
        {
            if (group == null)
                throw new ArgumentNullException("group", "Cannot be null");
            if (file_name == null)
                throw new ArgumentNullException("file_name", "Cannot be null");
            if (this.Ignored)
            {
                this.Image = null;
                return;
            }
            if (this.Image == null || this.Image.Tag.ToString() != this.FullLocalPath)
            {
                try
                {
                    if (!File.Exists(this.FullLocalPath))
                    {
                        string directory = Path.GetDirectoryName(Path.GetFullPath(this.FullLocalPath));
                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(CachedImage.URL + VERSION + "/img/" + this.Group + "/" + this.FileName, this.FullLocalPath);
                        }
                    }
                    // don't use else here
                    if (File.Exists(this.FullLocalPath))
                    {
                        this.Image = new Bitmap(this.FullLocalPath) { Tag = this.FullLocalPath };
                    }
                }
                catch
                {
                    this.Ignore();
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

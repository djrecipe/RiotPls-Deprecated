using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization.ExtensionMethods
{
    /// <summary>
    /// Facilitates serialization of a class to a JSON file on disk 
    /// </summary>
    public static class JsonSaveEngine
    {
        /// <summary>
        /// Serializes the class to a JSON string and saves the string to the specified path
        /// </summary>
        /// <param name="obj">JSON serializable object</param>
        /// <param name="path">Path to save at</param>
        public static void SaveAsJson(this object obj, string path)
        {
            try
            {
                if (Path.GetExtension(path) == null)
                    throw new Exception();
            }
            catch
            {
                throw new ArgumentException("A rooted directory and file extension are required.", "path");
            }
            try
            {
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Reuse,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                string text = JsonConvert.SerializeObject(obj, settings);
                File.WriteAllText(path, text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while saving as JSON.\n{0}", e.Message);
            }
            return;
        }
    }
}

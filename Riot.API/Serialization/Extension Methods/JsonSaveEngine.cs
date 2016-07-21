using System;
using System.IO;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization.ExtensionMethods
{
    /// <summary>
    /// Facilitates serialization of a class to/from a JSON file on disk 
    /// </summary>
    public static class JsonSaveEngine
    {
        /// <summary>
        /// Clone object of type T via serialization
        /// </summary>
        /// <typeparam name="T">Type of object to clone</typeparam>
        /// <param name="target">Object to clone</param>
        /// <returns>Clone of object</returns>
        public static T CloneJsonObject<T>(T target)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            string text = JsonConvert.SerializeObject(target, settings);
            return JsonConvert.DeserializeObject<T>(text, settings);
        }

        /// <summary>
        /// Deserialize an object from a file
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <param name="path">Path where JSON file exists</param>
        /// <returns>Object of type T</returns>
        public static T LoadFromJson<T>(string path)
        {
            if(string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return default(T);
            string text = File.ReadAllText(path);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(text, settings);
        }

        /// <summary>
        /// Serialize an object to JSON then save the JSON to disk
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <param name="path">Path to save JSON file</param>
        public static void SaveAsJson<T>(this T obj, string path)
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
                if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
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

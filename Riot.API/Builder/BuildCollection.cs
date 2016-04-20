using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.API.Builder
{
    /// <summary>
    /// Serializable list of builds
    /// </summary>
    /// <remarks>Instantiation is accomplished via the <see cref="BuildManager"/> class</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class BuildCollection
    {
        #region Instance Properties
        public Build this[int key] => key >= Builds.Count ? null : this.Builds[key];
        [JsonProperty("Builds", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private List<Build> Builds { get; set; } = new List<Build>();
        public int Count => this.Builds.Count;
        public string Name { get; set; } = "My Builds";
        #endregion
        #region Instance Methods
        public BuildCollection(string name = "My Builds")
        {
            this.Name = name;
            this.New();
            return;
        }
        public void Add(Build build)
        {
            this.Builds.Add(build);
            return;
        }
        public Build Find(string name)
        {
            return this.Builds.FirstOrDefault(b => b.Name == name);
        }
        public Build New()
        {
            Build build = new Build(string.Format("Build #{0}", this.Count + 1));
            this.Add(build);
            return build;
        }
        public void Remove(Build build)
        {
            if(this.Builds.Contains(build))
                this.Builds.Remove(build);
            return;
        }
        public void RemoveAt(int index)
        {
            if(index < this.Count)
                this.Builds.RemoveAt(index);
            return;
        }
        #endregion
    }
}

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
        #region Types
        public delegate void BuildCollectionChangedDelegate();
        #endregion
        #region Instance Members
        /// <summary>
        /// Event which fires when a build has been added or removed
        /// </summary>
        public event BuildCollectionChangedDelegate BuildCollectionChanged;
        #endregion
        #region Instance Properties
        /// <summary>
        /// Access a build at the specified index
        /// </summary>
        /// <param name="key">Index of the build</param>
        /// <returns>Build at the specified index, if any</returns>
        public Build this[int key] => key >= Builds.Count ? null : this.Builds[key];
        [JsonProperty("Builds", ItemIsReference = true, ReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        private List<Build> Builds { get; set; } = new List<Build>();
        /// <summary>
        /// Number of builds currently in this collection
        /// </summary>
        public int Count => this.Builds.Count;
        /// <summary>
        /// Build collection name
        /// </summary>
        public string Name { get; set; } = "My Builds";
        private int _SelectedRow = 0;
        /// <summary>
        /// Selected row for all builds in this collection
        /// </summary>
        public int SelectedRow
        {
            get { return this._SelectedRow; }
            set
            {
                this._SelectedRow = value;
                foreach (Build build in this.Builds)
                    build.SelectedRow = this.SelectedRow;
            }
        }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Desired name for this collection</param>
        public BuildCollection(string name = "My Builds")
        {
            this.Name = name;
            this.New();
            return;
        }
        /// <summary>
        /// Adds a build to this collection
        /// </summary>
        /// <param name="build">Build to add</param>
        public void Add(Build build)
        {
            build.SelectedRow = this.SelectedRow;
            build.SelectedRowChanged += this.Build_SelectedRowChanged;
            this.Builds.Add(build);
            if (this.BuildCollectionChanged != null)
                this.BuildCollectionChanged();
            return;
        }
        /// <summary>
        /// Find and retrieve a build with the specified name 
        /// </summary>
        /// <param name="name">Build name to search for</param>
        /// <returns>Build with the specified name, if any</returns>
        public Build Find(string name)
        {
            return this.Builds.FirstOrDefault(b => b.Name == name);
        }
        /// <summary>
        /// Instantiate and add a new build to this collection
        /// </summary>
        /// <returns>The newly instantiated build</returns>
        public Build New()
        {
            Build build = new Build(string.Format("Build #{0}", (this.Builds.Count) + 1));
            this.Add(build);
            return build;
        }
        /// <summary>
        /// Remove the specified build from this collection, if it exists
        /// </summary>
        /// <param name="build">Build to remove</param>
        public void Remove(Build build)
        {
            if (this.Builds.Contains(build))
            {
                build.SelectedRowChanged -= this.Build_SelectedRowChanged;
                this.Builds.Remove(build);
                if (this.BuildCollectionChanged != null)
                    this.BuildCollectionChanged();
            }
            return;
        }
        /// <summary>
        /// Remove the build at the specified index within this collection
        /// </summary>
        /// <param name="index">Index at which the build will be removed</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                Build build = this.Builds[index];
                this.Remove(build);
            }
            return;
        }
        /// <summary>
        /// Removes any builds that contain no items
        /// </summary>
        public void RemoveEmptyBuilds()
        {
            List<Build> builds = this.Builds.Where(b => b.ItemCount < 1).ToList();
            foreach (Build build in builds)
                this.Remove(build);
            return;
        }
        #endregion
        #region Event Methods
        private void Build_SelectedRowChanged(int row)
        {
            this.SelectedRow = row;
            return;
        }
        #endregion
    }
}

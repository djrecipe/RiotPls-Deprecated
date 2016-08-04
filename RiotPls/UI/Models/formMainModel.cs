using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.ExtensionMethods;
using RiotPls.Tools;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formMain
    /// </summary>
    /// <seealso cref="formMain"/>
    public class formMainModel
    {
        #region Instance Members
        #region Forms
        private formChampions fChampions = new formChampions();
        private formItems fItems = new formItems();
        private formMaps fMaps = new formMaps();
        private formSettings fSettings = new formSettings();
        #endregion
        #region Events
        public event BuildCollection.BuildCollectionChangedDelegate BuildCollectionChanged;
        #endregion
        private BuilderFormFactory builderFactory = null;
        #endregion
        #region Instance Properties
        private BuildCollection _Builds = new BuildCollection();
        /// <summary>
        /// Set of builds which may be modified
        /// </summary>
        public BuildCollection Builds
        {
            get { return this._Builds; }
            set
            {
                if (this.Builds != null)
                    this.Builds.BuildCollectionChanged -= this.BuildCollection_Changed;
                this._Builds = value;
                this.builderFactory.Builds = this.fChampions.Model.Builds = this.fItems.Model.Builds = this.Builds; 
                if(this.Builds != null)
                    this.Builds.BuildCollectionChanged += this.BuildCollection_Changed;
                return;
            }
        }
        /// <summary>
        /// Champions window is visible
        /// </summary>
        public bool ChampionsVisible
        {
            get { return this.fChampions.Visible; }
            set
            {
                Drawing.ToggleWindow(this.fChampions, value);
                return;
            }
        }
        /// <summary>
        /// Items window is visible
        /// </summary>
        public bool ItemsVisible
        {
            get { return this.fItems.Visible; }
            set
            {
                Drawing.ToggleWindow(this.fItems, value);
                return;
            }
        }
        /// <summary>
        /// Maps window is visible
        /// </summary>
        public bool MapsVisible
        {
            get { return this.fMaps.Visible; }
            set
            {
                Drawing.ToggleWindow(this.fMaps, value);
                return;
            }
        }
        /// <summary>
        /// Settings window is visible
        /// </summary>
        public bool SettingsVisible
        {
            get { return this.fSettings.Visible; }
            set
            {
                Drawing.ToggleWindow(this.fSettings, value);
                return;
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent_form">Owning window</param>
        #endregion
        #region Instance Methods
        public formMainModel(Form parent_form)
        {
            this.InitializeForms(parent_form);
            BuildCollection old_build = JsonSaveEngine.LoadFromJson<BuildCollection>(Path.Combine(Tools.Paths.Documents, "Builds", "Autosave.builds"));
            this.Builds = old_build ?? new BuildCollection();
            return;
        }
        ~formMainModel()
        {
            this.Builds.RemoveEmptyBuilds();
            this.Builds.SaveAsJson(Path.Combine(Tools.Paths.Documents, "Builds", "Autosave.builds"));
        }
        /// <summary>
        /// Create a new build and associated build window
        /// </summary>
        public void CreateNewBuild()
        {
            this.builderFactory.CreateNewBuild();
            return;
        }
        /// <summary>
        /// Generate a list of menu items to represent the current builds
        /// </summary>
        /// <returns>List of toolstrip menu items</returns>
        public List<ToolStripMenuItem> GetBuilderItems()
        {
            List<ToolStripMenuItem> menu_items = new List<ToolStripMenuItem>();
            for (int i = 0; i < this.Builds.Count; i++)
            {
                Build build = this.Builds[i];
                ToolStripMenuItem button = new ToolStripMenuItem(build.Name, null, this.btnSelectBuild_Click);
                menu_items.Add(button);
            }
            return menu_items;
        }
        private void InitializeForms(Form parent)
        {
            this.fChampions.MdiParent = parent;
            this.fItems.MdiParent = parent;
            this.fMaps.MdiParent = parent;
            this.fSettings.MdiParent = parent;
            this.builderFactory = new BuilderFormFactory(parent);
            return;
        }
        /// <summary>
        /// Show forms which were visible when the previous session was terminated
        /// </summary>
        public void InitializeFormVisibility()
        {
            this.fChampions.Visible = GeneralSettings.GetWindowWasOpen(this.fChampions);
            this.fItems.Visible = GeneralSettings.GetWindowWasOpen(this.fItems);
            this.fMaps.Visible = GeneralSettings.GetWindowWasOpen(this.fMaps);
            this.fSettings.Visible = GeneralSettings.GetWindowWasOpen(this.fSettings);
            this.builderFactory.InitializeFormVisibility();
            GeneralSettings.ClearOpenWindows();
            return;
        }
        #endregion
        #region Instance Events
        private void btnSelectBuild_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem button = sender as ToolStripMenuItem;
            if (button == null)
                return;
            ToolStripDropDownButton parent = button.OwnerItem as ToolStripDropDownButton;
            int index = parent?.DropDownItems.IndexOf(button) - 1 ?? -1;
            this.builderFactory.ShowBuild(index);
            return;
        }
        private void BuildCollection_Changed()
        {
            if (this.BuildCollectionChanged != null)
                this.BuildCollectionChanged();
            return;
        }
        #endregion
    }
}

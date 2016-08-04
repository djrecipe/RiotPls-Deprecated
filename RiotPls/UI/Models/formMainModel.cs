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
        private List<formBuilder> fBuilders = new List<formBuilder>();
        private Form parentWindow = null;
        #endregion
        #region Events
        public event BuildCollection.BuildCollectionChangedDelegate BuildCollectionChanged;
        #endregion
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
                this.UpdateBuilds();
                if(this.Builds != null)
                    this.Builds.BuildCollectionChanged += this.BuildCollection_Changed;
                return;
            }
        }
        public bool ChampionsVisible
        {
            get { return this.fChampions.Visible; }
            set
            {
                this.ToggleWindow(this.fChampions, value);
                return;
            }
        }
        public bool ItemsVisible
        {
            get { return this.fItems.Visible; }
            set
            {
                this.ToggleWindow(this.fItems, value);
                return;
            }
        }
        public bool MapsVisible
        {
            get { return this.fMaps.Visible; }
            set
            {
                this.ToggleWindow(this.fMaps, value);
                return;
            }
        }
        public bool SettingsVisible
        {
            get { return this.fSettings.Visible; }
            set
            {
                this.ToggleWindow(this.fSettings, value);
                return;
            }
        }
        #endregion
        public formMainModel(Form parent_form)
        {
            this.InitializeForms(parent_form);
            BuildCollection old_build = JsonSaveEngine.LoadFromJson<BuildCollection>(Path.Combine(Tools.Paths.Documents, "Builds", "Autosave.builds"));
            this.Builds = old_build ?? new BuildCollection();
            return;
        }

        public void Cleanup()
        {
            Tools.GeneralSettings.ClearOpenWindows();
            Tools.GeneralSettings.SaveOpenWindows(this.fBuilders.Cast<Form>().ToList());
            Tools.GeneralSettings.SaveOpenWindow(this.fChampions);
            Tools.GeneralSettings.SaveOpenWindow(this.fItems);
            Tools.GeneralSettings.SaveOpenWindow(this.fMaps);
            Tools.GeneralSettings.SaveOpenWindow(this.fSettings);
            Tools.GeneralSettings.Save();
            this.Builds.RemoveEmptyBuilds();
            this.Builds.SaveAsJson(Path.Combine(Tools.Paths.Documents, "Builds", "Autosave.builds"));
            return;
        }
        private void CreateBuilderWindow(Build build, bool show)
        {
            formBuilder fBuilder = new formBuilder(build)
            {
                MdiParent = this.parentWindow,
                Name = build.Name
            };
            fBuilder.FormClosed += this.formBuilder_FormClosed;
            this.fBuilders.Add(fBuilder);
            if (show)
                this.ToggleWindow(fBuilder, true);
            return;
        }
        public void CreateNewBuild()
        {
            this.CreateBuilderWindow(this.Builds.New(), true);
            return;
        }
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
            this.parentWindow = parent;
            this.fChampions.MdiParent = parent;
            this.fItems.MdiParent = parent;
            this.fMaps.MdiParent = parent;
            this.fSettings.MdiParent = parent;
            return;
        }

        public void InitializeFormVisibility()
        {
            this.fChampions.Visible = GeneralSettings.GetWindowWasOpen(this.fChampions);
            this.fItems.Visible = GeneralSettings.GetWindowWasOpen(this.fItems);
            this.fMaps.Visible = GeneralSettings.GetWindowWasOpen(this.fMaps);
            this.fSettings.Visible = GeneralSettings.GetWindowWasOpen(this.fSettings);
            foreach(formBuilder form in this.fBuilders)
                form.Visible = GeneralSettings.GetWindowWasOpen(form);
            return;
        }
        private void ToggleWindow(Form form, bool value)
        {
            bool was_visible = form.Visible;
            form.Visible = value;
            if (value)
            {
                if (form.WindowState == FormWindowState.Minimized || !form.ContainsFocus)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                }
                else if (was_visible)
                    form.WindowState = FormWindowState.Minimized;
            }
            return;
        }
        public void UpdateBuilds()
        {
            this.fChampions.Model.Builds = this.fItems.Model.Builds = this.Builds;
            this.fBuilders.Clear();
            for (int i = 0; i < this.Builds.Count; i++)
                this.CreateBuilderWindow(this.Builds[i], false);
            return;
        }
        private void btnSelectBuild_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem button = sender as ToolStripMenuItem;
            if (button == null)
                return;
            ToolStripDropDownButton parent = button.OwnerItem as ToolStripDropDownButton;
            int index = parent?.DropDownItems.IndexOf(button) - 1 ?? -1;
            if (index < 0 || index >= this.fBuilders.Count)
                return;
            formBuilder form = this.fBuilders[index];
            this.ToggleWindow(form, true);
            return;
        }
        private void formBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBuilder form = sender as formBuilder;
            if (form == null)
                return;
            this.fBuilders.Remove(form);
            this.Builds.Remove(form.Model.Build);
            return;
        }
        private void BuildCollection_Changed()
        {
            if (this.BuildCollectionChanged != null)
                this.BuildCollectionChanged();
            return;
        }
    }
}

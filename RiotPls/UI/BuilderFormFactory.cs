using System.Collections.Generic;
using System.Windows.Forms;
using RiotPls.API.Builder;
using RiotPls.Tools;
using RiotPls.UI.Views;

namespace RiotPls.UI
{
    /// <summary>
    /// Creates and manages build windows
    /// </summary>
    public class BuilderFormFactory
    {
        #region Instance Members
        private readonly Form parentWindow = null;
        private readonly List<formBuilder> fBuilders = new List<formBuilder>();
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
                this._Builds = value;
                this.UpdateBuilds();
                return;
            }
        }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent">Parent window of all build forms</param>
        public BuilderFormFactory(Form parent)
        {
            this.parentWindow = parent;
            return;
        }

        private void CreateBuilderWindow(Build build, bool show)
        {
            formBuilder form = new formBuilder(build)
            {
                MdiParent = this.parentWindow,
                Name = build.Name
            };
            form.FormClosed += this.formBuilder_FormClosed;
            form.FormClosing += this.formBuilder_FormClosing;
            this.fBuilders.Add(form);
            if (show)
                Drawing.ToggleWindow(form, true);
            return;
        }
        /// <summary>
        /// Create a new build and associated build window
        /// </summary>
        public void CreateNewBuild()
        {
            this.CreateBuilderWindow(this.Builds.New(), true);
            return;
        }

        /// <summary>
        /// Show forms which were visible when the previous session was terminated
        /// </summary>
        public void InitializeFormVisibility()
        {
            foreach (formBuilder form in this.fBuilders)
                form.Visible = GeneralSettings.GetWindowWasOpen(form);
            return;
        }

        /// <summary>
        /// Prompts the user to close a build window
        /// </summary>
        /// <param name="name">Name of the build associated with the window</param>
        /// <returns>True if the user wishes to close the window, false otherwise</returns>
        private bool PromptToClose(string name)
        {

            if (MessageBox.Show(this.parentWindow,
                string.Format("Closing this window will delete the build ('{0}'). Continue?", name), "Delete Build?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Show the build window associated with the specified index
        /// </summary>
        /// <param name="index">Index of the build window to show</param>
        public void ShowBuild(int index)
        {
            if (index < 0 || index >= this.fBuilders.Count)
                return;
            formBuilder form = this.fBuilders[index];
            Drawing.ToggleWindow(form, true);
            return;
        }

        /// <summary>
        /// Refresh window list to reflect build collection changes
        /// </summary>
        public void UpdateBuilds()
        {
            this.fBuilders.Clear();
            for (int i = 0; i < this.Builds.Count; i++)
                this.CreateBuilderWindow(this.Builds[i], false);
            return;
        }
        #endregion
        #region Event Methods
        private void formBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBuilder form = sender as formBuilder;
            if (form == null || e.CloseReason != CloseReason.UserClosing)
                return;
            this.fBuilders.Remove(form);
            this.Builds.Remove(form.Model.Build);
            return;
        }
        private void formBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            // we only want to respond to a user action
            if (e.CloseReason != CloseReason.UserClosing)
                return;
            formBuilder form = sender as formBuilder;
            if (form == null)
                return;
            int index = this.fBuilders.IndexOf(form);
            if (index < 0)
                return;
            Build build = this.Builds[index];
            if (build == null)
                return;
            e.Cancel = !this.PromptToClose(build.Name);
            return;
        }
        #endregion
    }
}

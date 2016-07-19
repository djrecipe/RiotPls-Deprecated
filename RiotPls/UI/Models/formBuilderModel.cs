using RiotPls.API.Builder;
using RiotPls.Tools;

namespace RiotPls.Forms.UI.Models
{
    /// <summary>
    /// View model for formBuilder
    /// </summary>
    /// <seealso cref="formBuilder"/>
    public class formBuilderModel
    {
        #region Instance Members
        #region Events
        public event IntegerDelegate RowChanged;
        public event Build.BuildDelegate BuildChanged;
        #endregion
        #endregion
        #region Instance Properties
        /// <summary>
        /// Build associated with the window and view model
        /// </summary>
        public Build Build { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="build">Build associated with the window and view model</param>
        #endregion
        #region Instance Methods
        public formBuilderModel(Build build)
        {
            this.Build = build;
            this.Build.BuildChanged += this.Build_BuildChanged;
            this.Build.SelectedRowChanged += this.Build_SelectedRowChanged;
        }
        /// <summary>
        /// Notify all listeners that the build has changed
        /// </summary>
        public void UpdateBuild()
        {
            if (this.BuildChanged != null)
                this.BuildChanged(this.Build);
            return;
        }
        /// <summary>
        /// Notify all listeners that the selected row has changed
        /// </summary>
        /// <param name="row">Index of the newly selected row</param>
        public void SelectRow(int row)
        {
            if (this.RowChanged != null)
                this.RowChanged(row);
            return;
        }
        private void Build_BuildChanged(string name)
        {
            this.UpdateBuild();
            return;
        }
        private void Build_SelectedRowChanged(int row)
        {
            this.SelectRow(row);
            return;
        }
        #endregion
    }
}

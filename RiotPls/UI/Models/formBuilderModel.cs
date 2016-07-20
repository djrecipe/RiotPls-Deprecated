using System;
using System.ComponentModel;
using RiotPls.API.Builder;
using RiotPls.Tools;
using RiotPls.UI.Interfaces;
using RiotPls.UI.Models;
using RiotPls.UI.Views;

namespace RiotPls.Forms.UI.Models
{
    /// <summary>
    /// View model for formBuilder
    /// </summary>
    /// <seealso cref="formBuilder"/>
    public class formBuilderModel : ITemplateViewModel
    {
        #region Instance Members
        #region Events                 
        /// <summary>
        /// Current build has changed
        /// </summary>
        public event Build.BuildDelegate BuildChanged;
        /// <summary>
        /// Data has finished updating
        /// </summary>
        public event EventHandler<object> DataUpdateFinished;
        /// <summary>
        /// Data update is about to start
        /// </summary>
        public event VoidDelegate DataUpdateStarted;
        /// <summary>
        /// Selected row has changed
        /// </summary>
        public event IntegerDelegate RowChanged;
        #endregion     
        #endregion
        #region Instance Properties
        /// <summary>
        /// Build associated with the window and view model
        /// </summary>
        public Build Build { get; set; }
        /// <summary>
        /// Currently selected item
        /// </summary>
        public string SelectedItem { get; set; }
        /// <summary>
        /// Worker for updating data
        /// </summary>
        public BackgroundWorker Worker { get; }
        #endregion
        #region Instance Methods        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="build">Build associated with the window and view model</param>
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
        /// <summary>
        /// Update data
        /// </summary>
        public void UpdateData()
        {
        }
        #endregion
        #region Instance Events
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

using System;
using RiotPls.Tools;
using RiotPls.UI.Views;

namespace RiotPls.UI.Interfaces
{
    /// <summary>
    /// View model interface for formTemplate
    /// </summary>
    /// <seealso cref="formTemplate"/>
    public interface ITemplateViewModel
    {
        #region Events              
        /// <summary>
        /// Data has finished updating
        /// </summary>
        event EventHandler<object> DataUpdateFinished;
        /// <summary>
        /// Data update is about to start
        /// </summary>
        event VoidDelegate DataUpdateStarted;
        #endregion
        #region Properties
        /// <summary>
        /// Worker for updating data
        /// </summary>
        System.ComponentModel.BackgroundWorker Worker { get; }
        #endregion
        #region Methods
        /// <summary>
        /// Update data
        /// </summary>
        void UpdateData();
        #endregion
    }
}

using System;
using System.ComponentModel;
using RiotPls.Tools;
using RiotPls.UI.Interfaces;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formSettings
    /// </summary>
    /// <seealso cref="formSettings"/>
    public class formSettingsModel : ITemplateViewModel
    {
        #region Instance Members                                         
        #region Events                 
        /// <summary>
        /// Data has finished updating
        /// </summary>    
        public event EventHandler<object> DataUpdateFinished;
        /// <summary>
        /// Data update is about to start
        /// </summary>
        public event VoidDelegate DataUpdateStarted;
        #endregion
        #endregion
        #region Instance Properties  
        /// <summary>
        /// Worker for updating data
        /// </summary>
        public BackgroundWorker Worker { get; private set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public formSettingsModel()
        {
            this.Worker = new BackgroundWorker();
            this.Worker.DoWork += this.BackgroundWorker_DoWork;
            this.Worker.RunWorkerCompleted += this.BackgroundWorker_RunWorkerCompleted;
            return;
        }
        /// <summary>
        /// Update data
        /// </summary>
        public void UpdateData()
        {
            if (this.Worker.IsBusy)
                return;
            if (this.DataUpdateStarted != null)
                this.DataUpdateStarted();
            this.Worker.RunWorkerAsync();
            return;
        }

        #endregion
        #region Instance Events    
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                API.Engine.Key.Load();
                e.Result = API.Engine.Key.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading API key\n{0}", ex.Message);
            }
            return;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.DataUpdateFinished != null)
                this.DataUpdateFinished(this, e.Result);
            return;
        }
        #endregion
    }
}

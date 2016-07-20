using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using RiotPls.API;
using RiotPls.API.Serialization.Maps;
using RiotPls.Tools;
using RiotPls.UI.Interfaces;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formMaps
    /// </summary>
    /// <seealso cref="formMaps"/>
    public class formMapsModel : ITemplateViewModel
    {
        #region Instance Members                                         
        private Dictionary<string, MapInfo> source = new Dictionary<string, MapInfo>();
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
        public formMapsModel()
        {
            this.Worker = new BackgroundWorker();
            this.Worker.DoWork += this.BackgroundWorker_DoWork;
            this.Worker.RunWorkerCompleted += this.BackgroundWorker_RunWorkerCompleted;
            return;
        }

        /// <summary>
        /// Retrieve image for the map with the specified name
        /// </summary>
        /// <param name="name">Map name</param>
        /// <returns>Map image</returns>
        public Image GetImage(string name)
        {
            if (this.source == null || name == null || this.source.Values.Count < 1)
                return null;
            return this.source.Values.FirstOrDefault(m => m.Name == name)?.Image;
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
            this.source = Engine.GetMapInfo();
            e.Result = this.source;
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

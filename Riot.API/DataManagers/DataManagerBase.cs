using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.Tools;

namespace RiotPls.API.DataManagers
{
    /// <summary>
    /// Manages a 'master' collection of data
    /// </summary>
    public abstract class DataManagerBase<T> where T : INameable
    {
        #region Types
        /// <summary>
        /// Data states
        /// </summary>
        public enum States : uint
        {
            /// <summary>
            /// No data available
            /// </summary>
            Invalid = 0,
            /// <summary>
            /// Local cached data available
            /// </summary>
            Cached = 1,
            /// <summary>
            /// Data is up-to-date
            /// </summary>
            Live = 3
        }
        #endregion
        #region Instance Members
        /// <summary>
        /// API key for retrieving remote information
        /// </summary>
        protected APIKey apiKey = null;
        /// <summary>
        /// Data collection
        /// </summary>
        protected Dictionary<string, T> infos = new Dictionary<string, T>();
        /// <summary>
        /// Data update completed
        /// </summary>
        public event VoidDelegate DataUpdateFinished = null;
        private readonly BackgroundWorker workerUpdate = new BackgroundWorker();
        #endregion
        #region Instance Properties
        public States State { get; protected set; } = States.Invalid;
        #endregion
        #region Instance Methods     
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">API key for retrieving remote information</param>
        public DataManagerBase(APIKey key)
        {
            if(key == null)
                throw new ArgumentNullException("key", "You must provide a non-null API key");
            this.workerUpdate.DoWork += this.BackgroundWorker_DoWork;
            this.workerUpdate.RunWorkerCompleted += this.BackgroundWorker_RunWorkerCompleted;
            this.apiKey = key;
            this.Update();
            return;
        }

        /// <summary>
        /// Background worker data update implementation
        /// </summary>
        /// <returns>Data update result</returns>
        protected abstract Tuple<Dictionary<string, T>, States> DoWork();

        /// <summary>
        /// Retrieve a datum associated with the specified name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Single instance of data</returns>
        public T Get(string name)
        {
            T item = this.infos.Values.FirstOrDefault(i => i.Name == name);
            return item;
        }

        /// <summary>
        /// Retrieve all data in the collection
        /// </summary>
        /// <returns>List of instances of data</returns>
        public List<T> GetList()
        {
            return this.infos.Values.OrderBy(item => item.Name).ToList();
        }
        /// <summary>
        /// Fire DataUpdateFinished event
        /// </summary>
        protected void OnDataUpdateFinished()
        {
            if (this.DataUpdateFinished != null)
                this.DataUpdateFinished();
            return;
        }

        /// <summary>
        /// Update data
        /// </summary>
        public void Update()
        {
            this.workerUpdate.RunWorkerAsync();
        }
        #endregion
        #region Event Methods        
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = this.DoWork();
            return;
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<Dictionary<string, T>, States> result = e.Result as Tuple<Dictionary<string, T>, States>;
            this.infos = result.Item1;
            this.State = result.Item2;
            this.OnDataUpdateFinished();
            return;
        }
        #endregion
    }
}

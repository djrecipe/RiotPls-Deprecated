using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.DataManagers;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.Tools;

namespace RiotPls.Binding
{
    public abstract class BindingListBase<T> : IInfoBindingList<T> where T: INameable
    {
        #region Instance Members
        private readonly DataManagerBase<T> dataManager = null;
        /// <summary>
        /// Data update completed
        /// </summary>
        public event VoidDelegate DataUpdateFinished = null;
        #endregion
        #region Instance Properties
        /// <summary>
        /// Data to bind directly to control(s) 
        /// </summary>
        public SortableBindingList<T> Binding { get; protected set; }
        /// <summary>
        /// Categories/columns to be used when filtering
        /// </summary>
        /// <seealso cref="SetFilter"/>
        public List<string> FilterItems { get; private set; } = new List<string>();
        /// <summary>
        /// Search text used when filtering
        /// </summary>
        /// <seealso cref="SetFilter"/>
        public string SearchText { get; private set; }
        /// <summary>
        /// Original data collection, without filters
        /// </summary>
        public SortableBindingList<T> Source { get; private set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public BindingListBase(DataManagerBase<T> data_manager)
        {
            if (data_manager == null)
                throw new ArgumentNullException("data_manager", "Invalid data manager");
            this.dataManager = data_manager;
            this.dataManager.DataUpdateFinished += this.ChampionDataManager_DataUpdateFinished;
            this.Source = new SortableBindingList<T>(this.dataManager.GetList());
            return;
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
        /// Retrieve a ChampionInfo that uses the specified name
        /// </summary>
        /// <param name="name">Identifier to search for</param>     
        /// <returns>ChampionInfo using the specified name, if any</returns>
        public T Retrieve(string name)
        {
            return this.Source.FirstOrDefault(i => i.Name == name);
        }
        /// <summary>
        /// Set filter category(s) and search text
        /// </summary>
        /// <param name="items">Categories/columns to filter</param>
        /// <param name="search_text">Search text to include in the filter</param>
        /// <remarks>Filter is not updated until Update() is called</remarks>
        public void SetFilter(IEnumerable<string> items, string search_text)
        {
            this.FilterItems = items?.ToList() ?? new List<string>();
            this.SearchText = search_text;
            return;
        }

        /// <summary>
        /// Update binding to reflect data or filter changes
        /// </summary>
        public abstract void UpdateFilter();
        #endregion
        #region Event Methods
        private void ChampionDataManager_DataUpdateFinished()
        {
            this.Source = new SortableBindingList<T>(this.dataManager.GetList());
            this.UpdateFilter();
            return;
        }
        #endregion
    }
}

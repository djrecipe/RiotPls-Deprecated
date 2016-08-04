using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.DataManagers
{
    /// <summary>
    /// Manages a 'master' collection of data
    /// </summary>
    public abstract class DataManagerBase<T> where T : INameable
    {
        #region Instance Members
        /// <summary>
        /// API key for retrieving remote information
        /// </summary>
        protected APIKey apiKey = null;
        /// <summary>
        /// Data collection
        /// </summary>
        protected Dictionary<string, T> infos = new Dictionary<string, T>();
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
            this.apiKey = key;
            this.Update();
            return;
        }

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
        /// Update data
        /// </summary>
        public abstract void Update();
        #endregion
    }
}

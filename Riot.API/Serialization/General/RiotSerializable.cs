using System;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    /// <summary>
    /// Implementation of a generic serializable collection of data, cached locally
    /// </summary>
    /// <typeparam name="T">Root object type to serialize/deserialize</typeparam>
    /// <seealso cref="IRiotSerializable{T}"/>
    public abstract class RiotSerializable<T> : IRiotSerializable<T>
    {
        #region Instance Members
        /// <summary>
        /// API key used for remote connections
        /// </summary>
        protected APIKey apiKey = null;
        #endregion
        #region Instance Properties   
        /// <summary>
        /// Local filename where cache is stored
        /// </summary>
        public abstract string LocalFileName { get; }
        /// <summary>
        /// Root JSON token from which the serializable data will be extracted
        /// </summary>
        public abstract string RootToken { get; }
        /// <summary>
        /// A Riot URL from which the data is originally obtained
        /// </summary>
        public abstract RiotURL URL { get; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">API key to use for remote connections</param>
        protected RiotSerializable(APIKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key", "You must provide a non-null API key");
            this.apiKey = key;
            return;
        }
        /// <summary>
        /// Dynamically retrieves deserialized object data, either from the remote URL or local cache
        /// </summary>
        /// <param name="remote_retrieval">Output variable specifying whether the data was retrieved from a remote source</param>
        /// <returns>Deserialized object data</returns>
        public T Get(out bool remote_retrieval)
        {
            this.Validate();
            JsonPayload<T> payload = new JsonPayload<T>(this.URL, this.LocalFileName, this.RootToken);
            return payload.Get(out remote_retrieval);
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.LocalFileName))
                throw new ArgumentException("Must provide a valid local file name", "LocalFileName");
            if (string.IsNullOrWhiteSpace(this.URL))
                throw new ArgumentException("Must provide a valid URL object", "URL");
            return;
        }
        #endregion
    }
}

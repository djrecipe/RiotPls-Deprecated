using System;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    public abstract class RiotSerializable<T> : IRiotSerializable<T>
    {
        #region Instance Members
        protected APIKey apiKey = null;
        #endregion
        #region Instance Properties
        public abstract string LocalFileName { get; }
        public abstract string RootToken { get; }
        public abstract RiotURL URL { get; }
        #endregion
        #region Instance Methods
        public RiotSerializable(APIKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key", "You must provide a non-null API key");
            this.apiKey = key;
            return;
        } 
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

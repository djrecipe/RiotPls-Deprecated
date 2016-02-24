using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.API.Serialization.Transport;

namespace RiotPls.API.Serialization.General
{
    public abstract class RiotSerializable<T> : IRiotSerializable<T>
    {
        public abstract string LocalFileName { get; }
        public abstract string RootToken { get; }
        public abstract RiotURL URL { get; }
        public T Get()
        {
            this.Validate();
            JsonPayload<T> payload = new JsonPayload<T>(this.URL, this.LocalFileName, this.RootToken);
            return payload.Get();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.LocalFileName))
                throw new ArgumentException("Must provide a valid local file name", "LocalFileName");
            if (string.IsNullOrWhiteSpace(this.URL))
                throw new ArgumentException("Must provide a valid URL object", "URL");
            return;
        }
    }
}

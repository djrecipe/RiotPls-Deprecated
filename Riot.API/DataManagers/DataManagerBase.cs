using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Interfaces;

namespace RiotPls.API.DataManagers
{
    public abstract class DataManagerBase<T> where T : INameable
    {
        protected APIKey apiKey = null;
        protected Dictionary<string, T> infos = new Dictionary<string, T>();
        public DataManagerBase(APIKey key)
        {
            if(key == null)
                throw new ArgumentNullException("key", "You must provide a non-null API key");
            this.apiKey = key;
            this.Update();
            return;
        }

        public T Get(string name)
        {
            T item = this.infos.Values.FirstOrDefault(i => i.Name == name);
            return item;
        }
        public List<T> GetList()
        {
            return this.infos.Values.OrderBy(item => item.Name).ToList();
        }
        public abstract void Update();
    }
}

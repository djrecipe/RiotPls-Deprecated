﻿using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.Serialization.Items;

namespace RiotPls.API.DataManagers
{
    /// <summary>
    /// Manages a 'master' collection of items
    /// </summary>
    public class ItemDataManager : DataManagerBase<ItemInfo>
    {
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">API key for retrieving remote information</param>
        public ItemDataManager(APIKey key) : base(key)
        {
        }
        /// <summary>
        /// Retrieve all build components of the specified item
        /// </summary>
        /// <param name="item">Item to retrieve components of</param>
        /// <param name="recurse">True to retrieve components-of-components</param>
        /// <returns>A list of item components</returns>
        public List<ItemInfo> GetItemComponents(ItemInfo item, bool recurse)
        {
            List<ItemInfo> components = new List<ItemInfo>();
            foreach (string component_id in item.ComponentIDs.Where(id => this.infos.ContainsKey(id)))
            {
                ItemInfo item_component = this.infos[component_id];
                if (item_component != null)
                {
                    components.Add(item_component);
                    if (recurse)
                    {
                        List<ItemInfo> sub_components = this.GetItemComponents(item_component, true);
                        if (sub_components != null && sub_components.Count > 0)
                            components.AddRange(sub_components);
                    }
                }
            }
            return components;

        }
        #endregion
        #region Override Methods   
        /// <summary>
        /// Background worker data update implementation
        /// </summary>
        /// <returns>Data update result</returns>
        protected override Tuple<Dictionary<string, ItemInfo>, States> DoWork()
        {
            Dictionary<string, ItemInfo> item_infos = new Dictionary<string, ItemInfo>();
            States state = States.Invalid;
            try
            {
                ItemInfoSet items = new ItemInfoSet(this.apiKey);
                bool remote_retrieval = false;
                item_infos = items.Get(out remote_retrieval);
                state = remote_retrieval ? States.Live : States.Cached;
            }
            catch (Exception e)
            {
                state = States.Invalid;
            }
            return new Tuple<Dictionary<string, ItemInfo>, States>(item_infos, state);
        }
        #endregion
    }
}

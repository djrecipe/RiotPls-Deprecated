using System.Collections.Generic;
using System.Linq;
using RiotPls.API;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Binding
{
    public class ItemInfoBindingList : IInfoBindingList<ItemInfo>
    {
        #region Instance Properties
        /// <summary>
        /// Data to bind directly to control(s) 
        /// </summary>
        public SortableBindingList<ItemInfo> Binding { get; private set; }
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
        public SortableBindingList<ItemInfo> Source { get; private set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public ItemInfoBindingList()
        {
            this.Source = new SortableBindingList<ItemInfo>(Engine.Items.GetList());
            this.Update();
            return;
        }
        /// <summary>
        /// Retrieve an ItemInfo that uses the specified name
        /// </summary>
        /// <param name="name">Identifier to search for</param>
        /// <returns>ItemInfo using the specified name, if any</returns>
        public ItemInfo Retrieve(string name)
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
            if (items == null)
                return;
            this.FilterItems = items.ToList();
            this.SearchText = search_text;
            return;
        }
        /// <summary>
        /// Update binding to reflect data or filter changes
        /// </summary>
        public void Update()
        {
            // always active filter
            SortableBindingList<ItemInfo> new_binding = new SortableBindingList<ItemInfo>(this.Source.Where(info => string.IsNullOrWhiteSpace(info.RequiredChampion)).ToList<ItemInfo>());
            // other filters
            if (this.FilterItems.Contains("Consumables"))
                new_binding =
                    new SortableBindingList<ItemInfo>(new_binding.Where(info => info.Consumable).ToList<ItemInfo>());
            if (this.FilterItems.Contains("Non-Consumables"))
                new_binding =
                    new SortableBindingList<ItemInfo>(new_binding.Where(info => !info.Consumable).ToList<ItemInfo>());
            // TODO: 07/20/16 implement more filters here
            this.Binding = new_binding;
            return;
        }
        #endregion
    }
}

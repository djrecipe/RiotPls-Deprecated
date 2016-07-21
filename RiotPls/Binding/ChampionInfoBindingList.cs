using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API;
using RiotPls.API.Serialization.Champions;

namespace RiotPls.Binding
{
    /// <summary>
    /// Facilitates data binding of a collection of ChampionInfo objects
    /// </summary>
    /// <seealso cref="ChampionInfo"/>
    public class ChampionInfoBindingList : IInfoBindingList<ChampionInfo>
    {
        #region Instance Properties
        /// <summary>
        /// Data to bind directly to control(s) 
        /// </summary>
        public SortableBindingList<ChampionInfo> Binding { get; private set; }
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
        public SortableBindingList<ChampionInfo> Source { get; private set; }
        #endregion
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChampionInfoBindingList()
        {
            Dictionary <string, ChampionInfo> infos = Engine.GetChampionInfo();
            this.Source = new SortableBindingList<ChampionInfo>(infos.Values.OrderBy(champ => champ.Name).ToList());
            this.Update();
            return;
        }
        /// <summary>
        /// Retrieve a ChampionInfo that uses the specified name
        /// </summary>
        /// <param name="name">Identifier to search for</param>     
        /// <returns>ChampionInfo using the specified name, if any</returns>
        public ChampionInfo Retrieve(string name)
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
            SortableBindingList<ChampionInfo> new_binding = new SortableBindingList<ChampionInfo>(this.Source.Where(info => info != null).ToList<ChampionInfo>());
            // other filters   
            string filter_category = this.FilterItems.Count > 0 ? this.FilterItems[0] : null;
            switch (filter_category)
            {
                case "Free":
                    if (this.SearchText != "Any")
                    {
                        bool free_to_play = this.SearchText == "Free";
                        new_binding = new SortableBindingList<ChampionInfo>(this.Source.Where(info =>
                            info.FreeToPlay == free_to_play).ToList<ChampionInfo>());
                    }
                    break;
                case "Name":
                    new_binding = new SortableBindingList<ChampionInfo>(this.Source.Where(info =>
                        info.Name.ToUpper().Contains(this.SearchText.ToUpper())).ToList<ChampionInfo>());
                    break;
                case "Tags":
                    new_binding = new SortableBindingList<ChampionInfo>(this.Source.Where(info =>
                        info.TagList.ToUpper().Contains(this.SearchText.ToUpper())).ToList<ChampionInfo>());
                    break;
                case "Title":
                    new_binding = new SortableBindingList<ChampionInfo>(this.Source.Where(info =>
                        info.Title.ToUpper().Contains(this.SearchText.ToUpper())).ToList<ChampionInfo>());
                    break;
                // TODO: 07/20/16 implement more filters here
                default:
                    break;
            }
            this.Binding = new_binding;
            return;
        }
        #endregion
    }
}

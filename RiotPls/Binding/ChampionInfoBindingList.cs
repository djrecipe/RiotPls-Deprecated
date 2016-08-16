using System;
using System.Collections.Generic;
using System.Linq;
using RiotPls.API.DataManagers;
using RiotPls.API.Serialization.Champions;
using RiotPls.Tools;

namespace RiotPls.Binding
{
    /// <summary>
    /// Facilitates data binding of a collection of ChampionInfo objects
    /// </summary>
    /// <seealso cref="ChampionInfo"/>
    public class ChampionInfoBindingList : BindingListBase<ChampionInfo>
    {
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChampionInfoBindingList(ChampionDataManager data_manager) : base(data_manager)
        {
            return;
        }

        /// <summary>
        /// Update binding to reflect data or filter changes
        /// </summary>
        public override void UpdateFilter()
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
            this.OnDataUpdateFinished();
            return;
        }
        #endregion
    }
}

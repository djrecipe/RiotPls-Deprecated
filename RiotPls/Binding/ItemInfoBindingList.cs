using System.Linq;
using RiotPls.API.DataManagers;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Binding
{
    /// <summary>
    /// Facilitates data binding of a collection of ItemInfo objects
    /// </summary>
    /// <seealso cref="ItemInfo"/>
    public class ItemInfoBindingList : BindingListBase<ItemInfo>
    {
        #region Instance Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public ItemInfoBindingList(ItemDataManager data_manager) : base(data_manager)
        {
            return;
        }
        /// <summary>
        /// Update binding to reflect data or filter changes
        /// </summary>
        public override void UpdateFilter()
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
            this.OnDataUpdateFinished();
            return;
        }
        #endregion  
    }
}

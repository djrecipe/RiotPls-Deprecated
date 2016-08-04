using System;
using System.Collections.Generic;
using System.Drawing;
using RiotPls.API;
using RiotPls.API.Serialization.Items;
using RiotPls.UI.Controls;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formItemComponents
    /// </summary>
    /// <seealso cref="formItemComponents"/>
    public class formItemComponentsModel
    {
        #region Instance Members
        private Dictionary<ItemInfo, List<ItemInfo>> itemRelations = new Dictionary<ItemInfo, List<ItemInfo>>();
        #endregion
        #region Instance Properties
        private ItemInfo _Item = null;
        public ItemInfo Item
        {
            get { return this._Item; }
            set
            {
                this._Item = value;
                this.Update();
            }
        }

        #endregion
        #region Instance Methods
        public formItemComponentsModel(ItemInfo item)
        {
            this.Item = item;
            return;
        }

        public Dictionary<DropSlot, List<DropSlot>> GenerateDropSlots(out DropSlot first_slot)
        {
            Dictionary<DropSlot, List<DropSlot>> slots = new Dictionary<DropSlot, List<DropSlot>>();
            first_slot = null;
            foreach (KeyValuePair<ItemInfo, List<ItemInfo>> pair in this.itemRelations)
            {
                DropSlot key_slot = new DropSlot();
                key_slot.Set(pair.Key);
                key_slot.ForeColor = Color.FromArgb(225, 225, 225);
                key_slot.Type = DropSlot.DataTypes.Item;
                if (pair.Key == this.Item)
                    first_slot = key_slot;
                List<DropSlot> value_slots = new List<DropSlot>();
                foreach (ItemInfo component in pair.Value)
                {
                    DropSlot component_slot = new DropSlot();
                    component_slot.Set(component);
                    component_slot.ForeColor = Color.FromArgb(225, 225, 225);
                    component_slot.Type = DropSlot.DataTypes.Item;
                    value_slots.Add(component_slot);
                }
                slots.Add(key_slot, value_slots);
            }
            return slots;
        }

        private void RecurseComponents(ItemInfo item)
        {
            List<ItemInfo> components = Engine.Items.GetItemComponents(item, false);
            if (components.Count > 0 && !this.itemRelations.ContainsKey(item))
            {
                this.itemRelations.Add(item, components);
                foreach (ItemInfo component in components)
                {
                    this.RecurseComponents(component);
                }
            }
            return;
        }

        private void Update()
        {
            this.RecurseComponents(this.Item);
            return;
        }
        #endregion
    }
}

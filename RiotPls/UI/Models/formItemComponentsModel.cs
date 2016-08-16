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

        public List<DropSlot> GenerateDropSlots()
        {
            List<DropSlot> slots = new List<DropSlot>();
            if (!this.itemRelations.ContainsKey(this.Item))
                return slots;
            foreach (ItemInfo item in this.itemRelations[this.Item])
            {
                DropSlot component_slot = new DropSlot();
                component_slot.Set(item);
                component_slot.ForeColor = Color.FromArgb(225, 225, 225);
                component_slot.Type = DropSlot.DataTypes.Item;
                slots.Add(component_slot);
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

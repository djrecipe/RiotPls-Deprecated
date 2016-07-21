using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Items;
using RiotPls.Binding;
using RiotPls.Tools;
using RiotPls.UI.Interfaces;
using RiotPls.UI.Views;

namespace RiotPls.UI.Models
{
    /// <summary>
    /// View model for formItems
    /// </summary>
    /// <seealso cref="formItems"/>
    public class formItemsModel : IBuildModifier
    {
        #region Instance Members  
        private ItemInfoBindingList binding = null;
        #region Events
        public event VoidDelegate DataUpdateStarted;
        public event EventHandler<object> DataUpdateFinished;
        #endregion
        #endregion
        #region Instance Properties
        /// <summary>
        /// Set of builds which may be modified
        /// </summary>
        public BuildCollection Builds { get; set; }
        public string SelectedItem { get; set; }
        public BackgroundWorker Worker { get; private set; }
        #endregion
        #region Instance Methods
        public formItemsModel()
        {
            this.Worker = new BackgroundWorker();
            this.Worker.DoWork += this.BackgroundWorker_DoWork;
            this.Worker.RunWorkerCompleted += this.BackgroundWorker_RunWorkerCompleted;
            return;
        }
        public List<ToolStripMenuItem> GetBuildMenuItems()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            for (int i = 0; i < this.Builds.Count; i++)
            {
                Build build = this.Builds[i];
                if (build == null)
                    continue;
                List<int> indices = build.GetItemIndices(this.SelectedItem);
                ToolStripMenuItem item = new ToolStripMenuItem(build.Name)
                {
                    CheckOnClick = false,
                    Checked = indices.Count > 0
                };
                for (int j = 0; j < 6; j++)
                {
                    ToolStripMenuItem subitem = new ToolStripMenuItem(string.Format("Item #{0}", j + 1))
                    {
                        CheckOnClick = true,
                        Checked = indices.Contains(j)
                    };
                    subitem.CheckedChanged += this.itmSetAsItem_CheckedChanged;
                    item.DropDownItems.Add(subitem);
                }
                items.Add(item);
            }
            return items;
        } 

        public void SetBuildItem(int build_index, int item_index, ItemInfo item)
        {
            Build build = this.Builds[build_index];
            if (build == null)
                return;
            build.SetItem(item_index, item);
        }

        public void SetFilter(CheckedListBox.CheckedItemCollection items)
        {
            this.binding?.SetFilter(items.Cast<string>(), null);
            return;
        }
        public void UpdateData()
        {
            if (this.Worker.IsBusy)
                return;
            if (this.DataUpdateStarted != null)
                this.DataUpdateStarted();
            this.Worker.RunWorkerAsync();
            return;
        }

        #endregion
        #region Instance Events    
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(this.binding == null)                        // only instantiate once, but instantiate on worker thread to keep UI responsive
                this.binding = new ItemInfoBindingList();
            else                                            // update filter
                this.binding.Update();
            e.Result = this.binding.Binding;
            return;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.DataUpdateFinished != null)
                this.DataUpdateFinished(this, e.Result);
            return;
        }
        private void itmSetAsItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_item = sender as ToolStripMenuItem;
            ToolStripMenuItem parent_item = menu_item?.OwnerItem as ToolStripMenuItem;
            int item_index = parent_item?.DropDownItems.IndexOf(menu_item) ?? -1;
            if (item_index < 0)
                return;
            ToolStripMenuItem root_item = parent_item.OwnerItem as ToolStripMenuItem;
            int build_index = root_item?.DropDownItems.IndexOf(parent_item) ?? -1;
            if (build_index < 0)
                return;
            ItemInfo item = menu_item.Checked ? this.binding.Retrieve(this.SelectedItem) : null;
            this.SetBuildItem(build_index, item_index, item);
            return;
        }
        #endregion
    }
}

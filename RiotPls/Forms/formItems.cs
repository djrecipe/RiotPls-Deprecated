using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Items;
using RiotPls.Controls;

namespace RiotPls.Forms
{
    /// <summary>
    /// Displays a list of items and their descriptions
    /// </summary>
    public class formItems : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private System.Windows.Forms.CheckedListBox chkdlistFilter;
        private ContextMenuStrip cmenMain;
        private ToolStripMenuItem itmShowStats;
        private ToolStripMenuItem itmLockTooltip;
        private ToolStripMenuItem itmSelectedForBuilder;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        #endregion
        private Dictionary<string, ItemInfo> items = new Dictionary<string, ItemInfo>();
        private BindingList<ItemInfo> source = null;
        private string lastItemName = null;
        #endregion
        #region Instance Properties    
        /// <summary>
        /// Set of builds which may be modified
        /// </summary>
        public BuildCollection Builds { get; set; }
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public formItems()
        {
            this.InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
            this.gridMain.DataError += this.gridMain_DataError;
            return;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formItems));
            this.gridMain = new RiotPls.Controls.Grid();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmShowStats = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLockTooltip = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSelectedForBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.chkdlistFilter = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.cmenMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(533, 349);
            // 
            // gridMain
            // 
            this.gridMain.AllowUserToAddRows = false;
            this.gridMain.AllowUserToDeleteRows = false;
            this.gridMain.AllowUserToResizeColumns = false;
            this.gridMain.AllowUserToResizeRows = false;
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridMain.BackgroundColor = System.Drawing.Color.Black;
            this.gridMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colName,
            this.colDescription});
            this.gridMain.ContextMenuStrip = this.cmenMain;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(29, 109);
            this.gridMain.Margin = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridMain.RowHeadersWidth = 22;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMain.RowTemplate.Height = 70;
            this.gridMain.RowTemplate.ReadOnly = true;
            this.gridMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(1137, 689);
            this.gridMain.TabIndex = 3;
            this.gridMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMain_CellMouseDown);
            this.gridMain.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellMouseEnter);
            this.gridMain.SizeChanged += new System.EventHandler(this.gridMain_SizeChanged);
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colImage.DataPropertyName = "Image";
            this.colImage.HeaderText = "Image";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImage.Width = 64;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 889;
            // 
            // cmenMain
            // 
            this.cmenMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmShowStats,
            this.itmLockTooltip,
            this.itmSelectedForBuilder});
            this.cmenMain.Name = "cmenMain";
            this.cmenMain.Size = new System.Drawing.Size(170, 92);
            this.cmenMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmenMain_Opening);
            // 
            // itmShowStats
            // 
            this.itmShowStats.CheckOnClick = true;
            this.itmShowStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmShowStats.Name = "itmShowStats";
            this.itmShowStats.Size = new System.Drawing.Size(169, 22);
            this.itmShowStats.Text = "Show Stats";
            // 
            // itmLockTooltip
            // 
            this.itmLockTooltip.CheckOnClick = true;
            this.itmLockTooltip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmLockTooltip.Name = "itmLockTooltip";
            this.itmLockTooltip.Size = new System.Drawing.Size(169, 22);
            this.itmLockTooltip.Text = "Lock Tooltip Data";
            // 
            // itmSelectedForBuilder
            // 
            this.itmSelectedForBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmSelectedForBuilder.Name = "itmSelectedForBuilder";
            this.itmSelectedForBuilder.ShowShortcutKeys = false;
            this.itmSelectedForBuilder.Size = new System.Drawing.Size(169, 22);
            this.itmSelectedForBuilder.Text = "Selected for Builder";
            // 
            // chkdlistFilter
            // 
            this.chkdlistFilter.BackColor = System.Drawing.Color.Black;
            this.chkdlistFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkdlistFilter.CheckOnClick = true;
            this.chkdlistFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chkdlistFilter.FormattingEnabled = true;
            this.chkdlistFilter.Items.AddRange(new object[] {
            "Consumables",
            "Howling Abyss",
            "Non-Consumables",
            "Summoner\'s Rift",
            "Twisted Treeline"});
            this.chkdlistFilter.Location = new System.Drawing.Point(49, 29);
            this.chkdlistFilter.Margin = new System.Windows.Forms.Padding(40, 20, 10, 10);
            this.chkdlistFilter.MultiColumn = true;
            this.chkdlistFilter.Name = "chkdlistFilter";
            this.chkdlistFilter.Size = new System.Drawing.Size(248, 60);
            this.chkdlistFilter.Sorted = true;
            this.chkdlistFilter.TabIndex = 4;
            this.chkdlistFilter.ThreeDCheckBoxes = true;
            this.chkdlistFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkdlistFilter_ItemCheck);
            // 
            // formItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 827);
            this.Controls.Add(this.chkdlistFilter);
            this.Controls.Add(this.gridMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "formItems";
            this.ShowLoading = true;
            this.Text = "Items";
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.chkdlistFilter, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.cmenMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private BindingList<ItemInfo> ConstructFilter()
        {
            if (this.source == null)
                return null;
            BindingList<ItemInfo> new_binding = new BindingList<ItemInfo>(this.source.Where(info => string.IsNullOrWhiteSpace(info.RequiredChampion)).ToList<ItemInfo>());
            if (!this.chkdlistFilter.GetItemChecked(this.chkdlistFilter.Items.IndexOf("Consumables")))
            {
                new_binding = new BindingList<ItemInfo>(new_binding.Where(info => !info.Consumable).ToList<ItemInfo>());
            }
            if (!this.chkdlistFilter.GetItemChecked(this.chkdlistFilter.Items.IndexOf("Non-Consumables")))
            {
                new_binding = new BindingList<ItemInfo>(new_binding.Where(info => info.Consumable).ToList<ItemInfo>());
            }
            if (!this.chkdlistFilter.GetItemChecked(this.chkdlistFilter.Items.IndexOf("Howling Abyss")))
            {
            }
            if (!this.chkdlistFilter.GetItemChecked(this.chkdlistFilter.Items.IndexOf("Summoner's Rift")))
            {
            }
            if (!this.chkdlistFilter.GetItemChecked(this.chkdlistFilter.Items.IndexOf("Twisted Treeline")))
            {
            }
            return new_binding;
        }
        private void ResizeColumns()
        {
            int width = this.gridMain.Width - 270;
            this.colDescription.Width = width;
            return;
        }
        #endregion
        #region Event Methods
        private void chkdlistFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(this.IsHandleCreated && this.Visible)
            {
                this.UpdateData();
            }
            return;
        }
        private void cmenMain_Opening(object sender, CancelEventArgs e)
        {
            if (this.lastItemName == null)
                e.Cancel = true;
            else
            {
                bool check_root = false;
                this.itmSelectedForBuilder.DropDownItems.Clear();
                for (int i = 0; i < this.Builds.Count; i++)
                {
                    Build build = this.Builds[i];
                    if (build == null)
                        continue;
                    List<int> indices = build.GetItemIndices(this.lastItemName);
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
                    this.itmSelectedForBuilder.Checked = indices.Count > 0;
                    this.itmSelectedForBuilder.DropDownItems.Add(item);
                }
                return;
            }
            return;
        }
        private void gridMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.items == null || e.RowIndex < 0 || e.RowIndex >= this.gridMain.RowCount)
                return;
            ItemInfo info = this.gridMain.Rows[e.RowIndex].DataBoundItem as ItemInfo;
            if (info != null)
            {
                this.BeginInvoke((MethodInvoker)delegate
                { this.gridMain.DoDragDrop(info.Clone() as ItemInfo, DragDropEffects.Copy); });
            }
            return;
        }
        private void gridMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= this.gridMain.RowCount)
                return;
            this.lastItemName = this.gridMain.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            return;
        }
        private void gridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        private void gridMain_SizeChanged(object sender, EventArgs e)
        {
            this.ResizeColumns();
            return;
        }
        private void itmSetAsItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menu_item = sender as ToolStripMenuItem;
            if (menu_item == null)
                return;
            ToolStripMenuItem parent_item =
                this.itmSelectedForBuilder.DropDownItems.Cast<ToolStripMenuItem>()
                    .FirstOrDefault(itm => itm.DropDownItems.Contains(menu_item));
            if (parent_item == null)
                return;
            int item_index = parent_item.DropDownItems.IndexOf(menu_item);
            if (item_index < 0)
                return;
            int build_index = this.itmSelectedForBuilder.DropDownItems.IndexOf(parent_item);
            if (build_index < 0)
                return;
            Build build = this.Builds[build_index];
            if (build == null)
                return;
            ItemInfo item = menu_item.Checked ? Engine.GetItem(this.lastItemName) : null;
            build.SetItem(item_index, item);
            return;
        }
        #endregion
        #region Override Methods
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void workerUpdateData_DoWork(object sender, DoWorkEventArgs e)
        {
            this.items = Engine.GetItemInfo();
            this.source = new SortableBindingList<ItemInfo>(this.items.Values.OrderBy(item => item.Name).ToList());
            e.Result = this.ConstructFilter();
            return;
        }
        protected override void workerUpdateData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindingList<ItemInfo> new_binding = e.Result as BindingList<ItemInfo>;
            if (new_binding != null)
                this.gridMain.DataSource = new_binding;
            this.picLoading.Visible = false;
            this.gridMain.Focus();
            return;
        }
        #endregion
    }
}

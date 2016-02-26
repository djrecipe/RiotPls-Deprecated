using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

using RiotPls.API;
using RiotPls.API.Serialization;
using RiotPls.API.Serialization.Items;
using RiotPls.Builder;

namespace RiotPls.Forms
{
    public class formItems : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private System.Windows.Forms.CheckedListBox chkdlistFilter;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewImageColumn colImage;
        private ContextMenuStrip cmenMain;
        private ToolStripMenuItem itmShowStats;
        private ToolStripMenuItem itmLockTooltip;
        private ToolStripMenuItem itmSelectedForBuilder;
        private ToolStripMenuItem itmSetAsItem1;
        private ToolStripMenuItem itmSetAsItem2;
        private ToolStripMenuItem itmSetAsItem3;
        private ToolStripMenuItem itmSetAsItem4;
        private ToolStripMenuItem itmSetAsItem5;
        private ToolStripMenuItem itmSetAsItem6;
        private ToolStripMenuItem[] menuItems = null;
        #endregion
        private Dictionary<string, ItemInfo> items = new Dictionary<string, ItemInfo>();
        private BindingList<ItemInfo> source = null;
        private string last_item_name = null;
        private Build build = null;
        private bool listeningToCheckboxes = false;
        #endregion
        #region Instance Methods
        public formItems()
        {
            this.InitializeComponent();
            this.menuItems = new ToolStripMenuItem[] { this.itmSetAsItem1, this.itmSetAsItem2, this.itmSetAsItem3, this.itmSetAsItem4, this.itmSetAsItem5, this.itmSetAsItem6};
            this.gridMain.AutoGenerateColumns = false;
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
            this.gridMain = new RiotPls.Grid();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmShowStats = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLockTooltip = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSelectedForBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSetAsItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.chkdlistFilter = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.cmenMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1166, 9);
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(533, 349);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Visible = false;
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
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // cmenMain
            // 
            this.cmenMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmShowStats,
            this.itmLockTooltip,
            this.itmSelectedForBuilder});
            this.cmenMain.Name = "cmenMain";
            this.cmenMain.Size = new System.Drawing.Size(177, 70);
            this.cmenMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmenMain_Opening);
            // 
            // itmShowStats
            // 
            this.itmShowStats.CheckOnClick = true;
            this.itmShowStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmShowStats.Name = "itmShowStats";
            this.itmShowStats.Size = new System.Drawing.Size(176, 22);
            this.itmShowStats.Text = "Show Stats";
            // 
            // itmLockTooltip
            // 
            this.itmLockTooltip.CheckOnClick = true;
            this.itmLockTooltip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmLockTooltip.Name = "itmLockTooltip";
            this.itmLockTooltip.Size = new System.Drawing.Size(176, 22);
            this.itmLockTooltip.Text = "Lock Tooltip Data";
            // 
            // itmSelectedForBuilder
            // 
            this.itmSelectedForBuilder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSetAsItem1,
            this.itmSetAsItem2,
            this.itmSetAsItem3,
            this.itmSetAsItem4,
            this.itmSetAsItem5,
            this.itmSetAsItem6});
            this.itmSelectedForBuilder.Name = "itmSelectedForBuilder";
            this.itmSelectedForBuilder.Size = new System.Drawing.Size(176, 22);
            this.itmSelectedForBuilder.Text = "Selected for Builder";
            this.itmSelectedForBuilder.DropDownClosed += new System.EventHandler(this.itmSelectedForBuilder_DropDownClosed);
            this.itmSelectedForBuilder.DropDownOpening += new System.EventHandler(this.itmSelectedForBuilder_DropDownOpening);
            // 
            // itmSetAsItem1
            // 
            this.itmSetAsItem1.CheckOnClick = true;
            this.itmSetAsItem1.Name = "itmSetAsItem1";
            this.itmSetAsItem1.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem1.Text = "Set as Item 1";
            this.itmSetAsItem1.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
            // 
            // itmSetAsItem2
            // 
            this.itmSetAsItem2.CheckOnClick = true;
            this.itmSetAsItem2.Name = "itmSetAsItem2";
            this.itmSetAsItem2.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem2.Text = "Set as Item 2";
            this.itmSetAsItem2.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
            // 
            // itmSetAsItem3
            // 
            this.itmSetAsItem3.CheckOnClick = true;
            this.itmSetAsItem3.Name = "itmSetAsItem3";
            this.itmSetAsItem3.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem3.Text = "Set as Item 3";
            this.itmSetAsItem3.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
            // 
            // itmSetAsItem4
            // 
            this.itmSetAsItem4.CheckOnClick = true;
            this.itmSetAsItem4.Name = "itmSetAsItem4";
            this.itmSetAsItem4.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem4.Text = "Set as Item 4";
            this.itmSetAsItem4.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
            // 
            // itmSetAsItem5
            // 
            this.itmSetAsItem5.CheckOnClick = true;
            this.itmSetAsItem5.Name = "itmSetAsItem5";
            this.itmSetAsItem5.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem5.Text = "Set as Item 5";
            this.itmSetAsItem5.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
            // 
            // itmSetAsItem6
            // 
            this.itmSetAsItem6.CheckOnClick = true;
            this.itmSetAsItem6.Name = "itmSetAsItem6";
            this.itmSetAsItem6.Size = new System.Drawing.Size(152, 22);
            this.itmSetAsItem6.Text = "Set as Item 6";
            this.itmSetAsItem6.CheckedChanged += new System.EventHandler(this.itmSetAsItem_CheckedChanged);
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
            this.ChildWindow = true;
            this.ClientSize = new System.Drawing.Size(1195, 827);
            this.Controls.Add(this.chkdlistFilter);
            this.Controls.Add(this.gridMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formItems";
            this.ShowLoading = true;
            this.Text = "RiotPls-Items";
            this.VisibleChanged += new System.EventHandler(this.formItems_VisibleChanged);
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.chkdlistFilter, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.cmenMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
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
            if (this.last_item_name == null)
                e.Cancel = true;
            else
            {
                int index = this.build.GetItemIndex(this.last_item_name);
                this.itmSelectedForBuilder.Checked = index > -1;
            }
            return;
        }
        private void formItems_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.build = Build.GetBuild(0);
            }
            return;
        }
        private void gridMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.items == null)
                return;
            ItemInfo info = this.gridMain.Rows[e.RowIndex].DataBoundItem as ItemInfo;
            if (info != null)
            {
                this.BeginInvoke((MethodInvoker)delegate
                { this.gridMain.DoDragDrop(info, DragDropEffects.Copy); });
            }
            return;
        }
        private void gridMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= this.gridMain.RowCount)
                return;
            this.last_item_name = this.gridMain.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            return;
        }
        private void itmSetAsItem_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.listeningToCheckboxes)
                return;
            ToolStripMenuItem menu_item = sender as ToolStripMenuItem;
            int index = this.menuItems.ToList().IndexOf(menu_item);
            ItemInfo item = Engine.GetItem(this.last_item_name);
            if (menu_item.Checked)
            {
                this.build.SetItem(index, item);
            }
            else
            {
                this.build.SetItem(index, null);
            }
            return;
        }
        private void itmSelectedForBuilder_DropDownClosed(object sender, EventArgs e)
        {
        }
        private void itmSelectedForBuilder_DropDownOpening(object sender, EventArgs e)
        {
            this.listeningToCheckboxes = false;
            int index = this.build.GetItemIndex(this.last_item_name);
            for (int i = 0; i < this.menuItems.Length; i++)
            {
                this.menuItems[i].Checked = i == index;
            }
            this.listeningToCheckboxes = true;
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

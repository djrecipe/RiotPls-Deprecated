using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

using RiotPls.API;
using RiotPls.API.Serialization;

namespace RiotPls.Forms
{
    public class formItems : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private System.Windows.Forms.CheckedListBox chkdlistFilter;
        #endregion
        private Dictionary<string, ItemInfo> items = new Dictionary<string, ItemInfo>();
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private BindingList<ItemInfo> source = null;
        #endregion
        #region Instance Methods
        public formItems()
        {
            this.InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
            this.LoadRegistrySettings();
            return;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMain = new RiotPls.Grid();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkdlistFilter = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(29, 109);
            this.gridMain.Margin = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(1137, 689);
            this.gridMain.TabIndex = 3;
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImage.DataPropertyName = "Image";
            this.colImage.HeaderText = "Image";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImage.Width = 45;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 61;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
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
            this.Name = "formItems";
            this.ShowLoading = true;
            this.Text = "RiotPls-Items";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formItems_FormClosing);
            this.Load += new System.EventHandler(this.formItems_Load);
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.chkdlistFilter, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
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
        private void LoadRegistrySettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\RiotPls\\Items");
            if (key != null)
            {
                int? x = (int?)key.GetValue("X");
                int? y = (int?)key.GetValue("Y");
                if (x.HasValue && y.HasValue)
                    this.Location = new Point(x.Value, y.Value);
                string value = (string)key.GetValue("Chkbox_Consumables");
                bool temp = false;
                if (bool.TryParse(value, out temp))
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Consumables"), temp);
                else
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Consumables"), false);
                value = (string)key.GetValue("Chkbox_HowlyingAbyss");
                if (bool.TryParse(value, out temp))
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Howling Abyss"), temp);
                else
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Howling Abyss"), false);
                value = (string)key.GetValue("Chkbox_NonConsumables");
                if (bool.TryParse(value, out temp))
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Non-Consumables"), temp);
                else
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Non-Consumables"), true);
                value = (string)key.GetValue("Chkbox_SummonersRift");
                if (bool.TryParse(value, out temp))
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Summoner's Rift"), temp);
                else
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Summoner's Rift"), true);
                value = (string)key.GetValue("Chkbox_TwistedTreeline");
                if (bool.TryParse(value, out temp))
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Twisted Treeline"), temp);
                else
                    this.chkdlistFilter.SetItemChecked(this.chkdlistFilter.Items.IndexOf("Twisted Treeline"), false);
                key.Close();
            }
            return;
        }
        private void SaveRegistrySettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\RiotPls\\Items");
            if (key != null)
            {
                key.SetValue("X", this.Left);
                key.SetValue("Y", this.Top);
                key.SetValue("Chkbox_Consumables", this.chkdlistFilter.SelectedItems.Contains("Consumables"));
                key.SetValue("Chkbox_HowlingAbyss", this.chkdlistFilter.SelectedItems.Contains("Howling Abyss"));
                key.SetValue("Chkbox_NonConsumables", this.chkdlistFilter.SelectedItems.Contains("Non-Consumables"));
                key.SetValue("Chkbox_SummonersRift", this.chkdlistFilter.SelectedItems.Contains("Summoner's Rift"));
                key.SetValue("Chkbox_TwistedTreeline", this.chkdlistFilter.SelectedItems.Contains("Twisted Treeline"));
                key.Close();
            }
            return;
        }
        #endregion
        private void chkdlistFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(this.IsHandleCreated && this.Visible)
            {
                this.UpdateData();
            }
            return;
        }
        private void formItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveRegistrySettings();
            return;
        }
        private void formItems_Load(object sender, EventArgs e)
        {
            return;
        }
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

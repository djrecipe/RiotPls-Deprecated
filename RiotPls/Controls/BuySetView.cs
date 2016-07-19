using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Controls
{
    public class BuySetView : UserControl
    {
        #region Instance Members
        private IContainer components = null;
        private TableLayoutPanel layoutMain;
        private TextBox txtName;
        private Label lblCost;
        private ContextMenuStrip cmenItems;
        private Button btnAddItem;
        private List<DropSlot>  dropSlots = new List<DropSlot>();
        #endregion
        #region Instance Properties
        public Build Build { get; set; }
        private BuySet _BuySet = null;
        public BuySet BuySet
        {
            get { return this._BuySet; }
            set
            {
                this._BuySet = value;
                if (value != null)
                    this.txtName.Text = value.Name;
            }
        }
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public BuySetView()
        {
            this.InitializeComponent();
            return;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmenItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.layoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenItems
            // 
            this.cmenItems.Name = "cmenItems";
            this.cmenItems.Size = new System.Drawing.Size(61, 4);
            this.cmenItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmenItems_Opening);
            this.cmenItems.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmenItems_ItemClicked);
            // 
            // layoutMain
            // 
            this.layoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutMain.AutoScroll = true;
            this.layoutMain.BackColor = System.Drawing.Color.Transparent;
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutMain.Controls.Add(this.btnAddItem, 0, 0);
            this.layoutMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.layoutMain.Location = new System.Drawing.Point(-2, 30);
            this.layoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMain.Size = new System.Drawing.Size(260, 152);
            this.layoutMain.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtName.Location = new System.Drawing.Point(18, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "Buy #1";
            this.txtName.WordWrap = false;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lblCost.Location = new System.Drawing.Point(148, 10);
            this.lblCost.Margin = new System.Windows.Forms.Padding(10);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(98, 20);
            this.lblCost.TabIndex = 3;
            this.lblCost.Text = "Cost: 0 gold";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAddItem.FlatAppearance.BorderSize = 5;
            this.btnAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnAddItem.Location = new System.Drawing.Point(20, 51);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(120, 50);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // BuildFlow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.layoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(260, 180);
            this.Name = "BuildFlow";
            this.Size = new System.Drawing.Size(256, 180);
            this.layoutMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PopulateContextMenu()
        {
            this.cmenItems.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                ItemInfo info = this.Build.GetItem(i);
                if (info != null && !this.BuySet.ContainsItem(info))
                {
                    ToolStripItem item = new ToolStripMenuItem(info.Name);
                    item.Tag = i;
                    this.cmenItems.Items.Add(item);
                }
            }
        }
        #endregion

        private void AddItem(int index)
        {
            ItemInfo item = this.Build.GetItem(index);
            this.BuySet.AddItem(item);
            DropSlot box = new DropSlot
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Left,
                ForeColor = Color.Black,
                Margin = new Padding(10, 0, 10, 0),
                Size = new Size(110, 110),
                Type = DropSlot.DataTypes.ItemBuy,
            };
            this.dropSlots.Add(box);
            box.Set(item);
            box.DropOccurred += this.DropSlot_DropOccurred;
            box.PricingChanged += this.DropSlot_PricingChanged;
            this.layoutMain.Controls.Add(box);
            this.UpdateCost();
            return;
        }


        private void UpdateCost()
        {
            this.lblCost.Text = string.Format("Cost: {0} gold", this.BuySet.TotalCost);
            return;
        }
        #endregion       
        #region Event Methods    
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.PopulateContextMenu();
            this.cmenItems.Show(this.btnAddItem, Point.Empty, ToolStripDropDownDirection.Default);
            return;
        }
        private void cmenItems_Opening(object sender, CancelEventArgs e)
        {
            return;
        }
        private void cmenItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem menu_item = e.ClickedItem;
            int index = (int)menu_item.Tag;
            if (index > -1)
                this.AddItem(index);
            return;
        }
        private void DropSlot_DropOccurred(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop)
        {
            int index = this.dropSlots.IndexOf(slot);
            this.BuySet.RemoveItemAt(index);
            if (drop == null)
            {
                this.layoutMain.Controls.Remove(slot);
                this.dropSlots.Remove(slot);
                slot = null;
            }
            else
            {
                this.BuySet.AddItem(drop as ItemInfo);
                slot.Set(drop);
            }
            this.UpdateCost();
            return;
        }
        private void DropSlot_PricingChanged(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop, bool full_pricing)
        {
            this.UpdateCost();
            return;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(this.BuySet != null)
                this.BuySet.Name = this.txtName.Text;
        }
        #endregion
        #region Override Methods
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

    }
}

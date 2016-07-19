using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Interfaces;
using RiotPls.API.Serialization.Items;

namespace RiotPls.Controls
{
    /// <summary>
    /// Receives and displays a drag-and-droppable Riot API entity
    /// </summary>
    public class DropSlot : UserControl
    {
        #region Types                                                                     
        public delegate void DropOccurredDelegate(DropSlot slot, IRiotDroppable drop);
        public delegate void LevelObtainedChangedDelegate(DropSlot slot, IRiotDroppable drop, int level);
        public delegate void PricingChangedDelegate(DropSlot slot, IRiotDroppable drop, bool full_pricing);
        /// <summary>
        /// Type of Riot entity being represented
        /// </summary>
        public enum DataTypes : uint
        {
            Champion = 0,
            Item = 1,
            ItemBuy = 2
        }
        #endregion
        #region Instance Members
        #region Controls           
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip cmenItem;
        private ContextMenuStrip cmenChampion;
        private ToolStripMenuItem mnuitmRemoveItem;
        private ToolStripMenuItem mnuitmItemLevelObtained;
        private ToolStripMenuItem mnuitmRemoveChampion;
        private ToolStripTextBox mnuitmLevelObtainedValue;
        private Label lblMain;
        private PictureBox picMain;
        private ContextMenuStrip cmenItemBuy;
        private ToolStripMenuItem mnuitmRemoveItemBuy;
        private ToolStripMenuItem mnuitmPricing;
        private ToolStripMenuItem mnuitmFullPricing;
        private ToolStripMenuItem mnuitmUpgradePricing;
        #endregion
        #region Events       
        /// <summary>
        /// An entity has been dropped onto the control
        /// </summary>
        public event DropOccurredDelegate DropOccurred;
        /// <summary>
        /// Level obtained value for the current entity has changed
        /// </summary>
        public event LevelObtainedChangedDelegate LevelObtainedChanged;
        /// <summary>
        /// Pricing style changed
        /// </summary>
        public event PricingChangedDelegate PricingChanged;
        #endregion
        private IRiotDroppable drop = null;
        #endregion
        #region Instance Properties
        private string _NullText = "";
        /// <summary>
        /// Displayed text when no entity is being represented
        /// </summary>
        public string NullText
        {
            get { return this._NullText; }
            set
            {
                this._NullText = value ?? "";
                this.UpdateData();
            }
        }
        private DataTypes _Type = DataTypes.Champion;
        /// <summary>
        /// Type of entity being represented by this control
        /// </summary>
        public DataTypes Type
        {
            get { return this._Type; }
            set
            {
                this._Type = value;
                this.UpdateContextMenu();
            }
        }

        #endregion
        #region Instance Methods
        public DropSlot()
        {
            this.InitializeComponent();
            this.UpdateContextMenu();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lblMain = new System.Windows.Forms.Label();
            this.cmenItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuitmRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuitmItemLevelObtained = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuitmLevelObtainedValue = new System.Windows.Forms.ToolStripTextBox();
            this.cmenChampion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuitmRemoveChampion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenItemBuy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuitmRemoveItemBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuitmPricing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuitmFullPricing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuitmUpgradePricing = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.cmenItem.SuspendLayout();
            this.cmenChampion.SuspendLayout();
            this.cmenItemBuy.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMain.Location = new System.Drawing.Point(10, 10);
            this.picMain.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(60, 60);
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            this.picMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMain_MouseDown);
            // 
            // lblMain
            // 
            this.lblMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMain.Location = new System.Drawing.Point(0, 79);
            this.lblMain.Margin = new System.Windows.Forms.Padding(0);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(80, 30);
            this.lblMain.TabIndex = 1;
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmenItem
            // 
            this.cmenItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmRemoveItem,
            this.mnuitmItemLevelObtained});
            this.cmenItem.Name = "cmenItem";
            this.cmenItem.Size = new System.Drawing.Size(154, 48);
            // 
            // mnuitmRemoveItem
            // 
            this.mnuitmRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuitmRemoveItem.Name = "mnuitmRemoveItem";
            this.mnuitmRemoveItem.Size = new System.Drawing.Size(153, 22);
            this.mnuitmRemoveItem.Text = "Remove";
            this.mnuitmRemoveItem.Click += new System.EventHandler(this.mnuitmRemove_Click);
            // 
            // mnuitmItemLevelObtained
            // 
            this.mnuitmItemLevelObtained.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuitmItemLevelObtained.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmLevelObtainedValue});
            this.mnuitmItemLevelObtained.Name = "mnuitmItemLevelObtained";
            this.mnuitmItemLevelObtained.Size = new System.Drawing.Size(153, 22);
            this.mnuitmItemLevelObtained.Text = "Level Obtained";
            this.mnuitmItemLevelObtained.DropDownOpened += new System.EventHandler(this.mnuitmItemLevelObtained_DropDownOpened);
            // 
            // mnuitmLevelObtainedValue
            // 
            this.mnuitmLevelObtainedValue.Name = "mnuitmLevelObtainedValue";
            this.mnuitmLevelObtainedValue.Size = new System.Drawing.Size(100, 23);
            this.mnuitmLevelObtainedValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mnuitmLevelObtainedValue_KeyDown);
            this.mnuitmLevelObtainedValue.TextChanged += new System.EventHandler(this.mnuitmLevelObtainedValue_TextChanged);
            // 
            // cmenChampion
            // 
            this.cmenChampion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmRemoveChampion});
            this.cmenChampion.Name = "cmenChampion";
            this.cmenChampion.Size = new System.Drawing.Size(118, 26);
            // 
            // mnuitmRemoveChampion
            // 
            this.mnuitmRemoveChampion.Name = "mnuitmRemoveChampion";
            this.mnuitmRemoveChampion.Size = new System.Drawing.Size(117, 22);
            this.mnuitmRemoveChampion.Text = "Remove";
            this.mnuitmRemoveChampion.Click += new System.EventHandler(this.mnuitmRemove_Click);
            // 
            // cmenItemBuy
            // 
            this.cmenItemBuy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmRemoveItemBuy,
            this.mnuitmPricing});
            this.cmenItemBuy.Name = "cmenItem";
            this.cmenItemBuy.Size = new System.Drawing.Size(118, 48);
            // 
            // mnuitmRemoveItemBuy
            // 
            this.mnuitmRemoveItemBuy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuitmRemoveItemBuy.Name = "mnuitmRemoveItemBuy";
            this.mnuitmRemoveItemBuy.Size = new System.Drawing.Size(117, 22);
            this.mnuitmRemoveItemBuy.Text = "Remove";
            this.mnuitmRemoveItemBuy.Click += new System.EventHandler(this.mnuitmRemove_Click);
            // 
            // mnuitmPricing
            // 
            this.mnuitmPricing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuitmPricing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmFullPricing,
            this.mnuitmUpgradePricing});
            this.mnuitmPricing.Name = "mnuitmPricing";
            this.mnuitmPricing.Size = new System.Drawing.Size(117, 22);
            this.mnuitmPricing.Text = "Pricing";
            this.mnuitmPricing.DropDownOpening += new System.EventHandler(this.mnuitmPricing_DropDownOpening);
            // 
            // mnuitmFullPricing
            // 
            this.mnuitmFullPricing.CheckOnClick = true;
            this.mnuitmFullPricing.Name = "mnuitmFullPricing";
            this.mnuitmFullPricing.Size = new System.Drawing.Size(152, 22);
            this.mnuitmFullPricing.Text = "Full";
            this.mnuitmFullPricing.CheckedChanged += new System.EventHandler(this.mnuitmFullPricing_CheckedChanged);
            // 
            // mnuitmUpgradePricing
            // 
            this.mnuitmUpgradePricing.CheckOnClick = true;
            this.mnuitmUpgradePricing.Name = "mnuitmUpgradePricing";
            this.mnuitmUpgradePricing.Size = new System.Drawing.Size(152, 22);
            this.mnuitmUpgradePricing.Text = "Upgrade";
            this.mnuitmUpgradePricing.CheckedChanged += new System.EventHandler(this.mnuitmUpgradePricing_CheckedChanged);
            // 
            // DropSlot
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.picMain);
            this.MinimumSize = new System.Drawing.Size(80, 110);
            this.Name = "DropSlot";
            this.Size = new System.Drawing.Size(80, 110);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.cmenItem.ResumeLayout(false);
            this.cmenChampion.ResumeLayout(false);
            this.cmenItemBuy.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Removes the currently represented entity
        /// </summary>
        public void Clear()
        {
            this.drop = null;
            this.UpdateData();
            this.FireDropOccurredEvent(this.drop);
        }

        private void FireDropOccurredEvent(IRiotDroppable drop)
        {
            if (this.DropOccurred != null)
                this.DropOccurred(this, drop);
            return;
        }
        /// <summary>
        /// Sets the currently represented entity
        /// </summary>
        /// <param name="new_drop">Entity to represent</param>
        public void Set(IRiotDroppable new_drop)
        {
            if (this.drop != new_drop)
            {
                this.drop = new_drop;
                this.UpdateData();
                this.FireDropOccurredEvent(this.drop);
            }
            return;
        }

        private void UpdateContextMenu()
        {
            switch (this.Type)
            {
                case DataTypes.Champion:
                    this.ContextMenuStrip = this.cmenChampion;
                    break;
                case DataTypes.Item:
                    this.ContextMenuStrip = this.cmenItem;
                    break;
                case DataTypes.ItemBuy:
                    this.ContextMenuStrip = this.cmenItemBuy;
                    break;
            }
            return;
        }
        private void UpdateData()
        {
            this.picMain.BackgroundImage = this.drop?.Image;
            this.lblMain.Text = this.drop?.Name ?? this.NullText;
            this.mnuitmLevelObtainedValue.Text = (this.drop?.LevelObtained ?? 1).ToString();
            return;
        }

        private void UpdatePrice()
        {
            ItemInfo item = this.drop as ItemInfo;
            if (item != null)
            {
                item.PricingStyle = this.mnuitmFullPricing.Checked
                    ? ItemInfo.PricingStyles.Full
                    : ItemInfo.PricingStyles.Upgrade;
            }
            if (this.PricingChanged != null)
                this.PricingChanged(this, this.drop, this.mnuitmFullPricing.Checked);
        }
        #region Event Methods     
        #region Menu Events       
        private void mnuitmFullPricing_CheckedChanged(object sender, EventArgs e)
        {
            this.mnuitmUpgradePricing.Checked = !this.mnuitmFullPricing.Checked;
            this.UpdatePrice();
            return;
        }
        private void mnuitmItemLevelObtained_DropDownOpened(object sender, EventArgs e)
        {
            this.mnuitmLevelObtainedValue.Focus();
            this.mnuitmLevelObtainedValue.SelectionStart = 0;
            this.mnuitmLevelObtainedValue.SelectionLength = this.mnuitmLevelObtainedValue.TextLength;
        }
        private void mnuitmLevelObtainedValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmenItem.Close();
                e.Handled = true;
            }
            return;
        }
        private void mnuitmLevelObtainedValue_TextChanged(object sender, EventArgs e)
        {
            if (this.drop == null)
                return;
            int level = 1;
            if (int.TryParse(this.mnuitmLevelObtainedValue.Text, out level))
            {
                this.drop.LevelObtained = level;
                if (this.LevelObtainedChanged != null)
                    this.LevelObtainedChanged(this, this.drop, this.drop.LevelObtained);
            }
            return;
        }
        private void mnuitmPricing_DropDownOpening(object sender, EventArgs e)
        {
            ItemInfo item = this.drop as ItemInfo;
            if (item == null)
                return;
            this.mnuitmFullPricing.Checked = item.PricingStyle == ItemInfo.PricingStyles.Full;
            this.mnuitmUpgradePricing.Checked = item.PricingStyle == ItemInfo.PricingStyles.Upgrade;
            return;
        }
        private void mnuitmRemove_Click(object sender, EventArgs e)
        {
            if (this.DropOccurred != null)
                this.DropOccurred(this, null);
        }
        private void mnuitmUpgradePricing_CheckedChanged(object sender, EventArgs e)
        {
            this.mnuitmFullPricing.Checked = !this.mnuitmUpgradePricing.Checked;
            this.UpdatePrice();
            return;
        }
        private void picMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.drop == null)
                return;
            this.BeginInvoke((MethodInvoker)delegate { this.DoDragDrop(this.drop.Clone() as IRiotDroppable, DragDropEffects.Copy); });
            return;
        }
        #endregion
        #endregion
        #endregion
        #region Override Methods
        protected override void OnDragDrop(DragEventArgs e)
        {                                                                                 
            base.OnDragDrop(e);
            switch (this.Type)
            {
                default:
                case DataTypes.Champion:
                    this.drop = (IRiotDroppable)e.Data.GetData(typeof(ChampionInfo));
                    break;
                case DataTypes.ItemBuy:
                case DataTypes.Item:
                    this.drop = (IRiotDroppable)e.Data.GetData(typeof(ItemInfo));
                    break;
            }
            this.UpdateData();
            this.FireDropOccurredEvent(this.drop);
            return;
        }

        protected override void OnDragEnter(DragEventArgs e)               
        {
            base.OnDragEnter(e);
            switch (this.Type)
            {
                default:
                case DataTypes.Champion:
                    if (e.Data.GetDataPresent(typeof(ChampionInfo)))
                        e.Effect = DragDropEffects.Copy;
                    break;
                case DataTypes.ItemBuy:
                case DataTypes.Item:
                    if (e.Data.GetDataPresent(typeof(ItemInfo)))
                        e.Effect = DragDropEffects.Copy;
                    break;
            }
            return;
        }
        #endregion

    }
}

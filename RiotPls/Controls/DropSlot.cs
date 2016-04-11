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
    public class DropSlot : UserControl
    {
        #region Types
        public delegate void delDropOccurred(DropSlot slot, IRiotDroppable drop);
        #endregion
        #region Instance Members
        #region Controls           
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip cmenItem;
        private ContextMenuStrip cmenChampion;
        private ToolStripMenuItem mnuitmRemoveItem;
        private ToolStripMenuItem mnuitmItemLevelObtained;
        private ToolStripTextBox mnuitmLevelObtainedValue;
        private Label lblMain;
        private PictureBox picMain;
        #endregion
        #region Events
        public event delDropOccurred DropOccurred;
        #endregion
        private IRiotDroppable drop = null;
        #endregion
        #region Instance Properties
        private DataType _DataType = DataType.Champion;
        public DataType DataType
        {
            get { return this._DataType; }
            set
            {
                this._DataType = value;
                this.UpdateContextMenu();
            }
        }
        private string _NullText = "";
        public string NullText
        {
            get { return this._NullText; }
            set
            {
                this._NullText = value ?? "";
                this.UpdateData();
            }
        }

        #endregion
        #region Instance Methods
        public DropSlot()
        {
            this.InitializeComponent();
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
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.cmenItem.SuspendLayout();
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
            this.mnuitmRemoveItem.Click += new System.EventHandler(this.mnuitmRemoveItem_Click);
            // 
            // mnuitmItemLevelObtained
            // 
            this.mnuitmItemLevelObtained.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuitmItemLevelObtained.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmLevelObtainedValue});
            this.mnuitmItemLevelObtained.Name = "mnuitmItemLevelObtained";
            this.mnuitmItemLevelObtained.Size = new System.Drawing.Size(153, 22);
            this.mnuitmItemLevelObtained.Text = "Level Obtained";
            this.mnuitmItemLevelObtained.TextChanged += new System.EventHandler(this.mnuitmItemLevelObtained_TextChanged);
            // 
            // mnuitmLevelObtainedValue
            // 
            this.mnuitmLevelObtainedValue.Name = "mnuitmLevelObtainedValue";
            this.mnuitmLevelObtainedValue.Size = new System.Drawing.Size(100, 23);
            // 
            // cmenChampion
            // 
            this.cmenChampion.Name = "cmenChampion";
            this.cmenChampion.Size = new System.Drawing.Size(153, 26);
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
            this.ResumeLayout(false);

        }

        public void Clear()
        {
            this.drop = null;
            this.UpdateData();
        }

        private void FireDropOccurredEvent(IRiotDroppable drop)
        {
            if (this.DropOccurred != null)
                this.DropOccurred(this, drop);
            return;
        }
        public void Set(IRiotDroppable new_drop)
        {
            if (this.drop != new_drop)
            {
                this.drop = new_drop;
                this.UpdateData();
            }
            return;
        }

        private void UpdateContextMenu()
        {
            this.ContextMenuStrip = this.DataType == DataType.Item ? this.cmenItem : this.cmenChampion;
            return;
        }
        private void UpdateData()
        {
            this.picMain.BackgroundImage = this.drop?.Image;
            this.lblMain.Text = this.drop?.Name ?? this.NullText;
            this.FireDropOccurredEvent(this.drop);
            return;
        }
        #region Event Methods        
        private void mnuitmItemLevelObtained_TextChanged(object sender, EventArgs e)
        {

        }
        private void mnuitmRemoveItem_Click(object sender, EventArgs e)
        {
            if (this.DropOccurred != null)
                this.DropOccurred(this, null);
        }
        #endregion
        #region Override Methods
        protected override void OnDragDrop(DragEventArgs e)
        {                                                                                 
            base.OnDragDrop(e);
            switch (this.DataType)
            {
                default:
                case DataType.Champion:
                    this.drop = (IRiotDroppable)e.Data.GetData(typeof(ChampionInfo));
                    break;
                case DataType.Item:
                    this.drop = (IRiotDroppable)e.Data.GetData(typeof(ItemInfo));
                    break;
            }
            this.UpdateData();
            return;
        }

        protected override void OnDragEnter(DragEventArgs e)               
        {
            base.OnDragEnter(e);
            switch (this.DataType)
            {
                default:
                case DataType.Champion:
                    if (e.Data.GetDataPresent(typeof(ChampionInfo)))
                        e.Effect = DragDropEffects.Copy;
                    break;
                case DataType.Item:
                    if (e.Data.GetDataPresent(typeof(ItemInfo)))
                        e.Effect = DragDropEffects.Copy;
                    break;
            }
            return;
        }

        #endregion
        #endregion

    }
}

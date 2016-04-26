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
        /// <summary>
        /// Type of Riot entity being represented
        /// </summary>
        public enum DataType : uint
        {
            Champion = 0,
            Item = 1
        };
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
        private DataType _Type = DataType.Champion;
        /// <summary>
        /// Type of entity being represented by this control
        /// </summary>
        public DataType Type
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
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.cmenItem.SuspendLayout();
            this.cmenChampion.SuspendLayout();
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
            this.cmenItem.Size = new System.Drawing.Size(154, 70);
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
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Removes the currently represented entity
        /// </summary>
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
            }
            return;
        }

        private void UpdateContextMenu()
        {
            this.ContextMenuStrip = this.Type == DataType.Item ? this.cmenItem : this.cmenChampion;
            return;
        }
        private void UpdateData()
        {
            this.picMain.BackgroundImage = this.drop?.Image;
            this.lblMain.Text = this.drop?.Name ?? this.NullText;
            this.mnuitmLevelObtainedValue.Text = (this.drop?.LevelObtained ?? 1).ToString();
            this.FireDropOccurredEvent(this.drop);
            return;
        }
        #region Event Methods     
        #region Menu Events
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
        private void mnuitmRemove_Click(object sender, EventArgs e)
        {
            if (this.DropOccurred != null)
                this.DropOccurred(this, null);
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
            switch (this.Type)
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

    }
}

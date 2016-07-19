using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;
using RiotPls.Controls;
using RiotPls.Forms.Models;
using RiotPls.Tools;

namespace RiotPls.Forms
{
    /// <summary>
    /// Facilitates displaying and modifying of a build
    /// </summary>
    /// <remarks>A build typically consists of a champion, set of items, table of stats, and other metadata</remarks>
    public class formBuilder : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private StatGrid gridMain;
        private DropSlot dropChampion;
        private DropSlot dropItem1;
        private DropSlot dropItem2;
        private DropSlot dropItem3;
        private DropSlot dropItem4;
        private DropSlot dropItem5;
        private DropSlot dropItem6;
        private DropSlot[] itemDrops = null;
        private FlowLayoutPanel flowTop;
        private TabControl tabsMain;
        private TabPage tabStats;
        private TabPage tabBuys;
        private BuySetCollectionView buildcolMain;
        private SplitContainer splitVertical;
        #endregion
        #endregion
        #region Instance Properties
        public formBuilderModel Model { get; private set; } = null;
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public formBuilder(Build build)
        {
            this.InitializeComponent();
            this.InitializeDragDrop();
            this.buildcolMain.Build = build;
            this.Model = new formBuilderModel(build);
            this.Model.BuildChanged += this.Model_BuildChanged;
            this.Model.RowChanged += this.Model_RowChanged;
            return;
        }

        private void Model_BuildChanged()
        {
            if (!this.Visible)
                return;
            this.Text = this.Model.Build.Name;
            Drawing.SuspendDrawing(this.gridMain);
            // update champion
            this.dropChampion.Set(this.Model.Build.Champion);
            // update items
            for (int i = 0; i < 6; i++)
                this.itemDrops[i].Set(this.Model.Build.GetItem(i));
            // update grid
            this.gridMain.DataSource = this.Model.Build.Table;
            this.Model.SelectRow(this.Model.Build.SelectedRow);
            Drawing.ResumeDrawing(this.gridMain);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBuilder));
            this.dropChampion = new RiotPls.Controls.DropSlot();
            this.dropItem1 = new RiotPls.Controls.DropSlot();
            this.dropItem2 = new RiotPls.Controls.DropSlot();
            this.dropItem3 = new RiotPls.Controls.DropSlot();
            this.dropItem4 = new RiotPls.Controls.DropSlot();
            this.dropItem5 = new RiotPls.Controls.DropSlot();
            this.dropItem6 = new RiotPls.Controls.DropSlot();
            this.gridMain = new RiotPls.Controls.StatGrid();
            this.flowTop = new System.Windows.Forms.FlowLayoutPanel();
            this.splitVertical = new System.Windows.Forms.SplitContainer();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.tabBuys = new System.Windows.Forms.TabPage();
            this.buildcolMain = new RiotPls.Controls.BuySetCollectionView();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.flowTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).BeginInit();
            this.splitVertical.Panel1.SuspendLayout();
            this.splitVertical.Panel2.SuspendLayout();
            this.splitVertical.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.tabBuys.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(318, 186);
            // 
            // dropChampion
            // 
            this.dropChampion.AllowDrop = true;
            this.dropChampion.BackColor = System.Drawing.Color.Transparent;
            this.dropChampion.Location = new System.Drawing.Point(20, 20);
            this.dropChampion.Margin = new System.Windows.Forms.Padding(20, 20, 5, 20);
            this.dropChampion.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropChampion.Name = "dropChampion";
            this.dropChampion.NullText = "Champion";
            this.dropChampion.Size = new System.Drawing.Size(124, 151);
            this.dropChampion.TabIndex = 22;
            this.dropChampion.Type = RiotPls.Controls.DropSlot.DataTypes.Champion;
            this.dropChampion.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropChampion_DropOccurred);
            // 
            // dropItem1
            // 
            this.dropItem1.AllowDrop = true;
            this.dropItem1.BackColor = System.Drawing.Color.Transparent;
            this.dropItem1.Location = new System.Drawing.Point(154, 50);
            this.dropItem1.Margin = new System.Windows.Forms.Padding(5, 50, 0, 5);
            this.dropItem1.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem1.Name = "dropItem1";
            this.dropItem1.NullText = "Item 1";
            this.dropItem1.Size = new System.Drawing.Size(96, 121);
            this.dropItem1.TabIndex = 23;
            this.dropItem1.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem1.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem1.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // dropItem2
            // 
            this.dropItem2.AllowDrop = true;
            this.dropItem2.BackColor = System.Drawing.Color.Transparent;
            this.dropItem2.Location = new System.Drawing.Point(250, 50);
            this.dropItem2.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem2.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem2.Name = "dropItem2";
            this.dropItem2.NullText = "Item 2";
            this.dropItem2.Size = new System.Drawing.Size(96, 121);
            this.dropItem2.TabIndex = 24;
            this.dropItem2.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem2.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem2.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // dropItem3
            // 
            this.dropItem3.AllowDrop = true;
            this.dropItem3.BackColor = System.Drawing.Color.Transparent;
            this.dropItem3.Location = new System.Drawing.Point(346, 50);
            this.dropItem3.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem3.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem3.Name = "dropItem3";
            this.dropItem3.NullText = "Item 3";
            this.dropItem3.Size = new System.Drawing.Size(96, 121);
            this.dropItem3.TabIndex = 25;
            this.dropItem3.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem3.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem3.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // dropItem4
            // 
            this.dropItem4.AllowDrop = true;
            this.dropItem4.BackColor = System.Drawing.Color.Transparent;
            this.dropItem4.Location = new System.Drawing.Point(442, 50);
            this.dropItem4.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem4.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem4.Name = "dropItem4";
            this.dropItem4.NullText = "Item 4";
            this.dropItem4.Size = new System.Drawing.Size(96, 121);
            this.dropItem4.TabIndex = 26;
            this.dropItem4.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem4.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem4.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // dropItem5
            // 
            this.dropItem5.AllowDrop = true;
            this.dropItem5.BackColor = System.Drawing.Color.Transparent;
            this.dropItem5.Location = new System.Drawing.Point(538, 50);
            this.dropItem5.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem5.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem5.Name = "dropItem5";
            this.dropItem5.NullText = "Item 5";
            this.dropItem5.Size = new System.Drawing.Size(96, 121);
            this.dropItem5.TabIndex = 27;
            this.dropItem5.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem5.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem5.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // dropItem6
            // 
            this.dropItem6.AllowDrop = true;
            this.dropItem6.BackColor = System.Drawing.Color.Transparent;
            this.dropItem6.Location = new System.Drawing.Point(634, 50);
            this.dropItem6.Margin = new System.Windows.Forms.Padding(0, 50, 5, 5);
            this.dropItem6.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem6.Name = "dropItem6";
            this.dropItem6.NullText = "Item 6";
            this.dropItem6.Size = new System.Drawing.Size(96, 121);
            this.dropItem6.TabIndex = 28;
            this.dropItem6.Type = RiotPls.Controls.DropSlot.DataTypes.Item;
            this.dropItem6.DropOccurred += new RiotPls.Controls.DropSlot.DropOccurredDelegate(this.dropItem_DropOccurred);
            this.dropItem6.LevelObtainedChanged += new RiotPls.Controls.DropSlot.LevelObtainedChangedDelegate(this.dropItem_LevelObtainedChanged);
            // 
            // gridMain
            // 
            this.gridMain.DataSource = null;
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.Margin = new System.Windows.Forms.Padding(0);
            this.gridMain.Name = "gridMain";
            this.gridMain.Padding = new System.Windows.Forms.Padding(20, 0, 20, 10);
            this.gridMain.Size = new System.Drawing.Size(756, 287);
            this.gridMain.TabIndex = 29;
            this.gridMain.SelectedRowChanged += new RiotPls.Controls.StatGrid.SelectedRowChangedDelegate(this.gridMain_SelectedRowChanged);
            // 
            // flowTop
            // 
            this.flowTop.Controls.Add(this.dropChampion);
            this.flowTop.Controls.Add(this.dropItem1);
            this.flowTop.Controls.Add(this.dropItem2);
            this.flowTop.Controls.Add(this.dropItem3);
            this.flowTop.Controls.Add(this.dropItem4);
            this.flowTop.Controls.Add(this.dropItem5);
            this.flowTop.Controls.Add(this.dropItem6);
            this.flowTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTop.Location = new System.Drawing.Point(0, 0);
            this.flowTop.Name = "flowTop";
            this.flowTop.Size = new System.Drawing.Size(756, 183);
            this.flowTop.TabIndex = 30;
            this.flowTop.WrapContents = false;
            // 
            // splitVertical
            // 
            this.splitVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitVertical.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.splitVertical.IsSplitterFixed = true;
            this.splitVertical.Location = new System.Drawing.Point(0, 0);
            this.splitVertical.Name = "splitVertical";
            this.splitVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitVertical.Panel1
            // 
            this.splitVertical.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitVertical.Panel1.Controls.Add(this.flowTop);
            // 
            // splitVertical.Panel2
            // 
            this.splitVertical.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitVertical.Panel2.Controls.Add(this.gridMain);
            this.splitVertical.Size = new System.Drawing.Size(756, 474);
            this.splitVertical.SplitterDistance = 183;
            this.splitVertical.TabIndex = 31;
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tabStats);
            this.tabsMain.Controls.Add(this.tabBuys);
            this.tabsMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Multiline = true;
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(764, 501);
            this.tabsMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabsMain.TabIndex = 29;
            // 
            // tabStats
            // 
            this.tabStats.BackColor = System.Drawing.Color.Black;
            this.tabStats.Controls.Add(this.splitVertical);
            this.tabStats.Location = new System.Drawing.Point(4, 23);
            this.tabStats.Margin = new System.Windows.Forms.Padding(0);
            this.tabStats.Name = "tabStats";
            this.tabStats.Size = new System.Drawing.Size(756, 474);
            this.tabStats.TabIndex = 0;
            this.tabStats.Text = "Stats";
            // 
            // tabBuys
            // 
            this.tabBuys.BackColor = System.Drawing.Color.Black;
            this.tabBuys.Controls.Add(this.buildcolMain);
            this.tabBuys.Location = new System.Drawing.Point(4, 23);
            this.tabBuys.Margin = new System.Windows.Forms.Padding(0);
            this.tabBuys.Name = "tabBuys";
            this.tabBuys.Size = new System.Drawing.Size(756, 474);
            this.tabBuys.TabIndex = 1;
            this.tabBuys.Text = "Buys";
            // 
            // buildcolMain
            // 
            this.buildcolMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buildcolMain.BackColor = System.Drawing.Color.Transparent;
            this.buildcolMain.Build = null;
            this.buildcolMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildcolMain.Location = new System.Drawing.Point(0, 0);
            this.buildcolMain.Name = "buildcolMain";
            this.buildcolMain.Size = new System.Drawing.Size(756, 474);
            this.buildcolMain.TabIndex = 0;
            // 
            // formBuilder
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 501);
            this.CloseButtonEnabled = true;
            this.Controls.Add(this.tabsMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(780, 400);
            this.Name = "formBuilder";
            this.Text = "Build #1";
            this.VisibleChanged += new System.EventHandler(this.formStatSheet_VisibleChanged);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.tabsMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.flowTop.ResumeLayout(false);
            this.splitVertical.Panel1.ResumeLayout(false);
            this.splitVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).EndInit();
            this.splitVertical.ResumeLayout(false);
            this.tabsMain.ResumeLayout(false);
            this.tabStats.ResumeLayout(false);
            this.tabBuys.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void InitializeDragDrop()
        {
            this.itemDrops = new DropSlot[] { this.dropItem1, this.dropItem2, this.dropItem3,
                this.dropItem4, this.dropItem5, this.dropItem6 };
            return;
        }
        #endregion
        #endregion
        #region Event Methods
        #region Build Events
        #endregion
        #region Form Events       
        private void formStatSheet_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Model.UpdateBuild();
            return;
        }
        #endregion
        #region DropSlot Events
        private void dropChampion_DropOccurred(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop)
        {
            ChampionInfo champ = drop as ChampionInfo;
            this.Model.Build.SetChampion(champ);
        }

        private void dropItem_DropOccurred(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop)
        {
            int index = this.itemDrops.ToList().IndexOf(slot);
            ItemInfo item = drop as ItemInfo;
            this.Model.Build.SetItem(index, item);
        }
        private void dropItem_LevelObtainedChanged(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop, int level)
        {
            int index = this.itemDrops.ToList().IndexOf(slot);
            this.Model.Build.SetItemLevel(index, level);
        }
        #endregion
        #region Grid Events
        private void gridMain_SelectedRowChanged(int row)
        {
            this.Model.Build.SelectedRow = row;
        }
        #endregion
        #region Model Events
        private void Model_RowChanged(int value)
        {
            if (value < 0 || value >= this.gridMain.RowCount)
                value = 0;
            this.gridMain.SetSelectedRow(value);
            return;
        }
        #endregion
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
        #endregion

    }
}

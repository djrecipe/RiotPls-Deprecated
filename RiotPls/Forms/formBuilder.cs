using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;
using RiotPls.Controls;
using RiotPls.Tools;

namespace RiotPls.Forms
{
    public class formBuilder : formTemplate
    {
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
        #endregion
        private FlowLayoutPanel flowTop;
        private SplitContainer splitVertical;
        private Build build = null;
        public formBuilder()
        {
            this.InitializeComponent();
            this.InitializeDragDrop();
            Build.BuildChanged += this.BuildManager_BuildChanged;
            return;
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
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.flowTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).BeginInit();
            this.splitVertical.Panel1.SuspendLayout();
            this.splitVertical.Panel2.SuspendLayout();
            this.splitVertical.SuspendLayout();
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
            this.dropChampion.DataType = RiotPls.API.Serialization.Interfaces.DataType.Champion;
            this.dropChampion.Location = new System.Drawing.Point(20, 20);
            this.dropChampion.Margin = new System.Windows.Forms.Padding(20, 20, 5, 20);
            this.dropChampion.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropChampion.Name = "dropChampion";
            this.dropChampion.NullText = "Champion";
            this.dropChampion.Size = new System.Drawing.Size(124, 151);
            this.dropChampion.TabIndex = 22;
            this.dropChampion.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropChampion_DropOccurred);
            // 
            // dropItem1
            // 
            this.dropItem1.AllowDrop = true;
            this.dropItem1.BackColor = System.Drawing.Color.Transparent;
            this.dropItem1.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem1.Location = new System.Drawing.Point(154, 50);
            this.dropItem1.Margin = new System.Windows.Forms.Padding(5, 50, 0, 5);
            this.dropItem1.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem1.Name = "dropItem1";
            this.dropItem1.NullText = "Item 1";
            this.dropItem1.Size = new System.Drawing.Size(96, 121);
            this.dropItem1.TabIndex = 23;
            this.dropItem1.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // dropItem2
            // 
            this.dropItem2.AllowDrop = true;
            this.dropItem2.BackColor = System.Drawing.Color.Transparent;
            this.dropItem2.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem2.Location = new System.Drawing.Point(250, 50);
            this.dropItem2.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem2.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem2.Name = "dropItem2";
            this.dropItem2.NullText = "Item 2";
            this.dropItem2.Size = new System.Drawing.Size(96, 121);
            this.dropItem2.TabIndex = 24;
            this.dropItem2.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // dropItem3
            // 
            this.dropItem3.AllowDrop = true;
            this.dropItem3.BackColor = System.Drawing.Color.Transparent;
            this.dropItem3.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem3.Location = new System.Drawing.Point(346, 50);
            this.dropItem3.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem3.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem3.Name = "dropItem3";
            this.dropItem3.NullText = "Item 3";
            this.dropItem3.Size = new System.Drawing.Size(96, 121);
            this.dropItem3.TabIndex = 25;
            this.dropItem3.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // dropItem4
            // 
            this.dropItem4.AllowDrop = true;
            this.dropItem4.BackColor = System.Drawing.Color.Transparent;
            this.dropItem4.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem4.Location = new System.Drawing.Point(442, 50);
            this.dropItem4.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem4.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem4.Name = "dropItem4";
            this.dropItem4.NullText = "Item 4";
            this.dropItem4.Size = new System.Drawing.Size(96, 121);
            this.dropItem4.TabIndex = 26;
            this.dropItem4.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // dropItem5
            // 
            this.dropItem5.AllowDrop = true;
            this.dropItem5.BackColor = System.Drawing.Color.Transparent;
            this.dropItem5.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem5.Location = new System.Drawing.Point(538, 50);
            this.dropItem5.Margin = new System.Windows.Forms.Padding(0, 50, 0, 5);
            this.dropItem5.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem5.Name = "dropItem5";
            this.dropItem5.NullText = "Item 5";
            this.dropItem5.Size = new System.Drawing.Size(96, 121);
            this.dropItem5.TabIndex = 27;
            this.dropItem5.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // dropItem6
            // 
            this.dropItem6.AllowDrop = true;
            this.dropItem6.BackColor = System.Drawing.Color.Transparent;
            this.dropItem6.DataType = RiotPls.API.Serialization.Interfaces.DataType.Item;
            this.dropItem6.Location = new System.Drawing.Point(634, 50);
            this.dropItem6.Margin = new System.Windows.Forms.Padding(0, 50, 5, 5);
            this.dropItem6.MinimumSize = new System.Drawing.Size(80, 110);
            this.dropItem6.Name = "dropItem6";
            this.dropItem6.NullText = "Item 6";
            this.dropItem6.Size = new System.Drawing.Size(96, 121);
            this.dropItem6.TabIndex = 28;
            this.dropItem6.DropOccurred += new RiotPls.Controls.DropSlot.delDropOccurred(this.dropItem_DropOccurred);
            // 
            // gridMain
            // 
            this.gridMain.DataSource = null;
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.Margin = new System.Windows.Forms.Padding(0);
            this.gridMain.Name = "gridMain";
            this.gridMain.Padding = new System.Windows.Forms.Padding(20, 0, 20, 10);
            this.gridMain.Size = new System.Drawing.Size(764, 314);
            this.gridMain.TabIndex = 29;
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
            this.flowTop.Size = new System.Drawing.Size(764, 183);
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
            this.splitVertical.Panel1.Controls.Add(this.flowTop);
            // 
            // splitVertical.Panel2
            // 
            this.splitVertical.Panel2.Controls.Add(this.gridMain);
            this.splitVertical.Size = new System.Drawing.Size(764, 501);
            this.splitVertical.SplitterDistance = 183;
            this.splitVertical.TabIndex = 31;
            // 
            // formBuilder
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 501);
            this.Controls.Add(this.splitVertical);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(780, 400);
            this.Name = "formBuilder";
            this.Text = "Builder";
            this.VisibleChanged += new System.EventHandler(this.formStatSheet_VisibleChanged);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.splitVertical, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.flowTop.ResumeLayout(false);
            this.splitVertical.Panel1.ResumeLayout(false);
            this.splitVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).EndInit();
            this.splitVertical.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeDragDrop()
        {
            this.itemDrops = new DropSlot[] { this.dropItem1, this.dropItem2, this.dropItem3,
                this.dropItem4, this.dropItem5, this.dropItem6 };
            return;
        }
        private void UpdateBuild()
        {
            if (!this.Visible)
                return;
            Drawing.SuspendDrawing(this.gridMain);
            this.build = Build.GetBuild(0);
            // update champion
            this.dropChampion.Set(this.build.Champion);
            // update items
            for (int i = 0; i < 6; i++)
                this.itemDrops[i].Set(this.build.GetItem(i));
            // update grid
            this.gridMain.DataSource = this.build.Table;
            Drawing.ResumeDrawing(this.gridMain);
            return;
        }
        private void BuildManager_BuildChanged(int index)
        {
            this.UpdateBuild();
            return;
        }
        private void formStatSheet_VisibleChanged(object sender, System.EventArgs e)
        {
            this.UpdateBuild();
            return;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dropChampion_DropOccurred(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop)
        {
            ChampionInfo champ = drop as ChampionInfo;
            this.build.SetChampion(champ);
        }

        private void dropItem_DropOccurred(DropSlot slot, API.Serialization.Interfaces.IRiotDroppable drop)
        {
            int index = this.itemDrops.ToList().IndexOf(slot);
            ItemInfo item = drop as ItemInfo;
            this.build.SetItem(index, item);
        }
    }
}

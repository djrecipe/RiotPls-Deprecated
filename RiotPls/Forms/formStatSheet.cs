using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API.Serialization.Champions;
using RiotPls.API.Serialization.Items;
using RiotPls.Builder;
using RiotPls.Tools;

namespace RiotPls.Forms
{
    public class formStatSheet : formTemplate
    {
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picChampion;
        private System.Windows.Forms.Label lblChampion;
        private Label lblItem1;
        private PictureBox picItem1;
        private Label lblItem2;
        private PictureBox picItem2;
        private Label lblItem3;
        private PictureBox picItem3;
        private Label lblItem4;
        private PictureBox picItem4;
        private Label lblItem5;
        private PictureBox picItem5;
        private Label lblItem6;
        private PictureBox picItem6;
        private Label[] itemLabels = null;
        private PictureBox[] itemPictures = null;
        #endregion
        private Build build = null;
        private ItemInfo[] items = new ItemInfo[6];
        public formStatSheet()
        {
            this.InitializeComponent();
            this.InitializeDragDrop();
            Build.BuildChanged += this.BuildManager_BuildChanged;
            return;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStatSheet));
            this.picChampion = new System.Windows.Forms.PictureBox();
            this.lblChampion = new System.Windows.Forms.Label();
            this.lblItem1 = new System.Windows.Forms.Label();
            this.picItem1 = new System.Windows.Forms.PictureBox();
            this.lblItem2 = new System.Windows.Forms.Label();
            this.picItem2 = new System.Windows.Forms.PictureBox();
            this.lblItem3 = new System.Windows.Forms.Label();
            this.picItem3 = new System.Windows.Forms.PictureBox();
            this.lblItem4 = new System.Windows.Forms.Label();
            this.picItem4 = new System.Windows.Forms.PictureBox();
            this.lblItem5 = new System.Windows.Forms.Label();
            this.picItem5 = new System.Windows.Forms.PictureBox();
            this.lblItem6 = new System.Windows.Forms.Label();
            this.picItem6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(646, 9);
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(273, 186);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Visible = false;
            // 
            // picChampion
            // 
            this.picChampion.BackColor = System.Drawing.Color.Transparent;
            this.picChampion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picChampion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picChampion.Location = new System.Drawing.Point(35, 29);
            this.picChampion.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picChampion.Name = "picChampion";
            this.picChampion.Size = new System.Drawing.Size(100, 100);
            this.picChampion.TabIndex = 3;
            this.picChampion.TabStop = false;
            this.picChampion.DragDrop += new System.Windows.Forms.DragEventHandler(this.picChampion_DragDrop);
            this.picChampion.DragEnter += new System.Windows.Forms.DragEventHandler(this.picChampion_DragEnter);
            // 
            // lblChampion
            // 
            this.lblChampion.Location = new System.Drawing.Point(35, 139);
            this.lblChampion.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblChampion.Name = "lblChampion";
            this.lblChampion.Size = new System.Drawing.Size(100, 14);
            this.lblChampion.TabIndex = 4;
            this.lblChampion.Text = "Champion";
            this.lblChampion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItem1
            // 
            this.lblItem1.Location = new System.Drawing.Point(45, 263);
            this.lblItem1.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem1.Name = "lblItem1";
            this.lblItem1.Size = new System.Drawing.Size(80, 30);
            this.lblItem1.TabIndex = 11;
            this.lblItem1.Text = "Item 1";
            this.lblItem1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem1
            // 
            this.picItem1.BackColor = System.Drawing.Color.Transparent;
            this.picItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem1.Location = new System.Drawing.Point(55, 193);
            this.picItem1.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem1.Name = "picItem1";
            this.picItem1.Size = new System.Drawing.Size(60, 60);
            this.picItem1.TabIndex = 10;
            this.picItem1.TabStop = false;
            this.picItem1.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem1.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // lblItem2
            // 
            this.lblItem2.Location = new System.Drawing.Point(145, 263);
            this.lblItem2.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem2.Name = "lblItem2";
            this.lblItem2.Size = new System.Drawing.Size(80, 30);
            this.lblItem2.TabIndex = 13;
            this.lblItem2.Text = "Item 2";
            this.lblItem2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem2
            // 
            this.picItem2.BackColor = System.Drawing.Color.Transparent;
            this.picItem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem2.Location = new System.Drawing.Point(155, 193);
            this.picItem2.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem2.Name = "picItem2";
            this.picItem2.Size = new System.Drawing.Size(60, 60);
            this.picItem2.TabIndex = 12;
            this.picItem2.TabStop = false;
            this.picItem2.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem2.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // lblItem3
            // 
            this.lblItem3.Location = new System.Drawing.Point(245, 263);
            this.lblItem3.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem3.Name = "lblItem3";
            this.lblItem3.Size = new System.Drawing.Size(80, 30);
            this.lblItem3.TabIndex = 15;
            this.lblItem3.Text = "Item 3";
            this.lblItem3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem3
            // 
            this.picItem3.BackColor = System.Drawing.Color.Transparent;
            this.picItem3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem3.Location = new System.Drawing.Point(255, 193);
            this.picItem3.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem3.Name = "picItem3";
            this.picItem3.Size = new System.Drawing.Size(60, 60);
            this.picItem3.TabIndex = 14;
            this.picItem3.TabStop = false;
            this.picItem3.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem3.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // lblItem4
            // 
            this.lblItem4.Location = new System.Drawing.Point(345, 263);
            this.lblItem4.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem4.Name = "lblItem4";
            this.lblItem4.Size = new System.Drawing.Size(80, 30);
            this.lblItem4.TabIndex = 17;
            this.lblItem4.Text = "Item 4";
            this.lblItem4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem4
            // 
            this.picItem4.BackColor = System.Drawing.Color.Transparent;
            this.picItem4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem4.Location = new System.Drawing.Point(355, 193);
            this.picItem4.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem4.Name = "picItem4";
            this.picItem4.Size = new System.Drawing.Size(60, 60);
            this.picItem4.TabIndex = 16;
            this.picItem4.TabStop = false;
            this.picItem4.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem4.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // lblItem5
            // 
            this.lblItem5.Location = new System.Drawing.Point(445, 263);
            this.lblItem5.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem5.Name = "lblItem5";
            this.lblItem5.Size = new System.Drawing.Size(80, 30);
            this.lblItem5.TabIndex = 19;
            this.lblItem5.Text = "Item 5";
            this.lblItem5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem5
            // 
            this.picItem5.BackColor = System.Drawing.Color.Transparent;
            this.picItem5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem5.Location = new System.Drawing.Point(455, 193);
            this.picItem5.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem5.Name = "picItem5";
            this.picItem5.Size = new System.Drawing.Size(60, 60);
            this.picItem5.TabIndex = 18;
            this.picItem5.TabStop = false;
            this.picItem5.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem5.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // lblItem6
            // 
            this.lblItem6.Location = new System.Drawing.Point(545, 263);
            this.lblItem6.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblItem6.Name = "lblItem6";
            this.lblItem6.Size = new System.Drawing.Size(80, 30);
            this.lblItem6.TabIndex = 21;
            this.lblItem6.Text = "Item 6";
            this.lblItem6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picItem6
            // 
            this.picItem6.BackColor = System.Drawing.Color.Transparent;
            this.picItem6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picItem6.Location = new System.Drawing.Point(555, 193);
            this.picItem6.Margin = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.picItem6.Name = "picItem6";
            this.picItem6.Size = new System.Drawing.Size(60, 60);
            this.picItem6.TabIndex = 20;
            this.picItem6.TabStop = false;
            this.picItem6.DragDrop += new System.Windows.Forms.DragEventHandler(this.picItem_DragDrop);
            this.picItem6.DragEnter += new System.Windows.Forms.DragEventHandler(this.picItem_DragEnter);
            // 
            // formStatSheet
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 500);
            this.Controls.Add(this.lblItem6);
            this.Controls.Add(this.picItem6);
            this.Controls.Add(this.lblItem5);
            this.Controls.Add(this.picItem5);
            this.Controls.Add(this.lblItem4);
            this.Controls.Add(this.picItem4);
            this.Controls.Add(this.lblItem3);
            this.Controls.Add(this.picItem3);
            this.Controls.Add(this.lblItem2);
            this.Controls.Add(this.picItem2);
            this.Controls.Add(this.lblItem1);
            this.Controls.Add(this.picItem1);
            this.Controls.Add(this.lblChampion);
            this.Controls.Add(this.picChampion);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formStatSheet";
            this.Text = "formStatSheet";
            this.VisibleChanged += new System.EventHandler(this.formStatSheet_VisibleChanged);
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.picChampion, 0);
            this.Controls.SetChildIndex(this.lblChampion, 0);
            this.Controls.SetChildIndex(this.picItem1, 0);
            this.Controls.SetChildIndex(this.lblItem1, 0);
            this.Controls.SetChildIndex(this.picItem2, 0);
            this.Controls.SetChildIndex(this.lblItem2, 0);
            this.Controls.SetChildIndex(this.picItem3, 0);
            this.Controls.SetChildIndex(this.lblItem3, 0);
            this.Controls.SetChildIndex(this.picItem4, 0);
            this.Controls.SetChildIndex(this.lblItem4, 0);
            this.Controls.SetChildIndex(this.picItem5, 0);
            this.Controls.SetChildIndex(this.lblItem5, 0);
            this.Controls.SetChildIndex(this.picItem6, 0);
            this.Controls.SetChildIndex(this.lblItem6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem6)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeDragDrop()
        {

            this.itemLabels = new Label[] { this.lblItem1, this.lblItem2, this.lblItem3, this.lblItem4, this.lblItem5, this.lblItem6 };
            this.itemPictures = new PictureBox[] { this.picItem1, this.picItem2, this.picItem3, this.picItem4, this.picItem5, this.picItem6 };
            this.picChampion.AllowDrop = true;
            foreach (PictureBox picbox in this.itemPictures)
                picbox.AllowDrop = true;
            return;
        }
        private void UpdateBuild()
        {
            if (!this.Visible)
                return;
            this.build = Build.GetBuild(0);
            // update champion
            ChampionInfo champion = this.build.GetChampion();
            if (champion != null)
            {
                this.picChampion.BackgroundImage = champion.Image;
                this.lblChampion.Text = champion.Name;
            }
            // update items
            List<ItemInfo> new_items = this.build.GetItems();
            for (int i = 0; i < 6; i++)
            {
                this.items[i] = new_items[i];
                this.itemLabels[i].Text = this.items[i]?.Name ?? string.Format("Item {0}", i + 1);
                this.itemPictures[i].BackgroundImage = this.items[i]?.Image;
            }
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
        private void picChampion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ChampionInfo)))
                e.Effect = DragDropEffects.Copy;
            return;
        }
        private void picChampion_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ChampionInfo)))
                return;
            ChampionInfo champion = (ChampionInfo)e.Data.GetData(typeof (ChampionInfo));
            this.build.SetChampion(champion);
            return;
        }
        private void picItem_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pic_box = sender as PictureBox;
            int index = this.itemPictures.ToList().IndexOf(pic_box);
            if (!e.Data.GetDataPresent(typeof(ItemInfo)))
                return;
            ItemInfo item = (ItemInfo)e.Data.GetData(typeof(ItemInfo));
            this.build.SetItem(index, item);
            return;
        }
        private void picItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemInfo)))
                e.Effect = DragDropEffects.Copy;
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

    }
}

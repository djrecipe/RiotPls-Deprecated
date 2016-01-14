using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls
{
    public class formMenu : formTemplate
    {
        #region Instance Members
        private Button btnChampions;
        private Button btnItems;
        private Button btnMaps;
        private Button btnBuilder;
        private formStatSheet fStatSheet = new formStatSheet();
        private formChampions fChampions = new formChampions();
        private formItems fItems = new formItems();
        private formMaps fMaps = new formMaps();
        private LinkLabel lblVersion;
        private System.ComponentModel.IContainer components = null;
        #endregion
        #region Instance Methods
        public formMenu()
        {
            this.InitializeComponent();
            return;
        }
        private void InitializeComponent()
        {
            this.btnChampions = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnMaps = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(119, 9);
            // 
            // btnChampions
            // 
            this.btnChampions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChampions.Location = new System.Drawing.Point(29, 39);
            this.btnChampions.Margin = new System.Windows.Forms.Padding(20, 30, 20, 10);
            this.btnChampions.Name = "btnChampions";
            this.btnChampions.Size = new System.Drawing.Size(90, 30);
            this.btnChampions.TabIndex = 3;
            this.btnChampions.Text = "Champions";
            this.btnChampions.UseVisualStyleBackColor = true;
            this.btnChampions.Click += new System.EventHandler(this.btnChampions_Click);
            // 
            // btnItems
            // 
            this.btnItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItems.Location = new System.Drawing.Point(29, 89);
            this.btnItems.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(90, 30);
            this.btnItems.TabIndex = 4;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnMaps
            // 
            this.btnMaps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaps.Location = new System.Drawing.Point(29, 139);
            this.btnMaps.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnMaps.Name = "btnMaps";
            this.btnMaps.Size = new System.Drawing.Size(90, 30);
            this.btnMaps.TabIndex = 5;
            this.btnMaps.Text = "Maps";
            this.btnMaps.UseVisualStyleBackColor = true;
            this.btnMaps.Click += new System.EventHandler(this.btnMaps_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuilder.Location = new System.Drawing.Point(29, 189);
            this.btnBuilder.Margin = new System.Windows.Forms.Padding(20, 10, 20, 30);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(90, 30);
            this.btnBuilder.TabIndex = 6;
            this.btnBuilder.Text = "Builder";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblVersion.Location = new System.Drawing.Point(9, 235);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(34, 14);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.TabStop = true;
            this.lblVersion.Text = "v0.00";
            this.lblVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblVersion_LinkClicked);
            // 
            // formMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 258);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnBuilder);
            this.Controls.Add(this.btnMaps);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnChampions);
            this.Name = "formMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMenu";
            this.Load += new System.EventHandler(this.formMenu_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnChampions, 0);
            this.Controls.SetChildIndex(this.btnItems, 0);
            this.Controls.SetChildIndex(this.btnMaps, 0);
            this.Controls.SetChildIndex(this.btnBuilder, 0);
            this.Controls.SetChildIndex(this.lblVersion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void UpdateVersionLabel()
        {
            this.lblVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return;
        }
        #endregion
        #region Event Methods
        #region Button Events
        private void btnBuilder_Click(object sender, EventArgs e)
        {
            if (this.fStatSheet.Visible)
                this.fStatSheet.Activate();
            else
                this.fStatSheet.Show(this);
            return;
        }
        private void btnChampions_Click(object sender, EventArgs e)
        {
            if (this.fChampions.Visible)    
                this.fChampions.Activate();
            else
                this.fChampions.Show(this);
            return;
        }
        private void btnItems_Click(object sender, EventArgs e)
        {
            if (this.fItems.Visible)
                this.fItems.Activate();
            else
                this.fItems.Show(this);
            return;
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            if (this.fMaps.Visible)
                this.fMaps.Activate();
            else
                this.fMaps.Show(this);
            return;
        }
        #endregion
        #region Form Events
        private void formMenu_Load(object sender, EventArgs e)
        {
            this.UpdateVersionLabel();
            return;
        }
        #endregion 
        #region Label Events
        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/djrecipe/RitoPls");
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
            return;
        }
        #endregion

    }
}

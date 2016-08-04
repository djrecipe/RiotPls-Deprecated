using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.ExtensionMethods;
using RiotPls.UI.Models;

namespace RiotPls.UI.Views
{
    /// <summary>
    /// Primary application window
    /// </summary>
    /// <remarks>Behaves as an MDI parent</remarks>
    public class formMain : Form
    {
        #region Instance Members       
        #region Controls    
        private System.ComponentModel.IContainer components = null;
        private ToolStrip toolsTop;
        private ToolStripButton btnChampions;
        private ToolStripButton btnItems;
        private ToolStripButton btnMaps;
        private ToolStripButton btnConfig;
        private ToolStripDropDownButton btnBuilder;
        private ToolStripMenuItem btnCreateBuild;
        #endregion
        private formMainModel model = null;
        #endregion
        #region Instance Properties
        #endregion
        #region Instance Methods
        #region Intialization Methods
        public formMain()
        {
            this.InitializeComponent();
            Engine.Initialize();
            this.model = new formMainModel(this);
            this.model.BuildCollectionChanged += this.Model_BuildCollectionChanged;
            this.UpdateBuilderButton();
            return;
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.toolsTop = new System.Windows.Forms.ToolStrip();
            this.btnChampions = new System.Windows.Forms.ToolStripButton();
            this.btnItems = new System.Windows.Forms.ToolStripButton();
            this.btnMaps = new System.Windows.Forms.ToolStripButton();
            this.btnBuilder = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCreateBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.toolsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsTop
            // 
            this.toolsTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.toolsTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChampions,
            this.btnItems,
            this.btnMaps,
            this.btnBuilder,
            this.btnConfig});
            this.toolsTop.Location = new System.Drawing.Point(0, 0);
            this.toolsTop.Name = "toolsTop";
            this.toolsTop.Size = new System.Drawing.Size(101, 261);
            this.toolsTop.TabIndex = 1;
            this.toolsTop.Text = "toolStrip1";
            // 
            // btnChampions
            // 
            this.btnChampions.AutoSize = false;
            this.btnChampions.Image = global::RiotPls.Properties.Resources.ChampionIcon;
            this.btnChampions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChampions.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.btnChampions.Name = "btnChampions";
            this.btnChampions.Size = new System.Drawing.Size(90, 20);
            this.btnChampions.Text = "Champions";
            this.btnChampions.Click += new System.EventHandler(this.btnChampions_Click);
            // 
            // btnItems
            // 
            this.btnItems.AutoSize = false;
            this.btnItems.Image = global::RiotPls.Properties.Resources.ItemsIcon;
            this.btnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItems.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(90, 20);
            this.btnItems.Text = "Items";
            this.btnItems.ToolTipText = "Items";
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnMaps
            // 
            this.btnMaps.AutoSize = false;
            this.btnMaps.Image = global::RiotPls.Properties.Resources.MapsIcon;
            this.btnMaps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMaps.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnMaps.Name = "btnMaps";
            this.btnMaps.Size = new System.Drawing.Size(90, 20);
            this.btnMaps.Text = "Maps";
            this.btnMaps.Click += new System.EventHandler(this.btnMaps_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.AutoSize = false;
            this.btnBuilder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateBuild});
            this.btnBuilder.Image = global::RiotPls.Properties.Resources.BuilderIcon;
            this.btnBuilder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuilder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuilder.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(90, 20);
            this.btnBuilder.Text = "Builder";
            // 
            // btnCreateBuild
            // 
            this.btnCreateBuild.Name = "btnCreateBuild";
            this.btnCreateBuild.Size = new System.Drawing.Size(107, 22);
            this.btnCreateBuild.Text = "New...";
            this.btnCreateBuild.Click += new System.EventHandler(this.btnCreateBuild_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConfig.AutoSize = false;
            this.btnConfig.Image = global::RiotPls.Properties.Resources.Gears;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(90, 20);
            this.btnConfig.Text = "Settings";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.toolsTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "formMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RiotPls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.toolsTop.ResumeLayout(false);
            this.toolsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void UpdateBuilderButton()
        {
            this.btnBuilder.DropDownItems.Clear();
            this.btnBuilder.DropDownItems.Add(this.btnCreateBuild);
            List<ToolStripMenuItem> items = this.model.GetBuilderItems();
            this.btnBuilder.DropDownItems.AddRange(items.ToArray());
            return;
        }
        #endregion

        #endregion
        #region Event Methods   
        #region Button Events
        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.model.SettingsVisible = true;
            return;
        }
        private void btnChampions_Click(object sender, EventArgs e)
        {
            this.model.ChampionsVisible = true;
            return;
        }
        private void btnCreateBuild_Click(object sender, EventArgs e)
        {
            this.model.CreateNewBuild();
            return;
        }
        private void btnItems_Click(object sender, EventArgs e)
        {
            this.model.ItemsVisible = true;
            return;
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            this.model.MapsVisible = true;
            return;
        }
        #endregion
        #region Form Events
        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.model.Cleanup();
        }
        private void formMain_Load(object sender, EventArgs e)
        {
            Tools.GeneralSettings.LoadWindowSettings(this);
            this.model.InitializeFormVisibility();
            return;
        }
        #endregion
        #region Model Events
        private void Model_BuildCollectionChanged()
        {
            this.UpdateBuilderButton();
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

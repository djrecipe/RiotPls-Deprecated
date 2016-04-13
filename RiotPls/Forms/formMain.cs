using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls.Forms
{
    public class formMain : Form
    {
        private ToolStrip toolsTop;
        private ToolStripButton btnChampions;
        private System.ComponentModel.IContainer components = null;
        private ToolStripButton btnItems;
        private ToolStripButton btnMaps;
        private ToolStripButton btnConfig;
        private ToolStripButton btnBuilder;
        private formBuilder fBuilder = new formBuilder();
        private formChampions fChampions = new formChampions();
        private formItems fItems = new formItems();
        private formMaps fMaps = new formMaps();
        private formSettings fSettings = new formSettings();
        private bool BuilderVisible
        {
            get { return this.fBuilder.Visible; }
            set
            {
                this.ToggleWindow(this.fBuilder, value);
                return;
            }
        }
        private bool ChampionsVisible
        {
            get { return this.fChampions.Visible; }
            set
            {
                this.ToggleWindow(this.fChampions, value);
                return;
            }
        }
        private bool ItemsVisible
        {
            get { return this.fItems.Visible; }
            set
            {
                this.ToggleWindow(this.fItems, value);
                return;
            }
        }
        private bool MapsVisible
        {
            get { return this.fMaps.Visible; }
            set
            {
                this.ToggleWindow(this.fMaps, value);
                return;
            }
        }
        private bool SettingsVisible
        {
            get { return this.fSettings.Visible; }
            set
            {
                this.ToggleWindow(this.fSettings, value);
                return;
            }
        }
        public formMain()
        {
            InitializeComponent();
            this.fBuilder.MdiParent = this;
            this.fChampions.MdiParent = this;
            this.fItems.MdiParent = this;
            this.fMaps.MdiParent = this;
            this.fSettings.MdiParent = this;
            return;
        }

        private void InitializeComponent()
        {
            this.toolsTop = new System.Windows.Forms.ToolStrip();
            this.btnChampions = new System.Windows.Forms.ToolStripButton();
            this.btnItems = new System.Windows.Forms.ToolStripButton();
            this.btnMaps = new System.Windows.Forms.ToolStripButton();
            this.btnBuilder = new System.Windows.Forms.ToolStripButton();
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
            this.btnBuilder.Image = global::RiotPls.Properties.Resources.BuilderIcon;
            this.btnBuilder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuilder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuilder.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(90, 20);
            this.btnBuilder.Text = "Builder";
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
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
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "formMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.toolsTop.ResumeLayout(false);
            this.toolsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ToggleWindow(Form form, bool value)
        {
            bool was_visible = form.Visible;
            form.Visible = value;
            if (value)
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                }
                else if(was_visible)
                    form.WindowState = FormWindowState.Minimized;
            }
            return;
        }
        private void btnBuilder_Click(object sender, EventArgs e)
        {
            this.BuilderVisible = true;
            return;
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.SettingsVisible = true;
            return;
        }
        private void btnChampions_Click(object sender, EventArgs e)
        {
            this.ChampionsVisible = true;
            return;
        }
        private void btnItems_Click(object sender, EventArgs e)
        {
            this.ItemsVisible = true;
            return;
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            this.MapsVisible = true;
            return;
        }
        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tools.GeneralSettings.SaveWindowSettings(this.fBuilder);
            Tools.GeneralSettings.SaveWindowSettings(this.fChampions);
            Tools.GeneralSettings.SaveWindowSettings(this.fItems);
            Tools.GeneralSettings.SaveWindowSettings(this.fMaps);
            Tools.GeneralSettings.SaveWindowSettings(this.fSettings);
            Tools.GeneralSettings.SaveWindowSettings(this);
            Tools.GeneralSettings.Save();
        }
        private void formMain_Load(object sender, EventArgs e)
        {

            Tools.GeneralSettings.LoadWindowSettings(this);
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

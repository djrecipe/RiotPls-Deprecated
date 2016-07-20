using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using RiotPls.API;
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Maps;
using RiotPls.UI.Models;

namespace RiotPls.UI.Views
{
    /// <summary>
    /// Displays hi-resolution images depicting each playable map
    /// </summary>
    public class formMaps : formTemplate
    {
        #region Instance Members
        #region Controls   
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboMaps;
        private Cyotek.Windows.Forms.ImageBox imgboxMap;
        #endregion
        #endregion
        #region Instance Properties  
        public formMapsModel Model => this.model as formMapsModel;
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public formMaps()
        {
            InitializeComponent();
            this.model = new formMapsModel();
            this.model.DataUpdateStarted += Model_DataUpdateStarted;
            this.model.DataUpdateFinished += Model_DataUpdateFinished;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMaps));
            this.comboMaps = new System.Windows.Forms.ComboBox();
            this.imgboxMap = new Cyotek.Windows.Forms.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(157, 176);
            // 
            // comboMaps
            // 
            this.comboMaps.BackColor = System.Drawing.Color.Black;
            this.comboMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMaps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.comboMaps.FormattingEnabled = true;
            this.comboMaps.Items.AddRange(new object[] {
            "Howling Abyss",
            "Summoner\'s Rift",
            "Twisted Treeline"});
            this.comboMaps.Location = new System.Drawing.Point(29, 29);
            this.comboMaps.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.comboMaps.Name = "comboMaps";
            this.comboMaps.Size = new System.Drawing.Size(144, 22);
            this.comboMaps.Sorted = true;
            this.comboMaps.TabIndex = 3;
            this.comboMaps.SelectedIndexChanged += new System.EventHandler(this.comboMaps_SelectedIndexChanged);
            // 
            // imgboxMap
            // 
            this.imgboxMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgboxMap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imgboxMap.Location = new System.Drawing.Point(29, 71);
            this.imgboxMap.Margin = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.imgboxMap.Name = "imgboxMap";
            this.imgboxMap.Size = new System.Drawing.Size(1137, 727);
            this.imgboxMap.TabIndex = 4;
            this.imgboxMap.ZoomChanged += new System.EventHandler(this.imgboxMap_ZoomChanged);
            // 
            // formMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 827);
            this.Controls.Add(this.imgboxMap);
            this.Controls.Add(this.comboMaps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(470, 300);
            this.Name = "formMaps";
            this.Text = "Maps";
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.comboMaps, 0);
            this.Controls.SetChildIndex(this.imgboxMap, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private void UpdateImage()
        {
            string name = this.comboMaps.SelectedIndex < 0 || this.comboMaps.SelectedIndex >= this.comboMaps.Items.Count
                ? null : this.comboMaps.Items[this.comboMaps.SelectedIndex].ToString();
            this.imgboxMap.Image = this.Model.GetImage(name);
            this.imgboxMap.ZoomToFit();
            this.imgboxMap.Focus();
            return;
        }
        #endregion
        #region Event Methods
        private void comboMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateImage();
            return;
        }
        private void imgboxMap_ZoomChanged(object sender, EventArgs e)
        {
            this.imgboxMap.Zoom = Math.Max(0, this.imgboxMap.Zoom);
            return;
        }
        #region Model Events
        private void Model_DataUpdateFinished(object sender, object e)
        {
            this.comboMaps.SelectedIndex = this.comboMaps.Items.IndexOf("Summoner's Rift");
            return;
        }
        private void Model_DataUpdateStarted()
        {
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls
{
    public class formMaps : formTemplate
    {
        private ComboBox comboMaps;
        private System.ComponentModel.IContainer components = null;
        private Cyotek.Windows.Forms.ImageBox imgboxMap;
        private Dictionary<string, MapInfo> source = new Dictionary<string, MapInfo>();
        private int original_zoom = -1;
        public formMaps()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.comboMaps = new System.Windows.Forms.ComboBox();
            this.imgboxMap = new Cyotek.Windows.Forms.ImageBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1166, 9);
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
            "Old Summoner\'s Rift",
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
            this.Name = "formMaps";
            this.Text = "formMaps";
            this.Load += new System.EventHandler(this.formMaps_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.comboMaps, 0);
            this.Controls.SetChildIndex(this.imgboxMap, 0);
            this.ResumeLayout(false);

        }
        private void formMaps_Load(object sender, EventArgs e)
        {
            this.source = RiotAPI.GetMapInfo();
            this.comboMaps.SelectedIndex = this.comboMaps.Items.IndexOf("Summoner's Rift");
            return;
        }
        private void UpdateImage()
        {
            this.imgboxMap.Image = this.comboMaps.SelectedIndex < 0 ? null : this.source.Values.FirstOrDefault(m => m.Name == this.comboMaps.Items[this.comboMaps.SelectedIndex].ToString()).Image;
            this.imgboxMap.ZoomToFit();
            this.original_zoom = this.imgboxMap.Zoom;
            this.imgboxMap.Focus();
            return;
        }
        private void comboMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateImage();
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

        private void imgboxMap_ZoomChanged(object sender, EventArgs e)
        {
            this.imgboxMap.Zoom = Math.Max(this.original_zoom, this.imgboxMap.Zoom);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls.Controls
{
    public class BuildFlow : UserControl
    {
        #region Instance Members
        private IContainer components = null;
        private FlowLayoutPanel layoutMain;
        private PictureBox picAdd;
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public BuildFlow()
        {
            this.InitializeComponent();
            return;
        }
        private void InitializeComponent()
        {
            this.layoutMain = new System.Windows.Forms.FlowLayoutPanel();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.BackColor = System.Drawing.Color.Transparent;
            this.layoutMain.Controls.Add(this.picAdd);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.layoutMain.Size = new System.Drawing.Size(260, 140);
            this.layoutMain.TabIndex = 0;
            // 
            // picAdd
            // 
            this.picAdd.BackgroundImage = global::RiotPls.Properties.Resources.Add;
            this.picAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picAdd.Location = new System.Drawing.Point(20, 20);
            this.picAdd.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(100, 100);
            this.picAdd.TabIndex = 0;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // BuildFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(9999, 140);
            this.MinimumSize = new System.Drawing.Size(260, 140);
            this.Name = "BuildFlow";
            this.Size = new System.Drawing.Size(260, 140);
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region Event Methods
        #endregion
        private void picAdd_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Override Methods
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

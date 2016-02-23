using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using RiotPls.API.Serialization.Champion;
using RiotPls.Builder;

namespace RiotPls.Forms
{
    public class formStatSheet : formTemplate
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picChampion;
        private System.Windows.Forms.Label lblChampion;
        public formStatSheet()
        {
            this.InitializeComponent();
            this.picChampion.AllowDrop = true;
            this.picChampion.DragEnter += this.picChampion_DragEnter;
            this.picChampion.DragDrop += this.picChampion_DragDrop;
            BuildManager.BuildChanged += this.BuildManager_BuildChanged;
            return;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStatSheet));
            this.picChampion = new System.Windows.Forms.PictureBox();
            this.lblChampion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(721, 9);
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
            // 
            // lblChampion
            // 
            this.lblChampion.AutoSize = true;
            this.lblChampion.Location = new System.Drawing.Point(54, 139);
            this.lblChampion.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblChampion.Name = "lblChampion";
            this.lblChampion.Size = new System.Drawing.Size(63, 14);
            this.lblChampion.TabIndex = 4;
            this.lblChampion.Text = "Champion";
            this.lblChampion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formStatSheet
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.lblChampion);
            this.Controls.Add(this.picChampion);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formStatSheet";
            this.Text = "formStatSheet";
            this.Load += new System.EventHandler(this.formStatSheet_Load);
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.picChampion, 0);
            this.Controls.SetChildIndex(this.lblChampion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void UpdateBuild()
        {
            ChampionInfo info = BuildManager.GetChampion(0);
            if (info != null)
            {
                this.picChampion.BackgroundImage = info.Image;
            }
            return;
        }
        private void BuildManager_BuildChanged(int index)
        {
            if(index == 0 && this.Visible)
                this.UpdateBuild();
            return;
        }
        private void formStatSheet_Load(object sender, System.EventArgs e)
        {
            this.UpdateBuild();
            return;
        }
        private void picChampion_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
            return;
        }
        private void picChampion_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Bitmap bitmap = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                if (bitmap != null)
                {
                    string name = bitmap.Tag as string;
                    if(BuildManager.SetChampion(0, name))
                        this.UpdateBuild();
                }
            }
            catch
            {
            }
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

namespace RiotPls.Forms
{
    partial class formStatSheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picChampion = new System.Windows.Forms.PictureBox();
            this.lblChampion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(721, 9);
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
            this.Name = "formStatSheet";
            this.Text = "formStatSheet";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.formStatSheet_DragDrop);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.picChampion, 0);
            this.Controls.SetChildIndex(this.lblChampion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picChampion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picChampion;
        private System.Windows.Forms.Label lblChampion;
    }
}
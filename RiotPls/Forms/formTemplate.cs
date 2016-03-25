using System;
using System.Drawing;
using System.Windows.Forms;

namespace RiotPls.Forms
{
    public class formTemplate : Form
    {
        #region Instance Members  
        #region Controls               
        private System.ComponentModel.IContainer components = null;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSettings;
        protected System.ComponentModel.BackgroundWorker workerUpdateData;
        protected System.Windows.Forms.PictureBox picLoading;
        #endregion
        private Point last_mouse = Point.Empty;
        #endregion
        #region Instance Properties  
        public bool ChildWindow
        {
            get;
            set;
        } = false;  
        public bool ShowLoading
        {
            get;
            set;
        } = false;
        #endregion
        #region Instance Methods
        protected formTemplate()
        {
            this.InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTemplate));
            this.btnClose = new System.Windows.Forms.Button();
            this.workerUpdateData = new System.ComponentModel.BackgroundWorker();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnClose.Location = new System.Drawing.Point(302, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "x";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            // 
            // workerUpdateData
            // 
            this.workerUpdateData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerUpdateData_DoWork);
            this.workerUpdateData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerUpdateData_RunWorkerCompleted);
            // 
            // picLoading
            // 
            this.picLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLoading.Image = global::RiotPls.Properties.Resources.Loading;
            this.picLoading.InitialImage = null;
            this.picLoading.Location = new System.Drawing.Point(101, 77);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(128, 128);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 7;
            this.picLoading.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::RiotPls.Properties.Resources.Gears;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(10, 10);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(16, 16);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // formTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(331, 282);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formTemplate";
            this.Text = "formTemplate";
            this.VisibleChanged += new System.EventHandler(this.formTemplate_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.formTemplate_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formTemplate_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        protected void LoadWindowSettings()
        {
            Tools.GeneralSettings.LoadWindowSettings(this);
            return;
        }
        protected void SaveWindowSettings()
        {
            Tools.GeneralSettings.SaveWindowSettings(this);
            return;
        }

        protected void UpdateData()
        {
            if (this.workerUpdateData.IsBusy)
                return;
            this.picLoading.Visible = this.ShowLoading;
            this.picLoading.BringToFront();
            this.workerUpdateData.RunWorkerAsync();
            return;
        }

        #endregion
        #region Event Methods
        protected virtual void btnSettings_Click(object sender, EventArgs e)
        {
        }
        protected virtual void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            if(this.ChildWindow)
                this.Hide();
            else
                this.Close();
        }
        protected void formTemplate_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons.HasFlag(MouseButtons.Left))
            {
                if (this.last_mouse != Point.Empty)
                    this.Location = new Point(this.Left + (e.X - this.last_mouse.X), this.Top + (e.Y - this.last_mouse.Y));
                else
                    this.last_mouse = e.Location;
            }
            else
                this.last_mouse = Point.Empty;
            return;
        }
        private void formTemplate_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(46, 46, 46), 6.0f), new Rectangle(this.DisplayRectangle.Left, this.DisplayRectangle.Top, this.DisplayRectangle.Width, this.DisplayRectangle.Height));
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(120, 120, 120), 2.0f), new Rectangle(this.DisplayRectangle.Left, this.DisplayRectangle.Top, this.DisplayRectangle.Width, this.DisplayRectangle.Height));
        }
        private void formTemplate_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Tools.GeneralSettings.LoadWindowSettings(this);
                this.UpdateData();
            }
            else
                Tools.GeneralSettings.SaveWindowSettings(this);
            return;
        }
        protected virtual void workerUpdateData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
        protected virtual void workerUpdateData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
        #endregion  
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

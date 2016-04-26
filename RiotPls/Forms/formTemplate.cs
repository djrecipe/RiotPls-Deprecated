using System;
using System.Drawing;
using System.Windows.Forms;

namespace RiotPls.Forms
{
    /// <summary>
    /// Provides a window template with custom styling
    /// </summary>
    public class formTemplate : Form
    {
        #region Constants
        private const int CP_NOCLOSE_BUTTON = 0x200;
        #endregion
        #region Instance Members  
        #region Controls               
        private System.ComponentModel.IContainer components = null;
        protected System.ComponentModel.BackgroundWorker workerUpdateData;
        protected System.Windows.Forms.PictureBox picLoading;
        #endregion
        private Point last_mouse = Point.Empty;
        #endregion
        #region Instance Properties  
        private bool _CloseButtonEnabled = false;
        /// <summary>
        /// Enable the built-in Windows Forms close (x) button
        /// </summary>
        /// <remarks>If False, the close button will be visible but disabled</remarks>
        public bool CloseButtonEnabled
        {
            get { return this._CloseButtonEnabled; }
            set { this._CloseButtonEnabled = value; }
        }
        /// <summary>
        /// Show loading gif when form is first opened 
        /// </summary>
        /// <remarks>Typically the loading gif is hidden after data binding is complete</remarks>
        public bool ShowLoading
        {
            get;
            set;
        } = false;
        #region Override Properties
        /// <summary>
        /// Results in a disabled close ('x') button
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams my_cp = base.CreateParams;
                my_cp.ClassStyle = my_cp.ClassStyle;
                if (this.CloseButtonEnabled)
                    my_cp.ClassStyle &= ~CP_NOCLOSE_BUTTON;
                else
                    my_cp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return my_cp;
            }
        }
        #endregion
        #endregion
        #region Instance Methods
        #region Initialization Methods
        protected formTemplate()
        {
            this.InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTemplate));
            this.workerUpdateData = new System.ComponentModel.BackgroundWorker();
            this.picLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
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
            // formTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(331, 282);
            this.Controls.Add(this.picLoading);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formTemplate";
            this.Load += new System.EventHandler(this.formTemplate_Load);
            this.SizeChanged += new System.EventHandler(this.formTemplate_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.formTemplate_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.formTemplate_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formTemplate_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
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
        private void formTemplate_Load(object sender, EventArgs e)
        {
            Tools.GeneralSettings.LoadWindowSettings(this);
            return;
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
        private void formTemplate_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void formTemplate_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.UpdateData();
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

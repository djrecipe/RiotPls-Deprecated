using System.Drawing;
using System.Windows.Forms;

namespace RiotPls.Forms
{
    public partial class formTemplate : Form
    {
        #region Instance Members
        protected Point last_mouse = Point.Empty;
        #endregion
        #region Instance Properties    
        public bool NeedsUpdate
        {
            get;
            set;
        } = true;
        #endregion
        #region Instance Methods
        public formTemplate()
        {
            this.InitializeComponent();
            this.NeedsUpdate = true;
        }
        public void UpdateData()
        {
            if (!this.NeedsUpdate)
                return;
            this.NeedsUpdate = false;
            this.workerUpdateData.RunWorkerAsync();
            return;
        }
        #endregion
        #region Event Methods
        protected virtual void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
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
        protected virtual void workerUpdateData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
        protected virtual void workerUpdateData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

    }
}

using System.Windows.Forms;

namespace RiotPls.Forms
{
    public class formTooltipTemplate : formTemplate
    {
        #region Instance Members
        #region Controls
        protected Label lblTitle;
        protected Label lblSubTitle;
        private System.ComponentModel.IContainer components = null;
        #endregion
        #endregion
        #region Instance Properties
        public string ToolTipSubTitle
        {
            get
            {
                return this.lblSubTitle.Text;
            }
            set
            {
                this.lblSubTitle.Text = value;
                return;
            }
        }
        public string ToolTipTitle
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                this.lblTitle.Text = value;
                return;
            }
        }
        #endregion
        #region Instance Methods
        public formTooltipTemplate()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(391, 9);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(19, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(160, 20);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(70)))), ((int)(((byte)(40)))));
            this.lblSubTitle.Location = new System.Drawing.Point(199, 19);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblSubTitle.Size = new System.Drawing.Size(182, 20);
            this.lblSubTitle.TabIndex = 5;
            this.lblSubTitle.Text = "SubTitle";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSubTitle_MouseMove);
            // 
            // formTooltipTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildWindow = true;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "formTooltipTemplate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formTooltip";
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }
        public void HideTooltip()
        {
            if (this.Visible)
                this.Hide();
            return;
        }
        public virtual void ShowTooltip(string title, string sub_title, IWin32Window owner = null)
        {
            if (!this.Visible)
            {
                if (owner != null)
                    this.Show(owner);
                else
                    this.Show();
            }
            this.ToolTipSubTitle = sub_title;
            this.ToolTipTitle = title;
            return;
        }
        #endregion
        #region Event Methods
        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            this.formTemplate_MouseMove(sender, e);
        }
        private void lblSubTitle_MouseMove(object sender, MouseEventArgs e)
        {

            this.formTemplate_MouseMove(sender, e);
        }
        #endregion
        #region Override Methods
        protected override void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hide();
        }
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

using System;
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
    public class formTooltip : formTooltipTemplate
    {
        private Label lblText;
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        #endregion
        #endregion
        #region Instance Properties
        public string ToolTipText
        {
            get
            {
                return this.lblText.Text;
            }
            set
            {
                this.lblText.Text = value;
            }
        }
        #endregion
        #region Instance Methods
        public formTooltip()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Location = new System.Drawing.Point(219, 19);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblText.Location = new System.Drawing.Point(19, 54);
            this.lblText.Margin = new System.Windows.Forms.Padding(10);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(20);
            this.lblText.Size = new System.Drawing.Size(382, 117);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Ipsum emilium descripitorium in your anal bummium and no I won\'t make out with yo" +
    "u!";
            // 
            // formTooltip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.lblText);
            this.Name = "formTooltip";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblText, 0);
            this.ResumeLayout(false);

        }
        public void ShowTooltip(string title, string sub_title, string text, IWin32Window owner = null)
        {
            base.ShowTooltip(title, sub_title, owner);
            this.ToolTipText = text;
            return;
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

namespace RiotPls.Forms
{
    partial class formSettings
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
            this.lblAPIURL = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // lblAPIURL
            // 
            this.lblAPIURL.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.lblAPIURL.Location = new System.Drawing.Point(101, 88);
            this.lblAPIURL.Name = "lblAPIURL";
            this.lblAPIURL.Size = new System.Drawing.Size(55, 13);
            this.lblAPIURL.TabIndex = 3;
            this.lblAPIURL.TabStop = true;
            this.lblAPIURL.Text = "API URL";
            this.lblAPIURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 282);
            this.Controls.Add(this.lblAPIURL);
            this.Name = "formSettings";
            this.Text = "formSettings";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblAPIURL, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblAPIURL;
    }
}
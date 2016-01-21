using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RiotPls.Forms
{
    public class formSettings : formTemplate
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.LinkLabel lblAPIStepOneInstructions;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.GroupBox groupAPI;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAPIStepTwo;
        private System.Windows.Forms.Label lblAPIStepOne;
        private Label lblAPIStepThree;
        private Label lblStepThreeInstructions;
        private System.Windows.Forms.LinkLabel lblAPIStepTwoInstructions;
        public formSettings()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblAPIStepOneInstructions = new System.Windows.Forms.LinkLabel();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.groupAPI = new System.Windows.Forms.GroupBox();
            this.lblStepThreeInstructions = new System.Windows.Forms.Label();
            this.lblAPIStepThree = new System.Windows.Forms.Label();
            this.lblAPIStepTwoInstructions = new System.Windows.Forms.LinkLabel();
            this.lblAPIStepTwo = new System.Windows.Forms.Label();
            this.lblAPIStepOne = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupAPI.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(413, 9);
            // 
            // lblAPIStepOneInstructions
            // 
            this.lblAPIStepOneInstructions.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.lblAPIStepOneInstructions.Location = new System.Drawing.Point(150, 37);
            this.lblAPIStepOneInstructions.Margin = new System.Windows.Forms.Padding(10, 20, 20, 5);
            this.lblAPIStepOneInstructions.Name = "lblAPIStepOneInstructions";
            this.lblAPIStepOneInstructions.Size = new System.Drawing.Size(155, 13);
            this.lblAPIStepOneInstructions.TabIndex = 3;
            this.lblAPIStepOneInstructions.TabStop = true;
            this.lblAPIStepOneInstructions.Text = "Sign-in to Riot Games";
            this.lblAPIStepOneInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAPIStepOneInstructions.VisitedLinkColor = System.Drawing.Color.Violet;
            this.lblAPIStepOneInstructions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAPIStepOneInstructions_LinkClicked);
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAPIKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPIKey.Font = new System.Drawing.Font("Source Code Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtAPIKey.Location = new System.Drawing.Point(43, 117);
            this.txtAPIKey.Margin = new System.Windows.Forms.Padding(40, 10, 40, 20);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(298, 24);
            this.txtAPIKey.TabIndex = 4;
            this.txtAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupAPI
            // 
            this.groupAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAPI.BackColor = System.Drawing.Color.Transparent;
            this.groupAPI.Controls.Add(this.lblStepThreeInstructions);
            this.groupAPI.Controls.Add(this.lblAPIStepThree);
            this.groupAPI.Controls.Add(this.lblAPIStepTwoInstructions);
            this.groupAPI.Controls.Add(this.lblAPIStepTwo);
            this.groupAPI.Controls.Add(this.lblAPIStepOne);
            this.groupAPI.Controls.Add(this.txtAPIKey);
            this.groupAPI.Controls.Add(this.lblAPIStepOneInstructions);
            this.groupAPI.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupAPI.Location = new System.Drawing.Point(29, 29);
            this.groupAPI.Margin = new System.Windows.Forms.Padding(20);
            this.groupAPI.Name = "groupAPI";
            this.groupAPI.Size = new System.Drawing.Size(384, 160);
            this.groupAPI.TabIndex = 5;
            this.groupAPI.TabStop = false;
            this.groupAPI.Text = "API Key";
            // 
            // lblStepThreeInstructions
            // 
            this.lblStepThreeInstructions.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lblStepThreeInstructions.Location = new System.Drawing.Point(150, 86);
            this.lblStepThreeInstructions.Margin = new System.Windows.Forms.Padding(10, 5, 20, 5);
            this.lblStepThreeInstructions.Name = "lblStepThreeInstructions";
            this.lblStepThreeInstructions.Size = new System.Drawing.Size(155, 15);
            this.lblStepThreeInstructions.TabIndex = 10;
            this.lblStepThreeInstructions.Text = "Copy and Paste Below";
            this.lblStepThreeInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAPIStepThree
            // 
            this.lblAPIStepThree.Location = new System.Drawing.Point(80, 86);
            this.lblAPIStepThree.Margin = new System.Windows.Forms.Padding(20, 5, 10, 5);
            this.lblAPIStepThree.Name = "lblAPIStepThree";
            this.lblAPIStepThree.Size = new System.Drawing.Size(50, 15);
            this.lblAPIStepThree.TabIndex = 9;
            this.lblAPIStepThree.Text = "Step 3:";
            this.lblAPIStepThree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAPIStepTwoInstructions
            // 
            this.lblAPIStepTwoInstructions.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.lblAPIStepTwoInstructions.Location = new System.Drawing.Point(150, 62);
            this.lblAPIStepTwoInstructions.Margin = new System.Windows.Forms.Padding(10, 5, 20, 5);
            this.lblAPIStepTwoInstructions.Name = "lblAPIStepTwoInstructions";
            this.lblAPIStepTwoInstructions.Size = new System.Drawing.Size(155, 13);
            this.lblAPIStepTwoInstructions.TabIndex = 8;
            this.lblAPIStepTwoInstructions.TabStop = true;
            this.lblAPIStepTwoInstructions.Text = "Navigate to Your API Keys";
            this.lblAPIStepTwoInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAPIStepTwoInstructions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAPIStepTwoInstructions_LinkClicked);
            // 
            // lblAPIStepTwo
            // 
            this.lblAPIStepTwo.Location = new System.Drawing.Point(80, 61);
            this.lblAPIStepTwo.Margin = new System.Windows.Forms.Padding(20, 5, 10, 5);
            this.lblAPIStepTwo.Name = "lblAPIStepTwo";
            this.lblAPIStepTwo.Size = new System.Drawing.Size(50, 15);
            this.lblAPIStepTwo.TabIndex = 7;
            this.lblAPIStepTwo.Text = "Step 2:";
            this.lblAPIStepTwo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAPIStepOne
            // 
            this.lblAPIStepOne.Location = new System.Drawing.Point(80, 36);
            this.lblAPIStepOne.Margin = new System.Windows.Forms.Padding(20, 20, 10, 5);
            this.lblAPIStepOne.Name = "lblAPIStepOne";
            this.lblAPIStepOne.Size = new System.Drawing.Size(50, 15);
            this.lblAPIStepOne.TabIndex = 6;
            this.lblAPIStepOne.Text = "Step 1:";
            this.lblAPIStepOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(323, 219);
            this.btnOK.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(29, 219);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 268);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupAPI);
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "+";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.groupAPI, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.groupAPI.ResumeLayout(false);
            this.groupAPI.PerformLayout();
            this.ResumeLayout(false);

        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
            return;
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                API.Engine.SaveKey(this.txtAPIKey.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error While Saving Key:\n{0}", ex.Message));
            }
            return;
        }
        private void lblAPIStepOneInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://developer.riotgames.com/sign-in");
        }
        private void lblAPIStepTwoInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://developer.riotgames.com/");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void workerUpdateData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                API.Engine.LoadKey();
                e.Result = API.Engine.APIKeyRaw;
            }
            catch(Exception ex)
            {

            }
        }
        protected override void workerUpdateData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.txtAPIKey.Text = e.Result as string;
            }
            catch (Exception ex)
            {
            }
        }
    }
}

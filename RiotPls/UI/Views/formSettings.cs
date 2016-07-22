using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using RiotPls.UI.Models;

namespace RiotPls.UI.Views
{
    /// <summary>
    /// Provides a UI for modifying application settings
    /// </summary>
    public class formSettings : formTemplate
    {
        #region Instance Members
        #region Controls
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
        private GroupBox groupResources;
        private Label lblIgnoredCount;
        private LinkLabel lblIgnoreCountValue;
        private LinkLabel lblContentVersionValue;
        private Label lblContentVersion;
        private System.Windows.Forms.LinkLabel lblAPIStepTwoInstructions;
        #endregion
        #endregion
        #region Instance Properties
        private formSettingsModel Model => this.model as formSettingsModel;
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public formSettings()  : base()
        {
            this.InitializeComponent();
            this.model = new formSettingsModel();
            this.model.DataUpdateFinished += this.Model_DataUpdateFinished;
            this.model.DataUpdateStarted += this.Model_DataUpdateStarted;
            return;
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
            this.groupResources = new System.Windows.Forms.GroupBox();
            this.lblContentVersionValue = new System.Windows.Forms.LinkLabel();
            this.lblContentVersion = new System.Windows.Forms.Label();
            this.lblIgnoredCount = new System.Windows.Forms.Label();
            this.lblIgnoreCountValue = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.groupAPI.SuspendLayout();
            this.groupResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(101, 183);
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
            this.txtAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtAPIKey.Location = new System.Drawing.Point(43, 117);
            this.txtAPIKey.Margin = new System.Windows.Forms.Padding(40, 10, 40, 20);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(298, 22);
            this.txtAPIKey.TabIndex = 4;
            this.txtAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupAPI
            // 
            this.groupAPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.btnOK.Location = new System.Drawing.Point(323, 431);
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
            this.btnCancel.Location = new System.Drawing.Point(29, 431);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupResources
            // 
            this.groupResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResources.BackColor = System.Drawing.Color.Transparent;
            this.groupResources.Controls.Add(this.lblContentVersionValue);
            this.groupResources.Controls.Add(this.lblContentVersion);
            this.groupResources.Controls.Add(this.lblIgnoredCount);
            this.groupResources.Controls.Add(this.lblIgnoreCountValue);
            this.groupResources.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupResources.Location = new System.Drawing.Point(29, 229);
            this.groupResources.Margin = new System.Windows.Forms.Padding(20);
            this.groupResources.Name = "groupResources";
            this.groupResources.Size = new System.Drawing.Size(384, 160);
            this.groupResources.TabIndex = 11;
            this.groupResources.TabStop = false;
            this.groupResources.Text = "Resources";
            // 
            // lblContentVersionValue
            // 
            this.lblContentVersionValue.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.lblContentVersionValue.Location = new System.Drawing.Point(227, 94);
            this.lblContentVersionValue.Margin = new System.Windows.Forms.Padding(10, 20, 20, 5);
            this.lblContentVersionValue.Name = "lblContentVersionValue";
            this.lblContentVersionValue.Size = new System.Drawing.Size(50, 13);
            this.lblContentVersionValue.TabIndex = 8;
            this.lblContentVersionValue.TabStop = true;
            this.lblContentVersionValue.Text = "6.6.1";
            this.lblContentVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContentVersionValue.VisitedLinkColor = System.Drawing.Color.Violet;
            this.lblContentVersionValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblContentVersionValue_LinkClicked);
            // 
            // lblContentVersion
            // 
            this.lblContentVersion.Location = new System.Drawing.Point(107, 93);
            this.lblContentVersion.Margin = new System.Windows.Forms.Padding(20, 20, 10, 5);
            this.lblContentVersion.Name = "lblContentVersion";
            this.lblContentVersion.Size = new System.Drawing.Size(100, 15);
            this.lblContentVersion.TabIndex = 7;
            this.lblContentVersion.Text = "Content Version:";
            this.lblContentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgnoredCount
            // 
            this.lblIgnoredCount.Location = new System.Drawing.Point(107, 53);
            this.lblIgnoredCount.Margin = new System.Windows.Forms.Padding(20, 20, 10, 5);
            this.lblIgnoredCount.Name = "lblIgnoredCount";
            this.lblIgnoredCount.Size = new System.Drawing.Size(100, 15);
            this.lblIgnoredCount.TabIndex = 6;
            this.lblIgnoredCount.Text = "Ignore Count:";
            this.lblIgnoredCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIgnoreCountValue
            // 
            this.lblIgnoreCountValue.LinkColor = System.Drawing.Color.PaleTurquoise;
            this.lblIgnoreCountValue.Location = new System.Drawing.Point(227, 53);
            this.lblIgnoreCountValue.Margin = new System.Windows.Forms.Padding(10, 20, 20, 5);
            this.lblIgnoreCountValue.Name = "lblIgnoreCountValue";
            this.lblIgnoreCountValue.Size = new System.Drawing.Size(50, 13);
            this.lblIgnoreCountValue.TabIndex = 3;
            this.lblIgnoreCountValue.TabStop = true;
            this.lblIgnoreCountValue.Text = "1";
            this.lblIgnoreCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIgnoreCountValue.VisitedLinkColor = System.Drawing.Color.Violet;
            this.lblIgnoreCountValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIgnoreCountValue_LinkClicked);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 480);
            this.Controls.Add(this.groupResources);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupAPI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.groupAPI, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.groupResources, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.groupAPI.ResumeLayout(false);
            this.groupAPI.PerformLayout();
            this.groupResources.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion
        #region Event Methods
        #region Button Events
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            return;
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                API.Engine.SetAPIKey(this.txtAPIKey.Text);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error While Saving Key:\n{0}", ex.Message));
            }
            return;
        }
        #endregion
        #region Label Events
        private void lblAPIStepOneInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://developer.riotgames.com/sign-in");
        }
        private void lblAPIStepTwoInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://developer.riotgames.com/");
        }
        private void lblContentVersionValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (Directory.Exists(API.Resources.Resource.ContentDirectory))
                    Process.Start(API.Resources.Resource.ContentDirectory);
            }
            catch
            {
                // ignored
            }
            return;
        }
        private void lblIgnoreCountValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (File.Exists(API.Resources.Resource.IgnoreListFilePath))
                    Process.Start(API.Resources.Resource.IgnoreListFilePath);
            }
            catch
            {
                // ignored
            }
            return;
        }
        #endregion
        #region Model Events
        private void Model_DataUpdateFinished(object sender, object e)
        {
            try
            {
                this.txtAPIKey.Text = e as string;
                this.lblIgnoreCountValue.Text = API.Resources.Resource.IgnoreCount.ToString();
                this.lblContentVersionValue.Text = API.Resources.Resource.ContentVersion.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading API key\n{0}", ex.Message);
            }
            return;
        }
        private void Model_DataUpdateStarted()
        {
        }
        #endregion
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

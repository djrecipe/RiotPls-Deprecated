using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RiotPls.API.Builder;

namespace RiotPls.Controls
{
    public class BuySetCollectionView : UserControl
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Button btnAdd;
        #endregion
        private readonly List<BuySetView> buildFlows = new List<BuySetView>();
        #endregion
        #region Instance Properties   
        private Build _Build = null;
        public Build Build
        {
            get
            {
                return this._Build;
            }
            set
            {
                this._Build = value;
                this.ClearBuys();
                if (value != null)
                    this.AddNewBuy();
                return;
            }
        }
        #endregion
        public BuySetCollectionView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutMain.AutoScroll = true;
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMain.Size = new System.Drawing.Size(480, 210);
            this.layoutMain.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAdd.FlatAppearance.BorderSize = 5;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnAdd.Location = new System.Drawing.Point(20, 230);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(20, 10, 10, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 50);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "New Buy";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BuildFlowCollection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.layoutMain);
            this.Name = "BuildFlowCollection";
            this.Size = new System.Drawing.Size(480, 300);
            this.ResumeLayout(false);

        }

        private void AddNewBuy()
        {
            BuySet set = new BuySet()
            {
                Name = string.Format("Buy #{0}", this.buildFlows.Count + 1)
            };
            this.Build.Buys.Add(set);
            BuySetView flow = new BuySetView
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                Build = this.Build,
                BuySet = set,
                Dock = DockStyle.None,
                Height = 160,
                Margin = new Padding(10),
                Name = string.Format("buy{0}", this.buildFlows.Count + 1)
            };
            this.buildFlows.Add(flow);
            //
            this.layoutMain.Controls.Add(flow);
            //
            return;
        }

        private void ClearBuys()
        {
            this.buildFlows.Clear();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.AddNewBuy();
        }
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
    }
}

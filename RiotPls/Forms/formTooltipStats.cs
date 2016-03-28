using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiotPls.Controls;
using Champion = RiotPls.API.Serialization.Champions;

namespace RiotPls.Forms
{
    public class formTooltipStats : formTooltipTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private StatGrid gridMain;
        #endregion
        private Champion.ChampionInfo champChampionInfo = null;
        public event EventHandler<List<Point>> GridSelectionChanged = null;
        public event EventHandler<int> GridScrolled = null;
        private bool changing_selection = false;
        #endregion
        #region Instance Properties
        public int ScrollIndex
        {
            get
            {
                return this.gridMain.FirstDisplayedScrollingRowIndex;
            }
            set
            {
                this.gridMain.FirstDisplayedScrollingRowIndex = value;
                return;
            }
        }
        public List<Point> Selections
        {
            get
            {
                List<Point> list = new List<Point>();
                if (this.gridMain.SelectedCells.Count > 0)
                    list.AddRange(this.gridMain.SelectedCells.Cast<DataGridViewCell>().Select(cell => new Point(cell.RowIndex, cell.ColumnIndex)).OrderBy(pt => pt.X).ThenBy(pt => pt.Y));
                list.Add(new Point(this.gridMain.CurrentCell.RowIndex, this.gridMain.CurrentCell.ColumnIndex));
                return list;
            }
            set
            {
                this.changing_selection = true;
                this.gridMain.ClearSelection();
                this.gridMain.CurrentCell = value.Count > 0 ? this.gridMain.Rows[value[value.Count - 1].X].Cells[value[value.Count - 1].Y] : null;
                foreach (Point point in value.Where(p => p.X < this.gridMain.RowCount && p.Y < this.gridMain.ColumnCount))
                    this.gridMain.Rows[point.X].Cells[point.Y].Selected = true;
                this.changing_selection = false;
                return;
            }
        }
        #endregion
        #region Instance Methods
        public formTooltipStats()
        {
            this.InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridMain = new StatGrid();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Visible = false;
            // 
            // gridMain
            // 
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.DataMember = "Stats";
            this.gridMain.Location = new System.Drawing.Point(19, 54);
            this.gridMain.Margin = new System.Windows.Forms.Padding(10);
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(382, 117);
            this.gridMain.TabIndex = 6;
            this.gridMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridMain_Scroll);
            this.gridMain.SelectionChanged += new System.EventHandler(this.gridMain_SelectionChanged);
            // 
            // formTooltipStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.gridMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Name = "formTooltipStats";
            this.Activated += new System.EventHandler(this.formTooltipStats_Activated);
            this.Controls.SetChildIndex(this.btnSettings, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);

        }
        public void ShowTooltip(string title, string sub_title, Champion.ChampionInfo champion_info, IWin32Window owner = null)
        {
            this.changing_selection = true;
            base.ShowTooltip(title, sub_title, owner);
            this.champChampionInfo = champion_info;
            this.gridMain.DataSource = this.champChampionInfo.Stats.Table;
            this.changing_selection = false;
            return;
        }
        #endregion
        #region Event Methods
        private void formTooltipStats_Activated(object sender, EventArgs e)
        {
            this.gridMain.Focus();
            return;
        }
        private void gridMain_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.changing_selection && this.GridSelectionChanged != null)
                this.GridSelectionChanged(this, this.Selections);
            return;
        }
        private void gridMain_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.GridScrolled != null)
                this.GridScrolled(this, this.gridMain.FirstDisplayedScrollingRowIndex);
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
        protected override void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
            return;
        }
        #endregion

    }
}

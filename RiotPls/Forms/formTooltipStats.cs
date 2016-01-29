using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Champion = RiotPls.API.Serialization.Champion;

namespace RiotPls.Forms
{
    public class formTooltipStats : formTooltipTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private DataGridViewTextBoxColumn colMovementSpeed;
        private DataGridViewTextBoxColumn colAttackRange;
        private DataGridViewTextBoxColumn colAttackDamage;
        private DataGridViewTextBoxColumn colAttackSpeed;
        private DataGridViewTextBoxColumn colCriticalStrike;
        private DataGridViewTextBoxColumn colArmor;
        private DataGridViewTextBoxColumn colMagicResist;
        private DataGridViewTextBoxColumn colHealth;
        private DataGridViewTextBoxColumn colResource;
        #endregion
        private Champion.Info champ_info = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMain = new RiotPls.Grid();
            this.colMovementSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriticalStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicResist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            // 
            // gridMain
            // 
            this.gridMain.AllowUserToAddRows = false;
            this.gridMain.AllowUserToDeleteRows = false;
            this.gridMain.AllowUserToResizeColumns = false;
            this.gridMain.AllowUserToResizeRows = false;
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridMain.BackgroundColor = System.Drawing.Color.Black;
            this.gridMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMovementSpeed,
            this.colAttackRange,
            this.colAttackDamage,
            this.colAttackSpeed,
            this.colCriticalStrike,
            this.colArmor,
            this.colMagicResist,
            this.colHealth,
            this.colResource});
            this.gridMain.DataMember = "Stats";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(19, 54);
            this.gridMain.Margin = new System.Windows.Forms.Padding(10);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            this.gridMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowCellToolTips = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(382, 117);
            this.gridMain.TabIndex = 6;
            this.gridMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridMain_DataBindingComplete);
            this.gridMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridMain_Scroll);
            this.gridMain.SelectionChanged += new System.EventHandler(this.gridMain_SelectionChanged);
            // 
            // colMovementSpeed
            // 
            this.colMovementSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMovementSpeed.DataPropertyName = "MovementSpeed";
            dataGridViewCellStyle2.Format = "n0";
            this.colMovementSpeed.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMovementSpeed.HeaderText = "Spd";
            this.colMovementSpeed.Name = "colMovementSpeed";
            this.colMovementSpeed.ReadOnly = true;
            this.colMovementSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMovementSpeed.Width = 32;
            // 
            // colAttackRange
            // 
            this.colAttackRange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackRange.DataPropertyName = "AttackRange";
            dataGridViewCellStyle3.Format = "n0";
            this.colAttackRange.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAttackRange.HeaderText = "Rng";
            this.colAttackRange.Name = "colAttackRange";
            this.colAttackRange.ReadOnly = true;
            this.colAttackRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackRange.Width = 32;
            // 
            // colAttackDamage
            // 
            this.colAttackDamage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackDamage.DataPropertyName = "AttackDamage";
            dataGridViewCellStyle4.Format = "n1";
            this.colAttackDamage.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAttackDamage.HeaderText = "AD";
            this.colAttackDamage.Name = "colAttackDamage";
            this.colAttackDamage.ReadOnly = true;
            this.colAttackDamage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackDamage.Width = 26;
            // 
            // colAttackSpeed
            // 
            this.colAttackSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackSpeed.DataPropertyName = "AttackSpeed";
            dataGridViewCellStyle5.Format = "n1";
            this.colAttackSpeed.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAttackSpeed.HeaderText = "AS";
            this.colAttackSpeed.Name = "colAttackSpeed";
            this.colAttackSpeed.ReadOnly = true;
            this.colAttackSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackSpeed.Width = 26;
            // 
            // colCriticalStrike
            // 
            this.colCriticalStrike.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCriticalStrike.DataPropertyName = "CriticalStrike";
            dataGridViewCellStyle6.Format = "n1";
            this.colCriticalStrike.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCriticalStrike.HeaderText = "Crit";
            this.colCriticalStrike.Name = "colCriticalStrike";
            this.colCriticalStrike.ReadOnly = true;
            this.colCriticalStrike.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriticalStrike.Width = 31;
            // 
            // colArmor
            // 
            this.colArmor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colArmor.DataPropertyName = "Armor";
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.colArmor.DefaultCellStyle = dataGridViewCellStyle7;
            this.colArmor.HeaderText = "Armor";
            this.colArmor.Name = "colArmor";
            this.colArmor.ReadOnly = true;
            this.colArmor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArmor.Width = 47;
            // 
            // colMagicResist
            // 
            this.colMagicResist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMagicResist.DataPropertyName = "MagicResist";
            dataGridViewCellStyle8.Format = "n1";
            this.colMagicResist.DefaultCellStyle = dataGridViewCellStyle8;
            this.colMagicResist.HeaderText = "MR";
            this.colMagicResist.Name = "colMagicResist";
            this.colMagicResist.ReadOnly = true;
            this.colMagicResist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicResist.Width = 28;
            // 
            // colHealth
            // 
            this.colHealth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHealth.DataPropertyName = "Health";
            dataGridViewCellStyle9.Format = "n0";
            this.colHealth.DefaultCellStyle = dataGridViewCellStyle9;
            this.colHealth.HeaderText = "HP";
            this.colHealth.Name = "colHealth";
            this.colHealth.ReadOnly = true;
            this.colHealth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHealth.Width = 25;
            // 
            // colResource
            // 
            this.colResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colResource.DataPropertyName = "Resource";
            dataGridViewCellStyle10.Format = "n0";
            this.colResource.DefaultCellStyle = dataGridViewCellStyle10;
            this.colResource.HeaderText = "MP";
            this.colResource.Name = "colResource";
            this.colResource.ReadOnly = true;
            this.colResource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResource.Width = 28;
            // 
            // formTooltipStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildWindow = true;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.gridMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Name = "formTooltipStats";
            this.Activated += new System.EventHandler(this.formTooltipStats_Activated);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);

        }
        public void ShowTooltip(string title, string sub_title, Champion.Info info, IWin32Window owner = null)
        {
            this.changing_selection = true;
            base.ShowTooltip(title, sub_title, owner);
            this.champ_info = info;
            this.gridMain.DataSource = this.champ_info.Stats.Table;
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
        private void gridMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.gridMain.Rows[0].HeaderCell.Value = "1";
            this.gridMain.Rows[1].HeaderCell.Value = "Per";
            for (int i = 2; i <= 18; i++)
                this.gridMain.Rows[i].HeaderCell.Value = i.ToString();
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

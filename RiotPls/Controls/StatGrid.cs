using System;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.Tools;

namespace RiotPls.Controls
{
    public class StatGrid : UserControl
    {
        #region Types
        public delegate void SelectedRowChangedDelegate(int row);
        #endregion
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        #endregion                                 

        private DataGridViewTextBoxColumn colMovementSpeed;
        private DataGridViewTextBoxColumn colAttackRange;
        private DataGridViewTextBoxColumn colAttackDamage;
        private DataGridViewTextBoxColumn colAbilityPower;
        private DataGridViewTextBoxColumn colMagicPenFlat;
        private DataGridViewTextBoxColumn colMagicPenPerc;
        private DataGridViewTextBoxColumn colAttackSpeed;
        private DataGridViewTextBoxColumn colCriticalStrike;
        private DataGridViewTextBoxColumn colArmor;
        private DataGridViewTextBoxColumn colMagicResist;
        private DataGridViewTextBoxColumn colHealth;
        private DataGridViewTextBoxColumn colResource;

        public event SelectedRowChangedDelegate SelectedRowChanged;
        private bool ignoreRowChange = true;
        #endregion
        #region Instance Properties
        /// <summary>
        /// Data source which is bound to the table
        /// </summary>
        public StatsTable DataSource
        {
            get { return this.gridMain.DataSource as StatsTable; }
            set { this.gridMain.DataSource = value; }
        }

        /// <summary>
        /// Current number of rows in the table
        /// </summary>
        public int RowCount => this.gridMain.RowCount;

        #endregion
        #region Instance Methods
        public StatGrid()
        {
            InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMain = new RiotPls.Controls.Grid();
            this.colMovementSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbilityPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicPenFlat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicPenPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriticalStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicResist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.AllowUserToAddRows = false;
            this.gridMain.AllowUserToDeleteRows = false;
            this.gridMain.AllowUserToResizeColumns = false;
            this.gridMain.AllowUserToResizeRows = false;
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
            this.colAbilityPower,
            this.colMagicPenFlat,
            this.colMagicPenPerc,
            this.colAttackSpeed,
            this.colCriticalStrike,
            this.colArmor,
            this.colMagicResist,
            this.colHealth,
            this.colResource});
            this.gridMain.DataMember = "Stats";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle14.Format = "N3";
            dataGridViewCellStyle14.NullValue = null;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle14;
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.Margin = new System.Windows.Forms.Padding(23, 22, 22, 22);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            this.gridMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(150, 150);
            this.gridMain.TabIndex = 0;
            this.gridMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridMain_DataBindingComplete);
            this.gridMain.SelectionChanged += new System.EventHandler(this.gridMain_SelectionChanged);
            // 
            // colMovementSpeed
            // 
            this.colMovementSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMovementSpeed.DataPropertyName = "MovementSpeed";
            dataGridViewCellStyle2.Format = "n0";
            this.colMovementSpeed.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMovementSpeed.HeaderText = "Spd";
            this.colMovementSpeed.MinimumWidth = 35;
            this.colMovementSpeed.Name = "colMovementSpeed";
            this.colMovementSpeed.ReadOnly = true;
            this.colMovementSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMovementSpeed.Width = 70;
            // 
            // colAttackRange
            // 
            this.colAttackRange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAttackRange.DataPropertyName = "AttackRange";
            dataGridViewCellStyle3.Format = "n0";
            this.colAttackRange.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAttackRange.HeaderText = "Rng";
            this.colAttackRange.MinimumWidth = 35;
            this.colAttackRange.Name = "colAttackRange";
            this.colAttackRange.ReadOnly = true;
            this.colAttackRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackRange.Width = 70;
            // 
            // colAttackDamage
            // 
            this.colAttackDamage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAttackDamage.DataPropertyName = "AttackDamage";
            dataGridViewCellStyle4.Format = "n1";
            this.colAttackDamage.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAttackDamage.HeaderText = "AD";
            this.colAttackDamage.MinimumWidth = 35;
            this.colAttackDamage.Name = "colAttackDamage";
            this.colAttackDamage.ReadOnly = true;
            this.colAttackDamage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackDamage.Width = 70;
            // 
            // colAbilityPower
            // 
            this.colAbilityPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAbilityPower.DataPropertyName = "AbilityPower";
            dataGridViewCellStyle5.Format = "n1";
            this.colAbilityPower.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAbilityPower.HeaderText = "AP";
            this.colAbilityPower.MinimumWidth = 35;
            this.colAbilityPower.Name = "colAbilityPower";
            this.colAbilityPower.ReadOnly = true;
            this.colAbilityPower.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAbilityPower.Width = 70;
            // 
            // colMagicPenFlat
            // 
            this.colMagicPenFlat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicPenFlat.DataPropertyName = "MagicPenFlat";
            dataGridViewCellStyle6.Format = "n1";
            this.colMagicPenFlat.DefaultCellStyle = dataGridViewCellStyle6;
            this.colMagicPenFlat.HeaderText = "MPen (F)";
            this.colMagicPenFlat.MinimumWidth = 35;
            this.colMagicPenFlat.Name = "colMagicPenFlat";
            this.colMagicPenFlat.ReadOnly = true;
            this.colMagicPenFlat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicPenFlat.Width = 70;
            // 
            // colMagicPenPerc
            // 
            this.colMagicPenPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicPenPerc.DataPropertyName = "MagicPenPerc";
            dataGridViewCellStyle7.Format = "n1";
            this.colMagicPenPerc.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMagicPenPerc.HeaderText = "MPen (%)";
            this.colMagicPenPerc.MinimumWidth = 35;
            this.colMagicPenPerc.Name = "colMagicPenPerc";
            this.colMagicPenPerc.ReadOnly = true;
            this.colMagicPenPerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicPenPerc.Width = 70;
            // 
            // colAttackSpeed
            // 
            this.colAttackSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAttackSpeed.DataPropertyName = "AttackSpeed";
            dataGridViewCellStyle8.Format = "n1";
            this.colAttackSpeed.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAttackSpeed.HeaderText = "AS";
            this.colAttackSpeed.MinimumWidth = 35;
            this.colAttackSpeed.Name = "colAttackSpeed";
            this.colAttackSpeed.ReadOnly = true;
            this.colAttackSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackSpeed.Width = 70;
            // 
            // colCriticalStrike
            // 
            this.colCriticalStrike.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCriticalStrike.DataPropertyName = "CriticalStrike";
            dataGridViewCellStyle9.Format = "n1";
            this.colCriticalStrike.DefaultCellStyle = dataGridViewCellStyle9;
            this.colCriticalStrike.HeaderText = "Crit";
            this.colCriticalStrike.MinimumWidth = 35;
            this.colCriticalStrike.Name = "colCriticalStrike";
            this.colCriticalStrike.ReadOnly = true;
            this.colCriticalStrike.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriticalStrike.Width = 70;
            // 
            // colArmor
            // 
            this.colArmor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colArmor.DataPropertyName = "Armor";
            dataGridViewCellStyle10.Format = "N1";
            dataGridViewCellStyle10.NullValue = null;
            this.colArmor.DefaultCellStyle = dataGridViewCellStyle10;
            this.colArmor.HeaderText = "Armor";
            this.colArmor.MinimumWidth = 35;
            this.colArmor.Name = "colArmor";
            this.colArmor.ReadOnly = true;
            this.colArmor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArmor.Width = 70;
            // 
            // colMagicResist
            // 
            this.colMagicResist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicResist.DataPropertyName = "MagicResist";
            dataGridViewCellStyle11.Format = "n1";
            this.colMagicResist.DefaultCellStyle = dataGridViewCellStyle11;
            this.colMagicResist.HeaderText = "MR";
            this.colMagicResist.MinimumWidth = 35;
            this.colMagicResist.Name = "colMagicResist";
            this.colMagicResist.ReadOnly = true;
            this.colMagicResist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicResist.Width = 70;
            // 
            // colHealth
            // 
            this.colHealth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colHealth.DataPropertyName = "Health";
            dataGridViewCellStyle12.Format = "n0";
            this.colHealth.DefaultCellStyle = dataGridViewCellStyle12;
            this.colHealth.HeaderText = "HP";
            this.colHealth.MinimumWidth = 35;
            this.colHealth.Name = "colHealth";
            this.colHealth.ReadOnly = true;
            this.colHealth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHealth.Width = 70;
            // 
            // colResource
            // 
            this.colResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colResource.DataPropertyName = "Resource";
            dataGridViewCellStyle13.Format = "n0";
            this.colResource.DefaultCellStyle = dataGridViewCellStyle13;
            this.colResource.HeaderText = "MP";
            this.colResource.MinimumWidth = 35;
            this.colResource.Name = "colResource";
            this.colResource.ReadOnly = true;
            this.colResource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResource.Width = 70;
            // 
            // StatGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridMain);
            this.Name = "StatGrid";
            this.Load += new System.EventHandler(this.StatGrid_Load);
            this.SizeChanged += new System.EventHandler(this.StatGrid_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);

        }

        public void SetSelectedRow(int row)
        {
            this.ignoreRowChange = true;
            if (row >= 0 && row < this.gridMain.RowCount)
            {
                this.gridMain.Rows[row].Selected = true;
                this.gridMain.CurrentCell = this.gridMain.Rows[row].Cells[0];
            }
            this.ignoreRowChange = false;
            return;
        }
        private void ResizeColumns()
        {
            int width = (this.Width - this.gridMain.RowHeadersWidth - 55) / this.gridMain.ColumnCount;
            foreach (DataGridViewColumn column in this.gridMain.Columns)
                column.Width = width;
            return;
        }
        #endregion
        #region Event Methods
        private void StatGrid_SizeChanged(object sender, EventArgs e)
        {
            this.ResizeColumns();
            return;
        }
        private void StatGrid_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker) delegate { this.ResizeColumns(); });
            return;
        }
        private void gridMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.gridMain.RowCount < 1)
                return;
            this.gridMain.Rows[0].HeaderCell.Value = "1";
            this.gridMain.Rows[1].HeaderCell.Value = "Per";
            for (int i = 2; i <= 18; i++)
                this.gridMain.Rows[i].HeaderCell.Value = i.ToString();
            return;
        }
        private void gridMain_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.ignoreRowChange && this.SelectedRowChanged != null)
                this.SelectedRowChanged(this.gridMain.SelectedCells.Count > 0 ? this.gridMain.SelectedCells[0].RowIndex : 0);
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

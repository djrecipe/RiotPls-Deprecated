using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API;
using RiotPls.Tools;

namespace RiotPls.Controls
{
    /// <summary>
    /// Table of stats representing one or more Riot API entities
    /// </summary>
    public class StatGrid : UserControl
    {
        #region Types
        public delegate void SelectedRowChangedDelegate(int row);
        #endregion
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private ContextMenuStrip cmenMain;
        private ToolStripMenuItem mnuitmShowHideColumns;
        private DataGridViewTextBoxColumn colMovementSpeed;
        private DataGridViewTextBoxColumn colAttackRange;
        private DataGridViewTextBoxColumn colAttackDamage;
        private DataGridViewTextBoxColumn colAttackSpeed;
        private DataGridViewTextBoxColumn colCriticalStrike;
        private DataGridViewTextBoxColumn colArmorPenFlat;
        private DataGridViewTextBoxColumn colArmorPenPerc;
        private DataGridViewTextBoxColumn colAbilityPower;
        private DataGridViewTextBoxColumn colMagicPenFlat;
        private DataGridViewTextBoxColumn colMagicPenPerc;
        private DataGridViewTextBoxColumn colCooldownReduction;
        private DataGridViewTextBoxColumn colArmor;
        private DataGridViewTextBoxColumn colMagicResist;
        private DataGridViewTextBoxColumn colHealth;
        private DataGridViewTextBoxColumn colResource;
        private DataGridViewTextBoxColumn colTenacity;
        #endregion

        /// <summary>
        /// Currently selected row has changed
        /// </summary>
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
            this.InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
            this.InitializeColumnVisibility();
            return;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmenMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuitmShowHideColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMain = new RiotPls.Controls.Grid();
            this.colMovementSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriticalStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmorPenFlat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmorPenPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbilityPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicPenFlat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicPenPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCooldownReduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicResist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // cmenMain
            // 
            this.cmenMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuitmShowHideColumns});
            this.cmenMain.Name = "cmenMain";
            this.cmenMain.Size = new System.Drawing.Size(185, 26);
            this.cmenMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmenMain_Opening);
            // 
            // mnuitmShowHideColumns
            // 
            this.mnuitmShowHideColumns.Name = "mnuitmShowHideColumns";
            this.mnuitmShowHideColumns.Size = new System.Drawing.Size(184, 22);
            this.mnuitmShowHideColumns.Text = "Show/Hide Columns";
            this.mnuitmShowHideColumns.DropDownOpening += new System.EventHandler(this.mnuitmShowHideColumns_DropDownOpening);
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
            this.colAttackSpeed,
            this.colCriticalStrike,
            this.colArmorPenFlat,
            this.colArmorPenPerc,
            this.colAbilityPower,
            this.colMagicPenFlat,
            this.colMagicPenPerc,
            this.colCooldownReduction,
            this.colArmor,
            this.colMagicResist,
            this.colHealth,
            this.colResource,
            this.colTenacity});
            this.gridMain.ContextMenuStrip = this.cmenMain;
            this.gridMain.DataMember = "Stats";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle18.Format = "N3";
            dataGridViewCellStyle18.NullValue = null;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle18;
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.Margin = new System.Windows.Forms.Padding(23, 22, 22, 22);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            this.gridMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.gridMain.RowHeadersWidth = 50;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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
            this.colMovementSpeed.HeaderText = "Speed";
            this.colMovementSpeed.MinimumWidth = 45;
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
            this.colAttackRange.HeaderText = "Range";
            this.colAttackRange.MinimumWidth = 45;
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
            this.colAttackDamage.HeaderText = "Attack Damage";
            this.colAttackDamage.MinimumWidth = 50;
            this.colAttackDamage.Name = "colAttackDamage";
            this.colAttackDamage.ReadOnly = true;
            this.colAttackDamage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackDamage.Width = 70;
            // 
            // colAttackSpeed
            // 
            this.colAttackSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAttackSpeed.DataPropertyName = "AttackSpeed";
            dataGridViewCellStyle5.Format = "n1";
            this.colAttackSpeed.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAttackSpeed.HeaderText = "Attack Speed";
            this.colAttackSpeed.MinimumWidth = 45;
            this.colAttackSpeed.Name = "colAttackSpeed";
            this.colAttackSpeed.ReadOnly = true;
            this.colAttackSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAttackSpeed.Width = 70;
            // 
            // colCriticalStrike
            // 
            this.colCriticalStrike.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCriticalStrike.DataPropertyName = "CriticalStrike";
            dataGridViewCellStyle6.Format = "n1";
            this.colCriticalStrike.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCriticalStrike.HeaderText = "Crit Chance";
            this.colCriticalStrike.MinimumWidth = 45;
            this.colCriticalStrike.Name = "colCriticalStrike";
            this.colCriticalStrike.ReadOnly = true;
            this.colCriticalStrike.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriticalStrike.Width = 70;
            // 
            // colArmorPenFlat
            // 
            this.colArmorPenFlat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colArmorPenFlat.DataPropertyName = "ArmorPenFlat";
            dataGridViewCellStyle7.Format = "n1";
            this.colArmorPenFlat.DefaultCellStyle = dataGridViewCellStyle7;
            this.colArmorPenFlat.HeaderText = "Armor Pen (F)";
            this.colArmorPenFlat.MinimumWidth = 45;
            this.colArmorPenFlat.Name = "colArmorPenFlat";
            this.colArmorPenFlat.ReadOnly = true;
            this.colArmorPenFlat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArmorPenFlat.Width = 70;
            // 
            // colArmorPenPerc
            // 
            this.colArmorPenPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colArmorPenPerc.DataPropertyName = "ArmorPenPerc";
            dataGridViewCellStyle8.Format = "n1";
            this.colArmorPenPerc.DefaultCellStyle = dataGridViewCellStyle8;
            this.colArmorPenPerc.HeaderText = "Armor Pen (%)";
            this.colArmorPenPerc.MinimumWidth = 45;
            this.colArmorPenPerc.Name = "colArmorPenPerc";
            this.colArmorPenPerc.ReadOnly = true;
            this.colArmorPenPerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArmorPenPerc.Width = 70;
            // 
            // colAbilityPower
            // 
            this.colAbilityPower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAbilityPower.DataPropertyName = "AbilityPower";
            dataGridViewCellStyle9.Format = "n1";
            this.colAbilityPower.DefaultCellStyle = dataGridViewCellStyle9;
            this.colAbilityPower.HeaderText = "Ability Power";
            this.colAbilityPower.MinimumWidth = 45;
            this.colAbilityPower.Name = "colAbilityPower";
            this.colAbilityPower.ReadOnly = true;
            this.colAbilityPower.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAbilityPower.Width = 70;
            // 
            // colMagicPenFlat
            // 
            this.colMagicPenFlat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicPenFlat.DataPropertyName = "MagicPenFlat";
            dataGridViewCellStyle10.Format = "n1";
            this.colMagicPenFlat.DefaultCellStyle = dataGridViewCellStyle10;
            this.colMagicPenFlat.HeaderText = "Magic Pen (F)";
            this.colMagicPenFlat.MinimumWidth = 45;
            this.colMagicPenFlat.Name = "colMagicPenFlat";
            this.colMagicPenFlat.ReadOnly = true;
            this.colMagicPenFlat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicPenFlat.Width = 70;
            // 
            // colMagicPenPerc
            // 
            this.colMagicPenPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicPenPerc.DataPropertyName = "MagicPenPerc";
            dataGridViewCellStyle11.Format = "n1";
            this.colMagicPenPerc.DefaultCellStyle = dataGridViewCellStyle11;
            this.colMagicPenPerc.HeaderText = "Magic Pen (%)";
            this.colMagicPenPerc.MinimumWidth = 45;
            this.colMagicPenPerc.Name = "colMagicPenPerc";
            this.colMagicPenPerc.ReadOnly = true;
            this.colMagicPenPerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicPenPerc.Width = 70;
            // 
            // colCooldownReduction
            // 
            this.colCooldownReduction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCooldownReduction.DataPropertyName = "CooldownReduction";
            dataGridViewCellStyle12.Format = "n1";
            this.colCooldownReduction.DefaultCellStyle = dataGridViewCellStyle12;
            this.colCooldownReduction.HeaderText = "CDR";
            this.colCooldownReduction.MinimumWidth = 45;
            this.colCooldownReduction.Name = "colCooldownReduction";
            this.colCooldownReduction.ReadOnly = true;
            this.colCooldownReduction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCooldownReduction.Width = 70;
            // 
            // colArmor
            // 
            this.colArmor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colArmor.DataPropertyName = "Armor";
            dataGridViewCellStyle13.Format = "N1";
            dataGridViewCellStyle13.NullValue = null;
            this.colArmor.DefaultCellStyle = dataGridViewCellStyle13;
            this.colArmor.HeaderText = "Armor";
            this.colArmor.MinimumWidth = 45;
            this.colArmor.Name = "colArmor";
            this.colArmor.ReadOnly = true;
            this.colArmor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArmor.Width = 70;
            // 
            // colMagicResist
            // 
            this.colMagicResist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagicResist.DataPropertyName = "MagicResist";
            dataGridViewCellStyle14.Format = "n1";
            this.colMagicResist.DefaultCellStyle = dataGridViewCellStyle14;
            this.colMagicResist.HeaderText = "Magic Resist";
            this.colMagicResist.MinimumWidth = 45;
            this.colMagicResist.Name = "colMagicResist";
            this.colMagicResist.ReadOnly = true;
            this.colMagicResist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMagicResist.Width = 70;
            // 
            // colHealth
            // 
            this.colHealth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colHealth.DataPropertyName = "Health";
            dataGridViewCellStyle15.Format = "n0";
            this.colHealth.DefaultCellStyle = dataGridViewCellStyle15;
            this.colHealth.HeaderText = "Health";
            this.colHealth.MinimumWidth = 45;
            this.colHealth.Name = "colHealth";
            this.colHealth.ReadOnly = true;
            this.colHealth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHealth.Width = 70;
            // 
            // colResource
            // 
            this.colResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colResource.DataPropertyName = "Resource";
            dataGridViewCellStyle16.Format = "n0";
            this.colResource.DefaultCellStyle = dataGridViewCellStyle16;
            this.colResource.HeaderText = "Mana";
            this.colResource.MinimumWidth = 45;
            this.colResource.Name = "colResource";
            this.colResource.ReadOnly = true;
            this.colResource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResource.Width = 70;
            // 
            // colTenacity
            // 
            this.colTenacity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTenacity.DataPropertyName = "Tenacity";
            dataGridViewCellStyle17.Format = "n0";
            this.colTenacity.DefaultCellStyle = dataGridViewCellStyle17;
            this.colTenacity.HeaderText = "Tenacity";
            this.colTenacity.MinimumWidth = 50;
            this.colTenacity.Name = "colTenacity";
            this.colTenacity.ReadOnly = true;
            this.colTenacity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTenacity.Width = 70;
            // 
            // StatGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridMain);
            this.Name = "StatGrid";
            this.Load += new System.EventHandler(this.StatGrid_Load);
            this.SizeChanged += new System.EventHandler(this.StatGrid_SizeChanged);
            this.cmenMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);

        }
        private void InitializeColumnVisibility()
        {
            foreach (DataGridViewColumn column in this.gridMain.Columns)
                GeneralSettings.LoadStatColumnVisibility(column);
            this.InitializeContextMenu();
            return;
        }
        private void InitializeContextMenu()
        {
            foreach (DataGridViewColumn column in this.gridMain.Columns)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(column.HeaderText);
                item.Click += this.mnuitmColumnVisible_Click;
                this.mnuitmShowHideColumns.DropDownItems.Add(item);
            }
            return;
        }

        /// <summary>
        /// Set the currently selected row in the table
        /// </summary>
        /// <param name="row">Row index to select</param>
        public void SetSelectedRow(int row)
        {
            this.ignoreRowChange = true;
            if (row >= 0 && row < this.gridMain.RowCount)
            {
                this.gridMain.Rows[row].Selected = true;
                int first_visible = this.gridMain.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible)?.Index ?? 0;
                this.gridMain.CurrentCell = this.gridMain.Rows[row].Cells[first_visible];
            }
            this.ignoreRowChange = false;
            return;
        }
        private void ResizeColumns()
        {
            List<DataGridViewColumn> columns = this.gridMain.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
            int width = (this.Width - this.gridMain.RowHeadersWidth - 60) / columns.Count;
            foreach (DataGridViewColumn column in columns)
                column.Width = width;
            return;
        }
        #endregion
        #region Event Methods   
        #region Context Menu Events
        private void cmenMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void mnuitmColumnVisible_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            DataGridViewColumn column = this.gridMain.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == item.Text);
            if (column == null)
                return;
            item.Checked = !item.Checked;
            column.Visible = item.Checked;
            GeneralSettings.SaveStatColumnVisibility(column);
            this.ResizeColumns();
            return;
        }
        private void mnuitmShowHideColumns_DropDownOpening(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in this.gridMain.Columns)
            {
                ToolStripMenuItem item = this.mnuitmShowHideColumns.DropDownItems.Cast<ToolStripMenuItem>()
                        .FirstOrDefault(t => t.Text == column.HeaderText);
                if(item != null)
                    item.Checked = column.Visible;
            }
            return;
        }
        #endregion
        #region Grid Events   
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
            return;
        }
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

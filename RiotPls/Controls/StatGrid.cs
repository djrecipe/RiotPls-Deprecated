using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPls.Controls
{
    public class StatGrid : Grid
    {
        private DataGridViewTextBoxColumn colMovementSpeed;
        private DataGridViewTextBoxColumn colAttackRange;
        private DataGridViewTextBoxColumn colAttackDamage;
        private DataGridViewTextBoxColumn colAttackSpeed;
        private DataGridViewTextBoxColumn colCriticalStrike;
        private DataGridViewTextBoxColumn colArmor;
        private DataGridViewTextBoxColumn colMagicResist;
        private DataGridViewTextBoxColumn colHealth;
        private DataGridViewTextBoxColumn colResource;
        public StatGrid()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.colMovementSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttackSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriticalStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArmor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagicResist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // colMovementSpeed
            // 
            this.colMovementSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMovementSpeed.DataPropertyName = "MovementSpeed";
            dataGridViewCellStyle1.Format = "n0";
            this.colMovementSpeed.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMovementSpeed.HeaderText = "Spd";
            this.colMovementSpeed.Name = "colMovementSpeed";
            this.colMovementSpeed.ReadOnly = true;
            this.colMovementSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttackRange
            // 
            this.colAttackRange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackRange.DataPropertyName = "AttackRange";
            dataGridViewCellStyle2.Format = "n0";
            this.colAttackRange.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAttackRange.HeaderText = "Rng";
            this.colAttackRange.Name = "colAttackRange";
            this.colAttackRange.ReadOnly = true;
            this.colAttackRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttackDamage
            // 
            this.colAttackDamage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackDamage.DataPropertyName = "AttackDamage";
            dataGridViewCellStyle3.Format = "n1";
            this.colAttackDamage.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAttackDamage.HeaderText = "AD";
            this.colAttackDamage.Name = "colAttackDamage";
            this.colAttackDamage.ReadOnly = true;
            this.colAttackDamage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttackSpeed
            // 
            this.colAttackSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttackSpeed.DataPropertyName = "AttackSpeed";
            dataGridViewCellStyle4.Format = "n1";
            this.colAttackSpeed.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAttackSpeed.HeaderText = "AS";
            this.colAttackSpeed.Name = "colAttackSpeed";
            this.colAttackSpeed.ReadOnly = true;
            this.colAttackSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCriticalStrike
            // 
            this.colCriticalStrike.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCriticalStrike.DataPropertyName = "CriticalStrike";
            dataGridViewCellStyle5.Format = "n1";
            this.colCriticalStrike.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCriticalStrike.HeaderText = "Crit";
            this.colCriticalStrike.Name = "colCriticalStrike";
            this.colCriticalStrike.ReadOnly = true;
            this.colCriticalStrike.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colArmor
            // 
            this.colArmor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colArmor.DataPropertyName = "Armor";
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.colArmor.DefaultCellStyle = dataGridViewCellStyle6;
            this.colArmor.HeaderText = "Armor";
            this.colArmor.Name = "colArmor";
            this.colArmor.ReadOnly = true;
            this.colArmor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMagicResist
            // 
            this.colMagicResist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMagicResist.DataPropertyName = "MagicResist";
            dataGridViewCellStyle7.Format = "n1";
            this.colMagicResist.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMagicResist.HeaderText = "MR";
            this.colMagicResist.Name = "colMagicResist";
            this.colMagicResist.ReadOnly = true;
            this.colMagicResist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colHealth
            // 
            this.colHealth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHealth.DataPropertyName = "Health";
            dataGridViewCellStyle8.Format = "n0";
            this.colHealth.DefaultCellStyle = dataGridViewCellStyle8;
            this.colHealth.HeaderText = "HP";
            this.colHealth.Name = "colHealth";
            this.colHealth.ReadOnly = true;
            this.colHealth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colResource
            // 
            this.colResource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colResource.DataPropertyName = "Resource";
            dataGridViewCellStyle9.Format = "n0";
            this.colResource.DefaultCellStyle = dataGridViewCellStyle9;
            this.colResource.HeaderText = "MP";
            this.colResource.Name = "colResource";
            this.colResource.ReadOnly = true;
            this.colResource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StatGrid
            // 
            this.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMovementSpeed,
            this.colAttackRange,
            this.colAttackDamage,
            this.colAttackSpeed,
            this.colCriticalStrike,
            this.colArmor,
            this.colMagicResist,
            this.colHealth,
            this.colResource});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle11;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ShowCellToolTips = false;
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.StatGrid_DataBindingComplete);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void StatGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.Rows[0].HeaderCell.Value = "1";
            this.Rows[1].HeaderCell.Value = "Per";
            for (int i = 2; i <= 18; i++)
                this.Rows[i].HeaderCell.Value = i.ToString();
            return;
        }
    }
}

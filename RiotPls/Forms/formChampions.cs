using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

using RiotPls.API;
using Champion = RiotPls.API.Serialization.Champion;

namespace RiotPls.Forms
{
    public class formChampions : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private formTooltip fTooltip = new formTooltip();
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox comboFilter;
        private ContextMenuStrip cmenMain;
        private ToolStripMenuItem itmShowStats;
        #endregion
        private string last_champ_name = null;
        private Dictionary<string, API.Serialization.Champion.Info> champions = new Dictionary<string, Champion.Info>();
        private BindingList<Champion.Info> source = null;
        private Point last_location = Point.Empty;
        private ToolStripMenuItem itmLockTooltip;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewCheckBoxColumn colFreeToPlay;
        private DataGridViewTextBoxColumn colTags;
        private DataGridViewImageColumn colAttack;
        private DataGridViewImageColumn colDefense;
        private DataGridViewImageColumn colMagic;
        private DataGridViewImageColumn colDifficulty;
        private DataGridViewImageColumn colPassive;
        private DataGridViewImageColumn colQ;
        private DataGridViewImageColumn colW;
        private DataGridViewImageColumn colE;
        private DataGridViewImageColumn colR;
        private Dictionary<string, formTooltipStats> stat_windows = new Dictionary<string, formTooltipStats>();
        #endregion
        #region Static Properties
        #endregion
        #region Instance Methods
        public formChampions()
        {
            this.InitializeComponent();
            this.LoadRegistrySettings();
            this.gridMain.AutoGenerateColumns = false;
            return;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChampions));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridMain = new RiotPls.Grid();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreeToPlay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttack = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDefense = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMagic = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDifficulty = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPassive = new System.Windows.Forms.DataGridViewImageColumn();
            this.colQ = new System.Windows.Forms.DataGridViewImageColumn();
            this.colW = new System.Windows.Forms.DataGridViewImageColumn();
            this.colE = new System.Windows.Forms.DataGridViewImageColumn();
            this.colR = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmenMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmShowStats = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLockTooltip = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.cmenMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(1166, 9);
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
            this.colImage,
            this.colName,
            this.colTitle,
            this.colFreeToPlay,
            this.colTags,
            this.colAttack,
            this.colDefense,
            this.colMagic,
            this.colDifficulty,
            this.colPassive,
            this.colQ,
            this.colW,
            this.colE,
            this.colR});
            this.gridMain.ContextMenuStrip = this.cmenMain;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle32;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(34, 53);
            this.gridMain.Margin = new System.Windows.Forms.Padding(23, 22, 23, 22);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(1127, 703);
            this.gridMain.TabIndex = 0;
            this.gridMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMain_CellMouseDown);
            this.gridMain.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellMouseEnter);
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImage.DataPropertyName = "Image";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle11.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle11.NullValue")));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            this.colImage.DefaultCellStyle = dataGridViewCellStyle11;
            this.colImage.HeaderText = "Image";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImage.Width = 45;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(5);
            this.colName.DefaultCellStyle = dataGridViewCellStyle12;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colName.Width = 61;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.DataPropertyName = "Title";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTitle.DefaultCellStyle = dataGridViewCellStyle25;
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colFreeToPlay
            // 
            this.colFreeToPlay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFreeToPlay.DataPropertyName = "FreeToPlay";
            this.colFreeToPlay.HeaderText = "Free";
            this.colFreeToPlay.Name = "colFreeToPlay";
            this.colFreeToPlay.ReadOnly = true;
            this.colFreeToPlay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFreeToPlay.Width = 36;
            // 
            // colTags
            // 
            this.colTags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTags.DataPropertyName = "TagList";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTags.DefaultCellStyle = dataGridViewCellStyle26;
            this.colTags.HeaderText = "Tags";
            this.colTags.Name = "colTags";
            this.colTags.ReadOnly = true;
            this.colTags.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAttack
            // 
            this.colAttack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAttack.DataPropertyName = "AttackBitmap";
            this.colAttack.HeaderText = "Attack";
            this.colAttack.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colAttack.Name = "colAttack";
            this.colAttack.ReadOnly = true;
            this.colAttack.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAttack.Width = 60;
            // 
            // colDefense
            // 
            this.colDefense.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDefense.DataPropertyName = "DefenseBitmap";
            this.colDefense.HeaderText = "Defense";
            this.colDefense.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colDefense.Name = "colDefense";
            this.colDefense.ReadOnly = true;
            this.colDefense.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDefense.Width = 60;
            // 
            // colMagic
            // 
            this.colMagic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMagic.DataPropertyName = "MagicBitmap";
            this.colMagic.HeaderText = "Magic";
            this.colMagic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colMagic.Name = "colMagic";
            this.colMagic.ReadOnly = true;
            this.colMagic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMagic.Width = 60;
            // 
            // colDifficulty
            // 
            this.colDifficulty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDifficulty.DataPropertyName = "DifficultyBitmap";
            this.colDifficulty.HeaderText = "Difficulty";
            this.colDifficulty.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colDifficulty.Name = "colDifficulty";
            this.colDifficulty.ReadOnly = true;
            this.colDifficulty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDifficulty.Width = 60;
            // 
            // colPassive
            // 
            this.colPassive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPassive.DataPropertyName = "PassiveImage";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.NullValue = null;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(5);
            this.colPassive.DefaultCellStyle = dataGridViewCellStyle27;
            this.colPassive.HeaderText = "Passive";
            this.colPassive.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colPassive.Name = "colPassive";
            this.colPassive.ReadOnly = true;
            this.colPassive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPassive.Width = 54;
            // 
            // colQ
            // 
            this.colQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colQ.DataPropertyName = "SpellImageQ";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.NullValue = null;
            dataGridViewCellStyle28.Padding = new System.Windows.Forms.Padding(5);
            this.colQ.DefaultCellStyle = dataGridViewCellStyle28;
            this.colQ.HeaderText = "Q";
            this.colQ.Name = "colQ";
            this.colQ.ReadOnly = true;
            this.colQ.Width = 19;
            // 
            // colW
            // 
            this.colW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colW.DataPropertyName = "SpellImageW";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.NullValue = null;
            dataGridViewCellStyle29.Padding = new System.Windows.Forms.Padding(5);
            this.colW.DefaultCellStyle = dataGridViewCellStyle29;
            this.colW.HeaderText = "W";
            this.colW.Name = "colW";
            this.colW.ReadOnly = true;
            this.colW.Width = 21;
            // 
            // colE
            // 
            this.colE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colE.DataPropertyName = "SpellImageE";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.NullValue = null;
            dataGridViewCellStyle30.Padding = new System.Windows.Forms.Padding(5);
            this.colE.DefaultCellStyle = dataGridViewCellStyle30;
            this.colE.HeaderText = "E";
            this.colE.Name = "colE";
            this.colE.ReadOnly = true;
            this.colE.Width = 17;
            // 
            // colR
            // 
            this.colR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colR.DataPropertyName = "SpellImageR";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.NullValue = null;
            dataGridViewCellStyle31.Padding = new System.Windows.Forms.Padding(5);
            this.colR.DefaultCellStyle = dataGridViewCellStyle31;
            this.colR.HeaderText = "R";
            this.colR.Name = "colR";
            this.colR.ReadOnly = true;
            this.colR.Width = 18;
            // 
            // cmenMain
            // 
            this.cmenMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmShowStats,
            this.itmLockTooltip});
            this.cmenMain.Name = "cmenMain";
            this.cmenMain.Size = new System.Drawing.Size(167, 48);
            this.cmenMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmenMain_Opening);
            // 
            // itmShowStats
            // 
            this.itmShowStats.CheckOnClick = true;
            this.itmShowStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmShowStats.Name = "itmShowStats";
            this.itmShowStats.Size = new System.Drawing.Size(166, 22);
            this.itmShowStats.Text = "Show Stats";
            this.itmShowStats.CheckedChanged += new System.EventHandler(this.itmShowStats_CheckedChanged);
            // 
            // itmLockTooltip
            // 
            this.itmLockTooltip.CheckOnClick = true;
            this.itmLockTooltip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmLockTooltip.Name = "itmLockTooltip";
            this.itmLockTooltip.Size = new System.Drawing.Size(166, 22);
            this.itmLockTooltip.Text = "Lock Tooltip Data";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.txtSearch.Location = new System.Drawing.Point(84, 788);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(314, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Location = new System.Drawing.Point(19, 788);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 20);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Filter:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboFilter
            // 
            this.comboFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(421, 788);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(158, 22);
            this.comboFilter.TabIndex = 5;
            this.comboFilter.SelectionChangeCommitted += new System.EventHandler(this.comboFilter_SelectionChangeCommitted);
            // 
            // formChampions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1195, 827);
            this.ControlBox = false;
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gridMain);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.KeyPreview = true;
            this.Name = "formChampions";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Champions";
            this.Activated += new System.EventHandler(this.formChampions_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formChampions_FormClosing);
            this.Load += new System.EventHandler(this.formChampions_Load);
            this.LocationChanged += new System.EventHandler(this.formChampions_LocationChanged);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.comboFilter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.cmenMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadRegistrySettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software/RiotPls");
            if (key != null)
            {
                int? x = (int?)key.GetValue("X");
                int? y = (int?)key.GetValue("Y");
                key.Close();
                if (x.HasValue && y.HasValue)
                    this.Location = new Point(x.Value, y.Value);
            }
            return;
        }
        private void SaveRegistrySettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software/RiotPls");
            if (key != null)
            {
                key.SetValue("X", this.Left);
                key.SetValue("Y", this.Top);
                key.Close();
            }
            return;
        }
        private void ShowTooltip(int row_index, int column_index)
        {
            if (this.champions == null || row_index < 0 || column_index < 0 || row_index >= this.gridMain.RowCount || column_index >= this.gridMain.ColumnCount || (this.fTooltip.Visible && this.itmLockTooltip.Checked))
                return;
            string champion_name = this.gridMain.Rows[row_index].Cells["colName"].Value.ToString();
            this.last_champ_name = Engine.CleanseChampionName(this.champions, champion_name);
            Champion.Info info = this.champions[this.last_champ_name];
            string column_name = this.gridMain.Columns[column_index].HeaderText;
            string value_out = "???";
            string subtitle_out = column_name;
            switch (column_name)
            {

                case "Attack":
                    value_out = info.RatingInfo.Attack.ToString() + " / 10";
                    break;
                case "Defense":
                    value_out = info.RatingInfo.Defense.ToString() + " / 10";
                    break;
                case "Difficulty":
                    value_out = info.RatingInfo.Difficulty.ToString() + " / 10";
                    break;
                case "Magic":
                    value_out = info.RatingInfo.Magic.ToString() + " / 10";
                    break;
                case "Passive":
                    value_out = "     " + info.PassiveDescription;  
                    subtitle_out = info.PassiveName + " (Passive)";
                    break;
                //
                case "Q":
                    value_out = "     " + info.SpellDescriptionQ;
                    subtitle_out = info.SpellNameQ + " (Q)";
                    break;
                case "W":
                    value_out = "     " + info.SpellDescriptionW; 
                    subtitle_out = info.SpellNameW + " (W)";
                    break;
                case "E":
                    value_out = "     " + info.SpellDescriptionE;
                    subtitle_out = info.SpellNameE + " (E)";
                    break;
                case "R":
                    value_out = "     " + info.SpellDescriptionR;
                    subtitle_out = info.SpellNameR + " (R)";
                    break;
                //
                case "Image":
                    value_out = info.SkinList;
                    subtitle_out = "Skins";
                    break;
                case "Free":
                    value_out = info.FreeToPlay.ToString();
                    subtitle_out = "Free to Play?";
                    break;
                case "Name":
                    value_out = info.LoreSummary;
                    subtitle_out = "Lore Summary";
                    break;
                case "Tags":
                    value_out = info.TagList;
                    break;
                case "Title":
                    value_out = info.LoreSummary;
                    subtitle_out = "Lore Summary";
                    break;
            }
            this.fTooltip.ShowTooltip(info.Name, subtitle_out, value_out, this);
        }
        private void UpdateFilter()
        {
            if (this.champions == null || this.workerUpdateData.IsBusy)
                return;
            if (this.comboFilter.SelectedItem == null || this.txtSearch.TextLength < 1)
                this.gridMain.DataSource = this.source;
            else
            {
                switch (this.comboFilter.SelectedItem.ToString())
                {
                    case "Free":
                        if (this.txtSearch.Text == "Any")
                            this.gridMain.DataSource = this.source;
                        else
                        {
                            bool free_to_play = this.txtSearch.Text == "Free";
                            this.gridMain.DataSource = new BindingList<Champion.Info>(this.source.Where(info =>
                                info.FreeToPlay == free_to_play).ToList<Champion.Info>());
                        }
                        break;
                    case "Name":
                        this.gridMain.DataSource = new BindingList<Champion.Info>(this.source.Where(info =>
                            info.Name.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<Champion.Info>());
                        break;
                    case "Tags":
                        this.gridMain.DataSource = new BindingList<Champion.Info>(this.source.Where(info =>
                            info.TagList.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<Champion.Info>());
                        break;
                    case "Title":
                        this.gridMain.DataSource = new BindingList<Champion.Info>(this.source.Where(info =>
                            info.Title.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<Champion.Info>());
                        break;
                }
            }
            return;
        }
        #endregion
        #region Event Methods
        private void cmenMain_Opening(object sender, CancelEventArgs e)
        {
            if (this.last_champ_name == null)
                e.Cancel = true;
            else
                this.itmShowStats.Checked = this.stat_windows.ContainsKey(this.last_champ_name);
            return;
        }
        private void comboFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.comboFilter.SelectedItem != null && this.comboFilter.SelectedItem.ToString() == "Free")
            {
                this.txtSearch.ReadOnly = true;
                this.txtSearch.Cursor = Cursors.Hand;
                bool value = false;
                if (this.txtSearch.TextLength < 1 || (!bool.TryParse(this.txtSearch.Text, out value) && this.txtSearch.Text != "Any"))
                    this.txtSearch.Text = "Any";
            }
            else
            {
                this.txtSearch.Clear();
                this.txtSearch.ReadOnly = false;
                this.txtSearch.Cursor = Cursors.IBeam;
            }
            this.UpdateFilter();
            return;
        }
        private void formChampions_Activated(object sender, EventArgs e)
        {
            this.gridMain.Focus();
            return;
        }
        private void formChampions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveRegistrySettings();
            return;
        }
        private void formChampions_Load(object sender, EventArgs e)
        {
            this.UpdateData();
            return;
        }
        private void formChampions_LocationChanged(object sender, EventArgs e)
        {
            if (this.last_location != Point.Empty)
            {
                this.fTooltip.Location = new Point(this.fTooltip.Left + (this.Left - this.last_location.X), this.fTooltip.Top + (this.Top - this.last_location.Y));
                foreach (formTooltipStats form in this.stat_windows.Values)
                    form.Location = new Point(form.Left + (this.Left - this.last_location.X), form.Top + (this.Top - this.last_location.Y)); 
            }
            this.last_location = this.Location;
            return;
        }
        private void fStats_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTooltipStats old_window = sender as formTooltipStats;
            if (old_window != null && this.stat_windows.ContainsValue(old_window))
                this.stat_windows.Remove(this.stat_windows.FirstOrDefault(item => item.Value == old_window).Key);
            return;
        }
        private void fStats_GridScrolled(object sender, int e)
        {
            foreach (formTooltipStats form in this.stat_windows.Values.Where(f => f.ScrollIndex != e))
                form.ScrollIndex = e;
            return;
        }
        private void fStats_GridSelectionChanged(object sender, List<Point> e)
        {
            foreach (formTooltipStats form in this.stat_windows.Values.Where(f => f.Selections != e))
                form.Selections = e;
            return;
        }
        private void gridMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.champions == null)
                return;
            Bitmap bitmap = this.champions[this.gridMain.Rows[e.RowIndex].Cells["colName"].Value.ToString()].Image;
            if (bitmap != null)
            {
                this.BeginInvoke((MethodInvoker) delegate
                { this.gridMain.DoDragDrop(bitmap, DragDropEffects.Copy); });
            }
            return;                                                          
        }
        private void gridMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ShowTooltip(e.RowIndex, e.ColumnIndex);
            return;
        }
        private void itmShowStats_CheckedChanged(object sender, EventArgs e)
        {
            if(this.last_champ_name == null)
                return;
            if (this.itmShowStats.Checked)
            {
                if (!this.stat_windows.ContainsKey(this.last_champ_name))
                {
                    formTooltipStats last_window = null;
                    formTooltipStats fStats = new formTooltipStats();
                    if(this.stat_windows.Count<1)
                        fStats.Location = new Point(this.fTooltip.Left, this.fTooltip.Bottom + 10);
                    else
                    {
                        last_window = this.stat_windows[this.stat_windows.Keys.ToArray()[this.stat_windows.Keys.Count - 1]];
                        Point location = new Point(last_window.Left, last_window.Bottom + 10);
                        bool on_screen = false;
                        foreach (Screen screen in Screen.AllScreens)
                        {
                            if (screen.WorkingArea.Contains(new Rectangle(location, fStats.Size)))
                            {
                                on_screen = true;
                                break;
                            }
                        }             
                        if(!on_screen)
                            location = new Point(this.Left + 50, this.Top + 50);
                        fStats.Location = location; 
                    }
                    fStats.FormClosed += this.fStats_FormClosed;
                    fStats.GridSelectionChanged += this.fStats_GridSelectionChanged;
                    fStats.GridScrolled += this.fStats_GridScrolled;
                    fStats.ShowTooltip(this.champions[this.last_champ_name].Name, "Stats", this.champions[this.last_champ_name], this);
                    if (last_window != null)
                    {
                        fStats.Selections = last_window.Selections;
                        fStats.ScrollIndex = last_window.ScrollIndex;
                    }
                    this.stat_windows.Add(this.last_champ_name, fStats);
                }
            }
            else if(this.stat_windows.ContainsKey(this.last_champ_name))
            {
                this.stat_windows[this.last_champ_name].Close();
            }
            return;
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (this.comboFilter.SelectedItem != null && this.comboFilter.SelectedItem.ToString() == "Free")
                this.lblSearch.Focus();
        }
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.comboFilter.SelectedItem != null && this.comboFilter.SelectedItem.ToString() == "Free")
            {
                switch (this.txtSearch.Text)
                {
                    case "Any":
                        this.txtSearch.Text = "Free";
                        break;
                    case "Free":
                        this.txtSearch.Text = "Not Free";
                        break;
                    default:
                    case "Not Free":
                        this.txtSearch.Text = "Any";
                        break;
                }
                this.UpdateFilter();
            }
            return;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.UpdateFilter();
            return;
        }
        #region Worker Events
        protected override void workerUpdateData_DoWork(object sender, DoWorkEventArgs e)
        {
            this.champions = Engine.GetChampionInfo();
            this.source = new SortableBindingList<Champion.Info>(this.champions.Values.OrderBy(champ => champ.Name).ToList());
            return;
        }
        protected override void workerUpdateData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridMain.DataSource = this.source;
            this.comboFilter.DataSource = this.gridMain.Columns.Cast<DataGridViewColumn>().Where(col => !(col is DataGridViewImageColumn)).Select(col => col.HeaderText)
                .OrderBy(text => text).ToList<string>();
            this.fTooltip.Location = new Point(this.Right + 10, this.Top);
            this.ShowTooltip(this.gridMain.SelectedCells.Count > 0 && this.gridMain.SelectedCells[0].RowIndex > -1 ? this.gridMain.SelectedCells[0].RowIndex : 0,
                this.gridMain.SelectedCells.Count > 0 && this.gridMain.SelectedCells[0].ColumnIndex > -1 ? this.gridMain.SelectedCells[0].ColumnIndex : 0);
            this.gridMain.Focus();
        }
        #endregion
        #endregion
        #region Override Methods
        protected override void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.fTooltip.IsDisposed)
            {
                if(this.fTooltip.Visible)
                    this.fTooltip.Close();
                this.fTooltip.Dispose();
            }
            List<formTooltipStats> forms = this.stat_windows.Values.ToList();
            // while (1)
            // {
            //    Emmy.doesLove(JD)
            // }
            foreach (formTooltipStats form in forms)
            {
                if (!form.IsDisposed)
                {
                    if (form.Visible)
                        form.Close();
                    form.Dispose();
                }
            }
            base.btnClose_MouseDown(sender, e);
        }
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

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
using RiotPls.API.Builder;
using RiotPls.API.Serialization.Champions;
using RiotPls.Controls;

namespace RiotPls.Forms
{
    public class formChampions : formTemplate
    {
        #region Instance Members
        #region Controls
        private System.ComponentModel.IContainer components = null;
        private Grid gridMain;
        private TextBox txtSearch;
        private ComboBox comboFilter;
        private ContextMenuStrip cmenMain;
        private ToolStripMenuItem itmSelectedForBuilder;
        #endregion
        private string last_champ_name = null;
        private Dictionary<string, ChampionInfo> champions = new Dictionary<string, ChampionInfo>();
        private BindingList<ChampionInfo> source = null;
        private Label lblInfo;
        private Label lblInfoTitle;
        private Label lblSearchTitle;
        private SplitContainer splitBottom;
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
        private Build build = null;
        #endregion     
        #region Instance Methods
        public formChampions()
        {
            this.InitializeComponent();
            this.gridMain.AutoGenerateColumns = false;
            this.gridMain.DataError += this.gridMain_DataError;
            return;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChampions));
            this.gridMain = new RiotPls.Controls.Grid();
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
            this.itmSelectedForBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.splitBottom = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.cmenMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).BeginInit();
            this.splitBottom.Panel1.SuspendLayout();
            this.splitBottom.Panel2.SuspendLayout();
            this.splitBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(533, 249);
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridMain.EnableHeadersVisualStyles = false;
            this.gridMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.gridMain.Location = new System.Drawing.Point(29, 29);
            this.gridMain.Margin = new System.Windows.Forms.Padding(20, 20, 20, 15);
            this.gridMain.MultiSelect = false;
            this.gridMain.Name = "gridMain";
            this.gridMain.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridMain.RowHeadersWidth = 40;
            this.gridMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMain.RowTemplate.Height = 120;
            this.gridMain.RowTemplate.ReadOnly = true;
            this.gridMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMain.ShowCellErrors = false;
            this.gridMain.ShowEditingIcon = false;
            this.gridMain.ShowRowErrors = false;
            this.gridMain.Size = new System.Drawing.Size(1137, 467);
            this.gridMain.TabIndex = 0;
            this.gridMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMain_CellMouseDown);
            this.gridMain.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellMouseEnter);
            this.gridMain.SizeChanged += new System.EventHandler(this.gridMain_SizeChanged);
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colImage.DataPropertyName = "Image";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            this.colImage.DefaultCellStyle = dataGridViewCellStyle2;
            this.colImage.HeaderText = "Image";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImage.Width = 120;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 55;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colTitle
            // 
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTitle.DataPropertyName = "Title";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTitle.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTitle.HeaderText = "Title";
            this.colTitle.MinimumWidth = 30;
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
            this.colTags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTags.DataPropertyName = "TagList";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTags.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTags.HeaderText = "Tags";
            this.colTags.MinimumWidth = 30;
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
            this.colPassive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPassive.DataPropertyName = "PassiveImage";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            this.colPassive.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPassive.HeaderText = "Passive";
            this.colPassive.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colPassive.Name = "colPassive";
            this.colPassive.ReadOnly = true;
            this.colPassive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPassive.Width = 64;
            // 
            // colQ
            // 
            this.colQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colQ.DataPropertyName = "SpellImageQ";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            this.colQ.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQ.HeaderText = "Q";
            this.colQ.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colQ.Name = "colQ";
            this.colQ.ReadOnly = true;
            this.colQ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQ.Width = 64;
            // 
            // colW
            // 
            this.colW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colW.DataPropertyName = "SpellImageW";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(2);
            this.colW.DefaultCellStyle = dataGridViewCellStyle8;
            this.colW.HeaderText = "W";
            this.colW.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colW.Name = "colW";
            this.colW.ReadOnly = true;
            this.colW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colW.Width = 64;
            // 
            // colE
            // 
            this.colE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colE.DataPropertyName = "SpellImageE";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(2);
            this.colE.DefaultCellStyle = dataGridViewCellStyle9;
            this.colE.HeaderText = "E";
            this.colE.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colE.Name = "colE";
            this.colE.ReadOnly = true;
            this.colE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colE.Width = 64;
            // 
            // colR
            // 
            this.colR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colR.DataPropertyName = "SpellImageR";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(2);
            this.colR.DefaultCellStyle = dataGridViewCellStyle10;
            this.colR.HeaderText = "R";
            this.colR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colR.Name = "colR";
            this.colR.ReadOnly = true;
            this.colR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colR.Width = 64;
            // 
            // cmenMain
            // 
            this.cmenMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSelectedForBuilder});
            this.cmenMain.Name = "cmenMain";
            this.cmenMain.Size = new System.Drawing.Size(177, 26);
            this.cmenMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmenMain_Opening);
            // 
            // itmSelectedForBuilder
            // 
            this.itmSelectedForBuilder.CheckOnClick = true;
            this.itmSelectedForBuilder.Name = "itmSelectedForBuilder";
            this.itmSelectedForBuilder.Size = new System.Drawing.Size(176, 22);
            this.itmSelectedForBuilder.Text = "Selected for Builder";
            this.itmSelectedForBuilder.CheckedChanged += new System.EventHandler(this.itmSelectedForBuilder_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.txtSearch.Location = new System.Drawing.Point(26, 50);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(274, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // comboFilter
            // 
            this.comboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(313, 49);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(131, 22);
            this.comboFilter.TabIndex = 5;
            this.comboFilter.SelectionChangeCommitted += new System.EventHandler(this.comboFilter_SelectionChangeCommitted);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.Location = new System.Drawing.Point(20, 25);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(10);
            this.lblInfo.Size = new System.Drawing.Size(676, 73);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(110)))), ((int)(((byte)(40)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(20, 5);
            this.lblInfoTitle.Margin = new System.Windows.Forms.Padding(20, 0, 20, 5);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(676, 15);
            this.lblInfoTitle.TabIndex = 12;
            this.lblInfoTitle.Text = "Information";
            this.lblInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(240)))));
            this.lblSearchTitle.Location = new System.Drawing.Point(20, 5);
            this.lblSearchTitle.Margin = new System.Windows.Forms.Padding(20, 0, 20, 5);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(430, 15);
            this.lblSearchTitle.TabIndex = 13;
            this.lblSearchTitle.Text = "Search";
            this.lblSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitBottom
            // 
            this.splitBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitBottom.IsSplitterFixed = true;
            this.splitBottom.Location = new System.Drawing.Point(2, 506);
            this.splitBottom.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.splitBottom.Name = "splitBottom";
            // 
            // splitBottom.Panel1
            // 
            this.splitBottom.Panel1.Controls.Add(this.txtSearch);
            this.splitBottom.Panel1.Controls.Add(this.lblSearchTitle);
            this.splitBottom.Panel1.Controls.Add(this.comboFilter);
            // 
            // splitBottom.Panel2
            // 
            this.splitBottom.Panel2.Controls.Add(this.lblInfo);
            this.splitBottom.Panel2.Controls.Add(this.lblInfoTitle);
            this.splitBottom.Size = new System.Drawing.Size(1190, 118);
            this.splitBottom.SplitterDistance = 470;
            this.splitBottom.TabIndex = 14;
            // 
            // formChampions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ChildWindow = true;
            this.ClientSize = new System.Drawing.Size(1195, 626);
            this.Controls.Add(this.splitBottom);
            this.Controls.Add(this.gridMain);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "formChampions";
            this.ShowLoading = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Champions";
            this.Activated += new System.EventHandler(this.formChampions_Activated);
            this.VisibleChanged += new System.EventHandler(this.formChampions_VisibleChanged);
            this.Controls.SetChildIndex(this.gridMain, 0);
            this.Controls.SetChildIndex(this.picLoading, 0);
            this.Controls.SetChildIndex(this.splitBottom, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.cmenMain.ResumeLayout(false);
            this.splitBottom.Panel1.ResumeLayout(false);
            this.splitBottom.Panel1.PerformLayout();
            this.splitBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).EndInit();
            this.splitBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void ResizeColumns()
        {
            int width = (this.gridMain.Width - 770)/3;
            this.colName.Width = this.colTitle.Width = this.colTags.Width = width;
            return;
        }
        private void ShowTooltip(int row_index, int column_index)
        {
            if (this.champions == null || row_index < 0 || column_index < 0 || row_index >= this.gridMain.RowCount || column_index >= this.gridMain.ColumnCount)
                return;
            string champion_name = this.gridMain.Rows[row_index].Cells["colName"].Value.ToString();
            this.last_champ_name = Engine.CleanseChampionName(this.champions, champion_name);
            ChampionInfo champion_info = this.champions[this.last_champ_name];
            string column_name = this.gridMain.Columns[column_index].HeaderText;
            string value_out = "???";
            string subtitle_out = column_name;
            switch (column_name)
            {

                case "Attack":
                    value_out = champion_info.RatingInfo.Attack.ToString() + " / 10";
                    break;
                case "Defense":
                    value_out = champion_info.RatingInfo.Defense.ToString() + " / 10";
                    break;
                case "Difficulty":
                    value_out = champion_info.RatingInfo.Difficulty.ToString() + " / 10";
                    break;
                case "Magic":
                    value_out = champion_info.RatingInfo.Magic.ToString() + " / 10";
                    break;
                case "Passive":
                    value_out = "     " + champion_info.PassiveDescription;  
                    subtitle_out = champion_info.PassiveName + " (Passive)";
                    break;
                //
                case "Q":
                    value_out = "     " + champion_info.SpellDescriptionQ;
                    subtitle_out = champion_info.SpellNameQ + " (Q)";
                    break;
                case "W":
                    value_out = "     " + champion_info.SpellDescriptionW; 
                    subtitle_out = champion_info.SpellNameW + " (W)";
                    break;
                case "E":
                    value_out = "     " + champion_info.SpellDescriptionE;
                    subtitle_out = champion_info.SpellNameE + " (E)";
                    break;
                case "R":
                    value_out = "     " + champion_info.SpellDescriptionR;
                    subtitle_out = champion_info.SpellNameR + " (R)";
                    break;
                //
                case "Image":
                    value_out = champion_info.SkinList;
                    subtitle_out = "Skins";
                    break;
                case "Free":
                    value_out = champion_info.FreeToPlay.ToString();
                    subtitle_out = "Free to Play?";
                    break;
                case "Name":
                    value_out = champion_info.LoreSummary;
                    subtitle_out = "Lore Summary";
                    break;
                case "Tags":
                    value_out = champion_info.TagList;
                    break;
                case "Title":
                    value_out = champion_info.LoreSummary;
                    subtitle_out = "Lore Summary";
                    break;
            }
            this.lblInfoTitle.Text = subtitle_out;
            this.lblInfo.Text = value_out;
            return;
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
                            this.gridMain.DataSource = new BindingList<ChampionInfo>(this.source.Where(info =>
                                info.FreeToPlay == free_to_play).ToList<ChampionInfo>());
                        }
                        break;
                    case "Name":
                        this.gridMain.DataSource = new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.Name.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<ChampionInfo>());
                        break;
                    case "Tags":
                        this.gridMain.DataSource = new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.TagList.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<ChampionInfo>());
                        break;
                    case "Title":
                        this.gridMain.DataSource = new BindingList<ChampionInfo>(this.source.Where(info =>
                            info.Title.ToUpper().Contains(this.txtSearch.Text.ToUpper())).ToList<ChampionInfo>());
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
            {
                this.itmSelectedForBuilder.Checked = this.build.Champion?.Name == this.last_champ_name;
            }
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
        private void formChampions_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.LoadWindowSettings();
                this.build = Build.GetBuild(0);
                this.ShowTooltip(this.gridMain.SelectedCells.Count > 0 && this.gridMain.SelectedCells[0].RowIndex > -1 ? this.gridMain.SelectedCells[0].RowIndex : 0,
                    this.gridMain.SelectedCells.Count > 0 && this.gridMain.SelectedCells[0].ColumnIndex > -1 ? this.gridMain.SelectedCells[0].ColumnIndex : 0);
            }
            return;
        }
        private void gridMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.champions == null)
                return;
            ChampionInfo info = this.gridMain.Rows[e.RowIndex].DataBoundItem as ChampionInfo;
            if (info != null)
            {
                this.BeginInvoke((MethodInvoker) delegate
                { this.gridMain.DoDragDrop(info, DragDropEffects.Copy); });
            }
            return;                                                          
        }
        private void gridMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ShowTooltip(e.RowIndex, e.ColumnIndex);
            return;
        }
        private void gridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
        private void gridMain_SizeChanged(object sender, EventArgs e)
        {
            this.ResizeColumns();
            return;
        }
        private void itmSelectedForBuilder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.itmSelectedForBuilder.Checked)
            {
                ChampionInfo champion = Engine.GetChampion(this.last_champ_name);
                this.build.SetChampion(champion);
            }
            return;
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (this.comboFilter.SelectedItem != null && this.comboFilter.SelectedItem.ToString() == "Free")
                this.lblInfoTitle.Focus();
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
            this.source = new SortableBindingList<ChampionInfo>(this.champions.Values.OrderBy(champ => champ.Name).ToList());
            return;
        }
        protected override void workerUpdateData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridMain.DataSource = this.source;
            this.comboFilter.DataSource = this.gridMain.Columns.Cast<DataGridViewColumn>().Where(col => !(col is DataGridViewImageColumn)).Select(col => col.HeaderText)
                .OrderBy(text => text).ToList<string>();
            this.picLoading.Visible = false;
            this.gridMain.Focus();
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

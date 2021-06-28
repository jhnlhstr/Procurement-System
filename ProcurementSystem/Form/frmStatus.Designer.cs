namespace ProcurementSystem
{
    partial class frmStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bScrollStats = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.pnlOngoing = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.cmList = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.tsCancelled = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelivered = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPaid = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBill = new System.Windows.Forms.ToolStripMenuItem();
            this.rbPurchase = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.rbRequest = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvStatsRequest = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStatsPurchase = new System.Windows.Forms.DataGridView();
            this.bScrollPurchase = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.bHScrollPurchase = new Bunifu.UI.WinForms.BunifuHScrollBar();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // bScrollStats
            // 
            this.bScrollStats.AllowCursorChanges = true;
            this.bScrollStats.AllowHomeEndKeysDetection = false;
            this.bScrollStats.AllowIncrementalClickMoves = true;
            this.bScrollStats.AllowMouseDownEffects = true;
            this.bScrollStats.AllowMouseHoverEffects = true;
            this.bScrollStats.AllowScrollingAnimations = true;
            this.bScrollStats.AllowScrollKeysDetection = true;
            this.bScrollStats.AllowScrollOptionsMenu = true;
            this.bScrollStats.AllowShrinkingOnFocusLost = false;
            this.bScrollStats.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollStats.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bScrollStats.BackgroundImage")));
            this.bScrollStats.BindingContainer = null;
            this.bScrollStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollStats.BorderRadius = 14;
            this.bScrollStats.BorderThickness = 1;
            this.bScrollStats.DurationBeforeShrink = 2000;
            this.bScrollStats.LargeChange = 30;
            this.bScrollStats.Location = new System.Drawing.Point(1135, 128);
            this.bScrollStats.Maximum = 100;
            this.bScrollStats.Minimum = 0;
            this.bScrollStats.MinimumThumbLength = 18;
            this.bScrollStats.Name = "bScrollStats";
            this.bScrollStats.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bScrollStats.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bScrollStats.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bScrollStats.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollStats.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollStats.ShrinkSizeLimit = 3;
            this.bScrollStats.Size = new System.Drawing.Size(21, 547);
            this.bScrollStats.SmallChange = 1;
            this.bScrollStats.TabIndex = 288;
            this.bScrollStats.ThumbColor = System.Drawing.Color.Gray;
            this.bScrollStats.ThumbLength = 161;
            this.bScrollStats.ThumbMargin = 1;
            this.bScrollStats.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bScrollStats.Value = 0;
            this.bScrollStats.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bScrollStats_Scroll);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.White;
            this.gunaLabel3.Location = new System.Drawing.Point(862, 59);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(67, 18);
            this.gunaLabel3.TabIndex = 292;
            this.gunaLabel3.Text = "Ongoing";
            // 
            // pnlOngoing
            // 
            this.pnlOngoing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(121)))));
            this.pnlOngoing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOngoing.Location = new System.Drawing.Point(841, 61);
            this.pnlOngoing.Name = "pnlOngoing";
            this.pnlOngoing.Size = new System.Drawing.Size(15, 14);
            this.pnlOngoing.TabIndex = 291;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.White;
            this.gunaLabel2.Location = new System.Drawing.Point(956, 59);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(74, 18);
            this.gunaLabel2.TabIndex = 290;
            this.gunaLabel2.Text = "Cancelled";
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.gunaPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel2.Location = new System.Drawing.Point(935, 61);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(15, 14);
            this.gunaPanel2.TabIndex = 289;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "purchase.png");
            this.imageList1.Images.SetKeyName(1, "edit.png");
            this.imageList1.Images.SetKeyName(2, "onhold1.png");
            this.imageList1.Images.SetKeyName(3, "cancelled.png");
            this.imageList1.Images.SetKeyName(4, "delivered.png");
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.White;
            this.gunaLabel1.Location = new System.Drawing.Point(1057, 59);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(72, 18);
            this.gunaLabel1.TabIndex = 294;
            this.gunaLabel1.Text = "Delivered";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(161)))), ((int)(((byte)(99)))));
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gunaPanel1.Location = new System.Drawing.Point(1036, 61);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(15, 14);
            this.gunaPanel1.TabIndex = 293;
            // 
            // cmList
            // 
            this.cmList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCancelled,
            this.tsDelivered,
            this.tsPaid,
            this.tsBill});
            this.cmList.Name = "cmModify";
            this.cmList.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.cmList.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmList.RenderStyle.ColorTable = null;
            this.cmList.RenderStyle.RoundedEdges = true;
            this.cmList.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmList.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.cmList.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmList.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmList.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault;
            this.cmList.Size = new System.Drawing.Size(130, 92);
            // 
            // tsCancelled
            // 
            this.tsCancelled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tsCancelled.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCancelled.ForeColor = System.Drawing.Color.White;
            this.tsCancelled.Name = "tsCancelled";
            this.tsCancelled.Size = new System.Drawing.Size(129, 22);
            this.tsCancelled.Text = "Cancelled";
            this.tsCancelled.Click += new System.EventHandler(this.tsCancelled_Click);
            // 
            // tsDelivered
            // 
            this.tsDelivered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tsDelivered.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDelivered.ForeColor = System.Drawing.Color.White;
            this.tsDelivered.Name = "tsDelivered";
            this.tsDelivered.Size = new System.Drawing.Size(129, 22);
            this.tsDelivered.Text = "Delivered";
            this.tsDelivered.Click += new System.EventHandler(this.tsDelivered_Click);
            // 
            // tsPaid
            // 
            this.tsPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tsPaid.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPaid.ForeColor = System.Drawing.Color.White;
            this.tsPaid.Name = "tsPaid";
            this.tsPaid.Size = new System.Drawing.Size(129, 22);
            this.tsPaid.Text = "Paid";
            this.tsPaid.Click += new System.EventHandler(this.tsPaid_Click);
            // 
            // tsBill
            // 
            this.tsBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.tsBill.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBill.ForeColor = System.Drawing.Color.White;
            this.tsBill.Name = "tsBill";
            this.tsBill.Size = new System.Drawing.Size(129, 22);
            this.tsBill.Text = "Bill";
            this.tsBill.Click += new System.EventHandler(this.tsBill_Click);
            // 
            // rbPurchase
            // 
            this.rbPurchase.Checked = false;
            this.rbPurchase.Location = new System.Drawing.Point(236, 47);
            this.rbPurchase.Name = "rbPurchase";
            this.rbPurchase.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.rbPurchase.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.rbPurchase.Size = new System.Drawing.Size(25, 25);
            this.rbPurchase.TabIndex = 298;
            this.rbPurchase.Text = null;
            this.rbPurchase.CheckedChanged += new System.EventHandler(this.rbPurchase_CheckedChanged);
            // 
            // rbRequest
            // 
            this.rbRequest.Checked = true;
            this.rbRequest.Location = new System.Drawing.Point(51, 47);
            this.rbRequest.Name = "rbRequest";
            this.rbRequest.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.rbRequest.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.rbRequest.Size = new System.Drawing.Size(25, 25);
            this.rbRequest.TabIndex = 297;
            this.rbRequest.Text = null;
            this.rbRequest.CheckedChanged += new System.EventHandler(this.rbRequest_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(267, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 296;
            this.label9.Text = "PURCHASE ORDER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label10.Location = new System.Drawing.Point(82, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 18);
            this.label10.TabIndex = 295;
            this.label10.Text = "REQUEST NUMBER";
            // 
            // dgvStatsRequest
            // 
            this.dgvStatsRequest.AllowUserToAddRows = false;
            this.dgvStatsRequest.AllowUserToDeleteRows = false;
            this.dgvStatsRequest.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvStatsRequest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatsRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatsRequest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvStatsRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatsRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStatsRequest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatsRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatsRequest.ColumnHeadersHeight = 40;
            this.dgvStatsRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStatsRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatsRequest.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStatsRequest.EnableHeadersVisualStyles = false;
            this.dgvStatsRequest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvStatsRequest.Location = new System.Drawing.Point(38, 86);
            this.dgvStatsRequest.Name = "dgvStatsRequest";
            this.dgvStatsRequest.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatsRequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStatsRequest.RowHeadersVisible = false;
            this.dgvStatsRequest.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStatsRequest.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStatsRequest.RowTemplate.Height = 50;
            this.dgvStatsRequest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvStatsRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatsRequest.Size = new System.Drawing.Size(1091, 589);
            this.dgvStatsRequest.TabIndex = 299;
            this.dgvStatsRequest.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvStatsRequest_RowsAdded);
            this.dgvStatsRequest.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvStatsRequest_RowsRemoved);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 20F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Request Number";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Requestor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Client";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Request Description";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Request Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dgvStatsPurchase
            // 
            this.dgvStatsPurchase.AllowUserToAddRows = false;
            this.dgvStatsPurchase.AllowUserToDeleteRows = false;
            this.dgvStatsPurchase.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvStatsPurchase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStatsPurchase.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvStatsPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatsPurchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStatsPurchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatsPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStatsPurchase.ColumnHeadersHeight = 40;
            this.dgvStatsPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStatsPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatsPurchase.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvStatsPurchase.EnableHeadersVisualStyles = false;
            this.dgvStatsPurchase.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvStatsPurchase.Location = new System.Drawing.Point(38, 86);
            this.dgvStatsPurchase.Name = "dgvStatsPurchase";
            this.dgvStatsPurchase.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatsPurchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvStatsPurchase.RowHeadersVisible = false;
            this.dgvStatsPurchase.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStatsPurchase.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStatsPurchase.RowTemplate.Height = 50;
            this.dgvStatsPurchase.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvStatsPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatsPurchase.Size = new System.Drawing.Size(1091, 589);
            this.dgvStatsPurchase.TabIndex = 300;
            this.dgvStatsPurchase.Visible = false;
            this.dgvStatsPurchase.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatsPurchase_CellFormatting);
            this.dgvStatsPurchase.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStatsPurchase_CellMouseDown);
            this.dgvStatsPurchase.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvStatsPurchase_ColumnAdded);
            this.dgvStatsPurchase.ColumnRemoved += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvStatsPurchase_ColumnRemoved);
            this.dgvStatsPurchase.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvStatsPurchase_RowsAdded);
            this.dgvStatsPurchase.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvStatsPurchase_RowsRemoved);
            // 
            // bScrollPurchase
            // 
            this.bScrollPurchase.AllowCursorChanges = true;
            this.bScrollPurchase.AllowHomeEndKeysDetection = false;
            this.bScrollPurchase.AllowIncrementalClickMoves = true;
            this.bScrollPurchase.AllowMouseDownEffects = true;
            this.bScrollPurchase.AllowMouseHoverEffects = true;
            this.bScrollPurchase.AllowScrollingAnimations = true;
            this.bScrollPurchase.AllowScrollKeysDetection = true;
            this.bScrollPurchase.AllowScrollOptionsMenu = true;
            this.bScrollPurchase.AllowShrinkingOnFocusLost = false;
            this.bScrollPurchase.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollPurchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bScrollPurchase.BackgroundImage")));
            this.bScrollPurchase.BindingContainer = null;
            this.bScrollPurchase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollPurchase.BorderRadius = 14;
            this.bScrollPurchase.BorderThickness = 1;
            this.bScrollPurchase.DurationBeforeShrink = 2000;
            this.bScrollPurchase.LargeChange = 30;
            this.bScrollPurchase.Location = new System.Drawing.Point(1135, 128);
            this.bScrollPurchase.Maximum = 100;
            this.bScrollPurchase.Minimum = 0;
            this.bScrollPurchase.MinimumThumbLength = 18;
            this.bScrollPurchase.Name = "bScrollPurchase";
            this.bScrollPurchase.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bScrollPurchase.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bScrollPurchase.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bScrollPurchase.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollPurchase.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bScrollPurchase.ShrinkSizeLimit = 3;
            this.bScrollPurchase.Size = new System.Drawing.Size(21, 547);
            this.bScrollPurchase.SmallChange = 1;
            this.bScrollPurchase.TabIndex = 301;
            this.bScrollPurchase.ThumbColor = System.Drawing.Color.Gray;
            this.bScrollPurchase.ThumbLength = 161;
            this.bScrollPurchase.ThumbMargin = 1;
            this.bScrollPurchase.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bScrollPurchase.Value = 0;
            this.bScrollPurchase.Visible = false;
            this.bScrollPurchase.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bScrollPurchase_Scroll);
            // 
            // bHScrollPurchase
            // 
            this.bHScrollPurchase.AllowCursorChanges = true;
            this.bHScrollPurchase.AllowHomeEndKeysDetection = false;
            this.bHScrollPurchase.AllowIncrementalClickMoves = true;
            this.bHScrollPurchase.AllowMouseDownEffects = true;
            this.bHScrollPurchase.AllowMouseHoverEffects = true;
            this.bHScrollPurchase.AllowScrollingAnimations = true;
            this.bHScrollPurchase.AllowScrollKeysDetection = true;
            this.bHScrollPurchase.AllowScrollOptionsMenu = true;
            this.bHScrollPurchase.AllowShrinkingOnFocusLost = false;
            this.bHScrollPurchase.BackgoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bHScrollPurchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bHScrollPurchase.BackgroundImage")));
            this.bHScrollPurchase.BindingContainer = null;
            this.bHScrollPurchase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bHScrollPurchase.BorderRadius = 14;
            this.bHScrollPurchase.BorderThickness = 1;
            this.bHScrollPurchase.DurationBeforeShrink = 2000;
            this.bHScrollPurchase.LargeChange = 30;
            this.bHScrollPurchase.Location = new System.Drawing.Point(38, 681);
            this.bHScrollPurchase.Maximum = 100;
            this.bHScrollPurchase.Minimum = 0;
            this.bHScrollPurchase.MinimumThumbLength = 18;
            this.bHScrollPurchase.Name = "bHScrollPurchase";
            this.bHScrollPurchase.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bHScrollPurchase.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bHScrollPurchase.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bHScrollPurchase.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bHScrollPurchase.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.bHScrollPurchase.ShrinkSizeLimit = 3;
            this.bHScrollPurchase.Size = new System.Drawing.Size(363, 17);
            this.bHScrollPurchase.SmallChange = 1;
            this.bHScrollPurchase.TabIndex = 302;
            this.bHScrollPurchase.ThumbColor = System.Drawing.Color.Gray;
            this.bHScrollPurchase.ThumbLength = 107;
            this.bHScrollPurchase.ThumbMargin = 1;
            this.bHScrollPurchase.ThumbStyle = Bunifu.UI.WinForms.BunifuHScrollBar.ThumbStyles.Inset;
            this.bHScrollPurchase.Value = 0;
            this.bHScrollPurchase.Visible = false;
            this.bHScrollPurchase.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs>(this.bHScrollPurchase_Scroll);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 20F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "PRFID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Purchase Order";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Purchase Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Client";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 150F;
            this.Column7.HeaderText = "Purchase Description";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 50F;
            this.Column8.HeaderText = "Terms";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Purchase Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Delivery Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Paid Date";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Bill";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Countdown";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Pbit";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Bill";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // frmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1192, 723);
            this.Controls.Add(this.bHScrollPurchase);
            this.Controls.Add(this.bScrollPurchase);
            this.Controls.Add(this.dgvStatsPurchase);
            this.Controls.Add(this.dgvStatsRequest);
            this.Controls.Add(this.rbPurchase);
            this.Controls.Add(this.rbRequest);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.pnlOngoing);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaPanel2);
            this.Controls.Add(this.bScrollStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatus";
            this.Text = "frmStatus";
            this.cmList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuVScrollBar bScrollStats;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaPanel pnlOngoing;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaContextMenuStrip cmList;
        private System.Windows.Forms.ToolStripMenuItem tsCancelled;
        private System.Windows.Forms.ToolStripMenuItem tsDelivered;
        private Bunifu.UI.WinForms.BunifuRadioButton rbPurchase;
        private Bunifu.UI.WinForms.BunifuRadioButton rbRequest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvStatsRequest;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView dgvStatsPurchase;
        private Bunifu.UI.WinForms.BunifuVScrollBar bScrollPurchase;
        private Bunifu.UI.WinForms.BunifuHScrollBar bHScrollPurchase;
        private System.Windows.Forms.ToolStripMenuItem tsPaid;
        private System.Windows.Forms.ToolStripMenuItem tsBill;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewImageColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}
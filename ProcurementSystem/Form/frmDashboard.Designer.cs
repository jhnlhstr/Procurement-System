namespace ProcurementSystem
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalApproveReq = new System.Windows.Forms.Label();
            this.progressRequest = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.lblTotalCancelledReq = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalRequest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCancelPO = new System.Windows.Forms.Label();
            this.lblDeliveredPO = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblOngoingPO = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.progressPO = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.lblTotalPO = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bScrollRequest = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.dgvListRequest = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAmountPO = new System.Windows.Forms.Label();
            this.ScrollAmountPO = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.dgvTotalPO = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblPOYear = new System.Windows.Forms.Label();
            this.chartRequest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.dashImage = new System.Windows.Forms.ImageList(this.components);
            this.icnPrevious = new FontAwesome.Sharp.IconButton();
            this.icnNext = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRequest)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalPO)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblTotalApproveReq);
            this.panel1.Controls.Add(this.progressRequest);
            this.panel1.Controls.Add(this.lblTotalCancelledReq);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblTotalRequest);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(39, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 212);
            this.panel1.TabIndex = 49;
            // 
            // lblTotalApproveReq
            // 
            this.lblTotalApproveReq.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalApproveReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblTotalApproveReq.Location = new System.Drawing.Point(138, 158);
            this.lblTotalApproveReq.Name = "lblTotalApproveReq";
            this.lblTotalApproveReq.Size = new System.Drawing.Size(91, 21);
            this.lblTotalApproveReq.TabIndex = 55;
            this.lblTotalApproveReq.Text = "0";
            this.lblTotalApproveReq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressRequest
            // 
            this.progressRequest.animated = false;
            this.progressRequest.animationIterval = 5;
            this.progressRequest.animationSpeed = 300;
            this.progressRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.progressRequest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progressRequest.BackgroundImage")));
            this.progressRequest.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.progressRequest.LabelVisible = true;
            this.progressRequest.LineProgressThickness = 8;
            this.progressRequest.LineThickness = 5;
            this.progressRequest.Location = new System.Drawing.Point(235, 35);
            this.progressRequest.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.progressRequest.MaxValue = 100;
            this.progressRequest.Name = "progressRequest";
            this.progressRequest.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.progressRequest.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.progressRequest.Size = new System.Drawing.Size(143, 143);
            this.progressRequest.TabIndex = 51;
            this.progressRequest.Value = 0;
            // 
            // lblTotalCancelledReq
            // 
            this.lblTotalCancelledReq.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCancelledReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblTotalCancelledReq.Location = new System.Drawing.Point(138, 128);
            this.lblTotalCancelledReq.Name = "lblTotalCancelledReq";
            this.lblTotalCancelledReq.Size = new System.Drawing.Size(91, 21);
            this.lblTotalCancelledReq.TabIndex = 54;
            this.lblTotalCancelledReq.Text = "0";
            this.lblTotalCancelledReq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label10.Location = new System.Drawing.Point(29, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 21);
            this.label10.TabIndex = 53;
            this.label10.Text = "Total Approve :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(24, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 21);
            this.label9.TabIndex = 52;
            this.label9.Text = "Total Cancelled :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRequest
            // 
            this.lblTotalRequest.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblTotalRequest.Location = new System.Drawing.Point(17, 47);
            this.lblTotalRequest.Name = "lblTotalRequest";
            this.lblTotalRequest.Size = new System.Drawing.Size(209, 66);
            this.lblTotalRequest.TabIndex = 51;
            this.lblTotalRequest.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 50;
            this.label1.Text = "Total Request";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.lblCancelPO);
            this.panel2.Controls.Add(this.lblDeliveredPO);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblOngoingPO);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.progressPO);
            this.panel2.Controls.Add(this.lblTotalPO);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(461, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 212);
            this.panel2.TabIndex = 50;
            // 
            // lblCancelPO
            // 
            this.lblCancelPO.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblCancelPO.Location = new System.Drawing.Point(135, 174);
            this.lblCancelPO.Name = "lblCancelPO";
            this.lblCancelPO.Size = new System.Drawing.Size(91, 21);
            this.lblCancelPO.TabIndex = 61;
            this.lblCancelPO.Text = "0";
            this.lblCancelPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeliveredPO
            // 
            this.lblDeliveredPO.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveredPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblDeliveredPO.Location = new System.Drawing.Point(135, 147);
            this.lblDeliveredPO.Name = "lblDeliveredPO";
            this.lblDeliveredPO.Size = new System.Drawing.Size(91, 21);
            this.lblDeliveredPO.TabIndex = 59;
            this.lblDeliveredPO.Text = "0";
            this.lblDeliveredPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label15.Location = new System.Drawing.Point(17, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 21);
            this.label15.TabIndex = 60;
            this.label15.Text = "Total Cancelled :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOngoingPO
            // 
            this.lblOngoingPO.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOngoingPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblOngoingPO.Location = new System.Drawing.Point(135, 120);
            this.lblOngoingPO.Name = "lblOngoingPO";
            this.lblOngoingPO.Size = new System.Drawing.Size(91, 21);
            this.lblOngoingPO.TabIndex = 58;
            this.lblOngoingPO.Text = "0";
            this.lblOngoingPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label12.Location = new System.Drawing.Point(17, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 21);
            this.label12.TabIndex = 57;
            this.label12.Text = "Total Delivered :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label13.Location = new System.Drawing.Point(19, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 21);
            this.label13.TabIndex = 56;
            this.label13.Text = "Total Ongoing :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressPO
            // 
            this.progressPO.animated = false;
            this.progressPO.animationIterval = 5;
            this.progressPO.animationSpeed = 300;
            this.progressPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.progressPO.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progressPO.BackgroundImage")));
            this.progressPO.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.progressPO.LabelVisible = true;
            this.progressPO.LineProgressThickness = 8;
            this.progressPO.LineThickness = 5;
            this.progressPO.Location = new System.Drawing.Point(238, 35);
            this.progressPO.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.progressPO.MaxValue = 100;
            this.progressPO.Name = "progressPO";
            this.progressPO.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.progressPO.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.progressPO.Size = new System.Drawing.Size(143, 143);
            this.progressPO.TabIndex = 55;
            this.progressPO.Value = 0;
            // 
            // lblTotalPO
            // 
            this.lblTotalPO.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblTotalPO.Location = new System.Drawing.Point(17, 47);
            this.lblTotalPO.Name = "lblTotalPO";
            this.lblTotalPO.Size = new System.Drawing.Size(209, 66);
            this.lblTotalPO.TabIndex = 54;
            this.lblTotalPO.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(28, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 50;
            this.label2.Text = "Total PO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.bScrollRequest);
            this.panel3.Controls.Add(this.dgvListRequest);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(39, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 388);
            this.panel3.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(324, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 52;
            this.label5.Text = "Approved";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(308, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 15);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 290;
            this.pictureBox2.TabStop = false;
            // 
            // bScrollRequest
            // 
            this.bScrollRequest.AllowCursorChanges = true;
            this.bScrollRequest.AllowHomeEndKeysDetection = false;
            this.bScrollRequest.AllowIncrementalClickMoves = true;
            this.bScrollRequest.AllowMouseDownEffects = true;
            this.bScrollRequest.AllowMouseHoverEffects = true;
            this.bScrollRequest.AllowScrollingAnimations = true;
            this.bScrollRequest.AllowScrollKeysDetection = true;
            this.bScrollRequest.AllowScrollOptionsMenu = true;
            this.bScrollRequest.AllowShrinkingOnFocusLost = false;
            this.bScrollRequest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.bScrollRequest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bScrollRequest.BackgroundImage")));
            this.bScrollRequest.BindingContainer = null;
            this.bScrollRequest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.bScrollRequest.BorderRadius = 10;
            this.bScrollRequest.BorderThickness = 1;
            this.bScrollRequest.DurationBeforeShrink = 2000;
            this.bScrollRequest.LargeChange = 30;
            this.bScrollRequest.Location = new System.Drawing.Point(364, 54);
            this.bScrollRequest.Maximum = 100;
            this.bScrollRequest.Minimum = 0;
            this.bScrollRequest.MinimumThumbLength = 18;
            this.bScrollRequest.Name = "bScrollRequest";
            this.bScrollRequest.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bScrollRequest.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bScrollRequest.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bScrollRequest.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.bScrollRequest.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.bScrollRequest.ShrinkSizeLimit = 3;
            this.bScrollRequest.Size = new System.Drawing.Size(14, 315);
            this.bScrollRequest.SmallChange = 1;
            this.bScrollRequest.TabIndex = 289;
            this.bScrollRequest.ThumbColor = System.Drawing.Color.Gray;
            this.bScrollRequest.ThumbLength = 92;
            this.bScrollRequest.ThumbMargin = 1;
            this.bScrollRequest.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bScrollRequest.Value = 0;
            this.bScrollRequest.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bScrollRequest_Scroll);
            // 
            // dgvListRequest
            // 
            this.dgvListRequest.AllowUserToAddRows = false;
            this.dgvListRequest.AllowUserToDeleteRows = false;
            this.dgvListRequest.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvListRequest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvListRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListRequest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dgvListRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvListRequest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvListRequest.ColumnHeadersHeight = 40;
            this.dgvListRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListRequest.ColumnHeadersVisible = false;
            this.dgvListRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListRequest.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvListRequest.EnableHeadersVisualStyles = false;
            this.dgvListRequest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvListRequest.Location = new System.Drawing.Point(19, 54);
            this.dgvListRequest.Name = "dgvListRequest";
            this.dgvListRequest.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvListRequest.RowHeadersVisible = false;
            this.dgvListRequest.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvListRequest.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListRequest.RowTemplate.Height = 50;
            this.dgvListRequest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvListRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListRequest.Size = new System.Drawing.Size(339, 315);
            this.dgvListRequest.TabIndex = 288;
            this.dgvListRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRequest_CellClick);
            this.dgvListRequest.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvListRequest_RowsAdded);
            this.dgvListRequest.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvListRequest_RowsRemoved);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "ReqNum";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ReqDate";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Stats";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 30F;
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(29, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 22);
            this.label4.TabIndex = 50;
            this.label4.Text = "Approval of Request";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.lblAmountPO);
            this.panel4.Controls.Add(this.ScrollAmountPO);
            this.panel4.Controls.Add(this.dgvTotalPO);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(882, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 212);
            this.panel4.TabIndex = 52;
            // 
            // lblAmountPO
            // 
            this.lblAmountPO.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblAmountPO.Location = new System.Drawing.Point(86, 179);
            this.lblAmountPO.Name = "lblAmountPO";
            this.lblAmountPO.Size = new System.Drawing.Size(146, 23);
            this.lblAmountPO.TabIndex = 62;
            this.lblAmountPO.Text = "0";
            this.lblAmountPO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScrollAmountPO
            // 
            this.ScrollAmountPO.AllowCursorChanges = true;
            this.ScrollAmountPO.AllowHomeEndKeysDetection = false;
            this.ScrollAmountPO.AllowIncrementalClickMoves = true;
            this.ScrollAmountPO.AllowMouseDownEffects = true;
            this.ScrollAmountPO.AllowMouseHoverEffects = true;
            this.ScrollAmountPO.AllowScrollingAnimations = true;
            this.ScrollAmountPO.AllowScrollKeysDetection = true;
            this.ScrollAmountPO.AllowScrollOptionsMenu = true;
            this.ScrollAmountPO.AllowShrinkingOnFocusLost = false;
            this.ScrollAmountPO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ScrollAmountPO.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollAmountPO.BackgroundImage")));
            this.ScrollAmountPO.BindingContainer = null;
            this.ScrollAmountPO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ScrollAmountPO.BorderRadius = 10;
            this.ScrollAmountPO.BorderThickness = 1;
            this.ScrollAmountPO.DurationBeforeShrink = 2000;
            this.ScrollAmountPO.LargeChange = 30;
            this.ScrollAmountPO.Location = new System.Drawing.Point(238, 15);
            this.ScrollAmountPO.Maximum = 100;
            this.ScrollAmountPO.Minimum = 0;
            this.ScrollAmountPO.MinimumThumbLength = 18;
            this.ScrollAmountPO.Name = "ScrollAmountPO";
            this.ScrollAmountPO.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.ScrollAmountPO.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.ScrollAmountPO.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.ScrollAmountPO.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ScrollAmountPO.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ScrollAmountPO.ShrinkSizeLimit = 3;
            this.ScrollAmountPO.Size = new System.Drawing.Size(12, 158);
            this.ScrollAmountPO.SmallChange = 1;
            this.ScrollAmountPO.TabIndex = 290;
            this.ScrollAmountPO.ThumbColor = System.Drawing.Color.Gray;
            this.ScrollAmountPO.ThumbLength = 46;
            this.ScrollAmountPO.ThumbMargin = 1;
            this.ScrollAmountPO.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.ScrollAmountPO.Value = 0;
            this.ScrollAmountPO.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.ScrollAmountPO_Scroll);
            // 
            // dgvTotalPO
            // 
            this.dgvTotalPO.AllowUserToAddRows = false;
            this.dgvTotalPO.AllowUserToDeleteRows = false;
            this.dgvTotalPO.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgvTotalPO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvTotalPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotalPO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dgvTotalPO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotalPO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTotalPO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvTotalPO.ColumnHeadersHeight = 40;
            this.dgvTotalPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotalPO.ColumnHeadersVisible = false;
            this.dgvTotalPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalPO.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvTotalPO.EnableHeadersVisualStyles = false;
            this.dgvTotalPO.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgvTotalPO.Location = new System.Drawing.Point(11, 15);
            this.dgvTotalPO.Name = "dgvTotalPO";
            this.dgvTotalPO.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalPO.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvTotalPO.RowHeadersVisible = false;
            this.dgvTotalPO.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTotalPO.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTotalPO.RowTemplate.Height = 50;
            this.dgvTotalPO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTotalPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotalPO.Size = new System.Drawing.Size(221, 158);
            this.dgvTotalPO.TabIndex = 289;
            this.dgvTotalPO.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTotalPO_RowsAdded);
            this.dgvTotalPO.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTotalPO_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 80F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Client";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Total";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(20, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 55;
            this.label8.Text = "Total :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblDate.Location = new System.Drawing.Point(648, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(497, 42);
            this.lblDate.TabIndex = 53;
            this.lblDate.Text = "May 2021";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.lblPOYear);
            this.panel5.Controls.Add(this.chartRequest);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(461, 297);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(684, 388);
            this.panel5.TabIndex = 54;
            // 
            // lblPOYear
            // 
            this.lblPOYear.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblPOYear.Location = new System.Drawing.Point(167, 14);
            this.lblPOYear.Name = "lblPOYear";
            this.lblPOYear.Size = new System.Drawing.Size(260, 23);
            this.lblPOYear.TabIndex = 63;
            this.lblPOYear.Text = "0";
            this.lblPOYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartRequest
            // 
            this.chartRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.chartRequest.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.chartRequest.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            chartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisX.Title = "Year ( 2021 )";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            chartArea3.AxisX2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            chartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            chartArea3.BorderColor = System.Drawing.Color.Empty;
            chartArea3.Name = "ChartArea1";
            this.chartRequest.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            legend3.TitleFont = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartRequest.Legends.Add(legend3);
            this.chartRequest.Location = new System.Drawing.Point(5, 54);
            this.chartRequest.Name = "chartRequest";
            this.chartRequest.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartRequest.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))))};
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.IsVisibleInLegend = false;
            series3.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            series3.Legend = "Legend1";
            series3.Name = "Request";
            series3.YValuesPerPoint = 2;
            this.chartRequest.Series.Add(series3);
            this.chartRequest.Size = new System.Drawing.Size(674, 315);
            this.chartRequest.TabIndex = 51;
            this.chartRequest.Text = "chart1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(15, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 22);
            this.label7.TabIndex = 50;
            this.label7.Text = "Yearly Request";
            // 
            // dashImage
            // 
            this.dashImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dashImage.ImageStream")));
            this.dashImage.TransparentColor = System.Drawing.Color.Transparent;
            this.dashImage.Images.SetKeyName(0, "go.png");
            this.dashImage.Images.SetKeyName(1, "go1.png");
            // 
            // icnPrevious
            // 
            this.icnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnPrevious.FlatAppearance.BorderSize = 0;
            this.icnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnPrevious.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.icnPrevious.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            this.icnPrevious.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.icnPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnPrevious.IconSize = 35;
            this.icnPrevious.Location = new System.Drawing.Point(39, 22);
            this.icnPrevious.Name = "icnPrevious";
            this.icnPrevious.Size = new System.Drawing.Size(43, 33);
            this.icnPrevious.TabIndex = 60;
            this.icnPrevious.UseVisualStyleBackColor = false;
            this.icnPrevious.Click += new System.EventHandler(this.icnPrevious_Click);
            // 
            // icnNext
            // 
            this.icnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnNext.FlatAppearance.BorderSize = 0;
            this.icnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnNext.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.icnNext.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.icnNext.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.icnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnNext.IconSize = 35;
            this.icnNext.Location = new System.Drawing.Point(88, 22);
            this.icnNext.Name = "icnNext";
            this.icnNext.Size = new System.Drawing.Size(43, 33);
            this.icnNext.TabIndex = 61;
            this.icnNext.UseVisualStyleBackColor = false;
            this.icnNext.Click += new System.EventHandler(this.icnNext_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1192, 723);
            this.Controls.Add(this.icnNext);
            this.Controls.Add(this.icnPrevious);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRequest)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalPO)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTotalRequest;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuCircleProgressbar progressRequest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalApproveReq;
        private System.Windows.Forms.Label lblTotalCancelledReq;
        private System.Windows.Forms.Label lblTotalPO;
        private Bunifu.Framework.UI.BunifuCircleProgressbar progressPO;
        private System.Windows.Forms.Label lblDeliveredPO;
        private System.Windows.Forms.Label lblOngoingPO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCancelPO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvListRequest;
        private System.Windows.Forms.ImageList dashImage;
        private Bunifu.UI.WinForms.BunifuVScrollBar bScrollRequest;
        private FontAwesome.Sharp.IconButton icnPrevious;
        private FontAwesome.Sharp.IconButton icnNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Column5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvTotalPO;
        private Bunifu.UI.WinForms.BunifuVScrollBar ScrollAmountPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lblAmountPO;
        private System.Windows.Forms.Label lblPOYear;
    }
}
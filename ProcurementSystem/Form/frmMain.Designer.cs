namespace ProcurementSystem
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUsers = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnStatus = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnPurchasing = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnRequest = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnSupplier = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btnDashboard = new Guna.UI.WinForms.GunaAdvenceButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.icnLogout = new FontAwesome.Sharp.IconButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnStatus);
            this.panel1.Controls.Add(this.btnPurchasing);
            this.panel1.Controls.Add(this.btnRequest);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 790);
            this.panel1.TabIndex = 0;
            // 
            // btnUsers
            // 
            this.btnUsers.AnimationHoverSpeed = 0.07F;
            this.btnUsers.AnimationSpeed = 0.03F;
            this.btnUsers.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnUsers.BorderColor = System.Drawing.Color.Black;
            this.btnUsers.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnUsers.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnUsers.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnUsers.CheckedForeColor = System.Drawing.Color.White;
            this.btnUsers.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnUsers.CheckedImage")));
            this.btnUsers.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FocusedColor = System.Drawing.Color.Empty;
            this.btnUsers.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageOffsetX = 10;
            this.btnUsers.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUsers.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnUsers.LineLeft = 5;
            this.btnUsers.Location = new System.Drawing.Point(0, 344);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnUsers.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUsers.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUsers.OnHoverImage = null;
            this.btnUsers.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnUsers.OnPressedColor = System.Drawing.Color.Black;
            this.btnUsers.Size = new System.Drawing.Size(186, 40);
            this.btnUsers.TabIndex = 50;
            this.btnUsers.Text = "User Credentials";
            this.btnUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnUsers.TextOffsetX = 25;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 720);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 70);
            this.panel4.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnStatus
            // 
            this.btnStatus.AnimationHoverSpeed = 0.07F;
            this.btnStatus.AnimationSpeed = 0.03F;
            this.btnStatus.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnStatus.BorderColor = System.Drawing.Color.Black;
            this.btnStatus.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnStatus.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnStatus.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnStatus.CheckedForeColor = System.Drawing.Color.White;
            this.btnStatus.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnStatus.CheckedImage")));
            this.btnStatus.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStatus.FocusedColor = System.Drawing.Color.Empty;
            this.btnStatus.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnStatus.Image")));
            this.btnStatus.ImageOffsetX = 10;
            this.btnStatus.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStatus.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnStatus.LineLeft = 5;
            this.btnStatus.Location = new System.Drawing.Point(0, 304);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnStatus.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStatus.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStatus.OnHoverImage = null;
            this.btnStatus.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnStatus.OnPressedColor = System.Drawing.Color.Black;
            this.btnStatus.Size = new System.Drawing.Size(186, 40);
            this.btnStatus.TabIndex = 49;
            this.btnStatus.Text = "Status";
            this.btnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnStatus.TextOffsetX = 65;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnPurchasing
            // 
            this.btnPurchasing.AnimationHoverSpeed = 0.07F;
            this.btnPurchasing.AnimationSpeed = 0.03F;
            this.btnPurchasing.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPurchasing.BorderColor = System.Drawing.Color.Black;
            this.btnPurchasing.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnPurchasing.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnPurchasing.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnPurchasing.CheckedForeColor = System.Drawing.Color.White;
            this.btnPurchasing.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnPurchasing.CheckedImage")));
            this.btnPurchasing.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnPurchasing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchasing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchasing.FocusedColor = System.Drawing.Color.Empty;
            this.btnPurchasing.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchasing.ForeColor = System.Drawing.Color.White;
            this.btnPurchasing.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchasing.Image")));
            this.btnPurchasing.ImageOffsetX = 10;
            this.btnPurchasing.ImageSize = new System.Drawing.Size(20, 20);
            this.btnPurchasing.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPurchasing.LineLeft = 5;
            this.btnPurchasing.Location = new System.Drawing.Point(0, 264);
            this.btnPurchasing.Name = "btnPurchasing";
            this.btnPurchasing.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnPurchasing.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPurchasing.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPurchasing.OnHoverImage = null;
            this.btnPurchasing.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnPurchasing.OnPressedColor = System.Drawing.Color.Black;
            this.btnPurchasing.Size = new System.Drawing.Size(186, 40);
            this.btnPurchasing.TabIndex = 30;
            this.btnPurchasing.Text = "Purchasing Order";
            this.btnPurchasing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPurchasing.TextOffsetX = 15;
            this.btnPurchasing.Click += new System.EventHandler(this.btnPurchasing_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.AnimationHoverSpeed = 0.07F;
            this.btnRequest.AnimationSpeed = 0.03F;
            this.btnRequest.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnRequest.BorderColor = System.Drawing.Color.Black;
            this.btnRequest.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnRequest.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnRequest.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnRequest.CheckedForeColor = System.Drawing.Color.White;
            this.btnRequest.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnRequest.CheckedImage")));
            this.btnRequest.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequest.FocusedColor = System.Drawing.Color.Empty;
            this.btnRequest.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequest.ForeColor = System.Drawing.Color.White;
            this.btnRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnRequest.Image")));
            this.btnRequest.ImageOffsetX = 10;
            this.btnRequest.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRequest.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnRequest.LineLeft = 5;
            this.btnRequest.Location = new System.Drawing.Point(0, 224);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnRequest.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRequest.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRequest.OnHoverImage = null;
            this.btnRequest.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnRequest.OnPressedColor = System.Drawing.Color.Black;
            this.btnRequest.Size = new System.Drawing.Size(186, 40);
            this.btnRequest.TabIndex = 10;
            this.btnRequest.Text = "Purchase Request";
            this.btnRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRequest.TextOffsetX = 15;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.AnimationHoverSpeed = 0.07F;
            this.btnSupplier.AnimationSpeed = 0.03F;
            this.btnSupplier.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnSupplier.BorderColor = System.Drawing.Color.Black;
            this.btnSupplier.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnSupplier.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnSupplier.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnSupplier.CheckedForeColor = System.Drawing.Color.White;
            this.btnSupplier.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnSupplier.CheckedImage")));
            this.btnSupplier.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FocusedColor = System.Drawing.Color.Empty;
            this.btnSupplier.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageOffsetX = 10;
            this.btnSupplier.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSupplier.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnSupplier.LineLeft = 5;
            this.btnSupplier.Location = new System.Drawing.Point(0, 184);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnSupplier.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSupplier.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSupplier.OnHoverImage = null;
            this.btnSupplier.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnSupplier.OnPressedColor = System.Drawing.Color.Black;
            this.btnSupplier.Size = new System.Drawing.Size(186, 40);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier List";
            this.btnSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSupplier.TextOffsetX = 45;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.AnimationHoverSpeed = 0.07F;
            this.btnDashboard.AnimationSpeed = 0.03F;
            this.btnDashboard.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnDashboard.BorderColor = System.Drawing.Color.Black;
            this.btnDashboard.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnDashboard.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnDashboard.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnDashboard.CheckedImage")));
            this.btnDashboard.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FocusedColor = System.Drawing.Color.Empty;
            this.btnDashboard.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageOffsetX = 10;
            this.btnDashboard.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDashboard.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnDashboard.LineLeft = 5;
            this.btnDashboard.Location = new System.Drawing.Point(0, 144);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnDashboard.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDashboard.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDashboard.OnHoverImage = null;
            this.btnDashboard.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnDashboard.OnPressedColor = System.Drawing.Color.Black;
            this.btnDashboard.Size = new System.Drawing.Size(186, 40);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDashboard.TextOffsetX = 50;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(180)))), ((int)(((byte)(151)))));
            this.lblUsername.Location = new System.Drawing.Point(3, 97);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(180, 18);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(60, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.panel3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.icnLogout);
            this.panel3.Controls.Add(this.lblTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(186, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1192, 67);
            this.panel3.TabIndex = 1;
            // 
            // icnLogout
            // 
            this.icnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnLogout.FlatAppearance.BorderSize = 0;
            this.icnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.icnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnLogout.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.icnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.icnLogout.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.icnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnLogout.IconSize = 40;
            this.icnLogout.Location = new System.Drawing.Point(1142, 17);
            this.icnLogout.Name = "icnLogout";
            this.icnLogout.Size = new System.Drawing.Size(28, 33);
            this.icnLogout.TabIndex = 46;
            this.icnLogout.UseVisualStyleBackColor = false;
            this.icnLogout.Click += new System.EventHandler(this.icnLogout_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 40);
            this.lblTitle.TabIndex = 45;
            this.lblTitle.Text = "Dashboard";
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormLoader.Location = new System.Drawing.Point(186, 67);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(1192, 723);
            this.pnlFormLoader.TabIndex = 46;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1378, 790);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurement System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Panel panel3;
        internal Guna.UI.WinForms.GunaAdvenceButton btnSupplier;
        internal Guna.UI.WinForms.GunaAdvenceButton btnDashboard;
        private System.Windows.Forms.Panel pnlFormLoader;
        internal Guna.UI.WinForms.GunaAdvenceButton btnRequest;
        internal Guna.UI.WinForms.GunaAdvenceButton btnPurchasing;
        internal Guna.UI.WinForms.GunaAdvenceButton btnStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton icnLogout;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblTitle;
        internal Guna.UI.WinForms.GunaAdvenceButton btnUsers;
    }
}
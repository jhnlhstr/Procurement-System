using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcurementSystem.Class.Information;

namespace ProcurementSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //lblUsername.Text = InformationDetails.Username;

            //switch (InformationDetails.Credentials.ToLower())
            //{
            //    case "user":

            //        lblTitle.Text = "";

            //        btnDashboard.Visible = false;
            //        btnSupplier.Visible = false;
            //        btnPurchasing.Visible = false;
            //        btnStatus.Visible = false;

            //        break;

            //    case "admin":

            //        btnDashboard.Visible = false;
            //        //btnSupplier.Visible = false;
            //        btnRequest.Visible = false;
            //        btnPurchasing.Visible = false;
            //        //btnStatus.Visible = false;

            //        break;

            //    default:

            //        lblTitle.Text = "Dashboard";

            //        this.pnlFormLoader.Controls.Clear();
            //        frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //        frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            //        this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            //        frmDashboard_vrb.Show();

            //        break;
            //}

            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Supplier List";
            this.pnlFormLoader.Controls.Clear();
            frmSupplierList frmSupplier_vrb = new frmSupplierList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSupplier_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmSupplier_vrb);
            frmSupplier_vrb.Show();

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Purchase Request";
            this.pnlFormLoader.Controls.Clear();
            frmRequest frmRequest_vrb = new frmRequest() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmRequest_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmRequest_vrb);
            frmRequest_vrb.Show();
        }

        private void btnPurchasing_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Purchasing Order";
            this.pnlFormLoader.Controls.Clear();
            frmPurchasing frmPurchase_vrb = new frmPurchasing() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmPurchase_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmPurchase_vrb);
            frmPurchase_vrb.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Purchasing Status";
            this.pnlFormLoader.Controls.Clear();
            frmStatus frmStatus_vrb = new frmStatus() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmStatus_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmStatus_vrb);
            frmStatus_vrb.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "User Credentials";
            this.pnlFormLoader.Controls.Clear();
            frmUsers frmUsers_vrb = new frmUsers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmUsers_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmUsers_vrb);
            frmUsers_vrb.Show();
        }

        private void icnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

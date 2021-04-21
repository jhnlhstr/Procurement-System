using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ProcurementSystem.Class.DBMethods;

namespace ProcurementSystem
{
    public partial class Main : Form
    {
        ucPO myPO;

        private IconButton currentBtn;
        public Main()
        {
            InitializeComponent();

            toolTip1.SetToolTip(btnMaster, "Master List");
            toolTip1.SetToolTip(btnPO, "Purchasing Order");

            DataTable DtList = new DataTable();
            DtList = DBMethods.GetSupplierMasterList();

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    adgvMasterList.Rows.Add(DtList.Rows[i]["ItemName"].ToString(), DtList.Rows[i]["VendorName"].ToString(), DtList.Rows[i]["Address"].ToString(),
                                            DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(), DtList.Rows[i]["Email"].ToString(),
                                            DtList.Rows[i]["Terms"].ToString());

                    Application.DoEvents();
                }
            }

            btnMaster.IconColor = Color.FromArgb(15, 79, 111);
            btnMaster.BackColor = Color.White;

            tmClock.Start();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconColor = Color.FromArgb(15, 79, 111);
                currentBtn.BackColor = Color.White;

                btnPO.IconColor = Color.White;
                btnPO.BackColor = Color.FromArgb(15, 79, 111);

                pnlMaster.Visible = true;
                pnlMaster.BringToFront();

                //for update view in supplier list
                Refreshh();

                if (myPO != null)
                {
                    myPO.Hide();
                }
            }
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconColor = Color.FromArgb(15, 79, 111);
                currentBtn.BackColor = Color.White;

                btnMaster.IconColor = Color.White;
                btnMaster.BackColor = Color.FromArgb(15, 79, 111);

                pnlMaster.Visible = false;

                if (MessageBox.Show("You want to add new PO?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ucPO myPO = new ucPO();
                    myPO = new ucPO();
                    Controls.Add(myPO);
                    myPO.Location = new Point(85, 9);
                    myPO.Show();
                }
            }
        }

        private void icnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tmClock_Tick(object sender, EventArgs e)
        {
            lblUsername.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DBMethods.InsertSupplierList(txtItem.Text, txtVendor.Text, txtAddress.Text, txtContactPerson.Text, txtContactNumber.Text, txtEmail.Text, txtTerms.Text))
            {
                MessageBox.Show("Insert Supplier Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refreshh();
            }
            else
            {
                MessageBox.Show("Insert Supplier Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Refreshh()
        {
            DataTable DtList = new DataTable();
            DtList = DBMethods.GetSupplierMasterList();
            adgvMasterList.Rows.Clear();

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    adgvMasterList.Rows.Add(DtList.Rows[i]["ItemName"].ToString(), DtList.Rows[i]["VendorName"].ToString(), DtList.Rows[i]["Address"].ToString(),
                                            DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(), DtList.Rows[i]["Email"].ToString(),
                                            DtList.Rows[i]["Terms"].ToString());

                    Application.DoEvents();
                }
            }

            txtItem.Text = string.Empty;
            txtVendor.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTerms.Text = string.Empty;
        }


    }
}

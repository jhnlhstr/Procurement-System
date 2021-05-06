using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FontAwesome.Sharp;
using ProcurementSystem.Class.DBMethods;
using ProcurementSystem.Class.Information;

namespace ProcurementSystem
{
    public partial class Main : Form
    {
        ucPO myPO;
        POEdit myPOEdit;
        ucStatus myStatus;

        private IconButton currentBtn;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnMaster, "Master List");
            toolTip1.SetToolTip(btnPO, "Purchasing Order");
            toolTip1.SetToolTip(icnUser, InformationDetails.Username);

            DataTable DtList = new DataTable();
            DtList = DBMethods.GetSupplierMasterList("");

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    adgvMasterList.Rows.Add(DtList.Rows[i]["ID"].ToString(), DtList.Rows[i]["ItemName"].ToString(), DtList.Rows[i]["VendorName"].ToString(),
                                            DtList.Rows[i]["Address"].ToString(), DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(),
                                            DtList.Rows[i]["Email"].ToString(), DtList.Rows[i]["Terms"].ToString());

                    Application.DoEvents();
                }
            }

            btnMaster.IconColor = Color.FromArgb(15, 79, 111);
            btnMaster.BackColor = Color.White;
            btnMaster.ForeColor = Color.FromArgb(15, 79, 111);

            tmClock.Start();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconColor = Color.FromArgb(15, 79, 111);
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.FromArgb(15, 79, 111);

                btnPO.IconColor = Color.White;
                btnPO.BackColor = Color.FromArgb(15, 79, 111);
                btnPO.ForeColor = Color.White;

                btnStatus.IconColor = Color.White;
                btnStatus.BackColor = Color.FromArgb(15, 79, 111);
                btnStatus.ForeColor = Color.White;

                pnlMaster.Visible = true;
                pnlMaster.BringToFront();

                //for update view in supplier list
                Refreshh();

                if (myPO != null)
                {
                    myPO.Hide();
                }

                if (myPOEdit != null)
                {
                    myPOEdit.Hide();
                }

                if (myStatus != null)
                {
                    myStatus.Hide();
                }

                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

            }
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconColor = Color.FromArgb(15, 79, 111);
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.FromArgb(15, 79, 111);

                btnMaster.IconColor = Color.White;
                btnMaster.BackColor = Color.FromArgb(15, 79, 111);
                btnMaster.ForeColor = Color.White;

                btnStatus.IconColor = Color.White;
                btnStatus.BackColor = Color.FromArgb(15, 79, 111);
                btnStatus.ForeColor = Color.White;

                pnlMaster.Visible = false;

                if (myPO != null)
                {
                    myPO.Hide();
                }
                
                if (myPOEdit != null)
                {
                    myPOEdit.Hide();
                }

                if (myStatus != null)
                {
                    myStatus.Hide();
                }

                if (MessageBox.Show("You want to add new PO?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    myPO = new ucPO();
                    Controls.Add(myPO);
                    myPO.Location = new Point(85, 9);
                    myPO.Show();
                }
                else
                {
                    myPOEdit = new POEdit();
                    Controls.Add(myPOEdit);
                    myPOEdit.Location = new Point(85, 9);
                    myPOEdit.Show();
                }
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.IconColor = Color.FromArgb(15, 79, 111);
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.FromArgb(15, 79, 111);

                btnMaster.IconColor = Color.White;
                btnMaster.BackColor = Color.FromArgb(15, 79, 111);
                btnMaster.ForeColor = Color.White;

                btnPO.IconColor = Color.White;
                btnPO.BackColor = Color.FromArgb(15, 79, 111);
                btnPO.ForeColor = Color.White;

                pnlMaster.Visible = false;

                if (myPO != null)
                {
                    myPO.Hide();
                }

                if (myPOEdit != null)
                {
                    myPOEdit.Hide();
                }

                myStatus = new ucStatus();
                Controls.Add(myStatus);
                myStatus.Location = new Point(85, 9);
                myStatus.Show();

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
            DtList = DBMethods.GetSupplierMasterList("");
            adgvMasterList.Rows.Clear();

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    adgvMasterList.Rows.Add(DtList.Rows[i]["ID"].ToString(), DtList.Rows[i]["ItemName"].ToString(), DtList.Rows[i]["VendorName"].ToString(), 
                                            DtList.Rows[i]["Address"].ToString(), DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(), 
                                            DtList.Rows[i]["Email"].ToString(), DtList.Rows[i]["Terms"].ToString());

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

            lblID.Text = "0";

            btnAdd.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void adgvMasterList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    adgvMasterList.CurrentCell = adgvMasterList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    adgvMasterList.Rows[e.RowIndex].Selected = true;
                    cmList.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void tsSelect_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = DBMethods.GetSupplierMasterList(adgvMasterList.Rows[adgvMasterList.CurrentCell.RowIndex].Cells[0].Value.ToString());

            if (Dt.Rows.Count > 0)
            {
                lblID.Text = Dt.Rows[0]["ID"].ToString();
                txtItem.Text = Dt.Rows[0]["ItemName"].ToString();
                txtVendor.Text = Dt.Rows[0]["VendorName"].ToString();
                txtAddress.Text = Dt.Rows[0]["Address"].ToString();
                txtContactPerson.Text = Dt.Rows[0]["ContactPerson"].ToString();
                txtContactNumber.Text = Dt.Rows[0]["ContactNumber"].ToString();
                txtEmail.Text = Dt.Rows[0]["Email"].ToString();
                txtTerms.Text = Dt.Rows[0]["Terms"].ToString();

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DBMethods.EditSupplierList(lblID.Text, txtItem.Text, txtVendor.Text, txtAddress.Text, txtContactPerson.Text, txtContactNumber.Text, txtEmail.Text, txtTerms.Text))
            {
                MessageBox.Show("Edit Supplier Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refreshh();
            }
            else
            {
                MessageBox.Show("Edit Supplier Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBMethods.DeleteSupplier(lblID.Text))
            {
                MessageBox.Show("Delete Supplier Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refreshh();
            }
            else
            {
                MessageBox.Show("Delete Supplier Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFile.FileName) != ".xls")
                {
                    MessageBox.Show("Please select (.xls) file format only", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DBMethods.InsertBatchSupplierList(openFile.FileName))
                {
                    MessageBox.Show("Insert batch Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refreshh();
                }
                else
                {
                    MessageBox.Show("Insert batch Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

       



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcurementSystem.Class.DBMethods;
using Email = Microsoft.Office.Interop.Outlook;

namespace ProcurementSystem
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();

            pnlList.Visible = true;
            pnlCreate.Visible = false;

            DataTable DtUsers = new DataTable();
            DtUsers = DBMethods.GetUsersCredentialsList();
            dgvUsers.Rows.Clear();

            if (DtUsers.Rows.Count > 0)
            {
                for (int i = 0; i <= DtUsers.Rows.Count - 1; i++)
                {
                    dgvUsers.Rows.Add(new object[] { imageList1.Images[0], DtUsers.Rows[i]["ID"].ToString(), DtUsers.Rows[i]["Username"].ToString(), 
                                                     DtUsers.Rows[i]["Password"].ToString(), DtUsers.Rows[i]["Email"].ToString(), DtUsers.Rows[i]["Active"].ToString(),
                                                     DtUsers.Rows[i]["Active"].ToString() == "True" ? imageList1.Images[3] : imageList1.Images[4], DtUsers.Rows[i]["Rights"].ToString(),
                                                     imageList1.Images[1], imageList1.Images[2] });

                    Application.DoEvents();
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            pnlList.Visible = true;
            pnlCreate.Visible = false;
            SubRefresh();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                switch (dgvUsers.CurrentCell.ColumnIndex)
                {
                    case 6:

                        if (dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[5].Value.ToString().ToLower() == "true")
                        {
                            if (MessageBox.Show("You want to Deactivate this Account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (DBMethods.ActivateUserCredentials(dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[1].Value.ToString(), "False"))
                                {
                                    MessageBox.Show("Deactivate User Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SubRefresh();
                                }
                                else
                                {
                                    MessageBox.Show("Deactivate User Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("You want to Activate this Account?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (DBMethods.ActivateUserCredentials(dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[1].Value.ToString(), "True"))
                                {
                                    MessageBox.Show("Activate User Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SubRefresh();
                                }
                                else
                                {
                                    MessageBox.Show("Activate User Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                        break;


                    case 8:

                        //for edit user
                        if (MessageBox.Show("Are you sure you want to edit this User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DBMethods.UpdateUserCredentials(dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                                                                dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                                                                dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                                                                dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                                                                dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[7].Value.ToString()))
                            {
                                MessageBox.Show("Update User Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SubRefresh();
                            }
                            else
                            {
                                MessageBox.Show("Update User Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        break;

                    case 9:

                        //for delete user
                        if (MessageBox.Show("Are you sure you want to delete this User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DBMethods.DeleteCredentials(dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[1].Value.ToString()))
                            {
                                MessageBox.Show("Delete User Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SubRefresh();
                            }
                            else
                            {
                                MessageBox.Show("Delete User Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        break;

                    default:
                        break;
                }

            }
        }

        void SubRefresh()
        {
            DataTable DtUsers = new DataTable();
            DtUsers = DBMethods.GetUsersCredentialsList();
            dgvUsers.Rows.Clear();

            if (DtUsers.Rows.Count > 0)
            {
                for (int i = 0; i <= DtUsers.Rows.Count - 1; i++)
                {
                    dgvUsers.Rows.Add(new object[] { imageList1.Images[0], DtUsers.Rows[i]["ID"].ToString(), DtUsers.Rows[i]["Username"].ToString(),
                                                     DtUsers.Rows[i]["Password"].ToString(), DtUsers.Rows[i]["Email"].ToString(), DtUsers.Rows[i]["Active"].ToString(),
                                                     DtUsers.Rows[i]["Active"].ToString() == "True" ? imageList1.Images[3] : imageList1.Images[4], DtUsers.Rows[i]["Rights"].ToString(),
                                                     imageList1.Images[1], imageList1.Images[2] });

                    Application.DoEvents();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            pnlList.Visible = false;
            pnlCreate.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtEmail.Text == string.Empty || txtPassword.Text == string.Empty || cmbRights.Text == string.Empty)
            {
                MessageBox.Show("Please input all fields needed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DBMethods.InsertUserCredentials(txtUsername.Text, txtPassword.Text, txtEmail.Text, cmbRights.Text))
            {
                MessageBox.Show("Insert User Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //create draft email for account creation
                Email.Application Outlook;
                Email.MailItem Mail;

                Outlook = new Email.Application();
                Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                Mail.To = txtEmail.Text;

                Mail.Subject = "Procurement System Credentials";

                Mail.HTMLBody = "Hi, <br><br>" +
                                "Kindly see details below for your login credentials on the application <br><br>" +
                                "<b>LOGIN CREDENTIALS DETAILS</b><br>" +
                                "<b>Username :</b>" + " " + txtUsername.Text + "<br>" +
                                "<b>Password :</b>" + " " + txtPassword.Text;
                Mail.Display();

                txtUsername.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cmbRights.SelectedIndex = -1;
            }
        }




        private void dgvUsers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollUsers.Maximum = dgvUsers.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvUsers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollUsers.Maximum = dgvUsers.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollUsers_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvUsers.FirstDisplayedScrollingRowIndex = dgvUsers.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

      




    }

}

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
using Email = Microsoft.Office.Interop.Outlook;
using ProcurementSystem.Class.DBMethods;
using ProcurementSystem.Class.Information;

namespace ProcurementSystem
{
    public partial class frmRequest : Form
    {
        string _poReq;
        string _poReqRef;
        string _prID;
        string rName;
        string rEmail;

        public frmRequest()
        {
            InitializeComponent();

            if (InformationDetails.Credentials.ToLower() == "user")
            {
                btnProposal.Visible = false;
                btnStatsProp.Visible = false;
            }
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            Clearxx();

            pnlRequest.Visible = true;
            pnlProposal.Visible = false;
            pnlApprove.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string rwD = string.Empty;

            if (MessageBox.Show("Send Request Now?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvRequest.Rows.Count > 0)
                {
                    try
                    {
                        //---------for auto pick req number
                        _poReq = DBMethods.RequestNumber(DateTime.Now.ToString("MM")).ToString();
                        _poReqRef = _poReq;
                        //--------insert pr number continous
                        int pId = DBMethods.InsertPRNumber(_poReqRef, DateTime.Now.ToString("MM/dd/yyyy"), 0);

                        switch (_poReq.Length)
                        {
                            case 1:
                                _poReq = "PRF#00" + _poReq + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                                break;

                            case 2:
                                _poReq = "PRF#0" + _poReq + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                                break;

                            case 3:
                                _poReq = "PRF#" + _poReq + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                                break;

                            default:
                                break;
                        }

                        for (int rr = 0; rr <= dgvRequest.Rows.Count - 1; rr++)
                        {
                            DBMethods.InsertPurchaseRequest(txtName.Text, txtDepartment.Text, txtEmail.Text, txtTicketNum.Text,
                                                        cmbPriority.Text, chkPurchase.Checked == true ? "Purchase" : "Service", rbYes.Checked == true ? "1" : "0", txtAccount.Text,
                                                        dgvRequest.Rows[rr].Cells[1].Value.ToString(), dgvRequest.Rows[rr].Cells[2].Value.ToString(),
                                                        dgvRequest.Rows[rr].Cells[3].Value.ToString(), DateTime.Now.ToString("MM/dd/yyyy"), _poReq, pId);

                            rwD += "<tr>" +
                                      "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + dgvRequest.Rows[rr].Cells[1].Value.ToString() + "</td>" +
                                      "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + dgvRequest.Rows[rr].Cells[2].Value.ToString() + "</td>" +
                                      "<td style='border: 1px solid black; border-collapse: collapse'>" + dgvRequest.Rows[rr].Cells[3].Value.ToString() + "</td>" +
                                   "</tr>";
                        }

                        Email.Application Outlook;
                        Email.MailItem Mail;

                        Outlook = new Email.Application();
                        Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        //mcasero@isupportworldwide.com
                        Mail.To = "jbelicano@isupportworldwide.com";
                        Mail.CC = txtEmail.Text;
                        //Mail.BCC = emailBCC;

                        Mail.Subject = "Purchase Request ( " + _poReq + " )";

                        Mail.HTMLBody = "Hi,<br><br>" +
                                           "Please see below details for my request. Thank you! <br><br>" +
                                           "<i>*******(This is auto email from procurement system application)</i><br><br>" +
                                           "<b>Name :</b>" + " " + " " + " " + "" + txtName.Text + "" + "<br>" +
                                           "<b>Department :</b>" + " " + " " + " " + "" + txtDepartment.Text + "" + "<br>" +
                                           "<b>Account :</b>" + " " + " " + " " + "" + txtAccount.Text + "" + "<br>" +
                                           "<b>Priority :</b>" + " " + " " + " " + "" + cmbPriority.Text + "" + "" + "<br><br>" +
                                           "<table style = 'width: 100%'>" +
                                              "<tr>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Item #</th>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Qty</th>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Description</th>" +
                                              "</tr>" +
                                              rwD +
                                           "</table>";
                        //Mail.Display();
                        Mail.Send();

                        MessageBox.Show("Send Request Success?", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clearxx();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in sending request" + Environment.NewLine + ex.Message.ToString(), ex);
                    }
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvRequest.Rows.Add(new object[] { imageList1.Images[2], txtItem.Text, txtQty.Text, txtDescription.Text, imageList1.Images[1] });
            txtItem.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvRequest.CurrentCell.ColumnIndex == 4)
                {
                    dgvRequest.Rows.RemoveAt(dgvRequest.CurrentCell.RowIndex);
                }
            }
        }

        private void bScroll_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvRequest.FirstDisplayedScrollingRowIndex = dgvRequest.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvRequest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScroll.Maximum = dgvRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvRequest_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScroll.Maximum = dgvRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        void Clearxx()
        {
            txtName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTicketNum.Text = string.Empty;
            cmbPriority.SelectedIndex = -1;
            txtAccount.Text = string.Empty;

            txtItem.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtDescription.Text = string.Empty;
            dgvRequest.Rows.Clear();
        }



        //---------------------------------------------------------Proposal---------------------------------------------------------------------------

        private void btnProposal_Click(object sender, EventArgs e)
        {
            ClearxxProp();

            pnlProposal.Visible = true;
            pnlRequest.Visible = false;
            pnlApprove.Visible = false;

            DataTable Dtpr = new DataTable();
            Dtpr =  DBMethods.GetRequestNumber("", "");
            cmbPRFNum.Items.Clear();

            if (Dtpr.Rows.Count > 0)
            {
                for (int rr = 0; rr <= Dtpr.Rows.Count - 1; rr++)
                {
                    cmbPRFNum.Items.Add(Dtpr.Rows[rr]["RPRNum"].ToString());

                    Application.DoEvents();
                }
            }
        }

        private void cmbPRFNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Dtpr = new DataTable();
            Dtpr = DBMethods.GetRequestNumber("info", cmbPRFNum.Text);
            dgvRequestInfo.Rows.Clear();

            if (Dtpr.Rows.Count > 0)
            {
                _prID = Dtpr.Rows[0]["RPRID"].ToString();
                rName = Dtpr.Rows[0]["RName"].ToString();
                rEmail = Dtpr.Rows[0]["REmail"].ToString();

                for (int i = 0; i <= Dtpr.Rows.Count - 1; i++)
                {
                    dgvRequestInfo.Rows.Add(new object[] { imageList1.Images[2], Dtpr.Rows[i]["RItem"].ToString(), Dtpr.Rows[i]["RQty"].ToString(),
                                            Dtpr.Rows[i]["RDesc"].ToString() });

                    Application.DoEvents();
                }
            }
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            dgvProposal.Rows.Add(new object[] { imageList1.Images[2], txtVendorName.Text, txtItemProp.Text, txtQtyProp.Text, txtCostProp.Text, imageList1.Images[1] });
            txtVendorName.Text = string.Empty;
            txtItemProp.Text = string.Empty;
            txtQtyProp.Text = string.Empty;
            txtCostProp.Text = string.Empty;
        }

        private void btnSendProposal_Click(object sender, EventArgs e)
        {
            string rwP = string.Empty;

            if (MessageBox.Show("Draft Email Proposal?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvProposal.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i <= dgvProposal.Rows.Count - 1; i++)
                        {
                            DBMethods.InsertPurchaseProposal(_prID, dgvProposal.Rows[i].Cells[1].Value.ToString(), dgvProposal.Rows[i].Cells[2].Value.ToString(),
                                                                 dgvProposal.Rows[i].Cells[3].Value.ToString(), dgvProposal.Rows[i].Cells[4].Value.ToString());

                            rwP += "<tr>" +
                                     "<td style='border: 1px solid black; border-collapse: collapse'>" + dgvProposal.Rows[i].Cells[1].Value.ToString() + "</td>" +
                                     "<td style='border: 1px solid black; border-collapse: collapse'>" + dgvProposal.Rows[i].Cells[2].Value.ToString() + "</td>" +
                                     "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + dgvProposal.Rows[i].Cells[3].Value.ToString() + "</td>" +
                                     "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + string.Format("{0:#,#}", Convert.ToDecimal(dgvProposal.Rows[i].Cells[4].Value)) + "</td>" +
                                  "</tr>";
                        }

                        Email.Application Outlook;
                        Email.MailItem Mail;

                        Outlook = new Email.Application();
                        Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        Mail.To = rEmail;
                        Mail.CC = "jbelicano@isupportworldwide.com";
                        //mcasero@isupportworldwide.com

                        Mail.Subject = "Purchase Request ( " + cmbPRFNum.Text + " ) For ( Name : " + rName + " )";

                        Mail.HTMLBody = "Hi " + rName + ",<br><br>" +
                                           "Please see below details for my proposal for your request. Thank you! <br><br>" +
                                           "<i>*******(This is auto email from procurement system)</i><br><br>" +
                                           "<table style = 'width: 100%'>" +
                                              "<tr>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Vendor Name #</th>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Item</th>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Quantiy</th>" +
                                                 "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(255,255,0)'>Cost</th>" +
                                              "</tr>" +
                                              rwP +
                                           "</table>";
                        Mail.Display();

                        MessageBox.Show("Draft Email Proposal Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearxxProp();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error in Draft Proposal" + Environment.NewLine + ex.Message.ToString(), ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please add proposal list on the table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvProposal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvProposal.CurrentCell.ColumnIndex == 5)
                {
                    dgvProposal.Rows.RemoveAt(dgvProposal.CurrentCell.RowIndex);
                }
            }
        }

        void ClearxxProp()
        {
            cmbPRFNum.Text = string.Empty;
            dgvRequestInfo.Rows.Clear();

            txtVendorName.Text = string.Empty;
            txtItemProp.Text = string.Empty;
            txtQtyProp.Text = string.Empty;
            txtCostProp.Text = string.Empty;
            dgvProposal.Rows.Clear();
        }

        private void dgvRequestInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollRequest.Maximum = dgvRequestInfo.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvRequestInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollRequest.Maximum = dgvRequestInfo.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollRequest_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvRequestInfo.FirstDisplayedScrollingRowIndex = dgvRequestInfo.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvProposal_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bRequest2.Maximum = dgvProposal.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvProposal_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bRequest2.Maximum = dgvProposal.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bRequest2_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvProposal.FirstDisplayedScrollingRowIndex = dgvProposal.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }


        //---------------------------------------------------------Proposal Status---------------------------------------------------------------------------

        private void btnStatsProp_Click(object sender, EventArgs e)
        {
            pnlProposal.Visible = false;
            pnlRequest.Visible = false;
            pnlApprove.Visible = true;

            DataTable DtStats = new DataTable();
            DtStats = DBMethods.BindProposalStatus("");
            dgvProposalStatus.Rows.Clear();
            txtSearch.Text = string.Empty;

            if (DtStats.Rows.Count > 0)
            {
                for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                {
                    dgvProposalStatus.Rows.Add(new object[] { imageList1.Images[2], DtStats.Rows[ss]["pID"].ToString(), DtStats.Rows[ss]["RPRNum"].ToString(),
                                                              DtStats.Rows[ss]["PVendorName"].ToString(), DtStats.Rows[ss]["PItem"].ToString(), DtStats.Rows[ss]["PQty"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString() == "" ? imageList1.Images[4] : imageList1.Images[3],
                                                              string.Format("{0:#,#}" , Convert.ToDecimal(DtStats.Rows[ss]["PCost"])) });
                    Application.DoEvents();
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable DtStats = new DataTable();
            DtStats = DBMethods.BindProposalStatus(txtSearch.Text);
            dgvProposalStatus.Rows.Clear();

            if (DtStats.Rows.Count > 0)
            {
                for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                {
                    dgvProposalStatus.Rows.Add(new object[] { imageList1.Images[2], DtStats.Rows[ss]["pID"].ToString(), DtStats.Rows[ss]["RPRNum"].ToString(),
                                                              DtStats.Rows[ss]["PVendorName"].ToString(), DtStats.Rows[ss]["PItem"].ToString(), DtStats.Rows[ss]["PQty"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString() == "" ? imageList1.Images[4] : imageList1.Images[3],
                                                              string.Format("{0:#,#}" , Convert.ToDecimal(DtStats.Rows[ss]["PCost"])) });
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show("No Records Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProposalStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvProposalStatus.CurrentCell.ColumnIndex == 7)
                {
                    DataTable DtStats = new DataTable();

                    switch (dgvProposalStatus.Rows[dgvProposalStatus.CurrentCell.RowIndex].Cells[6].Value.ToString().ToLower())
                    {

                        case "":

                            if (MessageBox.Show("Approve Proposal?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (DBMethods.UpdatePurchaseProposal(dgvProposalStatus.Rows[dgvProposalStatus.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Approved"))
                                {
                                    MessageBox.Show("Approve Proposal Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 
                                    DtStats = DBMethods.BindProposalStatus("");
                                    dgvProposalStatus.Rows.Clear();

                                    if (DtStats.Rows.Count > 0)
                                    {
                                        for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                                        {
                                            dgvProposalStatus.Rows.Add(new object[] { imageList1.Images[2], DtStats.Rows[ss]["pID"].ToString(), DtStats.Rows[ss]["RPRNum"].ToString(),
                                                              DtStats.Rows[ss]["PVendorName"].ToString(), DtStats.Rows[ss]["PItem"].ToString(), DtStats.Rows[ss]["PQty"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString() == "" ? imageList1.Images[4] : imageList1.Images[3],
                                                              string.Format("{0:#,#}" , Convert.ToDecimal(DtStats.Rows[ss]["PCost"])) });
                                            Application.DoEvents();
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Approve Proposal Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            break;

                        case "approved":

                            if (MessageBox.Show("Disapprove Proposal?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (DBMethods.UpdatePurchaseProposal(dgvProposalStatus.Rows[dgvProposalStatus.CurrentCell.RowIndex].Cells[1].Value.ToString(), ""))
                                {
                                    MessageBox.Show("Disapprove Proposal Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DtStats = DBMethods.BindProposalStatus("");
                                    dgvProposalStatus.Rows.Clear();

                                    if (DtStats.Rows.Count > 0)
                                    {
                                        for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                                        {
                                            dgvProposalStatus.Rows.Add(new object[] { imageList1.Images[2], DtStats.Rows[ss]["pID"].ToString(), DtStats.Rows[ss]["RPRNum"].ToString(),
                                                              DtStats.Rows[ss]["PVendorName"].ToString(), DtStats.Rows[ss]["PItem"].ToString(), DtStats.Rows[ss]["PQty"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString(),
                                                              DtStats.Rows[ss]["PStatus"].ToString() == "" ? imageList1.Images[4] : imageList1.Images[3],
                                                              string.Format("{0:#,#}" , Convert.ToDecimal(DtStats.Rows[ss]["PCost"])) });
                                            Application.DoEvents();
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Approve Proposal Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void dgvProposalStatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollStatus.Maximum = dgvProposalStatus.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvProposalStatus_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollStatus.Maximum = dgvProposalStatus.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollStatus_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvProposalStatus.FirstDisplayedScrollingRowIndex = dgvProposalStatus.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

      
    }
}

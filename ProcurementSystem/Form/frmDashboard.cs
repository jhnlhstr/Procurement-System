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

namespace ProcurementSystem
{
    public partial class frmDashboard : Form
    {

        int datexx = 0;

        public frmDashboard()
        {
            InitializeComponent();

            //for Total Request Dashboard
            DashboardRequest(DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));

            //for total PO Created
            DashboardPO(DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));

            //for list request
            DashboardListRequest();

            lblDate.Text = DateTime.Now.ToString("MMMM yyyy");
        }

        void DashboardRequest(string month, string year)
        {
            DataTable DtReq = new DataTable();
            DtReq = DBMethods.DashBoardTotalRequest(month, year);

            if (DtReq.Rows.Count > 0)
            {
                lblTotalRequest.Text = DtReq.Rows[0]["TotalRequest"].ToString();
                lblTotalApproveReq.Text = DtReq.Rows[0]["TotalApprove"].ToString();
                lblTotalCancelledReq.Text = DtReq.Rows[0]["TotalCancel"].ToString();

                if (DtReq.Rows[0]["TotalRequest"].ToString() == "0")
                {
                    progressRequest.MaxValue = 1;
                    progressRequest.Value = 0;
                }
                else
                {
                    progressRequest.MaxValue = Convert.ToInt32(DtReq.Rows[0]["TotalRequest"]);
                    progressRequest.Value = Convert.ToInt32(DtReq.Rows[0]["TotalApprove"]);
                }
            }
        }

        void DashboardPO(string month, string year)
        {
            DataTable DtPO = new DataTable();
            DtPO = DBMethods.DashBoardTotalPO(month, year);

            if (DtPO.Rows.Count > 0)
            {
                lblTotalPO.Text = DtPO.Rows[0]["TotalPO"].ToString();
                lblOngoingPO.Text = DtPO.Rows[0]["TotalOngoing"].ToString();
                lblCancelPO.Text = DtPO.Rows[0]["TotalCancelled"].ToString();
                lblDeliveredPO.Text = DtPO.Rows[0]["TotalDelivered"].ToString();

                if (DtPO.Rows[0]["TotalPO"].ToString() == "0")
                {
                    progressPO.MaxValue = 1;
                    progressPO.Value = 0;
                }
                else
                {
                    progressPO.MaxValue = Convert.ToInt32(DtPO.Rows[0]["TotalPO"]);
                    progressPO.Value = Convert.ToInt32(DtPO.Rows[0]["TotalDelivered"]);
                }
            }
        }

        private void dgvListRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvListRequest.CurrentCell.ColumnIndex == 4)
                {
                    if (dgvListRequest.Rows[dgvListRequest.CurrentCell.RowIndex].Cells[3].Value.ToString() == "")
                    {
                        if (MessageBox.Show("Approve Request?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DBMethods.DashboardUpdateListRequest(dgvListRequest.Rows[dgvListRequest.CurrentCell.RowIndex].Cells[0].Value.ToString(), "Approved"))
                            {
                                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //for Total Request Dashboard
                                DashboardRequest(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
                                //for list request
                                DashboardListRequest();
                            }
                            else
                            {
                                MessageBox.Show("Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Re-open this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DBMethods.DashboardUpdateListRequest(dgvListRequest.Rows[dgvListRequest.CurrentCell.RowIndex].Cells[0].Value.ToString(), ""))
                            {
                                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //for Total Request Dashboard
                                DashboardRequest(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
                                //for list request
                                DashboardListRequest();
                            }
                            else
                            {
                                MessageBox.Show("Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                }
            }
        }

        void DashboardListRequest()
        {
            DataTable Dtlist = new DataTable();
            Dtlist = DBMethods.DashboardListRequest();
            dgvListRequest.Rows.Clear();

            if (Dtlist.Rows.Count > 0)
            {
                for (int i = 0; i <= Dtlist.Rows.Count - 1; i++)
                {
                    dgvListRequest.Rows.Add(new object[] { Dtlist.Rows[i]["RPRID"].ToString(), Dtlist.Rows[i]["RPRNum"].ToString(),
                                                           Convert.ToDateTime(Dtlist.Rows[i]["RDate"]).ToString("MMM dd, yyyy"),
                                                            Dtlist.Rows[i]["RStatus"].ToString(), Dtlist.Rows[i]["RStatus"].ToString() == "" ? dashImage.Images[1] : dashImage.Images[0] });

                    Application.DoEvents();
                }
            }
        }

        private void icnNext_Click(object sender, EventArgs e)
        {
            datexx += 1;
            lblDate.Text = DateTime.Now.AddMonths(datexx).ToString("MMMM yyyy");

            DashboardRequest(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
            //for total PO Created
            DashboardPO(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
        }

        private void icnPrevious_Click(object sender, EventArgs e)
        {
            datexx -= 1;
            lblDate.Text = DateTime.Now.AddMonths(datexx).ToString("MMMM yyyy");

            DashboardRequest(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
            //for total PO Created
            DashboardPO(DateTime.Now.AddMonths(datexx).ToString("MM"), DateTime.Now.AddMonths(datexx).ToString("yyyy"));
        }





        private void dgvListRequest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {

                bScrollRequest.Maximum = dgvListRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvListRequest_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {

                bScrollRequest.Maximum = dgvListRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollRequest_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {

                dgvListRequest.FirstDisplayedScrollingRowIndex = dgvListRequest.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        




    }
}

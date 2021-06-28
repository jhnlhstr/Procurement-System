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
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();

            DataTable DtStats = new DataTable();
            DtStats = DBMethods.PurchaseStatusBind("request");
            dgvStatsRequest.Rows.Clear();

            if (DtStats.Rows.Count > 0)
            {
                for (int i = 0; i <= DtStats.Rows.Count - 1; i++)
                {
                    dgvStatsRequest.Rows.Add(new object[] { imageList1.Images[0], DtStats.Rows[i]["PRFID"].ToString(), DtStats.Rows[i]["RPRNum"].ToString(), 
                                                            DtStats.Rows[i]["RName"].ToString(), DtStats.Rows[i]["RAccount"].ToString(), 
                                                            DtStats.Rows[i]["RDesc"].ToString(), Convert.ToDateTime(DtStats.Rows[i]["RDate"]).ToString("MMM dd, yyyy") });

                    Application.DoEvents();
                }
            }
        }

        private void rbRequest_CheckedChanged(object sender, EventArgs e)
        {
            dgvStatsRequest.Visible = true;
            bScrollStats.Visible = true;
            dgvStatsPurchase.Visible = false;
            bScrollPurchase.Visible = false;
            bHScrollPurchase.Visible = false;

            DataTable DtStats = new DataTable();
            DtStats = DBMethods.PurchaseStatusBind("request");
            dgvStatsRequest.Rows.Clear();

            if (DtStats.Rows.Count > 0)
            {
                for (int i = 0; i <= DtStats.Rows.Count - 1; i++)
                {
                    dgvStatsRequest.Rows.Add(new object[] { imageList1.Images[0], DtStats.Rows[i]["PRFID"].ToString(), DtStats.Rows[i]["RPRNum"].ToString(),
                                                            DtStats.Rows[i]["RName"].ToString(), DtStats.Rows[i]["RAccount"].ToString(),
                                                            DtStats.Rows[i]["RDesc"].ToString(), Convert.ToDateTime(DtStats.Rows[i]["RDate"]).ToString("MMM dd, yyyy") });

                    Application.DoEvents();
                }
            }

        }

        private void rbPurchase_CheckedChanged(object sender, EventArgs e)
        {
            dgvStatsRequest.Visible = false;
            bScrollStats.Visible = false;
            dgvStatsPurchase.Visible = true;
            bScrollPurchase.Visible = true;
            bHScrollPurchase.Visible = true;

            RefreshPurchaseView();
        }

        void RefreshPurchaseView()
        {
            DataTable DtPurchase = new DataTable();
            DtPurchase = DBMethods.PurchaseStatusBind("purchase");
            dgvStatsPurchase.Rows.Clear();

            if (DtPurchase.Rows.Count > 0)
            {
                for (int i = 0; i <= DtPurchase.Rows.Count - 1; i++)
                {
                    dgvStatsPurchase.Rows.Add(new object[] { imageList1.Images[0], DtPurchase.Rows[i]["StatsID"].ToString(), DtPurchase.Rows[i]["PRFID"].ToString(),
                                                            DtPurchase.Rows[i]["PONumber"].ToString(), Convert.ToDateTime(DtPurchase.Rows[i]["Purchase_Date"]).ToString("MMM dd, yyyy"),
                                                            DtPurchase.Rows[i]["RAccount"].ToString(), DtPurchase.Rows[i]["PDescription"].ToString(),
                                                            DtPurchase.Rows[i]["PTerms"].ToString(),
                                                            DtPurchase.Rows[i]["PO_Status"].ToString().ToLower() == "ongoing" ? imageList1.Images[2] :
                                                                DtPurchase.Rows[i]["PO_Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] : imageList1.Images[3],
                                                            DtPurchase.Rows[i]["PO_Status"].ToString().ToLower() == "delivered" ?
                                                                Convert.ToDateTime(DtPurchase.Rows[i]["Status_Date"]).ToString("MMM dd, yyyy") : "",
                                                            DtPurchase.Rows[i]["Paid_Date"].ToString() == "" ? "" :
                                                            Convert.ToDateTime(DtPurchase.Rows[i]["Paid_Date"]).ToString("MMM dd, yyyy"),
                                                            DtPurchase.Rows[i]["Bill"].ToString() == "" ? imageList1.Images[3] : imageList1.Images[1],
                                                            DtPurchase.Rows[i]["CountTerms"].ToString(), DtPurchase.Rows[i]["Pbit"].ToString(), DtPurchase.Rows[i]["Bill"].ToString() });

                    Application.DoEvents();
                }
            }
        }

        private void tsCancelled_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(dgvStatsPurchase.Rows[dgvStatsPurchase.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Cancelled"))
                {
                    MessageBox.Show("Cancelled item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPurchaseView();
                }
                else
                {
                    MessageBox.Show("Cancelled item Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tsDelivered_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(dgvStatsPurchase.Rows[dgvStatsPurchase.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Delivered"))
                {
                    MessageBox.Show("Delivered item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPurchaseView();
                }
                else
                {
                    MessageBox.Show("Delivered item Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tsPaid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatusPaid(dgvStatsPurchase.Rows[dgvStatsPurchase.CurrentCell.RowIndex].Cells[1].Value.ToString()))
                {
                    MessageBox.Show("Paid item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPurchaseView();
                }
                else
                {
                    MessageBox.Show("Paid item Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tsBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatusBilled(dgvStatsPurchase.Rows[dgvStatsPurchase.CurrentCell.RowIndex].Cells[1].Value.ToString(), "True"))
                {
                    MessageBox.Show("Bill item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPurchaseView();
                }
                else
                {
                    MessageBox.Show("Bill item Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvStatsPurchase_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dgvStatsPurchase.CurrentCell = dgvStatsPurchase.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvStatsPurchase.Rows[e.RowIndex].Selected = true;
                    cmList.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

      

        private void dgvStatsPurchase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStatsPurchase.Rows[e.RowIndex].Cells[13].Value.ToString() == "False")
            {
                for (int i = 0; i <= dgvStatsPurchase.Columns.Count - 1; i++)
                {
                    dgvStatsPurchase.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.FromArgb(223, 98, 98);
                    dgvStatsPurchase.Rows[e.RowIndex].Cells[i].Style.SelectionForeColor = Color.FromArgb(223, 98, 98);
                }
                
            }
        }



        private void dgvStatsRequest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollStats.Maximum = dgvStatsRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvStatsRequest_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollStats.Maximum = dgvStatsRequest.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollStats_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvStatsRequest.FirstDisplayedScrollingRowIndex = dgvStatsRequest.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }



        private void dgvStatsPurchase_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollPurchase.Maximum = dgvStatsPurchase.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvStatsPurchase_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollPurchase.Maximum = dgvStatsPurchase.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollPurchase_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvStatsPurchase.FirstDisplayedScrollingRowIndex = dgvStatsPurchase.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void bHScrollPurchase_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvStatsPurchase.FirstDisplayedScrollingColumnIndex = dgvStatsPurchase.Columns[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void dgvStatsPurchase_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bHScrollPurchase.Maximum = dgvStatsPurchase.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvStatsPurchase_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bHScrollPurchase.Maximum = dgvStatsPurchase.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

      
    }
}

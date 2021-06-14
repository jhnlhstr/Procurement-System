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

        private void tsCancelled_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(dgvStatsPurchase.Rows[dgvStatsPurchase.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Cancelled"))
                {
                    MessageBox.Show("Cancelled item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable DtPurchase = new DataTable();
                    DtPurchase = DBMethods.PurchaseStatusBind("purchase");
                    dgvStatsPurchase.Rows.Clear();

                    if (DtPurchase.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtPurchase.Rows.Count - 1; i++)
                        {
                            dgvStatsPurchase.Rows.Add(new object[] { imageList1.Images[0], DtPurchase.Rows[i]["StatsID"].ToString(), DtPurchase.Rows[i]["PRFID"].ToString(),
                                                            DtPurchase.Rows[i]["PONumber"].ToString(), Convert.ToDateTime(DtPurchase.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "ongoing" ? imageList1.Images[2] :
                                                                DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] : imageList1.Images[3],
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ?
                                                                Convert.ToDateTime(DtPurchase.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

                            Application.DoEvents();
                        }
                    }
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

                    DataTable DtPurchase = new DataTable();
                    DtPurchase = DBMethods.PurchaseStatusBind("purchase");
                    dgvStatsPurchase.Rows.Clear();

                    if (DtPurchase.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtPurchase.Rows.Count - 1; i++)
                        {
                            dgvStatsPurchase.Rows.Add(new object[] { imageList1.Images[0], DtPurchase.Rows[i]["StatsID"].ToString(), DtPurchase.Rows[i]["PRFID"].ToString(),
                                                            DtPurchase.Rows[i]["PONumber"].ToString(), Convert.ToDateTime(DtPurchase.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "ongoing" ? imageList1.Images[2] :
                                                                DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] : imageList1.Images[3],
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ?
                                                                Convert.ToDateTime(DtPurchase.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

                            Application.DoEvents();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Delivered item Failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void rbRequest_CheckedChanged(object sender, EventArgs e)
        {
            dgvStatsRequest.Visible = true;
            bScrollStats.Visible = true;
            dgvStatsPurchase.Visible = false;
            bScrollPurchase.Visible = false;

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

            DataTable DtPurchase = new DataTable();
            DtPurchase = DBMethods.PurchaseStatusBind("purchase");
            dgvStatsPurchase.Rows.Clear();

            if (DtPurchase.Rows.Count > 0)
            {
                for (int i = 0; i <= DtPurchase.Rows.Count - 1; i++)
                {
                    dgvStatsPurchase.Rows.Add(new object[] { imageList1.Images[0], DtPurchase.Rows[i]["StatsID"].ToString(), DtPurchase.Rows[i]["PRFID"].ToString(),
                                                            DtPurchase.Rows[i]["PONumber"].ToString(), Convert.ToDateTime(DtPurchase.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "ongoing" ? imageList1.Images[2] :
                                                                DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] : imageList1.Images[3],
                                                            DtPurchase.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ?
                                                                Convert.ToDateTime(DtPurchase.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

                    Application.DoEvents();
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





    }
}

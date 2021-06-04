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
            DtStats = DBMethods.PurchaseStatusBind();
            dgvStatus.Rows.Clear();

            if (DtStats.Rows.Count > 0)
            {
                for (int i = 0; i <= DtStats.Rows.Count - 1; i++)
                {
                    dgvStatus.Rows.Add(new object[] { imageList1.Images[0], DtStats.Rows[i]["RPRID"].ToString(), DtStats.Rows[i]["StatsID"].ToString(), DtStats.Rows[i]["Request"].ToString(),
                                                      DtStats.Rows[i]["Request Status"].ToString(), DtStats.Rows[i]["PO"].ToString(),
                                                      Convert.ToDateTime(DtStats.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] :
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "cancelled" ? imageList1.Images[3] : imageList1.Images[2],
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? Convert.ToDateTime(DtStats.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

                    Application.DoEvents();
                }
            }
        }

        private void tsCancelled_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to update this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(dgvStatus.Rows[dgvStatus.CurrentCell.RowIndex].Cells[2].Value.ToString(), "Cancelled"))
                {
                    MessageBox.Show("Cancelled item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable DtStats = new DataTable();
                    DtStats = DBMethods.PurchaseStatusBind();
                    dgvStatus.Rows.Clear();

                    if (DtStats.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtStats.Rows.Count - 1; i++)
                        {
                            dgvStatus.Rows.Add(new object[] { imageList1.Images[0], DtStats.Rows[i]["RPRID"].ToString(), DtStats.Rows[i]["StatsID"].ToString(), DtStats.Rows[i]["Request"].ToString(),
                                                      DtStats.Rows[i]["Request Status"].ToString(), DtStats.Rows[i]["PO"].ToString(),
                                                      Convert.ToDateTime(DtStats.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] :
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "cancelled" ? imageList1.Images[3] : imageList1.Images[2],
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? Convert.ToDateTime(DtStats.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

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
                if (DBMethods.UpdatePurchaseStatus(dgvStatus.Rows[dgvStatus.CurrentCell.RowIndex].Cells[2].Value.ToString(), "Delivered"))
                {
                    MessageBox.Show("Delivered item Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable DtStats = new DataTable();
                    DtStats = DBMethods.PurchaseStatusBind();
                    dgvStatus.Rows.Clear();

                    if (DtStats.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtStats.Rows.Count - 1; i++)
                        {
                            dgvStatus.Rows.Add(new object[] { imageList1.Images[0], DtStats.Rows[i]["RPRID"].ToString(), DtStats.Rows[i]["StatsID"].ToString(), DtStats.Rows[i]["Request"].ToString(),
                                                      DtStats.Rows[i]["Request Status"].ToString(), DtStats.Rows[i]["PO"].ToString(),
                                                      Convert.ToDateTime(DtStats.Rows[i]["Purchase Date"]).ToString("MMM dd, yyyy"),
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? imageList1.Images[4] :
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "cancelled" ? imageList1.Images[3] : imageList1.Images[2],
                                                      DtStats.Rows[i]["PO Status"].ToString().ToLower() == "delivered" ? Convert.ToDateTime(DtStats.Rows[i]["Stats Date"]).ToString("MMM dd, yyyy") : "" });

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

        private void dgvStatus_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dgvStatus.CurrentCell = dgvStatus.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvStatus.Rows[e.RowIndex].Selected = true;
                    cmList.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

     



        private void dgvStatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                
                bScrollStats.Maximum = dgvStatus.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvStatus_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollStats.Maximum = dgvStatus.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollStats_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvStatus.FirstDisplayedScrollingRowIndex = dgvStatus.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

       

       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcurementSystem.Class.DBMethods;

namespace ProcurementSystem
{
    public partial class ucStatus : UserControl
    {
        public ucStatus()
        {
            InitializeComponent();
        }

        private void ucStatus_Load(object sender, EventArgs e)
        {
            adgvStatus.Rows.Clear();
            
            DataTable DtStats = new DataTable();
            DtStats = DBMethods.GetPurchaseOrderStatus(DateTime.Now.ToString("MM/dd/yyyy"));

            if (DtStats.Rows.Count > 0)
            {
                for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                {
                    adgvStatus.Rows.Add(DtStats.Rows[ss]["SID"].ToString(), DtStats.Rows[ss]["Con"].ToString(), DtStats.Rows[ss]["PONumber"].ToString(), 
                                        DtStats.Rows[ss]["VendorName"].ToString(), DtStats.Rows[ss]["PODate"].ToString(), DtStats.Rows[ss]["Stats"].ToString());

                    Application.DoEvents();
                }

                adgvStatus.ClearSelection();
            }
        }

        private void adgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (adgvStatus.Rows[e.RowIndex].Cells[5].Value.ToString().ToLower())
            {
                case "ongoing":

                    if (adgvStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "GOOD")
                    {
                        adgvStatus.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.FromArgb(83, 180, 151);
                    }
                    else
                    {
                        if (adgvStatus.Rows[e.RowIndex].Cells[5].Value.ToString().ToLower() == "ongoing")
                        {
                            adgvStatus.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Red;
                            adgvStatus.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.FromArgb(255, 231, 231);
                            adgvStatus.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.FromArgb(255, 231, 231);
                            adgvStatus.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.FromArgb(255, 231, 231);
                            adgvStatus.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.FromArgb(255, 231, 231);
                        }
                    }

                    break;

                case "on-hold":
                case "cancelled":

                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Red;

                    break;

                case "delivered":

                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.FromArgb(83, 180, 151);
                    adgvStatus.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.FromArgb(226, 246, 240);

                    break;

                default:
                    break;
            }
           
        }

        private void adgvStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (adgvStatus.Rows[e.RowIndex].Cells[5].Value.ToString().ToLower())
            {
                case "ongoing":
                    
                    if (adgvStatus.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper() == "WARNING")
                    {
                        adgvStatus.Rows[e.RowIndex].Cells[2].Style.SelectionBackColor = Color.FromArgb(255, 231, 231);
                        adgvStatus.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.FromArgb(255, 231, 231);
                        adgvStatus.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.FromArgb(255, 231, 231);
                        adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionBackColor = Color.FromArgb(255, 231, 231);
                        adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionForeColor = Color.FromArgb(83, 180, 151);
                    }

                    break;

                case "on-hold":
                case "cancelled":

                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionForeColor = Color.Red;

                    break;

                case "delivered":

                    adgvStatus.Rows[e.RowIndex].Cells[2].Style.SelectionBackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionBackColor = Color.FromArgb(226, 246, 240);
                    adgvStatus.Rows[e.RowIndex].Cells[5].Style.SelectionForeColor = Color.FromArgb(83, 180, 151);

                    break;

                default:
                    break;
            }
        }

        private void adgvStatus_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    adgvStatus.CurrentCell = adgvStatus.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    adgvStatus.Rows[e.RowIndex].Selected = true;
                    cmStats.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void tsHold_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update status?", "Purchase Order Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(adgvStatus.Rows[adgvStatus.CurrentCell.RowIndex].Cells[0].Value.ToString(), "On-Hold"))
                {
                    MessageBox.Show("Update Status Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refreshhxxx();
                }
            }
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update status?", "Purchase Order Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(adgvStatus.Rows[adgvStatus.CurrentCell.RowIndex].Cells[0].Value.ToString(), "Cancelled"))
                {
                    MessageBox.Show("Update Status Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refreshhxxx();
                }
            }
        }

        private void tsDelivered_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update status?", "Purchase Order Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.UpdatePurchaseStatus(adgvStatus.Rows[adgvStatus.CurrentCell.RowIndex].Cells[0].Value.ToString(), "Delivered"))
                {
                    MessageBox.Show("Update Status Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refreshhxxx();
                }
            }
        }

        void Refreshhxxx()
        {
            adgvStatus.Rows.Clear();

            DataTable DtStats = new DataTable();
            DtStats = DBMethods.GetPurchaseOrderStatus(DateTime.Now.ToString("MM/dd/yyyy"));

            if (DtStats.Rows.Count > 0)
            {
                for (int ss = 0; ss <= DtStats.Rows.Count - 1; ss++)
                {
                    adgvStatus.Rows.Add(DtStats.Rows[ss]["SID"].ToString(), DtStats.Rows[ss]["Con"].ToString(), DtStats.Rows[ss]["PONumber"].ToString(),
                                        DtStats.Rows[ss]["VendorName"].ToString(), DtStats.Rows[ss]["PODate"].ToString(), DtStats.Rows[ss]["Stats"].ToString());

                    Application.DoEvents();
                }

                adgvStatus.ClearSelection();
            }
        }




    }
}

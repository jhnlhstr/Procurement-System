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
using ProcurementSystem.Class.DBMethods;

namespace ProcurementSystem
{
    public partial class frmSupplierList : Form
    {
        public frmSupplierList()
        {
            InitializeComponent();

            DataTable DtList = new DataTable();
            DtList = DBMethods.GetSupplierMasterList("");
            dgvSupplier.Rows.Clear();

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    dgvSupplier.Rows.Add(new object[] { imageList1.Images[0], DtList.Rows[i]["ID"].ToString(), DtList.Rows[i]["ItemName"].ToString(),
                    DtList.Rows[i]["VendorName"].ToString(), DtList.Rows[i]["Address"].ToString(), DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(),
                    DtList.Rows[i]["Email"].ToString(), DtList.Rows[i]["Terms"].ToString(), DtList.Rows[i]["TIN"].ToString(), 
                    DtList.Rows[i]["Active"].ToString() == "True" ? imageList1.Images[3] : imageList1.Images[4], imageList1.Images[1], DtList.Rows[i]["Active"].ToString() });

                    Application.DoEvents();
                }

                dgvSupplier.ClearSelection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save Supplier?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBMethods.InsertSupplierList(txtItem.Text, txtVendor.Text, txtAddress.Text, txtContactPerson.Text, txtContactNumber.Text, txtEmail.Text, txtTerms.Text, txtTIN.Text))
                {
                    MessageBox.Show("Save Supplier Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    txtItem.Text = string.Empty;
                    txtVendor.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtContactPerson.Text = string.Empty;
                    txtContactNumber.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtTerms.Text = string.Empty;
                    txtTIN.Text = string.Empty;
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Path.GetExtension(openFile.FileName) != ".xls")
                    {
                        MessageBox.Show("Please select (.xls) file format only", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (DBMethods.InsertBatchSupplierList(openFile.FileName))
                    {
                        MessageBox.Show("Upload file Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in uploading batch file" + Environment.NewLine + ex.Message.ToString(), ex);
                }
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                switch (dgvSupplier.CurrentCell.ColumnIndex)
                {
                    case 10:

                        //for edit status
                        
                        if (MessageBox.Show("Are you sure you want to edit status?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[12].Value.ToString() == "True")
                            {
                                if (DBMethods.EditStatusSupplier(dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[1].Value.ToString(), "False"))
                                {
                                    MessageBox.Show("Edit Status Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                }
                            }
                            else
                            {
                                if (DBMethods.EditStatusSupplier(dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[1].Value.ToString(), "True"))
                                {
                                    MessageBox.Show("Edit Status Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                }
                            }
                        }


                        break;

                    case 11:

                        //for edit supplier

                        if (MessageBox.Show("Are you sure you want to edit this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DBMethods.EditSupplierList(dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[8].Value.ToString(),
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[9].Value == null ? "" :
                                                           dgvSupplier.Rows[dgvSupplier.CurrentCell.RowIndex].Cells[9].Value.ToString()))
                            {
                                MessageBox.Show("Edit Supplier Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }


                     
                        break;

                    default:
                        break;
                }

            }
        }

        void LoadData()
        {
            DataTable DtList = new DataTable();
            DtList = DBMethods.GetSupplierMasterList("");
            dgvSupplier.Rows.Clear();

            if (DtList.Rows.Count > 0)
            {
                for (int i = 0; i <= DtList.Rows.Count - 1; i++)
                {
                    dgvSupplier.Rows.Add(new object[] { imageList1.Images[0], DtList.Rows[i]["ID"].ToString(), DtList.Rows[i]["ItemName"].ToString(),
                    DtList.Rows[i]["VendorName"].ToString(), DtList.Rows[i]["Address"].ToString(), DtList.Rows[i]["ContactPerson"].ToString(), DtList.Rows[i]["ContactNumber"].ToString(),
                    DtList.Rows[i]["Email"].ToString(), DtList.Rows[i]["Terms"].ToString(), DtList.Rows[i]["TIN"].ToString(),
                    DtList.Rows[i]["Active"].ToString() == "True" ? imageList1.Images[3] : imageList1.Images[4], imageList1.Images[1], DtList.Rows[i]["Active"].ToString() });

                    Application.DoEvents();
                }

                dgvSupplier.ClearSelection();
            }
        }

        private void bScroll_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvSupplier.FirstDisplayedScrollingRowIndex = dgvSupplier.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
            
        }

        private void dgvTest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScroll.Maximum = dgvSupplier.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvTest_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScroll.Maximum = dgvSupplier.RowCount - 1;
            }
            catch(Exception)
            {

            }
        }



        private void dgvSupplier_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bHScroll.Maximum = dgvSupplier.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvSupplier_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bHScroll.Maximum = dgvSupplier.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bHScroll_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvSupplier.FirstDisplayedScrollingColumnIndex = dgvSupplier.Columns[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }
    }
}

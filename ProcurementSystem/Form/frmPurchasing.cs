using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Email = Microsoft.Office.Interop.Outlook;
using ProcurementSystem.Class.DBMethods;

namespace ProcurementSystem
{
    public partial class frmPurchasing : Form
    {
        decimal tphp = 0;
        decimal tphpEdit = 0;
        string prfNumber = string.Empty;
        string accountxx = string.Empty;

        string edit_MID = string.Empty;
        string edit_PRFID = string.Empty;
        public frmPurchasing()
        {
            InitializeComponent();

            DataTable Dt = new DataTable();
            DataTable DtDept = new DataTable();
            DataTable DtPRF = new DataTable();

            Dt = DBMethods.GetSupplierMasterList("");
            DtDept = DBMethods.GetDepartmentList();
            DtPRF = DBMethods.GetRequestNumber("", "");

            cmbPRFPO.Items.Clear();
            cmbVendorPO.Items.Clear();
            cmbDepartmentPO.Items.Clear();

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbVendorPO.Items.Add(Dt.Rows[i]["VendorName"].ToString());
                }
            }

            if (DtDept.Rows.Count > 0)
            {
                for (int y = 0; y <= DtDept.Rows.Count - 1; y++)
                {
                    cmbDepartmentPO.Items.Add(DtDept.Rows[y]["Dept"].ToString());
                }
            }

            if (DtPRF.Rows.Count > 0)
            {
                for (int x = 0; x <= DtPRF.Rows.Count - 1; x++)
                {
                    cmbPRFPO.Items.Add(DtPRF.Rows[x]["RPRNum"].ToString());
                }
            }

        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            Clearxx();
            pnlPO.Visible = true;
            pnlPOEdit.Visible = false;
            DataTable Dt = new DataTable();
            DataTable DtDept = new DataTable();
            DataTable DtPRF = new DataTable();

            Dt = DBMethods.GetSupplierMasterList("");
            DtDept = DBMethods.GetDepartmentList();
            DtPRF = DBMethods.GetRequestNumber("", "");

            cmbPRFPO.Items.Clear();
            cmbVendorPO.Items.Clear();
            cmbDepartmentPO.Items.Clear();

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbVendorPO.Items.Add(Dt.Rows[i]["VendorName"].ToString());
                }
            }

            if (DtDept.Rows.Count > 0)
            {
                for (int y = 0; y <= DtDept.Rows.Count - 1; y++)
                {
                    cmbDepartmentPO.Items.Add(DtDept.Rows[y]["Dept"].ToString());
                }
            }

            if (DtPRF.Rows.Count > 0)
            {
                for (int x = 0; x <= DtPRF.Rows.Count - 1; x++)
                {
                    cmbPRFPO.Items.Add(DtPRF.Rows[x]["RPRNum"].ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkDetails.Checked)
            {
                dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, "", "", "", "", imageList1.Images[1] });
            }
            else
            {
                switch (cmbUOMPO.Text.ToLower())
                {
                    case "charges/percent":

                        dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, "", cmbUOMPO.Text, 
                                                                "", Math.Floor(tphp * Convert.ToDecimal(txtUnitPrice.Text)), imageList1.Images[1] });
                        tphp += Math.Floor(tphp * Convert.ToDecimal(txtUnitPrice.Text));

                        lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);

                        break;

                    case "charges/fixed":

                        dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, "", cmbUOMPO.Text, "", txtUnitPrice.Text, imageList1.Images[1] });
                        tphp += Convert.ToDecimal(txtUnitPrice.Text);

                        lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);

                        break;

                    case "discount/percent":

                        dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, "", cmbUOMPO.Text, "", 
                                                                 Math.Floor(tphp * Convert.ToDecimal(txtUnitPrice.Text)), imageList1.Images[1] });
                        tphp -= Math.Floor(tphp * Convert.ToDecimal(txtUnitPrice.Text));

                        lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);

                        break;

                    case "discount/fixed":
                        
                        dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, "", cmbUOMPO.Text, "", txtUnitPrice.Text, imageList1.Images[1] });
                        tphp -= Convert.ToDecimal(txtUnitPrice.Text);

                        lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);

                        break;

                    default:

                        dgvPurchaseOrder.Rows.Add(new object[] { imageList1.Images[0], txtDescription.Text, txtQuantity.Text, cmbUOMPO.Text, 
                                                                txtUnitPrice.Text, Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtUnitPrice.Text), imageList1.Images[1] });

                        //for total computation
                        tphp += Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtUnitPrice.Text);
                        lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);

                        break;
                }
            }

            txtDescription.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            cmbUOMPO.SelectedIndex = -1;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string _peza = string.Empty;
            string _poNum = string.Empty;
            string _poRef = string.Empty;

            try
            {
                if (cmbPRFPO.Text == string.Empty)
                {
                    MessageBox.Show("Please select PRF number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPRFPO.Focus();
                    return;
                }

                if (cmbVendorPO.Text == string.Empty)
                {
                    MessageBox.Show("Please select vendor name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbVendorPO.Focus();
                    return;
                }

                if (DBMethods.CheckingTIN(cmbVendorPO.Text) == string.Empty)
                {
                    MessageBox.Show("Please input TIN ID for this Vendor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbDepartmentPO.Text == string.Empty || txtRequestor.Text == string.Empty)
                {
                    MessageBox.Show("Please fill-up all details needed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rbPeza.Checked)
                {
                    _peza = "ZERO-RATED (PEZA)";
                }
                else
                {
                    _peza = "VAT-INCLUSIVE";
                }

                if (fbDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderpath = fbDialog.SelectedPath + "\\" + "Purchasing Order";

                    if (!(Directory.Exists(folderpath)))
                    {
                        Directory.CreateDirectory(folderpath);
                    }

                    //---------for auto pick po number
                    _poNum = DBMethods.PONumber(DateTime.Now.ToString("MM")).ToString();
                    _poRef = _poNum;

                    switch (_poNum.Length)
                    {
                        case 1:
                            _poNum = "P0#00" + _poNum + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                            break;

                        case 2:
                            _poNum = "P0#0" + _poNum + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                            break;

                        case 3:
                            _poNum = "P0#" + _poNum + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yy");
                            break;

                        default:
                            break;
                    }

                    Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 2, 2, 20, 2);
                    PdfWriter pdfWrite = PdfWriter.GetInstance(pdfDoc, new FileStream(folderpath + "\\" + _poNum + ".pdf", FileMode.Create));
                    PdfPCell pdfCell = null;

                    iTextSharp.text.Image companylogo = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "isupport.png");
                    iTextSharp.text.Image signature = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "signature.png");

                    pdfDoc.Open();
                    PdfPTable pdfTable = new PdfPTable(9);
                    pdfTable.WidthPercentage = 90f;
                    //BaseColor border1 = new BaseColor(0, 51, 92);
                    //BaseColor border2 = new BaseColor(194, 194, 196);

                    iTextSharp.text.Font fonthead = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                    iTextSharp.text.Font fontheadBold = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK));

                    iTextSharp.text.Font fontRed = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.RED));
                    iTextSharp.text.Font POFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 12.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY));

                    iTextSharp.text.Font PezaFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 9.0F, iTextSharp.text.Font.BOLD, BaseColor.RED));
                    iTextSharp.text.Font TotalFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 9.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                    iTextSharp.text.Font TotalFont2 = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK));
                    iTextSharp.text.Font subjectBill = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED));

                    iTextSharp.text.Font footerFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 5.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                    iTextSharp.text.Font footerRed = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLD, BaseColor.RED));

                    ////---------------------------------------------------
                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 2;
                    pdfCell.Image = companylogo;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(_poNum, POFont)));
                    pdfCell.Colspan = 7;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 2;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("AMMEX ISUPPORT INTERNATIONAL CORPORATION", fonthead)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Purchase Order #", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 2;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(_poNum, fontRed)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 2;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("6th, 9th and 10th Floor Cyberscape Alpha Building, Garnet & Sapphire Road", fonthead)));
                    pdfCell.Colspan = 9;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Ortigas Center, Pasig City 1605", fonthead)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Purchase Order Date", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 2;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(DateTime.Now.ToString("dd-MMM-yyyy"), fontRed)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 2;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("T: (02) 656 2061 loc.103", fonthead)));
                    pdfCell.Colspan = 9;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                    pdfCell.Colspan = 9;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    //----------------------------------------------------------- supplier details -----------------------------------------------------------------------

                    DataTable DtVendor = new DataTable();
                    DtVendor = DBMethods.GetVendorName(cmbVendorPO.Text);

                    if (DtVendor.Rows.Count > 0)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            pdfCell = new PdfPCell(new Phrase(new Chunk(DtVendor.Columns[i].ColumnName.ToString(), fonthead)));
                            pdfCell.Colspan = 1;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk(DtVendor.Rows[0][i].ToString(), fonthead)));
                            pdfCell.Colspan = 8;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfTable.AddCell(pdfCell);
                        }

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Billed to", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("AMMEX ISUPPORT INTERNATIONAL CORPORATION", fontheadBold)));
                        pdfCell.Colspan = 8;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfCell.BorderWidthBottom = 0.5F;
                        pdfTable.AddCell(pdfCell);


                        pdfCell = new PdfPCell(new Phrase(new Chunk("Delivery Address", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("6flr Robinsons Cyberscape Alpha Building, Sapphire & Garnet Rd. Ortigas Center, Pasig City", fonthead)));
                        pdfCell.Colspan = 8;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfCell.BorderWidthBottom = 0.5F;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                    }


                    //------------------------------------------------------------------- Item Column -------------------------------------------------------------------------

                    string[] colxx = { "Description", "Qty", "UOM", "Unit Price", "Total" };

                    for (int i = 0; i <= colxx.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                            pdfCell.Colspan = 3;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfCell.BorderWidthLeft = 0.5F;
                            pdfCell.BorderWidthTop = 0.5F;
                            pdfCell.BorderWidthRight = 0.5F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);
                        }
                        else if (i == 3 || i == 4)
                        {
                            pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                            pdfCell.Colspan = 2;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0.5F;
                            pdfCell.BorderWidthRight = 0.5F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);
                        }
                        else
                        {
                            pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                            pdfCell.Colspan = 1;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0.5F;
                            pdfCell.BorderWidthRight = 0.5F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);
                        }
                    }

                    //------------------------------------------------------------------- Item Description -------------------------------------------------------------------------

                    if (dgvPurchaseOrder.Rows.Count > 0)
                    {
                        for (int rr = 0; rr <= dgvPurchaseOrder.Rows.Count - 1; rr++)
                        {
                            if (dgvPurchaseOrder.Rows[rr].Cells[2].Value.ToString() == "")
                            {
                                if (dgvPurchaseOrder.Rows[rr].Cells[3].Value.ToString() == "charges/percent" ||
                                   dgvPurchaseOrder.Rows[rr].Cells[3].Value.ToString() == "charges/fixed" ||
                                   dgvPurchaseOrder.Rows[rr].Cells[3].Value.ToString() == "discount/percent" ||
                                   dgvPurchaseOrder.Rows[rr].Cells[3].Value.ToString() == "discount/fixed")
                                {
                                    //for charges or discount
                                    for (int cc = 1; cc <= dgvPurchaseOrder.Columns.Count - 2; cc++)
                                    {
                                        if (cc == 1)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPurchaseOrder.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                            pdfCell.Colspan = 3;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0.5F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 0;
                                            pdfTable.AddCell(pdfCell);
                                        }
                                        else if (cc == 5)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", Convert.ToDecimal(dgvPurchaseOrder.Rows[rr].Cells[cc].Value)), fontheadBold)));
                                            pdfCell.Colspan = 2;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);
                                        }
                                        else
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                            if (cc == 4)
                                            {
                                                pdfCell.Colspan = 2;
                                            }
                                            else
                                            {
                                                pdfCell.Colspan = 1;
                                            }
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);
                                            
                                        }

                                        Application.DoEvents();
                                    }

                                }
                                else
                                {
                                    //for details only
                                    for (int cc = 1; cc <= dgvPurchaseOrder.Columns.Count - 2; cc++)
                                    {
                                        if (cc == 1)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPurchaseOrder.Rows[rr].Cells[cc].Value.ToString(), fonthead)));
                                            pdfCell.Colspan = 3;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0.5F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 0;
                                            pdfTable.AddCell(pdfCell);
                                        }
                                        else if (cc == 4 || cc == 5)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                            pdfCell.Colspan = 2;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);
                                        }
                                        else
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                            pdfCell.Colspan = 1;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);
                                        }

                                        Application.DoEvents();
                                    }
                                }

                            }
                            else
                            {
                                for (int cc = 1; cc <= dgvPurchaseOrder.Columns.Count - 2; cc++)
                                {
                                    if (cc == 1)
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPurchaseOrder.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                        pdfCell.Colspan = 3;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0.5F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 0;
                                        pdfTable.AddCell(pdfCell);
                                    }
                                    else if (cc == 4 || cc == 5)
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", Convert.ToDecimal(dgvPurchaseOrder.Rows[rr].Cells[cc].Value)), fontheadBold)));
                                        pdfCell.Colspan = 2;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 1;
                                        pdfTable.AddCell(pdfCell);
                                    }
                                    else
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPurchaseOrder.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                        pdfCell.Colspan = 1;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 1;
                                        pdfTable.AddCell(pdfCell);
                                    }

                                    Application.DoEvents();
                                }
                            }

                            Application.DoEvents();
                        }

                        //for black space
                        for (int bb = 0; bb <= 1; bb++)
                        {
                            for (int ss = 0; ss <= 4; ss++)
                            {
                                if (ss == 0)
                                {
                                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontheadBold)));
                                    pdfCell.Colspan = 3;
                                    pdfCell.BorderWidthBottom = 0.5F;
                                    pdfCell.BorderWidthLeft = 0.5F;
                                    pdfCell.BorderWidthTop = 0F;
                                    pdfCell.BorderWidthRight = 0.5F;
                                    pdfCell.HorizontalAlignment = 1;
                                    pdfTable.AddCell(pdfCell);
                                }
                                else if (ss == 3 || ss == 4)
                                {
                                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                                    pdfCell.Colspan = 2;
                                    pdfCell.BorderWidthBottom = 0.5F;
                                    pdfCell.BorderWidthLeft = 0F;
                                    pdfCell.BorderWidthTop = 0F;
                                    pdfCell.BorderWidthRight = 0.5F;
                                    pdfCell.HorizontalAlignment = 1;
                                    pdfTable.AddCell(pdfCell);
                                }
                                else
                                {
                                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                                    pdfCell.Colspan = 1;
                                    pdfCell.BorderWidthBottom = 0.5F;
                                    pdfCell.BorderWidthLeft = 0F;
                                    pdfCell.BorderWidthTop = 0F;
                                    pdfCell.BorderWidthRight = 0.5F;
                                    pdfCell.HorizontalAlignment = 1;
                                    pdfTable.AddCell(pdfCell);
                                }

                                Application.DoEvents();
                            }

                            Application.DoEvents();
                        }

                        //---------------------------for subtotal rows

                        pdfCell = new PdfPCell(new Phrase(new Chunk(_peza, PezaFont)));
                        pdfCell.Colspan = 5;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("TOTAL PHP", TotalFont)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(lblTotalphp.Text, TotalFont2)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                    }

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Prepared By:", fonthead)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Reviewed By:", fonthead)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Approved By:", fonthead)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.Image = signature;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 8;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Merle Ann Casero", fonthead)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0.5F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0.5F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Ernest Joseph Gomez", fonthead)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0.5F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    //-------------------------------------footer-------------------------------------------------------

                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                    pdfCell.Colspan = 9;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                    pdfCell.Colspan = 9;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 1F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("PENALTY CLAUSE:", footerRed)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 1F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);



                    pdfCell = new PdfPCell(new Phrase(new Chunk("Should the Seller fail to make delivery on time as stipulated in the Contract," +
                                                                " AIIC reserves the right to cancel this PO without", footerFont)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 1F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Requestor", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(txtRequestor.Text + " / " + cmbDepartmentPO.Text, TotalFont2)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0.5F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);


                    pdfCell = new PdfPCell(new Phrase(new Chunk("liability and to charge Supplier with any loss incurred as a result of Supplier's" +
                                                                " failure to make the delivery within the delivery", footerFont)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 1F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Client", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(accountxx, TotalFont2)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0.5F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);


                    pdfCell = new PdfPCell(new Phrase(new Chunk("schedule specified or charge a penalty of 0.1% of the total price for every day of breach" +
                                                                " of the delivery schedule by the Supplier.", footerFont)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 1F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk("Subject for Billing", fonthead)));
                    pdfCell.Colspan = 1;
                    pdfCell.BorderWidthBottom = 0F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(chkSubject.Checked == true ? "Yes" : "No", subjectBill)));
                    pdfCell.Colspan = 2;
                    pdfCell.BorderWidthBottom = 0.5F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 1;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontRed)));
                    pdfCell.Colspan = 6;
                    pdfCell.BorderWidthBottom = 1F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 1F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontRed)));
                    pdfCell.Colspan = 3;
                    pdfCell.BorderWidthBottom = 1F;
                    pdfCell.BorderWidthLeft = 0F;
                    pdfCell.BorderWidthTop = 0F;
                    pdfCell.BorderWidthRight = 0F;
                    pdfCell.HorizontalAlignment = 0;
                    pdfTable.AddCell(pdfCell);

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    //for save order list
                    int pId = DBMethods.InsertPODetails(cmbVendorPO.Text, _poRef, DateTime.Now.ToString("MM/dd/yyyy"), 0);

                    if (dgvPurchaseOrder.Rows.Count > 0)
                    {
                        DBMethods.InsertPOStatus(pId, DateTime.Now.ToString("MM/dd/yyyy"));

                        for (int p = 0; p <= dgvPurchaseOrder.Rows.Count - 1; p++)
                        {
                            DBMethods.InsertPOList(prfNumber, pId, _poNum, dgvPurchaseOrder.Rows[p].Cells[1].Value.ToString(), dgvPurchaseOrder.Rows[p].Cells[2].Value.ToString(),
                                                   dgvPurchaseOrder.Rows[p].Cells[3].Value.ToString(), dgvPurchaseOrder.Rows[p].Cells[4].Value.ToString(),
                                                   dgvPurchaseOrder.Rows[p].Cells[5].Value.ToString());
                        }
                    }


                    //generation for draft email
                    DataTable DtReq = new DataTable();
                    DataTable DtProposalx = new DataTable();

                    string reqDetails = string.Empty;
                    string reqText = string.Empty;
                    string propText = string.Empty;

                    DtReq = DBMethods.ApprovalDetailsEmail("Request", prfNumber);

                    if (DtReq.Rows.Count > 0)
                    {
                        reqDetails = "<b>PRF Number :</b>" + " " + " " + " " + "" + cmbPRFPO.Text + "" + "<br>" +
                                     "<b>Name :</b>" + " " + " " + " " + "" + DtReq.Rows[0]["RName"].ToString() + "" + "<br>" +
                                     "<b>Department :</b>" + " " + " " + " " + "" + DtReq.Rows[0]["RDept"].ToString() + "" + "<br>" +
                                     "<b>Account :</b>" + " " + " " + " " + "" + accountxx + "" + "<br>" +
                                     "<b>Date :</b>" + " " + " " + " " + "" + Convert.ToDateTime(DtReq.Rows[0]["RDate"]).ToString("MMM dd, yyyy") + "" + "<br>";

                        for (int i = 0; i <= DtReq.Rows.Count - 1; i++)
                        {
                            reqText += "<tr>" +
                                          "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + DtReq.Rows[i]["RItem"].ToString() + "</td>" +
                                          "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + DtReq.Rows[i]["RQty"].ToString() + "</td>" +
                                          "<td style='border: 1px solid black; border-collapse: collapse'>" + DtReq.Rows[i]["RDesc"].ToString() + "</td>" +
                                       "</tr>";

                            Application.DoEvents();
                        }
                    }

                    DtProposalx = DBMethods.ApprovalDetailsEmail("Proposal", prfNumber);

                    if (DtProposalx.Rows.Count > 0)
                    {
                        for (int p = 0; p <= DtProposalx.Rows.Count - 1; p++)
                        {
                            propText += "<tr>" +
                                           "<td style='border: 1px solid black; border-collapse: collapse'>" + DtProposalx.Rows[p]["PVendorName"].ToString() + "</td>" +
                                           "<td style='border: 1px solid black; border-collapse: collapse'>" + DtProposalx.Rows[p]["PItem"].ToString() + "</td>" +
                                           "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + DtProposalx.Rows[p]["PQty"].ToString() + "</td>" +
                                           "<td style='border: 1px solid black; border-collapse: collapse; text-align: center'>" + string.Format("{0:#,#}", DtProposalx.Rows[p]["PCost"]) + "</td>" +
                                        "</tr>";

                            Application.DoEvents();
                        }
                    }

                    Email.Application Outlook;
                    Email.MailItem Mail;

                    Outlook = new Email.Application();
                    Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    Mail.To = "";
                    Mail.CC = "";

                    Mail.Attachments.Add(folderpath + "\\" + _poNum + ".pdf");

                    Mail.Subject = "Purchase Order Approval Request ( " + _poNum + " )";

                    Mail.HTMLBody = "Hi,<br><br>" +
                                       "Please see below details for PO Approval and Full details of the request. Thank you! <br><br>" +
                                       "<i>*******(This is auto email from procurement system application)</i><br><br>" +
                                       "<b>REQUEST DETAILS</b><br><br>" +
                                          reqDetails +
                                       "<br><br>" +
                                       "<table style = 'width: 100%'>" +
                                          "<tr>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Item #</th>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Qty</th>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Description</th>" +
                                          "</tr>" +
                                          reqText +
                                       "</table><br><br>" +

                                       "<b>PROPOSAL DETAILS</b><br><br>" +
                                       "<table style = 'width: 100%'>" +
                                          "<tr>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Vendor Name</th>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Item</th>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Qty</th>" +
                                             "<th style='border: 1px solid black; border-collapse: collapse; background: rgb(24, 30, 54); font-color: white'>Cost</th>" +
                                          "</tr>" +
                                          propText +
                                       "</table><br><br>";
                    Mail.Display();

                    MessageBox.Show("Export PDF completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tphp = 0;
                    Clearxx();
                    //Process.Start(folderpath + "\\" + _poNum + ".pdf");

                } //folder dialgog

            }
            catch(Exception ex)
            {
                throw new Exception("Error in creating PDF" + Environment.NewLine + ex.Message.ToString(), ex);
            }


        }

        private void dgvPurchaseOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvPurchaseOrder.CurrentCell.ColumnIndex == 6)
                {
                    if (dgvPurchaseOrder.Rows[dgvPurchaseOrder.CurrentCell.RowIndex].Cells[3].Value.ToString() == "")
                    {
                        dgvPurchaseOrder.Rows.RemoveAt(dgvPurchaseOrder.CurrentCell.RowIndex);
                    }
                    else
                    {
                        if (dgvPurchaseOrder.Rows[dgvPurchaseOrder.CurrentCell.RowIndex].Cells[3].Value.ToString().ToLower() == "discount/percent" ||
                            dgvPurchaseOrder.Rows[dgvPurchaseOrder.CurrentCell.RowIndex].Cells[3].Value.ToString().ToLower() == "discount/fixed")
                        {
                            //for total computation discount
                            tphp += Convert.ToDecimal(dgvPurchaseOrder.Rows[dgvPurchaseOrder.CurrentCell.RowIndex].Cells[5].Value);
                            lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);
                            dgvPurchaseOrder.Rows.RemoveAt(dgvPurchaseOrder.CurrentCell.RowIndex);
                        }
                        else
                        {
                            //for total computation charges
                            tphp -= Convert.ToDecimal(dgvPurchaseOrder.Rows[dgvPurchaseOrder.CurrentCell.RowIndex].Cells[5].Value);
                            lblTotalphp.Text = "PHP " + string.Format("{0:#,#.00}", tphp);
                            dgvPurchaseOrder.Rows.RemoveAt(dgvPurchaseOrder.CurrentCell.RowIndex);
                        }
                    }
                }
            }

        }

        private void cmbPRFPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Dtpr = new DataTable();
            Dtpr = DBMethods.GetRequestNumber("info", cmbPRFPO.Text);

            if (Dtpr.Rows.Count > 0)
            {
                prfNumber = Dtpr.Rows[0]["RPRID"].ToString();
                accountxx = Dtpr.Rows[0]["RAccount"].ToString();
            }
        }
        
        void Clearxx()
        {
            cmbPRFPO.Text = string.Empty;
            cmbVendorPO.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            cmbUOMPO.SelectedIndex = -1;
            txtUnitPrice.Text = string.Empty;

            cmbDepartmentPO.SelectedIndex = -1;
            txtRequestor.Text = string.Empty;
            chkSubject.Checked = false;

            dgvPurchaseOrder.Rows.Clear();
        }


        private void dgvPurchaseOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bScrollPurchaseOrder.Maximum = dgvPurchaseOrder.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void dgvPurchaseOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                bScrollPurchaseOrder.Maximum = dgvPurchaseOrder.RowCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bScrollPurchaseOrder_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dgvPurchaseOrder.FirstDisplayedScrollingRowIndex = dgvPurchaseOrder.Rows[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }







        //--------------------------------------------------------------- purchase edit ------------------------------------------------------------------------

        private void btnPOEdit_Click(object sender, EventArgs e)
        {
            pnlPO.Visible = false;
            pnlPOEdit.Visible = true;
            cmbVendorEdit.Text = string.Empty;
            cmbPONumEdit.Text = string.Empty;
            dgvPOEdit.Rows.Clear();

            DataTable Dt = new DataTable();
            Dt = DBMethods.GetSupplierMasterList("");
            cmbVendorEdit.Items.Clear();

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbVendorEdit.Items.Add(Dt.Rows[i]["VendorName"].ToString());
                }
            }

            DataTable DtDept = new DataTable();
            DtDept = DBMethods.GetDepartmentList();
            cmbDepartmentEdit.Items.Clear();

            if (DtDept.Rows.Count > 0)
            {
                for (int y = 0; y <= DtDept.Rows.Count - 1; y++)
                {
                    cmbDepartmentEdit.Items.Add(DtDept.Rows[y]["Dept"].ToString());
                }
            }
        }

        private void cmbVendorEdit_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = DBMethods.ListofPONum(cmbVendorEdit.Text);
            cmbPONumEdit.Items.Clear();

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbPONumEdit.Items.Add(Dt.Rows[i]["PONumber"].ToString());

                    Application.DoEvents();
                }
            }
        }

        private void cmbPONumEdit_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable DtPOEdit = new DataTable();
            DtPOEdit = DBMethods.GetPOListEditList(cmbPONumEdit.Text);
            dgvPOEdit.Rows.Clear();

            if (DtPOEdit.Rows.Count > 0)
            {
                edit_MID = DtPOEdit.Rows[0][0].ToString();
                edit_PRFID = DtPOEdit.Rows[0]["PRFID"].ToString();

                for (int i = 0; i <= DtPOEdit.Rows.Count - 1; i++)
                {
                    if (DtPOEdit.Rows[i]["PUOM"].ToString() != "")
                    {
                        if (DtPOEdit.Rows[i]["PUOM"].ToString().ToLower() == "charges/percent" ||
                            DtPOEdit.Rows[i]["PUOM"].ToString().ToLower() == "charges/fixed")
                        {
                            tphpEdit += Convert.ToDecimal(DtPOEdit.Rows[i]["PTotal"]);
                        }
                        else if (DtPOEdit.Rows[i]["PUOM"].ToString().ToLower() == "discount/percent" ||
                                 DtPOEdit.Rows[i]["PUOM"].ToString().ToLower() == "discount/fixed")
                             {
                                 tphpEdit -= Convert.ToDecimal(DtPOEdit.Rows[i]["PTotal"]);
                             
                             }
                        else
                        {
                            tphpEdit += Convert.ToDecimal(DtPOEdit.Rows[i]["PTotal"]);
                        }
                    }

                    dgvPOEdit.Rows.Add(new object[] { imageList1.Images[0], DtPOEdit.Rows[i][4].ToString(), DtPOEdit.Rows[i]["PDescription"].ToString(),
                                        DtPOEdit.Rows[i]["PQty"].ToString(), DtPOEdit.Rows[i]["PUOM"].ToString(),
                                        DtPOEdit.Rows[i]["PUnitPrice"].ToString() == "0" ? "" : DtPOEdit.Rows[i]["PUnitPrice"].ToString(),
                                        DtPOEdit.Rows[i]["PTotal"].ToString() == "0" ? "" : DtPOEdit.Rows[i]["PTotal"].ToString(), imageList1.Images[2], imageList1.Images[1] });

                    Application.DoEvents();
                }

            }
        }

        private void dgvPOEdit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvPOEdit.CurrentCell.ColumnIndex == 7)
                {
                    if (MessageBox.Show("You want to edit this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DBMethods.UpdatePOList(dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[1].Value.ToString(),
                                                           dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[2].Value.ToString(),
                                                           dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                                                           dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                                                           dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                                                           dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[6].Value.ToString()))
                        {
                            MessageBox.Show("Update List Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Update List Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }                 
                }

                if (dgvPOEdit.CurrentCell.ColumnIndex == 8)
                {
                    if (MessageBox.Show("Are you sure you want to remove item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DBMethods.DeletePOList(dgvPOEdit.Rows[dgvPOEdit.CurrentCell.RowIndex].Cells[1].Value.ToString()))
                        {
                            MessageBox.Show("Remove List Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearEditxx();
                        }
                        else
                        {
                            MessageBox.Show("Remove List Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }

        }

        private void btnAddPOList_Click(object sender, EventArgs e)
        {
            decimal tt = 0;

            if (MessageBox.Show("Are you sure you want to add this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (chkDetailsEdit.Checked)
                {
                    if (DBMethods.AddPOList(edit_PRFID, edit_MID, cmbPONumEdit.Text, txtDescriptionEdit.Text, "", "", "", ""))
                    {
                        MessageBox.Show("Adding PO List Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearEditxx();
                    }
                    else
                    {
                        MessageBox.Show("Adding PO List Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (cmbPONumEdit.Text == "charges/percent" || cmbPONumEdit.Text == "charges/fixed" || cmbPONumEdit.Text == "discount/percent" || cmbPONumEdit.Text == "discount/fixed")
                    {
                        if (DBMethods.AddPOList(edit_PRFID, edit_MID, cmbPONumEdit.Text, txtDescriptionEdit.Text, "",
                                               cmbUOMEdit.Text, "", txtUnitPriceEdit.Text))
                        {
                            MessageBox.Show("Adding PO List Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearEditxx();
                        }
                        else
                        {
                            MessageBox.Show("Adding PO List Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        tt = Convert.ToDecimal(txtQuantityEdit.Text) * Convert.ToDecimal(txtUnitPriceEdit.Text);

                        if (DBMethods.AddPOList(edit_PRFID, edit_MID, cmbPONumEdit.Text, txtDescriptionEdit.Text, txtQuantityEdit.Text,
                                               cmbUOMEdit.Text, txtUnitPriceEdit.Text, tt.ToString()))
                        {
                            MessageBox.Show("Adding PO List Success!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearEditxx();
                        }
                        else
                        {
                            MessageBox.Show("Adding PO List Failed!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                   
                }
            }
        }

        void ClearEditxx()
        {
            txtDescriptionEdit.Text = string.Empty;
            txtQuantityEdit.Text = string.Empty;
            txtUnitPriceEdit.Text = string.Empty;
            cmbUOMEdit.SelectedIndex = -1;

            DataTable DtPOEdit = new DataTable();
            DtPOEdit = DBMethods.GetPOListEditList(cmbPONumEdit.Text);
            dgvPOEdit.Rows.Clear();

            if (DtPOEdit.Rows.Count > 0)
            {
                edit_MID = DtPOEdit.Rows[0][0].ToString();
                edit_PRFID = DtPOEdit.Rows[0]["PRFID"].ToString();

                for (int i = 0; i <= DtPOEdit.Rows.Count - 1; i++)
                {
                    dgvPOEdit.Rows.Add(new object[] { imageList1.Images[0], DtPOEdit.Rows[i][4].ToString(), DtPOEdit.Rows[i]["PDescription"].ToString(),
                                        DtPOEdit.Rows[i]["PQty"].ToString(), DtPOEdit.Rows[i]["PUOM"].ToString(),
                                        DtPOEdit.Rows[i]["PUnitPrice"].ToString() == "0" ? "" : DtPOEdit.Rows[i]["PUnitPrice"].ToString(),
                                        DtPOEdit.Rows[i]["PTotal"].ToString() == "0" ? "" : DtPOEdit.Rows[i]["PTotal"].ToString(), imageList1.Images[2], imageList1.Images[1] });

                    Application.DoEvents();
                }

            }
        }

        private void btnPDFEdit_Click(object sender, EventArgs e)
        {
            DataTable DtPOList = new DataTable();
            string _peza = string.Empty;
            decimal _total = 0;
            string _poNum = string.Empty;

            try
            {

                if (cmbPONumEdit.Text == string.Empty)
                {
                    MessageBox.Show("Please select purchase number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPONumEdit.Focus();
                    return;
                }

                if (cmbDepartmentEdit.Text == string.Empty || txtRequestorEdit.Text == string.Empty)
                {
                    MessageBox.Show("Please fill-up all details needed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rbPezaEdit.Checked)
                {
                    _peza = "ZERO-RATED (PEZA)";
                }
                else
                {
                    _peza = "VAT-INCLUSIVE";
                }

                if (fbDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderpath = fbDialog.SelectedPath + "\\" + "Purchasing Order";

                    if (!(Directory.Exists(folderpath)))
                    {
                        Directory.CreateDirectory(folderpath);
                    }

                    DtPOList = DBMethods.GetPOListEditList(cmbPONumEdit.Text);

                    if (DtPOList.Rows.Count > 0)
                    {
                        _poNum = DtPOList.Rows[0]["PONumber"].ToString();

                        Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 2, 2, 20, 2);
                        PdfWriter pdfWrite = PdfWriter.GetInstance(pdfDoc, new FileStream(folderpath + "\\" + _poNum + ".pdf", FileMode.Create));
                        PdfPCell pdfCell = null;

                        iTextSharp.text.Image companylogo = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "isupport.png");
                        iTextSharp.text.Image signature = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "signature.png");

                        pdfDoc.Open();
                        PdfPTable pdfTable = new PdfPTable(9);
                        pdfTable.WidthPercentage = 90f;

                        iTextSharp.text.Font fonthead = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        iTextSharp.text.Font fontheadBold = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK));

                        iTextSharp.text.Font fontRed = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.RED));
                        iTextSharp.text.Font POFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 12.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY));

                        iTextSharp.text.Font PezaFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 9.0F, iTextSharp.text.Font.BOLD, BaseColor.RED));
                        iTextSharp.text.Font TotalFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 9.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                        iTextSharp.text.Font TotalFont2 = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK));
                        iTextSharp.text.Font subjectBill = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED));

                        iTextSharp.text.Font footerFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 5.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        iTextSharp.text.Font footerRed = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLD, BaseColor.RED));

                        ////---------------------------------------------------
                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 2;
                        pdfCell.Image = companylogo;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(_poNum, POFont)));
                        pdfCell.Colspan = 7;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("AMMEX ISUPPORT INTERNATIONAL CORPORATION", fonthead)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Purchase Order #", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(_poNum, fontRed)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("6th, 9th and 10th Floor Cyberscape Alpha Building, Garnet & Sapphire Road", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Ortigas Center, Pasig City 1605", fonthead)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Purchase Order Date", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(Convert.ToDateTime(DtPOList.Rows[0]["PODate"]).ToString("dd-MMM-yyyy"), fontRed)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 2;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("T: (02) 656 2061 loc.103", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        //----------------------------------------------------------- supplier details -----------------------------------------------------------------------

                        DataTable DtVendor = new DataTable();
                        DtVendor = DBMethods.GetVendorName(DtPOList.Rows[0]["VendorName"].ToString());

                        if (DtVendor.Rows.Count > 0)
                        {
                            for (int i = 0; i <= 5; i++)
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(DtVendor.Columns[i].ColumnName.ToString(), fonthead)));
                                pdfCell.Colspan = 1;
                                pdfCell.BorderWidthBottom = 0F;
                                pdfCell.BorderWidthLeft = 0F;
                                pdfCell.BorderWidthTop = 0F;
                                pdfCell.BorderWidthRight = 0F;
                                pdfCell.HorizontalAlignment = 0;
                                pdfTable.AddCell(pdfCell);

                                pdfCell = new PdfPCell(new Phrase(new Chunk(DtVendor.Rows[0][i].ToString(), fonthead)));
                                pdfCell.Colspan = 8;
                                pdfCell.BorderWidthBottom = 0F;
                                pdfCell.BorderWidthLeft = 0F;
                                pdfCell.BorderWidthTop = 0F;
                                pdfCell.BorderWidthRight = 0F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfTable.AddCell(pdfCell);
                            }

                            pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                            pdfCell.Colspan = 9;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk("Billed to", fonthead)));
                            pdfCell.Colspan = 1;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk("AMMEX ISUPPORT INTERNATIONAL CORPORATION", fontheadBold)));
                            pdfCell.Colspan = 8;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfTable.AddCell(pdfCell);


                            pdfCell = new PdfPCell(new Phrase(new Chunk("Delivery Address", fonthead)));
                            pdfCell.Colspan = 1;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk("6flr Robinsons Cyberscape Alpha Building, Sapphire & Garnet Rd. Ortigas Center, Pasig City", fonthead)));
                            pdfCell.Colspan = 8;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfCell.BorderWidthBottom = 0.5F;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                            pdfCell.Colspan = 9;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                            pdfCell.Colspan = 9;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 0;
                            pdfTable.AddCell(pdfCell);

                        }


                        //------------------------------------------------------------------- Item Column -------------------------------------------------------------------------

                        string[] colxx = { "Description", "Qty", "UOM", "Unit Price", "Total" };

                        for (int i = 0; i <= colxx.Length - 1; i++)
                        {
                            if (i == 0)
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                                pdfCell.Colspan = 3;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfCell.BorderWidthLeft = 0.5F;
                                pdfCell.BorderWidthTop = 0.5F;
                                pdfCell.BorderWidthRight = 0.5F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfTable.AddCell(pdfCell);
                            }
                            else if (i == 3 || i == 4)
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                                pdfCell.Colspan = 2;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfCell.BorderWidthLeft = 0F;
                                pdfCell.BorderWidthTop = 0.5F;
                                pdfCell.BorderWidthRight = 0.5F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfTable.AddCell(pdfCell);
                            }
                            else
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(colxx[i].ToString(), fonthead)));
                                pdfCell.Colspan = 1;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfCell.BorderWidthLeft = 0F;
                                pdfCell.BorderWidthTop = 0.5F;
                                pdfCell.BorderWidthRight = 0.5F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfTable.AddCell(pdfCell);
                            }
                        }

                        //------------------------------------------------------------------- Item Description -------------------------------------------------------------------------

                        if (dgvPOEdit.Rows.Count > 0)
                        {
                            for (int rr = 0; rr <= dgvPOEdit.Rows.Count - 1; rr++)
                            {
                                if (dgvPOEdit.Rows[rr].Cells[3].Value.ToString() == "")
                                {
                                    if (dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "charges/percent" ||
                                       dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "charges/fixed" ||
                                       dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "discount/percent" ||
                                       dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "discount/fixed")
                                    {
                                        //for charges or discount
                                        for (int cc = 2; cc <= dgvPOEdit.Columns.Count - 3; cc++)
                                        {
                                            if (cc == 2)
                                            {
                                                pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPOEdit.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                                pdfCell.Colspan = 3;
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0.5F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 0;
                                                pdfTable.AddCell(pdfCell);
                                            }
                                            else if (cc == 6)
                                            {
                                                if (dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "charges/percent" || dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "charges/fixed")
                                                {
                                                    _total += Convert.ToDecimal(dgvPOEdit.Rows[rr].Cells[cc].Value);
                                                }
                                                else if (dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "discount/percent" || dgvPOEdit.Rows[rr].Cells[4].Value.ToString() == "discount/fixed")
                                                {
                                                    _total -= Convert.ToDecimal(dgvPOEdit.Rows[rr].Cells[cc].Value);
                                                }

                                                pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", Convert.ToDecimal(dgvPOEdit.Rows[rr].Cells[cc].Value)), fontheadBold)));
                                                pdfCell.Colspan = 2;
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 1;
                                                pdfTable.AddCell(pdfCell);
                                            }
                                            else
                                            {
                                                pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                                if (cc == 5)
                                                {
                                                    pdfCell.Colspan = 2;
                                                }
                                                else
                                                {
                                                    pdfCell.Colspan = 1;
                                                }
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 1;
                                                pdfTable.AddCell(pdfCell);

                                            }

                                            Application.DoEvents();
                                        }

                                    }
                                    else
                                    {
                                        //for details only
                                        for (int cc = 2; cc <= dgvPOEdit.Columns.Count - 3; cc++)
                                        {
                                            if (cc == 2)
                                            {
                                                pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPOEdit.Rows[rr].Cells[cc].Value.ToString(), fonthead)));
                                                pdfCell.Colspan = 3;
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0.5F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 0;
                                                pdfTable.AddCell(pdfCell);
                                            }
                                            else if (cc == 5 || cc == 6)
                                            {
                                                pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                                pdfCell.Colspan = 2;
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 1;
                                                pdfTable.AddCell(pdfCell);
                                            }
                                            else
                                            {
                                                pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                                                pdfCell.Colspan = 1;
                                                pdfCell.BorderWidthBottom = 0.5F;
                                                pdfCell.BorderWidthLeft = 0F;
                                                pdfCell.BorderWidthTop = 0F;
                                                pdfCell.BorderWidthRight = 0.5F;
                                                pdfCell.HorizontalAlignment = 1;
                                                pdfTable.AddCell(pdfCell);
                                            }

                                            Application.DoEvents();
                                        }
                                    }

                                }
                                else
                                {
                                    for (int cc = 2; cc <= dgvPOEdit.Columns.Count - 3; cc++)
                                    {
                                        if (cc == 2)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPOEdit.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                            pdfCell.Colspan = 3;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0.5F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 0;
                                            pdfTable.AddCell(pdfCell);
                                        }
                                        else if (cc == 5 || cc == 6)
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", Convert.ToDecimal(dgvPOEdit.Rows[rr].Cells[cc].Value)), fontheadBold)));
                                            pdfCell.Colspan = 2;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);

                                            //total php
                                            if (cc == 6)
                                            {
                                                _total += Convert.ToDecimal(dgvPOEdit.Rows[rr].Cells[cc].Value);
                                            }
                                        }
                                        else
                                        {
                                            pdfCell = new PdfPCell(new Phrase(new Chunk(dgvPOEdit.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                            pdfCell.Colspan = 1;
                                            pdfCell.BorderWidthBottom = 0.5F;
                                            pdfCell.BorderWidthLeft = 0F;
                                            pdfCell.BorderWidthTop = 0F;
                                            pdfCell.BorderWidthRight = 0.5F;
                                            pdfCell.HorizontalAlignment = 1;
                                            pdfTable.AddCell(pdfCell);
                                        }

                                        Application.DoEvents();
                                    }
                                }
                                

                                Application.DoEvents();
                            }

                            //for black space
                            for (int bb = 0; bb <= 1; bb++)
                            {
                                for (int ss = 0; ss <= 4; ss++)
                                {
                                    if (ss == 0)
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontheadBold)));
                                        pdfCell.Colspan = 3;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0.5F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 1;
                                        pdfTable.AddCell(pdfCell);
                                    }
                                    else if (ss == 3 || ss == 4)
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                                        pdfCell.Colspan = 2;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 1;
                                        pdfTable.AddCell(pdfCell);
                                    }
                                    else
                                    {
                                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                                        pdfCell.Colspan = 1;
                                        pdfCell.BorderWidthBottom = 0.5F;
                                        pdfCell.BorderWidthLeft = 0F;
                                        pdfCell.BorderWidthTop = 0F;
                                        pdfCell.BorderWidthRight = 0.5F;
                                        pdfCell.HorizontalAlignment = 1;
                                        pdfTable.AddCell(pdfCell);
                                    }

                                    Application.DoEvents();
                                }

                                Application.DoEvents();
                            }

                            //---------------------------for subtotal rows

                            pdfCell = new PdfPCell(new Phrase(new Chunk(_peza, PezaFont)));
                            pdfCell.Colspan = 5;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk("TOTAL PHP", TotalFont)));
                            pdfCell.Colspan = 2;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 2;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", _total), TotalFont2)));
                            pdfCell.Colspan = 2;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);

                            pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                            pdfCell.Colspan = 9;
                            pdfCell.BorderWidthBottom = 0F;
                            pdfCell.BorderWidthLeft = 0F;
                            pdfCell.BorderWidthTop = 0F;
                            pdfCell.BorderWidthRight = 0F;
                            pdfCell.HorizontalAlignment = 1;
                            pdfTable.AddCell(pdfCell);

                        }

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Prepared By:", fonthead)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Reviewed By:", fonthead)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Approved By:", fonthead)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.Image = signature;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 8;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Merle Ann Casero", fonthead)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0.5F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0.5F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Ernest Joseph Gomez", fonthead)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0.5F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        //-------------------------------------footer-------------------------------------------------------

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("", fonthead)));
                        pdfCell.Colspan = 9;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 1F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("PENALTY CLAUSE:", footerRed)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 1F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);



                        pdfCell = new PdfPCell(new Phrase(new Chunk("Should the Seller fail to make delivery on time as stipulated in the Contract," +
                                                                    " AIIC reserves the right to cancel this PO without", footerFont)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 1F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Requestor", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(txtRequestorEdit.Text + " / " + cmbDepartmentEdit.Text, TotalFont2)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0.5F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);


                        pdfCell = new PdfPCell(new Phrase(new Chunk("liability and to charge Supplier with any loss incurred as a result of Supplier's" +
                                                                    " failure to make the delivery within the delivery", footerFont)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 1F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Client", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(DBMethods.GetAccountPOEdit(edit_PRFID), TotalFont2)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0.5F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);


                        pdfCell = new PdfPCell(new Phrase(new Chunk("schedule specified or charge a penalty of 0.1% of the total price for every day of breach" +
                                                                    " of the delivery schedule by the Supplier.", footerFont)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 1F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk("Subject for Billing", fonthead)));
                        pdfCell.Colspan = 1;
                        pdfCell.BorderWidthBottom = 0F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(chkSubjectEdit.Checked == true ? "Yes" : "No", subjectBill)));
                        pdfCell.Colspan = 2;
                        pdfCell.BorderWidthBottom = 0.5F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 1;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontRed)));
                        pdfCell.Colspan = 6;
                        pdfCell.BorderWidthBottom = 1F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 1F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fontRed)));
                        pdfCell.Colspan = 3;
                        pdfCell.BorderWidthBottom = 1F;
                        pdfCell.BorderWidthLeft = 0F;
                        pdfCell.BorderWidthTop = 0F;
                        pdfCell.BorderWidthRight = 0F;
                        pdfCell.HorizontalAlignment = 0;
                        pdfTable.AddCell(pdfCell);

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();

                        MessageBox.Show("Export PDF completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _total = 0;
                        txtRequestorEdit.Text = string.Empty;
                        cmbDepartmentEdit.SelectedIndex = -1;
                        chkSubjectEdit.Checked = false;
                        //Process.Start(folderpath + "\\" + _poNum + ".pdf");
                    }

                } //folder dialgog


            }
            catch(Exception ex)
            {
                throw new Exception("Error in edit PO" + Environment.NewLine  + ex.Message.ToString(), ex);
            }



        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Email.Application Outlook;
            Email.MailItem Mail;

            Outlook = new Email.Application();
            Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            Mail.To = "";
            Mail.CC = "";

            Mail.Subject = "Testing Open Apps";

            Mail.HTMLBody = "<script type='text/javascript' language='javascript'>" +
                                "function RunFile() {" +
                                "WshShell = new ActiveXObject('WScript.Shell');" +
                                "WshShell.Run('C:\\Users\\jbelicano\\Desktop\\Billing System Application\\BillingSystem.exe', 1, false);" +
                                "}" +
                            "</script>" +
                            "<a href='javascript: RunFile()'>Run program</a><br>" +
                            "<a href='C:\\Users\\jbelicano\\Desktop\\Billing System Application\\BillingSystem.exe'>Open Procurement System</a>";
            Mail.Display();
        }


    }
}

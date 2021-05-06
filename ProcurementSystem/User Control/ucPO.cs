using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ProcurementSystem.Class.DBMethods;

namespace ProcurementSystem
{
    public partial class ucPO : UserControl
    {
        public ucPO()
        {
            InitializeComponent();
        }

        private void ucPO_Load(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            DataTable DtDept = new DataTable();

            Dt = DBMethods.GetSupplierMasterList("");
            DtDept = DBMethods.GetDepartmentList();
            cmbVendor.Items.Clear();
            cmbDepartment.Items.Clear();

            if (Dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbVendor.Items.Add(Dt.Rows[i]["VendorName"].ToString());
                }
            }

            if (DtDept.Rows.Count > 0)
            {
                for (int y = 0; y <= DtDept.Rows.Count - 1; y++)
                {
                    cmbDepartment.Items.Add(DtDept.Rows[y]["Dept"].ToString());
                }
            }

            rbPeza.Checked = true;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            adgvPOList.Rows.Add(txtDescription.Text, txtQty.Text, txtUOM.Text, txtPrice.Text, txtTotal.Text);
            
            txtDescription.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUOM.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string _peza = string.Empty;
            decimal _total = 0;
            string _poNum = string.Empty;
            string _poRef = string.Empty;

            if (cmbVendor.Text == string.Empty)
            {
                MessageBox.Show("Please select vendor name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVendor.Focus();
                return;
            }

            if (cmbDepartment.Text == string.Empty || txtRequestor.Text == string.Empty)
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
                string folderpath = fbDialog.SelectedPath + "\\" + "PO";

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

                pdfWrite.PageEvent = new HeaderFooter();

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
                DtVendor = DBMethods.GetVendorName(cmbVendor.Text);

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

                if (adgvPOList.Rows.Count > 0)
                {
                    for (int rr = 0; rr <= adgvPOList.Rows.Count - 1; rr++)
                    {
                        for (int cc = 0; cc <= adgvPOList.Columns.Count - 1; cc++)
                        {
                            if (cc == 0)
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(adgvPOList.Rows[rr].Cells[cc].Value.ToString(), fontheadBold)));
                                pdfCell.Colspan = 3;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfCell.BorderWidthLeft = 0.5F;
                                pdfCell.BorderWidthTop = 0F;
                                pdfCell.BorderWidthRight = 0.5F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfTable.AddCell(pdfCell);
                            }
                            else if (cc == 3 || cc == 4)
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk("PHP " + string.Format("{0:#,#.00}", Convert.ToDecimal(adgvPOList.Rows[rr].Cells[cc].Value)), fonthead)));
                                pdfCell.Colspan = 2;
                                pdfCell.BorderWidthBottom = 0.5F;
                                pdfCell.BorderWidthLeft = 0F;
                                pdfCell.BorderWidthTop = 0F;
                                pdfCell.BorderWidthRight = 0.5F;
                                pdfCell.HorizontalAlignment = 1;
                                pdfTable.AddCell(pdfCell);

                                //for total
                                if (cc == 4)
                                {
                                    _total += Convert.ToDecimal(adgvPOList.Rows[rr].Cells[cc].Value);
                                }
                            }
                            else
                            {
                                pdfCell = new PdfPCell(new Phrase(new Chunk(adgvPOList.Rows[rr].Cells[cc].Value.ToString(), fonthead)));
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

                pdfCell = new PdfPCell(new Phrase(new Chunk(txtRequestor.Text, TotalFont2)));
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

                pdfCell = new PdfPCell(new Phrase(new Chunk("Department", fonthead)));
                pdfCell.Colspan = 1;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 0;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk(cmbDepartment.Text, TotalFont2)));
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
                int pId = DBMethods.InsertPODetails(cmbVendor.Text, _poRef, DateTime.Now.ToString("MM/dd/yyyy"), 0);

                if (adgvPOList.Rows.Count > 0)
                {
                    DBMethods.InsertPOStatus(pId, DateTime.Now.ToString("MM/dd/yyyy"));
                    
                    for (int p = 0; p <= adgvPOList.Rows.Count - 1; p++)
                    {
                        DBMethods.InsertPOList(pId, _poNum, adgvPOList.Rows[p].Cells[0].Value.ToString(), adgvPOList.Rows[p].Cells[1].Value.ToString(),
                                               adgvPOList.Rows[p].Cells[2].Value.ToString(), adgvPOList.Rows[p].Cells[3].Value.ToString(), adgvPOList.Rows[p].Cells[4].Value.ToString());
                    }
                }

                MessageBox.Show("Export PDF completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clearxx();
                Process.Start(folderpath + "\\" + _poNum +  ".pdf");

            } //folder dialgog

        }

        private void adgvPOList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    adgvPOList.CurrentCell = adgvPOList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    adgvPOList.Rows[e.RowIndex].Selected = true;
                    cmList.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void tsSelect_Click(object sender, EventArgs e)
        {
            adgvPOList.Rows.RemoveAt(adgvPOList.CurrentCell.RowIndex);
        }

        void Clearxx()
        {
            cmbVendor.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUOM.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotal.Text = string.Empty;

            cmbDepartment.SelectedIndex = -1;
            txtRequestor.Text = string.Empty;
            chkSubject.Checked = false;

            adgvPOList.Rows.Clear();
        }

        class HeaderFooter : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                //iTextSharp.text.Font footer = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                
                BaseColor footercolor = new BaseColor(0, 51, 92);
                iTextSharp.text.Font footer = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 6.0F, iTextSharp.text.Font.ITALIC, footercolor);

                PdfPCell _cell;

                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;

                _cell = new PdfPCell(new Phrase(new Chunk("Test Footer", footer)));
                _cell.HorizontalAlignment = Element.ALIGN_LEFT;
                _cell.Colspan = 3;
                //_cell.PaddingLeft = 20;
                //_cell.PaddingRight = 20;
                _cell.Border = 0;
                tbFooter.AddCell(_cell);

                tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 2, writer.DirectContent);
            }
        }


    }
}

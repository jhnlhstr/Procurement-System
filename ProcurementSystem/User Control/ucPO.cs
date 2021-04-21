using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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

        private void btnExtract_Click(object sender, EventArgs e)
        {

            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                string folderpath = fbDialog.SelectedPath + "\\" + "PO";

                if (!(Directory.Exists(folderpath)))
                {
                    Directory.CreateDirectory(folderpath);
                }

                Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 2, 2, 20, 2);
                PdfWriter pdfWrite = PdfWriter.GetInstance(pdfDoc, new FileStream(folderpath + "\\PO_Test.pdf", FileMode.Create));
                PdfPCell pdfCell = null;

                iTextSharp.text.Image companylogo = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "isupport.png");

                pdfDoc.Open();
                PdfPTable pdfTable = new PdfPTable(9);
                pdfTable.WidthPercentage = 90f;
                //BaseColor border1 = new BaseColor(0, 51, 92);
                //BaseColor border2 = new BaseColor(194, 194, 196);

                iTextSharp.text.Font fonthead = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                iTextSharp.text.Font fontRed = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 6.0F, iTextSharp.text.Font.NORMAL, BaseColor.RED));
                iTextSharp.text.Font POFont = new iTextSharp.text.Font(FontFactory.GetFont("Montserrat", 12.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY));

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

                pdfCell = new PdfPCell(new Phrase(new Chunk("PO#001-03-21", POFont)));
                pdfCell.Colspan = 7;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 2;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk("AMMEX ISUPPORT INTERNATIONAL CORPORATION", fonthead)));
                pdfCell.Colspan = 6;
                //pdfCell.Image = companylogo;
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

                pdfCell = new PdfPCell(new Phrase(new Chunk("PO#001-03-21", fontRed)));
                pdfCell.Colspan = 2;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 2;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk("6th, 9th and 10th Floor Cyberscape Alpha Building, Garnet & Sapphire Road", fonthead)));
                pdfCell.Colspan = 9;
                //pdfCell.Image = companylogo;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 0;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk("Ortigas Center, Pasig City 1605", fonthead)));
                pdfCell.Colspan = 6;
                //pdfCell.Image = companylogo;
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

                pdfCell = new PdfPCell(new Phrase(new Chunk("13-Apr-2021", fontRed)));
                pdfCell.Colspan = 2;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 2;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk("T: (02) 656 2061 loc.103", fonthead)));
                pdfCell.Colspan = 9;
                //pdfCell.Image = companylogo;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 0;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk(" ", fonthead)));
                pdfCell.Colspan = 9;
                //pdfCell.Image = companylogo;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 0;
                pdfTable.AddCell(pdfCell);


                //-----------------------------------supplier details------------------------------------------

                pdfCell = new PdfPCell(new Phrase(new Chunk("Supplier/Vendor", fonthead)));
                pdfCell.Colspan = 1;
                //pdfCell.Image = companylogo;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 0;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(new Chunk("Accent Micro Technologies Inc.", fonthead)));
                pdfCell.Colspan = 8;
                pdfCell.BorderWidthBottom = 0F;
                pdfCell.BorderWidthLeft = 0F;
                pdfCell.BorderWidthTop = 0F;
                pdfCell.BorderWidthRight = 0F;
                pdfCell.HorizontalAlignment = 1;
                pdfCell.BorderWidthBottom = 0.5F;
                pdfTable.AddCell(pdfCell);

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                MessageBox.Show("Exporing PO completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Process.Start(folderpath + "\\" + "" + DBMethods.GetClient(txtCode.Text) + "_" + cmxx + ".pdf");

            } //folder dialgog


        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;


namespace pdfpasswordprotect_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                Title = "Select PDF file",
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileInputPath = textBox1.Text;
            PdfDocument document = PdfReader.Open(fileInputPath, PdfDocumentOpenMode.Modify);
            PdfSecuritySettings securitySettings = document.SecuritySettings;

            //set user password to pdf file
            securitySettings.UserPassword = "passUser";

            //set owner password to pdf file
            securitySettings.OwnerPassword = "passOwner";

            securitySettings.PermitAccessibilityExtractContent = false;
            securitySettings.PermitAnnotations = false;
            securitySettings.PermitAssembleDocument = false;
            securitySettings.PermitExtractContent = false;
            securitySettings.PermitFormsFill = true;
            securitySettings.PermitFullQualityPrint = false;
            securitySettings.PermitModifyDocument = true;
            securitySettings.PermitPrint = false;

            //Save password protected file
            string fileOuputPath = "J:\\pdfOutput\\protectedPDF.pdf";

            document.Save(fileOuputPath);
        }
    }
}

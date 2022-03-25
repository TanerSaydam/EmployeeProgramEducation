using Business.Abstract;
using DevExpress.XtraEditors;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace EmployeeUI
{
    public partial class XtraPayroll : DevExpress.XtraEditors.XtraForm
    {
        private readonly IPayrollService _payrollService;
        public XtraPayroll(IPayrollService payrollService)
        {
            InitializeComponent();
            _payrollService = payrollService;   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            _payrollService.Add(Convert.ToInt16(txtMounth.Text), Convert.ToInt16(txtYear.Text));
            ExportExcel(Convert.ToInt16(txtMounth.Text), Convert.ToInt16(txtYear.Text));
            GetList();
        }

        void ExportExcel(int mounth, int year)
        {
            Excel.Application excel = new Excel.Application();
            object Missing = Type.Missing;
            Excel.Workbook workbook = excel.Workbooks.Add(Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Sheets[1];

            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

            worksheet.Range["A1"].ColumnWidth = 3.43;
            worksheet.Range["B1"].ColumnWidth = 30.43;
            worksheet.Range["C1:I1"].ColumnWidth = 12.43;
            worksheet.Range["A1"].RowHeight = 75;

            worksheet.Range["A:I"].Font.Name = "Times New Roman";
            worksheet.Range["A:I"].Font.Size = 12;

            worksheet.Range["A1:I1"].Font.Bold = true;
            worksheet.Range["A1:I1"].HorizontalAlignment = 3;
            worksheet.Range["A1:I1"].VerticalAlignment = 2;
            worksheet.Range["A1:I1"].WrapText = true;

            worksheet.Range["E:I"].NumberFormat = "#,##0.00";



            worksheet.Range["A1"].Value = "#";
            worksheet.Range["B1"].Value = "Personel Adı";
            worksheet.Range["C1"].Value = "Dönem";
            worksheet.Range["D1"].Value = "Gün";
            worksheet.Range["E1"].Value = "Brüt Ücret";
            worksheet.Range["F1"].Value = "SGK İşçi Payı %15";
            worksheet.Range["G1"].Value = "Gelir Vergisi Matrahı";
            worksheet.Range["H1"].Value = "Kümülatif Gelir Vergisi Matrahı";
            worksheet.Range["I1"].Value = "Net Ücret";

            var results = _payrollService.GetPayrollListWithEmployee().Where(w => w.Mounth == mounth && w.Year == year);

            int rowCount = worksheet.Range["A" + worksheet.Rows.Count].End[Excel.XlDirection.xlUp].Row;

            rowCount++;
            int n = 0;
            foreach (var payroll in results)
            {
                n++;
                worksheet.Range["A" + rowCount].Value = 1;
                worksheet.Range["B" + rowCount].Value = payroll.Name;
                worksheet.Range["C" + rowCount].Value = Convert.ToDateTime("01." + mounth + ".2022").ToString("MMMM").ToUpper();
                worksheet.Range["D" + rowCount].Value = payroll.ServiceDay;
                worksheet.Range["E" + rowCount].Value = payroll.GrossPay;
                worksheet.Range["F" + rowCount].Value = payroll.InsurancePremiumEmployeeShare;
                worksheet.Range["G" + rowCount].Value = payroll.IncomeTaxAssessment;
                worksheet.Range["H" + rowCount].Value = payroll.CumulaticeIncomeTaxAssessment;
                worksheet.Range["I" + rowCount].Value = payroll.NetPay;
                rowCount++;
            }

            rowCount = worksheet.Range["A" + worksheet.Rows.Count].End[Excel.XlDirection.xlUp].Row;
            worksheet.Range["A1:I" + rowCount].Borders.LineStyle = 1;


            worksheet.Range["E" + (rowCount + 1)].Formula = "=Sum(E2:E" + rowCount + ")";
            worksheet.Range["F" + (rowCount + 1)].Formula = "=Sum(F2:F" + rowCount + ")";
            worksheet.Range["G" + (rowCount + 1)].Formula = "=Sum(G2:G" + rowCount + ")";
            worksheet.Range["H" + (rowCount + 1)].Formula = "=Sum(H2:H" + rowCount + ")";
            worksheet.Range["I" + (rowCount + 1)].Formula = "=Sum(I2:I" + rowCount + ")";


            worksheet.Range["A" + (rowCount+1) + ":I" + (rowCount + 1)].Font.Bold = true;

            string mounthName = Convert.ToDateTime("01." + mounth + ".2022").ToString("MMMM").ToUpper();

            if (System.IO.File.Exists(@"C:\1\" + mounthName + " Bordro.xlsx") == true)
            {
                System.IO.File.Delete(@"C:\1\" + mounthName + " Bordro.xlsx");
            }

            workbook.SaveAs(@"C:\1\" + mounthName + " Bordro.xlsx", Missing,Missing,Missing,Missing, Missing, Excel.XlSaveAsAccessMode.xlNoChange,Missing,Missing);
            workbook.Close();
            excel.Quit();
            //excel.Visible = true;
        }

        private void XtraPayrol_Load(object sender, EventArgs e)
        {
            GetList();
        }

        void GetList()
        {
            var result = _payrollService.GetPayrolList();
            gC1.DataSource = result;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = (gridView1.GetFocusedRow() as PayrollListDto);
                var result = _payrollService.GetPayrollListWithEmployee().Where(w=> w.Mounth == selectedRow.Mounth && w.Year == selectedRow.Year);
                gC2.DataSource = result;
            }
            catch (Exception)
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var selectedRow = (gridView1.GetFocusedRow() as PayrollListDto);
            ExportExcel(selectedRow.Mounth, selectedRow.Year);
            SendEmail(selectedRow.MounthName);
        }      
        
        void SendEmail(string mounthName)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("personelbodro2@gmail.com");
                mail.To.Add("personelbodro2@gmail.com");
                mail.Subject = "Bordro";
                mail.Body = "<b><i> <font name='Times New Roman'>Bordro dosyamız ektedir. <br /> İyi çalışmalar dilerim.</font></i></b>";
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\1\" + mounthName + " Bordro.xlsx"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("personelbodro2@gmail.com", "personel.123456");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void repositoryBtnMail_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bordroyu mail göndermek istiyor musunuz?","Mail Gönder?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var selectedRow = (gridView1.GetFocusedRow() as PayrollListDto);
                ExportExcel(selectedRow.Mounth, selectedRow.Year);
                SendEmail(selectedRow.MounthName);
            }
        }

        void EmployeeExportExcel(int id)
        {
            Excel.Application excel = new Excel.Application();
            object Missing = Type.Missing;
            Excel.Workbook workbook = excel.Workbooks.Add(Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.Sheets[1];

            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

            worksheet.Range["A1"].ColumnWidth = 3.43;
            worksheet.Range["B1"].ColumnWidth = 30.43;
            worksheet.Range["C1:I1"].ColumnWidth = 12.43;
            worksheet.Range["A1"].RowHeight = 75;

            worksheet.Range["A:I"].Font.Name = "Times New Roman";
            worksheet.Range["A:I"].Font.Size = 12;

            worksheet.Range["A1:I1"].Font.Bold = true;
            worksheet.Range["A1:I1"].HorizontalAlignment = 3;
            worksheet.Range["A1:I1"].VerticalAlignment = 2;
            worksheet.Range["A1:I1"].WrapText = true;

            worksheet.Range["E:I"].NumberFormat = "#,##0.00";



            worksheet.Range["A1"].Value = "#";
            worksheet.Range["B1"].Value = "Personel Adı";
            worksheet.Range["C1"].Value = "Dönem";
            worksheet.Range["D1"].Value = "Gün";
            worksheet.Range["E1"].Value = "Brüt Ücret";
            worksheet.Range["F1"].Value = "SGK İşçi Payı %15";
            worksheet.Range["G1"].Value = "Gelir Vergisi Matrahı";
            worksheet.Range["H1"].Value = "Kümülatif Gelir Vergisi Matrahı";
            worksheet.Range["I1"].Value = "Net Ücret";

            var results = _payrollService.GetPayrollListWithEmployee().Where(w => w.Id == id);

            int rowCount = worksheet.Range["A" + worksheet.Rows.Count].End[Excel.XlDirection.xlUp].Row;

            int mounth = 0;
            rowCount++;
            int n = 0;
            foreach (var payroll in results)
            {
                mounth = payroll.Mounth;
                n++;
                worksheet.Range["A" + rowCount].Value = 1;
                worksheet.Range["B" + rowCount].Value = payroll.Name;
                worksheet.Range["C" + rowCount].Value = Convert.ToDateTime("01." + payroll.Mounth + ".2022").ToString("MMMM").ToUpper();
                worksheet.Range["D" + rowCount].Value = payroll.ServiceDay;
                worksheet.Range["E" + rowCount].Value = payroll.GrossPay;
                worksheet.Range["F" + rowCount].Value = payroll.InsurancePremiumEmployeeShare;
                worksheet.Range["G" + rowCount].Value = payroll.IncomeTaxAssessment;
                worksheet.Range["H" + rowCount].Value = payroll.CumulaticeIncomeTaxAssessment;
                worksheet.Range["I" + rowCount].Value = payroll.NetPay;
                rowCount++;
            }

            rowCount = worksheet.Range["A" + worksheet.Rows.Count].End[Excel.XlDirection.xlUp].Row;
            worksheet.Range["A1:I" + rowCount].Borders.LineStyle = 1;


            worksheet.Range["E" + (rowCount + 1)].Formula = "=Sum(E2:E" + rowCount + ")";
            worksheet.Range["F" + (rowCount + 1)].Formula = "=Sum(F2:F" + rowCount + ")";
            worksheet.Range["G" + (rowCount + 1)].Formula = "=Sum(G2:G" + rowCount + ")";
            worksheet.Range["H" + (rowCount + 1)].Formula = "=Sum(H2:H" + rowCount + ")";
            worksheet.Range["I" + (rowCount + 1)].Formula = "=Sum(I2:I" + rowCount + ")";


            worksheet.Range["A" + (rowCount + 1) + ":I" + (rowCount + 1)].Font.Bold = true;

            string mounthName = Convert.ToDateTime("01." + mounth + ".2022").ToString("MMMM").ToUpper();

            if (System.IO.File.Exists(@"C:\1\" + mounthName + " Bordro.xlsx") == true)
            {
                System.IO.File.Delete(@"C:\1\" + mounthName + " Bordro.xlsx");
            }

            workbook.SaveAs(@"C:\1\" + mounthName + " Bordro.xlsx", Missing, Missing, Missing, Missing, Missing, Excel.XlSaveAsAccessMode.xlNoChange, Missing, Missing);
            workbook.Close();
            excel.Quit();
            //excel.Visible = true;
        }

        private void repositoryEmployeePayrollEmail_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bordroyu mail göndermek istiyor musunuz?", "Mail Gönder?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = (gridView2.GetFocusedRow() as PayrollDto);
                EmployeeExportExcel(result.Id);

                string mountName = Convert.ToDateTime("01." + result.Mounth + ".2022").ToString("MMMM").ToUpper();

                SendEmail(mountName);
            }
        }
    }
}
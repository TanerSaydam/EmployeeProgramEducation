using Business.Abstract;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeUI
{
    public partial class XtraEmployeeQuit : DevExpress.XtraEditors.XtraForm
    {
        private readonly IEmployeeService _employeeService;

        public XtraEmployeeList employeeList;
        int employeeId;
        public XtraEmployeeQuit(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void XtraEmployeeQuit_Load(object sender, EventArgs e)
        {

        }

        public void Get(int id)
        {
            employeeId = id;
            var result = _employeeService.Get(employeeId);
            txtName.Text = result.Name.ToUpper() + " " + result.LastName.ToUpper();
            txtEndingDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtReasonOfLeaving.Focus();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEmployeeeQuit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(txtName.Text + " personelini işten çıkartmak istiyor musunuz?", "İşten Çıkart?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _employeeService.Get(employeeId);
                result.EndingDate = Convert.ToDateTime(txtEndingDate.Text);
                result.ReasonOfLeaving = txtReasonOfLeaving.Text;
                result.Status = "İşten Ayrıldı";
                _employeeService.QuitJob(result);
                employeeList.GetList();
                this.Close();
            }
        }
    }
}
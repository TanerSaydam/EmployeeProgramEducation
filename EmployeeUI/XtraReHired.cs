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
    public partial class XtraReHired : DevExpress.XtraEditors.XtraForm
    {
        private readonly IEmployeeService _employeeService;

        public XtraEmployeeList employeeList;   
        public int employeeId = 0 ;

        public XtraReHired(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XtraReHired_Load(object sender, EventArgs e)
        {
            txtStarringDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Personeli işe almak istiyor musunuz?","İşe Al?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _employeeService.Get(employeeId);
                result.EndingDate = null;
                result.ReasonOfLeaving = null;
                result.Status = "Çalışıyor";
                result.StartingDate = Convert.ToDateTime(txtStarringDate.Text);
                _employeeService.ReHired(result);

                employeeList.GetList();
                this.Close();
            }
        }
    }
}
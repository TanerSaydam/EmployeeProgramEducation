using Business.Abstract;
using DevExpress.XtraEditors;
using Entities.Concrete;
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
    public partial class XtraEmployeeAdd : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public XtraEmployeeList employeeList;

        public XtraEmployeeAdd(IDepartmentService deparmentService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _departmentService = deparmentService;
            _employeeService = employeeService;
        }


        int departmentId = 0;

        private void XtraEmployee_Load(object sender, EventArgs e)
        {
            var departments = _departmentService.GetListWithStatusTrue();
            foreach (var department in departments)
            {
                txtDeparment.Properties.Items.Add(department.Name.ToUpper());
            }            
                
            txtBirthDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtStartingDate.Text = DateTime.Now.ToString("dd.MM.yyyy");           
        }

        private void txtSalary_Enter(object sender, EventArgs e)
        {
            txtSalary.Focus();
            txtSalary.SelectAll();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.SelectAll();
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.Focus();    
            txtLastName.SelectAll();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txtDeparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentId = _departmentService.GetDepartmentId(txtDeparment.Text);           
        }
           
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee employee = new Employee
            {
                BirthDate = Convert.ToDateTime(txtBirthDate.Text),
                DepartmentId = departmentId,
                LastName = txtLastName.Text.ToLower(),
                Name = txtName.Text.ToLower(),
                Salary = Convert.ToDecimal(txtSalary.Text),
                StartingDate = Convert.ToDateTime(txtStartingDate.Text),
                IdentityNumber = txtIdentityNumber.Text,
                Status = "Çalışıyor"            
            };

            var result = _employeeService.Add(employee);

            if (result)
            {
                employeeList.GetList();
                Clear();
            }
        }

        void Clear()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtSalary.Text = "0";
            txtBirthDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtStartingDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtIdentityNumber.Text = "";
            txtDeparment.Text = "";
            txtName.Focus();
        }
    }
}
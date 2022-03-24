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
    public partial class XtraEmployeeUpdate : DevExpress.XtraEditors.XtraForm
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public XtraEmployeeList employeeList; 
        int employeeId = 0;
        int departmentId = 0;        
        string status = "";
        public XtraEmployeeUpdate(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        private void XtraEmployeeUpdate_Load(object sender, EventArgs e)
        {
            var departments = _departmentService.GetListWithStatusTrue();
            foreach (var department in departments)
            {
                txtDeparment.Properties.Items.Add(department.Name);
            }
        }

        public void Get(int id)
        { 
            var result = _employeeService.Get(id);

            var find = _departmentService.Get(result.DepartmentId);

            txtName.Text = result.Name.ToUpper();
            txtLastName.Text = result.LastName.ToUpper();
            txtBirthDate.Text = result.BirthDate.ToString("dd.MM.yyyy");
            txtStartingDate.Text = result.StartingDate.ToString("dd.MM.yyyy");
            txtSalary.Text = result.Salary.ToString();
            txtDeparment.Text = find.Name.ToUpper();
            txtIdentityNumber.Text = result.IdentityNumber;
            status = result.Status;
            employeeId = id;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee employee = new Employee
            {
                Id = employeeId,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                BirthDate = Convert.ToDateTime(txtBirthDate.Text),
                StartingDate = Convert.ToDateTime(txtStartingDate.Text),
                Salary = Convert.ToDecimal(txtSalary.Text),
                IdentityNumber = txtIdentityNumber.Text,
                DepartmentId = departmentId,
                Status = status
            };

            var result = _employeeService.Update(employee);
            if (result)
            {
                employeeList.GetList();
                this.Close();
            }
        }

        private void txtDeparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentId = _departmentService.GetDepartmentId(txtDeparment.Text);
        }
    }
}
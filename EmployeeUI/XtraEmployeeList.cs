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
    public partial class XtraEmployeeList : DevExpress.XtraEditors.XtraForm
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDeparmentService _deparmentService;
        public XtraEmployeeList(IEmployeeService employeeService, IDeparmentService deparmentService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _deparmentService = deparmentService;
        }

        private void XtraEmployeeList_Load(object sender, EventArgs e)
        {
            GetList();
        }   
        
        public void GetList()
        {
            var employeeList = _employeeService.GetEmployeeList();
            gCEmployeeList.DataSource = employeeList;

            var departmentList = _deparmentService.GetListEmployeeCount();
            gCDepartmentList.DataSource = departmentList;
        }
    }
}
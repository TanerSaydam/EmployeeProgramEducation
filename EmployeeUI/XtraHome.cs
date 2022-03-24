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
    public partial class XtraHome : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDeparmentService _deparmentService;
        private readonly IEmployeeService _employeeService;

        public XtraEmployeeList employeeList;
        public XtraHome(IDeparmentService deparmentService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _deparmentService = deparmentService;  
            _employeeService = employeeService;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            this.Close();
        }
        
        private void btnDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraDeparment department;
            department = new XtraDeparment(_deparmentService);
            //department.MdiParent = this;
            department.Show();
        }
        
        
        private void XtraHome_Load(object sender, EventArgs e)
        {
            GetEmployeeListForm();
        }

        void GetEmployeeListForm()
        {
            if (employeeList == null || employeeList.IsDisposed)
            {
                employeeList = new XtraEmployeeList(_employeeService, _deparmentService);
                employeeList.MdiParent = this;
                employeeList.Show();
            }
            else
            {
                employeeList.Focus();
            }
        }

        private void btnEmployeeAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraEmployeeAdd employee;
            employee = new XtraEmployeeAdd(_deparmentService, _employeeService);
            employee.employeeList = employeeList;
            employee.Show();
        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetEmployeeListForm();
        }

        //UI Katmanı - Arayüz Katmanımız
        //Entities - Table - Class
        //DataAccess - Contenxt - DB - CRUD
        //Business - İş Katmanı
    }
}
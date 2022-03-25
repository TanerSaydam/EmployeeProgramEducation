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
        private readonly IDepartmentService _deparmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IOffDayService _offDayService;
        private readonly IPayrollParameterService _payrollParameterService;
        private readonly IPayrollService _payrollService;

        public XtraEmployeeList employeeList;
        public XtraHome(IDepartmentService deparmentService, IEmployeeService employeeService, IOffDayService offDayService, IPayrollParameterService payrollParameterService, IPayrollService payrollService)
        {
            InitializeComponent();
            _deparmentService = deparmentService;  
            _employeeService = employeeService;
            _offDayService = offDayService;
            _payrollParameterService = payrollParameterService;
            _payrollService = payrollService;
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
                employeeList = new XtraEmployeeList(_employeeService, _deparmentService, _offDayService);
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

        private void btnOffDayAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraOffDayAdd offDayAdd;
            offDayAdd = new XtraOffDayAdd(_employeeService,_offDayService);
            offDayAdd.employeeList = employeeList;
            offDayAdd.Show();
        }

        private void btnOffDayList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraOffDayList offDayList;
            offDayList = new XtraOffDayList(_offDayService);
            offDayList.employeeList = employeeList;
            offDayList.Show();
        }

        private void btnPayrollParameter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraPayrolParameter payrolParameter;
            payrolParameter = new XtraPayrolParameter(_payrollParameterService);
            payrolParameter.Show();
        }

        private void btnPayroll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraPayroll payrol;
            payrol = new XtraPayroll(_payrollService);
            payrol.MdiParent = this;
            payrol.Show();
        }

        //UI Katmanı - Arayüz Katmanımız
        //Entities - Table - Class
        //DataAccess - Contenxt - DB - CRUD
        //Business - İş Katmanı
    }
}
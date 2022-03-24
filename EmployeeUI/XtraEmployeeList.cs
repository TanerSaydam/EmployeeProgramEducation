using Business.Abstract;
using DevExpress.XtraEditors;
using Entities.Concrete;
using Entities.Concrete.Dtos;
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
        private readonly IDepartmentService _deparmentService;
        public XtraEmployeeList(IEmployeeService employeeService, IDepartmentService deparmentService)
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
            gCEmployeeList.DataSource = employeeList.Where(e => e.Status == "Çalışıyor").ToList();

            var departmentList = _deparmentService.GetListEmployeeCount();
            gCDepartmentList.DataSource = departmentList;

            int employee = employeeList.Where(e=> e.Status == "Çalışıyor").Count();
            int off = employeeList.Where(e => e.Status == "İzinli").Count();
            int dismiss = employeeList.Where(e => e.Status == "İşten Ayrıldı").Count();
            btnEmployee.Text = "Çalışan: " + employee;
            btnOff.Text = "İzinli: " + off;
            btnDismiss.Text = "Ayrılan: " + dismiss;

            lbActiveList.Text = "Çalışan Listesi";
        }

        void GetOffEmployeeList()
        {
            var employeeList = _employeeService.GetEmployeeList().Where(e => e.Status == "İzinli").ToList();
            gCEmployeeList.DataSource = employeeList;

            lbActiveList.Text = "İzinli Listesi";
        }

        void GetDismissEmployeeList()
        {
            var employeeList = _employeeService.GetEmployeeList().Where(e => e.Status == "İşten Ayrıldı").ToList();
            gCEmployeeList.DataSource = employeeList;

            lbActiveList.Text = "Ayrılanlar Listesi";
            
        }

        private void repositoryBtnEdit_Click(object sender, EventArgs e)
        {
            if ((gridView1.GetFocusedRow() as EmployeeDto).Status == "İşten Ayrıldı")
            {
                MessageBox.Show("İşten ayrılmış personel güncellenemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = (gridView1.GetFocusedRow() as EmployeeDto).Id;

            XtraEmployeeUpdate employeeUpdate;
            employeeUpdate = new XtraEmployeeUpdate(_employeeService,_deparmentService);
            employeeUpdate.employeeList = this;
            employeeUpdate.Show();

            employeeUpdate.Get(id);
        }

        private void repositoryBtnDelete_Click(object sender, EventArgs e)
        {
            if ((gridView1.GetFocusedRow() as EmployeeDto).Status == "İşten Ayrıldı")
            {
                MessageBox.Show("İşten ayrılmış personel silinemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"{(gridView1.GetFocusedRow() as EmployeeDto).Name} personelini silmek istiyor musunuz?","Sil?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                var result = _employeeService.Get((gridView1.GetFocusedRow() as EmployeeDto).Id);
                _employeeService.Delete(result);
                MessageBox.Show("Personel başarıyla silindi", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetList();
            }
        }

        private void repositoryBtnEmployeeQuit_Click(object sender, EventArgs e)
        {
            if ((gridView1.GetFocusedRow() as EmployeeDto).Status == "İşten Ayrıldı")
            {
                MessageBox.Show("İşten ayrılmış personel tekrar çıkartılamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = (gridView1.GetFocusedRow() as EmployeeDto).Id;

            XtraEmployeeQuit employeeQuit;
            employeeQuit = new XtraEmployeeQuit(_employeeService);
            employeeQuit.employeeList = this;
            employeeQuit.Show();

            employeeQuit.Get(id);
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            GetOffEmployeeList();
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            GetDismissEmployeeList();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
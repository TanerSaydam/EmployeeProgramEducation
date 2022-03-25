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
    public partial class XtraOffDayList : DevExpress.XtraEditors.XtraForm
    {
        private readonly IOffDayService _offDayService;

        public XtraEmployeeList employeeList;

        public XtraOffDayList(IOffDayService offDayService)
        {
            InitializeComponent();
            _offDayService = offDayService; 
        }

        private void XtraOffDayList_Load(object sender, EventArgs e)
        {
            GetList();
        }

        public void GetList()
        {
            var result = _offDayService.GetEmplooyeOffDays();
            gC1.DataSource = result;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void repositoryBtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"{(gridView1.GetFocusedRow() as OffDayDto).Name} personelinin iznini silmek istiyor musunuz?","Sil?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int id = (gridView1.GetFocusedRow() as OffDayDto).Id;
                var result = _offDayService.Get(id);
                _offDayService.Delete(result);
                GetList();
                employeeList.GetList();
            }           
        }

        private void repositoryBtnUpdate_Click(object sender, EventArgs e)
        {
            XtraOffDayUpdate offDayUpdate;
            offDayUpdate = new XtraOffDayUpdate(_offDayService);
            offDayUpdate.employeeList = employeeList;
            offDayUpdate.offDayList = this;
            offDayUpdate.Show();

            offDayUpdate.txtEmployeeName.Text = (gridView1.GetFocusedRow() as OffDayDto).Name;
            offDayUpdate.txtOffStartDate.Text = (gridView1.GetFocusedRow() as OffDayDto).Date.ToString("dd.MM.yyyy");
            offDayUpdate.offDayId = (gridView1.GetFocusedRow() as OffDayDto).Id;
        }
    }
}
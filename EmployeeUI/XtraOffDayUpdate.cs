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
    public partial class XtraOffDayUpdate : DevExpress.XtraEditors.XtraForm
    {
        private readonly IOffDayService _offDayService;

        public XtraOffDayList offDayList;
        public XtraEmployeeList employeeList;
        public int offDayId = 0;
        public XtraOffDayUpdate(IOffDayService offDayService)
        {
            InitializeComponent();
            _offDayService = offDayService; 
        }

        private void XtraOffDayUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var offDay = _offDayService.Get(offDayId);
            offDay.Date = Convert.ToDateTime(txtOffStartDate.Text);

            var result = _offDayService.Update(offDay);
            if (result)
            {
                employeeList.GetList();
                offDayList.GetList();
                this.Close();
            }
        }
    }
}
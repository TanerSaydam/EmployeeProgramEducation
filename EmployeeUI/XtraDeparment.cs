using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
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
    public partial class XtraDeparment : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDeparmentService _deparmentService;  
        int _id;

        public XtraDeparment(IDeparmentService deparmentService)
        {
            InitializeComponent();
            _deparmentService = deparmentService;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Vazgeç")
            {
                Clear();
            }
            else
            {
                this.Close();
            }            
        }

        private void XtraDeparment_Load(object sender, EventArgs e)
        {
            GetList();
        }

        void GetList()
        {
            var result = _deparmentService.GetList();
            gC1.DataSource = result;
        }
        
        void Clear()
        {
            txtDeparmentName.Text = "";
            btnClose.Text = "Kapat";
            btnSave.Text = "Kaydet";
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Güncelle İşlemi
            if (btnSave.Text == "Güncelle")
            {
                var findDepartment = _deparmentService.Get(_id);
                findDepartment.Name = txtDeparmentName.Text.ToLower();
                var result = _deparmentService.Update(findDepartment);
                if (result)
                {                    
                    GetList();
                    Clear();                    
                }
            }
            else
            {
                //Kaydet İşlemi
                Department department = new Department
                {
                    Name = txtDeparmentName.Text.ToLower(),
                    Status = true
                };

                var result = _deparmentService.Add(department);
                if (result)
                {                    
                    GetList();
                    Clear();
                }                
            }          

        }

        private void repositoryBtnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"{(gridView1.GetFocusedRow() as Department).Name} bölümünü silmek istiyor musunuz","Sil?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var department = (gridView1.GetFocusedRow() as Department);
                _deparmentService.Delete(department);
                GetList();
            }
        }

        private void repositoryBtnEdit_Click(object sender, EventArgs e)
        {
            _id = (gridView1.GetFocusedRow() as Department).Id;
            string name = (gridView1.GetFocusedRow() as Department).Name;
            txtDeparmentName.Text = name;
            btnSave.Text = "Güncelle";
            btnClose.Text = "Vazgeç";
        }

        private void repositoryBtnStatusChange_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"{(gridView1.GetFocusedRow() as Department).Name} bölümünün durumunu değiştirmek istiyor musunuz", "Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var department = (gridView1.GetFocusedRow() as Department);
                _deparmentService.StatusChange(department);
                GetList();
            }
        }
    }
}
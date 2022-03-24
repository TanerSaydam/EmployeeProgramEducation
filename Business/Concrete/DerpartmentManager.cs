using Business.Abstract;
using Business.Validation;
using Business.Validation.FluentValidaiton;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DerpartmentManager : IDeparmentService
    {
        private readonly IDeparmentDal _deparmentDal;

        public DerpartmentManager(IDeparmentDal deparmentDal)
        {
            _deparmentDal = deparmentDal;
        }
        
        public bool Add(Department department)
        {
            bool validation = ValidationTool.Validate(new DepartmentValidator(), department);
            if (validation)
            {
                _deparmentDal.Add(department);
                MessageBox.Show("Bölüm başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        public void Delete(Department department)
        {
            var result = _deparmentDal.CheckDeparmentUses(department.Id);
            if (!result)
            {
                MessageBox.Show("Bu bölüme atanmış personeller olduğundan bölüm silinemiyor", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _deparmentDal.Delete(department);

        }

        public int GetDepartmentId(string departmentName)
        {
            return _deparmentDal.GetList().Where(d => d.Name == departmentName).Select(s => s.Id).FirstOrDefault();
        }

        public Department Get(int id)
        {
            return _deparmentDal.Get(g=> g.Id == id);
        }

        public List<Department> GetList()
        {
            return _deparmentDal.GetList();
        }

        public bool Update(Department department)
        {
            bool validation = ValidationTool.Validate(new DepartmentValidator(), department);
            if (validation)
            {
                _deparmentDal.Update(department);
                MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;            
        }

        public bool StatusChange(Department department)
        {
            _deparmentDal.StatusChange(department);
            //MessageBox.Show("Durum güncelleme işlemi başarıyla gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public List<Department> GetListWithStatusTrue()
        {
            return _deparmentDal.GetListWithStatusTrue();
        }

        public List<DepartmentDto> GetListEmployeeCount()
        {
            return _deparmentDal.GetListEmployeeCount();
        }
    }
}

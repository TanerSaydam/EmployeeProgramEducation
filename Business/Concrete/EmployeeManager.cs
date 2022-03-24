using Business.Abstract;
using Business.Validation.FluentValidaiton;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public bool Add(Employee employee)
        {
            bool validation = ValidationTool.Validate(new EmployeeValidator(), employee);
            if (validation)
            {
                var result = _employeeDal.CheckIdentityNumber(employee.IdentityNumber);
                if (!result)
                {
                    MessageBox.Show("Bu T.C. numarası daha önce kullanılmış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _employeeDal.Add(employee);
                MessageBox.Show("Personel başarıyla eklendi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetList();
        }

        public List<EmployeeDto> GetEmployeeList()
        {
            return _employeeDal.GetEmployeeList();
        }
    }
}

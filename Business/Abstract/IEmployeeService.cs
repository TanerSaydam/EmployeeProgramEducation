using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        bool Add(Employee employee);  
        bool Update(Employee employee);  
        void QuitJob(Employee employee);  
        void Delete(Employee employee);  
        Employee Get(int id);
        List<Employee> GetAll();
        List<EmployeeDto> GetEmployeeList();
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee,EmployeeDbContext>, IEmployeeDal
    {
        
        public bool CheckIdentityNumber(string identityNumber)
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.Employees.Where(e=> e.IdentityNumber == identityNumber);
                return (result.Count() > 0 ? false:true) ;
            }
        }

        public List<EmployeeDto> GetEmployeeList()
        {
            using (var context = new EmployeeDbContext())
            {               
                var result = from employee in context.Employees
                             join department in context.Departments on employee.DepartmentId equals department.Id
                             select new EmployeeDto
                             {
                                 Id = employee.Id,
                                 DepartmentId = department.Id,
                                 BirthDate = employee.BirthDate,
                                 DepartmentName = department.Name.ToUpper(),
                                 EndingDate = employee.EndingDate,
                                 IdentityNumber = employee.IdentityNumber,                                 
                                 Name = employee.Name.ToUpper() + " " + employee.LastName.ToUpper(),
                                 ReasonOfLeaving = employee.ReasonOfLeaving,
                                 Salary = employee.Salary,
                                 StartingDate = employee.StartingDate,
                                 Status = employee.Status,
                                 OffDayEndDate = (context.OffDays.Where(o=> o.EmployeeId == employee.Id).OrderByDescending(o=> o.Date).Count() == 0 ? null : context.OffDays.Where(o => o.EmployeeId == employee.Id).OrderByDescending(o => o.Date).Select(s=> s.Date).FirstOrDefault())
                             };

                return result.OrderBy(o=> o.Name).ToList();
            }
        }

        public List<OffDayEmployeeDto> GetEmployeeListByOffDay()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = from employee in context.Employees.Where(e=> e.Status != "İşten Ayrıldı")
                             join department in context.Departments on employee.DepartmentId equals department.Id
                             select new OffDayEmployeeDto
                             {
                                 Id = employee.Id,                                 
                                 BirthDate = employee.BirthDate,
                                 DepartmentName = department.Name.ToUpper(),                                 
                                 IdentityNumber = employee.IdentityNumber,
                                 Name = employee.Name.ToUpper() + " " + employee.LastName.ToUpper()
                             };

                return result.OrderBy(o => o.Name).ToList();
            }
        }

        public OffDay GetOffDayByEmployee(int employeeId, DateTime date)
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.OffDays.Where(o => o.EmployeeId == employeeId && o.Date == date).FirstOrDefault();
                return result;
            }
        }

        public PayrollParameter GetParameter()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.PayrollParameters.FirstOrDefault();
                return result;
            }
        }
    }
}

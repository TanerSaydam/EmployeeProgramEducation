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
    public class EfPayrollDal : EfEntityRepositoryBase<Payroll, EmployeeDbContext>, IPayrollDal
    {
        public List<Employee> GetEmployeeListe()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.Employees.ToList();
                return result.OrderBy(o => o.Name).ToList();
            }
        }

        public int GetEmployeeOffDayCount(int employeeId, int mounth, int year)
        {
            using (var context = new EmployeeDbContext())
            {
                DateTime date1 = Convert.ToDateTime("01." + mounth + "." + year); //01.02.2022
                DateTime date2 = date1.AddMonths(1);
                date2 = date2.AddDays(-1); //28.02.2022

                var result = context.OffDays.Where(o=> o.EmployeeId == employeeId && o.Date >= date1 && o.Date <= date2).Count();
                return result;
            }
        }

        public List<PayrollListDto> GetPayrolList()
        {
            using (var context = new EmployeeDbContext())
            {
                var f = from x in context.Payrolls.OrderBy(o => o.Mounth).ToList()
                        group x.Mounth by x.Mounth into g
                        select new { Id = g.Key, PayrollList = g.ToList() };

                var result = from x in f.ToList()
                             select new PayrollListDto
                             {
                                 Mounth = x.PayrollList.FirstOrDefault(),
                                 Year = 2022,
                                 EmployeeCount = context.Payrolls.Where(p => p.Mounth == x.PayrollList.FirstOrDefault() && p.Year == 2022).Count(),
                                 TotalNetPay = context.Payrolls.Where(p => p.Mounth == x.PayrollList.FirstOrDefault() && p.Year == 2022).Sum(s => s.NetPay)
                             };
                return result.ToList();
            }
        }

        public List<PayrollDto> GetPayrollListWithEmployee()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = from payroll in context.Payrolls
                             join employee in context.Employees on payroll.EmployeeId equals employee.Id
                             select new PayrollDto
                             {
                                 Id = payroll.Id,
                                 EmployeeId = employee.Id,
                                 CumulaticeİncomeTaxAssessment = payroll.CumulaticeİncomeTaxAssessment,
                                 GrossPay = payroll.GrossPay,
                                 IdentityNumber = employee.IdentityNumber,
                                 IncomeTaxAssessment = payroll.IncomeTaxAssessment,
                                 InsurancePremiumEmployeeShare = payroll.InsurancePremiumEmployeeShare,
                                 Mounth = payroll.Mounth,
                                 Name = employee.Name.ToUpper() + " " + employee.LastName.ToUpper(),
                                 NetPay = payroll.NetPay,
                                 ServiceDay = payroll.ServiceDay,
                                 Year = payroll.Year
                             };
                return result.OrderBy(o=> o.Name).ToList();
            }
        }

        public PayrollParameter GetPayrollParameter()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.PayrollParameters.FirstOrDefault();
                return result;
            }
        }
    }
}

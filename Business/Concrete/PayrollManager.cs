using Business.Abstract;
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
    public class PayrollManager : IPayrollService
    {
        private readonly IPayrollDal _payrollDal;

        public PayrollManager(IPayrollDal payrollDal)
        {
            _payrollDal = payrollDal;
        }

        public bool Add(int mounth, int year)
        {

            var payrollList = _payrollDal.GetList().Where(p=> p.Mounth == mounth && p.Year == year).ToList();
            if (payrollList.Count() > 0)
            {
                if (MessageBox.Show("Bu aya ait bir bordro var. İşeleme devam ederseniz bordro silinip tekrar hesaplanacak. İşleme devam etmek istiyor musunuz?","Bordro Mevcut!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var payroll in payrollList)
                    {
                        _payrollDal.Delete(payroll);
                    }                    
                }
                else
                {
                    return false;
                }
            }

            int serviceDay = 0;

            var parameter = _payrollDal.GetPayrollParameter();

            var employees = _payrollDal.GetEmployeeListe();
            foreach (var employee in employees)
            {
                int offDays = _payrollDal.GetEmployeeOffDayCount(employee.Id, mounth, year);

                DateTime date1 = Convert.ToDateTime("01." + mounth + "." + year); //01.02.2022
                DateTime date2 = date1.AddMonths(1);
                date2 = date2.AddDays(-1); //28.02.2022

                //01.10.2021 01.02.2022
                //02.02.2022 31.03.2022
                //10.02.2022


                if (employee.StartingDate <= date2)
                {
                    if (employee.Status == "İşten Ayrıldı")
                    {
                        if (employee.EndingDate >= date1)
                        {
                            if (employee.EndingDate <= date2)
                            {
                                TimeSpan ts = date2 - employee.StartingDate;
                                if ((Convert.ToInt16(ts.Days.ToString()) + 1) >= date2.Day)
                                {
                                    ts = Convert.ToDateTime(employee.EndingDate) - date1;
                                    serviceDay = (Convert.ToInt16(ts.Days.ToString()) + 1);
                                }
                                else
                                {
                                    ts = Convert.ToDateTime(employee.EndingDate) - employee.StartingDate;
                                    serviceDay = (Convert.ToInt16(ts.Days.ToString()) + 1);
                                }
                            }
                            else
                            {
                                TimeSpan ts = date2 - employee.StartingDate;
                                if ((Convert.ToInt16(ts.Days.ToString()) + 1) >= date2.Day)
                                {
                                    serviceDay = 30;
                                }
                                else
                                {
                                    serviceDay = (Convert.ToInt16(ts.Days.ToString()) + 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        TimeSpan ts = date2 - employee.StartingDate;
                        if ((Convert.ToInt16(ts.Days.ToString()) + 1) >= date2.Day)
                        {
                            serviceDay = 30;
                        }
                        else
                        {
                            serviceDay = (Convert.ToInt16(ts.Days.ToString()) + 1);
                        }
                    }
                }

                if (serviceDay > 0)
                {
                    decimal cumulatice = 0;
                    int m = mounth;
                    while (m == 0)
                    {
                        m--;
                        var findPayrol = _payrollDal.Get(g => g.EmployeeId == employee.Id && g.Mounth == m && g.Year == year);
                        cumulatice = cumulatice + findPayrol.IncomeTaxAssessment;
                    }

                    serviceDay = serviceDay - offDays;

                    Payroll payroll = new Payroll
                    {
                        EmployeeId = employee.Id,
                        NetPay = (employee.Salary / 30) * serviceDay,
                        ServiceDay = serviceDay,
                        Mounth = mounth,
                        Year = year,
                        GrossPay = (((employee.Salary / 30) * serviceDay) - ((parameter.Parameter1 / 30) * serviceDay)) * parameter.Parameter2,
                        InsurancePremiumEmployeeShare = ((((employee.Salary / 30) * serviceDay) - ((parameter.Parameter1 / 30) * serviceDay)) * parameter.Parameter2) * 15 / 100,
                        IncomeTaxAssessment = ((((employee.Salary / 30) * serviceDay) - ((parameter.Parameter1 / 30) * serviceDay)) * parameter.Parameter2),
                        CumulaticeİncomeTaxAssessment = cumulatice + ((((employee.Salary / 30) * serviceDay) - ((parameter.Parameter1 / 30) * serviceDay)) * parameter.Parameter2)
                    };

                    _payrollDal.Add(payroll);
                }

            }
            //_payrollDal.Add(payroll);
            return true;

            
        }

        public void Delete(Payroll payroll)
        {
            _payrollDal.Delete(payroll);
        }

        public List<PayrollListDto> GetPayrolList()
        {
           return _payrollDal.GetPayrolList();
        }

        public List<PayrollDto> GetPayrollListWithEmployee()
        {
            return _payrollDal.GetPayrollListWithEmployee();
        }
    }
}

using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOffDayService
    {
        bool Add(int id, string dateString1, string dateString2);
        bool Update(OffDay offDay);
        bool Delete(OffDay offDay);
        OffDay Get(int id);
        List<OffDayDto> GetEmplooyeOffDays();
        OffDay GetEmployeeOfDayByDate(int employeeId, DateTime date);
        Employee GetEmployee(int employeeId);
    }
}

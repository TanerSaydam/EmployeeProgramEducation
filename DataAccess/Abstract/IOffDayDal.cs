using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOffDayDal : IEntityRepository<OffDay>
    {
        List<OffDayDto> GetEmplooyeOffDays();
        Employee GetEmployee(int employeeId);
    }
}

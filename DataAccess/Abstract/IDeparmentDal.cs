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
    public interface IDeparmentDal : IEntityRepository<Department>
    {        
        void StatusChange(Department department); 
        List<Department> GetList();
        List<DepartmentDto> GetListEmployeeCount();
        List<Department> GetListWithStatusTrue();
        bool CheckDeparmentUses(int departmentId);
    }
}

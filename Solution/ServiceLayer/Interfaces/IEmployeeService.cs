using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
namespace ServiceLayer.Interfaces
{
    public interface IEmployeeService
    {
        decimal CalculateEmployeeBonus(int totalBonusPool, IHrEmployee employee, List<IHrEmployee> employees);
        List<IHrEmployee> GetHrEmployees();
        IHrEmployee GetHrEmployee(int employeeId);

    }
}

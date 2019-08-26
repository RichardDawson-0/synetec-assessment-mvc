using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using ServiceLayer.Interfaces;
using Common.Interfaces;
namespace ServiceLayer.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public decimal CalculateEmployeeBonus(int totalBonusPool, IHrEmployee employee, List<IHrEmployee> employees)
        {
            int totalSalary = employees.Sum(x => x.Salary);
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;
            decimal bonusPoolAllocation = (decimal)totalBonusPool * (decimal)bonusPercentage;
            return bonusPoolAllocation;
        }
        public List<IHrEmployee> GetHrEmployees()
        {
            List<IHrEmployee> employees = _unitOfWork.EmployeeRepository.Get(x => true).ToList<IHrEmployee>();
            return employees;
        }
        public IHrEmployee GetHrEmployee(int employeeId)
        {
            IHrEmployee employee = _unitOfWork.EmployeeRepository.Get(x => x.ID == employeeId).FirstOrDefault<IHrEmployee>();
            return employee;
        }
    }
}

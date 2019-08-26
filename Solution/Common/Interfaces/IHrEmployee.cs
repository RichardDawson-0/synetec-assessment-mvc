using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IHrEmployee
    {
        int ID { get; set; }
        string FistName { get; set; }
        string SecondName { get; set; }
        System.DateTime DateOfBirth { get; set; }
        int HrDepartmentId { get; set; }
        string JobTitle { get; set; }
        int Salary { get; set; }
        string Full_Name { get; set; }
    }
}

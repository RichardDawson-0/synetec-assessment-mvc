using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Concrete
{
    public class HrEmployeetest : IHrEmployee
    {
        public int ID { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int HrDepartmentId { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string Full_Name { get; set; }
    }
}

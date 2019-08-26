using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.ViewModels
{
    public class HrEmployeeViewModel : IHrEmployee
    {
        private string _ID_Enc;
        public int ID { get; set; }
        public string ID_Enc { get { return _ID_Enc; } set { _ID_Enc = value.Encrypt(); } }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int HrDepartmentId { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string Full_Name { get; set; }
    }
}
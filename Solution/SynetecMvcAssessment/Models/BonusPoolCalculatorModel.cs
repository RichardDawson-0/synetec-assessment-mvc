using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Interfaces;
using InterviewTestTemplatev2.ViewModels;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorModel
    {

        public int BonusPoolAmount { get; set; }
        public List<HrEmployeeViewModel> AllEmployees { get; set; }        
        public string SelectedEmployeeId_Enc { get; set; }

    }
}
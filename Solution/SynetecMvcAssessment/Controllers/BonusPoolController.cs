using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Interfaces;
using InterviewTestTemplatev2.Models;
using Common.Interfaces;
using InterviewTestTemplatev2.ViewModels;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        
        private IEmployeeService _employeeService;

        public BonusPoolController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult Index()
        {
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel
            {
                AllEmployees = _employeeService.GetHrEmployees().Select(x => new HrEmployeeViewModel()
                {
                    ID_Enc = x.HrDepartmentId.ToString()
                    ,Full_Name = x.Full_Name
                }).ToList<HrEmployeeViewModel>()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            int.TryParse(model.SelectedEmployeeId_Enc.Decrypt(), out int selectedEmployeeId);
            int totalBonusPool = model.BonusPoolAmount;
            IHrEmployee hrEmployee = _employeeService.GetHrEmployee(selectedEmployeeId);
            decimal bonusAllocation = _employeeService.CalculateEmployeeBonus(totalBonusPool, hrEmployee, _employeeService.GetHrEmployees());
            HrEmployeeViewModel hrEmployeeViewModel = new HrEmployeeViewModel()
            {
                ID_Enc = hrEmployee.HrDepartmentId.ToString()
                ,Full_Name = hrEmployee.Full_Name
            };
            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel
            {
                hrEmployee = hrEmployee,
                bonusPoolAllocation = bonusAllocation
            };
            return View(result);
        }
    }
}
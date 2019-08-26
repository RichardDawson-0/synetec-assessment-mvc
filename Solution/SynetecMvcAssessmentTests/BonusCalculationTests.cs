using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoFixture;
using NSubstitute;
using DAL.Interfaces;
using ServiceLayer.Concrete;
using Common.Interfaces;
using System.Collections.Generic;
using DAL;
using AutoFixture.Kernel;
using System.Linq;

namespace SynetecMvcAssessmentTests
{
    [TestClass]
    public class BonusCalculationTests
    {
        [TestMethod]
        public void CalculateEmployeeBonusTest()
        {
            // Arrange
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(
            new TypeRelay(
                typeof(IHrEmployee),
                typeof(HrEmployee)));
            IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
            EmployeeService employeeService = new EmployeeService(unitOfWork);
            int bonusPool = 60000;
            IHrEmployee employee = fixture.Create<HrEmployee>();
            employee.Salary = 30000;
            List<IHrEmployee> employees = fixture.CreateMany<IHrEmployee>(3).ToList();
            employees[0].Salary = 30000;
            employees[1].Salary = 40000;
            employees[2].Salary = 50000;
            // 30000 + 40000 + 50000 = 120000
            // 30000 is 25% of 120000
            // 25 % of 60000 is 15000
            // Act
            decimal result = employeeService.CalculateEmployeeBonus(bonusPool, employee, employees);
            // Asset
            int expectedResult = 15000;
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculateEmployeeBonusTest2()
        {
            // Arrange
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(
            new TypeRelay(
                typeof(IHrEmployee),
                typeof(HrEmployee)));
            IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
            EmployeeService employeeService = new EmployeeService(unitOfWork);
            int bonusPool = 70000;
            IHrEmployee employee = fixture.Create<HrEmployee>();
            employee.Salary = 30000;
            List<IHrEmployee> employees = fixture.CreateMany<IHrEmployee>(3).ToList();
            employees[0].Salary = 30000;
            employees[1].Salary = 35000;
            employees[2].Salary = 35000;
            // 30000 + 35000 + 35000 = 100000
            // 30000 is 30% of 120000
            // 30 % of 70000 is 21000
            // Act
            decimal result = employeeService.CalculateEmployeeBonus(bonusPool, employee, employees);
            // Asset
            int expectedResult = 21000;
            Assert.AreEqual(expectedResult, result);
        }
    }
}

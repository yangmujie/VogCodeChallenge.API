﻿using System;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Services
{
    public class TestEmployee
    {
        private readonly IEmployeeService _employeeService;

        public TestEmployee(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void CreateTestEmployees()
        {
            Department HRDepartment = new Department
            {
                Name = "Human Resource",
                Address = "Room 101",
                DepartmentID = Guid.NewGuid()
            };

            Department DevelopmentDepartment = new Department
            {
                Name = "Development",
                Address = "Room 102",
                DepartmentID = Guid.NewGuid()
            };



            Employee Justin = new Employee
            {
                Address = "123 Abc str",
                Department = HRDepartment,
                DepartmentID = HRDepartment.DepartmentID,
                EmployeeID = Guid.NewGuid(),
                FirstName = "Justin",
                LastName = "Bieber",
                JobTitle = "HR Manager"
            };

            Employee Celine = new Employee
            {
                Address = "555 Cba str",
                Department = DevelopmentDepartment,
                DepartmentID = DevelopmentDepartment.DepartmentID,
                EmployeeID = Guid.NewGuid(),
                FirstName = "Celine",
                LastName = "Dion",
                JobTitle = "Software Enginner"
            };

            Employee Avril = new Employee
            {
                Address = "999 Bcd str",
                Department = DevelopmentDepartment,
                DepartmentID = DevelopmentDepartment.DepartmentID,
                EmployeeID = Guid.NewGuid(),
                FirstName = "Avril",
                LastName = "Lavigne",
                JobTitle = "Senior Software Enginner"
            };


            _employeeService.Add(Justin);
            _employeeService.Add(Celine);
            _employeeService.Add(Avril);
        }
    }
}

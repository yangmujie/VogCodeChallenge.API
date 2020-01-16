using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Services
{
    public class DBEmployeeService:IEmployeeService
    {

        private readonly EmployeesDbContext _employeesDb;

        public DBEmployeeService(EmployeesDbContext employeesDb)
        {
            _employeesDb = employeesDb;
        }

        public void Add(Employee employee)
        {
            _employeesDb.Employees.Add(employee);
            _employeesDb.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeesDb.Employees.ToArray();
        }

        public IList<Employee> ListAll()
        {

            return _employeesDb.Employees.ToList();
        }
    }
}

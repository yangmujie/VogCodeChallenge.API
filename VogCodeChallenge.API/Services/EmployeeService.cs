using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Services
{
    /// <summary>
    /// Implement the IEmployeeService interface
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        //Use ConcurrentDictionary to save data because it is thread safe
        private readonly ConcurrentDictionary<Guid, Employee> _employees = new ConcurrentDictionary<Guid, Employee>();



        public void Add(Employee employee)
        {
            employee.EmployeeID = Guid.NewGuid();
            _employees[employee.EmployeeID] = employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees.Values;
        }

        public IList<Employee> ListAll()
        {
            return _employees.Values.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Services
{
    /// <summary>
    /// Define the Action by using interface
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// add employee
        /// </summary>
        /// <param name="employee">object of employee</param>
        void Add(Employee employee);

        /// <summary>
        /// get all employees as enumerable collection
        /// </summary>
        /// <returns>collection of employees </returns>
        IEnumerable<Employee> GetAll();


        /// <summary>
        /// get all employees as List collection
        /// </summary>
        /// <returns>collection of employees</returns>
        IList<Employee> ListAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VogCodeChallenge.API.Models;
using VogCodeChallenge.API.Services;

namespace VogCodeChallenge.API.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAll();
        }

        // GET: api/employees/department/{departmentId}
        [HttpGet("department/{departmentId}", Name = "GetEmployeesByDepartmentId")]
        public IActionResult GetEmployeesByDepartment(Guid departmentId)
        {

            IEnumerable<Employee> employeesInDepartment = _employeeService.GetAll().Where(e => e.DepartmentID == departmentId);



            
            if (employeesInDepartment.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(employeesInDepartment);
            }
        }

        // GET: api/Employees/{EmployeeId}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Employee employee = _employeeService.GetAll().Single(e => e.EmployeeID == id);
                return new ObjectResult(employee);
            }
            catch
            {
                return NotFound();
            }



        }

        // POST: api/Employees
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

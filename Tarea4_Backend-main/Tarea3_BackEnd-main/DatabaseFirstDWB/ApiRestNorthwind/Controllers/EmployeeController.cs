using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstDWB.BackEnd;
using DatabaseFirstDWB.DataAccess;
using DatabaseFirstDWB.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwind.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<EmployeeModel> Get()
        {
            var employees = new EmployeeSC().GetAllEmployees().Select(s => new EmployeeModel
            {
                IdNumber = s.EmployeeId,
                Name = s.FirstName,
                FamilyName = s.LastName
            }).ToList();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeModel Get(int id)
        {
            var employee = new EmployeeSC().GetEmployeeById(id);
            var employeeModel = new EmployeeModel();
            try
            {
                employeeModel.IdNumber = employee.EmployeeId;
                employeeModel.Name = employee.FirstName;
                employeeModel.FamilyName = employee.LastName;
            }
            catch
            {
                employeeModel.IdNumber = null;
                employeeModel.Name = "";
                employeeModel.FamilyName = "";
            }
            return employeeModel;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeModel newEmployee)
        {
            var employee = new EmployeeSC();
            employee.AddEmployee(newEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeModel employee)
        {
            new EmployeeSC().UpdateEmployee(id, employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new EmployeeSC().FireEmployee(id);
        }
    }
}

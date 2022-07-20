using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Model;
using employeeAPI.Interface;
using Microsoft.AspNetCore.Authorization;

namespace employeeAPI.Controllers
{
    [Authorize]
    [Route("api/employee")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;

      public employeeController(IEmployeeService employeeservice)
        {
            _employee = employeeservice;
        }

        [HttpGet]
        [Route("{employeeID}")]
        public IActionResult GetEmployeeByID(string employeeID)
        {
            try
            {
                var data = _employee.GetEmployeeByID(employeeID);

                return Ok(data);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

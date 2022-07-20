using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Model;
using employeeAPI.Interface;

namespace employeeAPI.Controllers
{
    [Route("api/admin/")]
    [ApiController]
    public class adminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public adminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Route("getemployee")]
        public IActionResult GetEmployeeAll()
        {
            try
            {
               var data = _adminService.GetEmployeeAll();

                return Ok(data);

            }catch(Exception ex)
            {
                return NoContent();
            }

        }

        [HttpGet]
        [Route("getemployee/{employeeID}")]
        public IActionResult GetEmployeeByID(string employeeID)
        {
            try
            {
                var data = _adminService.GetEmployeeByID(employeeID);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("save/employee")]
        public IActionResult AddEmployee([FromBody]employee employee)
        {
            try
            {
                return Ok(_adminService.AddEmployee(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("update/employee/{employeeID}")]
        public IActionResult AddEmployee(string employeeID,[FromBody]employee employee)
        {
            try
            {
                _adminService.UpdateEmployee(employeeID, employee);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("delete/employee/{employeeID}")]
        public IActionResult AddEmployee(string employeeID)
        {
            try
            {
                _adminService.DeleteEmployee(employeeID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}

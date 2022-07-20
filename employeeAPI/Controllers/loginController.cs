using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Service;
using employeeAPI.Interface;
using Microsoft.Extensions.Configuration;


namespace employeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly ILoginService _loginservice;

        public loginController(ILoginService loginservice)
        {
            _loginservice = loginservice;
        }

        [HttpPost]
        public IActionResult login(string email, string password)
        {
                

                var userData =  _loginservice.login(email,password);

                if (userData!=null)
                {
                //generate token key

                generateJWTtoken generateJWTtoken = new generateJWTtoken();

                var token = generateJWTtoken.GenerateToken(userData);


                   return Ok(token);
                }
                else
                {
                return Unauthorized();
                }

                
            
        }
    }
}

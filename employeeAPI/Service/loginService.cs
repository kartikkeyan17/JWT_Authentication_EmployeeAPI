using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using employeeAPI.Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using employeeAPI.Model;

namespace employeeAPI.Service
{
    public class loginService:Connectionstring,ILoginService
    {
        private readonly IConfiguration _config;
        public loginService(IConfiguration config)
            :base(config)
        {

        }

        public login login(string email,string password)
        {
            
            var parameter = new
            {
                email = email,

                password = password
            };

            using (SqlConnection con=new SqlConnection(_ConnectionString))
            {
                con.Open();

                var userData =  con.QuerySingle<login>("usp_ChechCredentials",parameter,null,null,CommandType.StoredProcedure);

                return userData;
            }
        }

    }
}

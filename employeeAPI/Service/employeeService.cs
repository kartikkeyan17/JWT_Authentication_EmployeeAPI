using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using employeeAPI.Model;
using Microsoft.Extensions.Configuration;
using employeeAPI.Interface;
using System.Data;

namespace employeeAPI.Service
{
    public class employeeService : Connectionstring,IEmployeeService
    {

     public employeeService(IConfiguration config)
            :base(config)
        {

        }

        public employee GetEmployeeByID(string employeeID)
        {
            var parameter = new
            {
                employeeID = employeeID
            };

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                con.Open();

                var data = con.QuerySingle<employee>("usp_GetEmployeeDataByID", parameter, null, null, CommandType.StoredProcedure);

                return data;

            }
        }
    }
}

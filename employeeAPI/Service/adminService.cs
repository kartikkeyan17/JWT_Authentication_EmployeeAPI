using employeeAPI.Model;
using employeeAPI.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace employeeAPI.Service
{
    public class adminService: Connectionstring,IAdminService
    {
        public adminService(IConfiguration config)
           : base(config)
        {
        }

        public employee AddEmployee(employee employee)
        {
           
            var parameter = new
            {
                employeeID = employee.employeeID,
                name = employee.name,
                department = employee.department,
                doj = employee.DOJ,
                age = employee.age,
                gender = employee.gender,
                address = employee.address,
                contactNumber = employee.contactNumber,
                emailID = employee.emialID
            };

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
              
                con.Open();

                con.Execute("usp_PostEmployeeDetails", parameter, null, null, CommandType.StoredProcedure);

            }

            return employee;
        }

        public List<employee> GetEmployeeAll()
        {
            List<employee> employees = new List<employee>();

            using (SqlConnection con=new SqlConnection(_ConnectionString))
            {
                con.Open();

                var data =  con.Query<employee>("usp_GetEmployeeDataAll",null,null,true,null,CommandType.StoredProcedure);

                foreach (var results in data)
                {
                    employees.Add(results);
                }
               
                return employees;

            }
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

        public void UpdateEmployee(string employeeID,employee employee)
        {
            var parameter = new
            {
                empid = employeeID,

                employeeID =employee.employeeID, 
           
                name=employee.name,

                department=employee.department,

                doj=employee.DOJ,

                age=employee.age,

                gender=employee.gender,

                address=employee.address,

                contactNumber=employee.contactNumber,

                emailID=employee.emialID
            };

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                con.Open();

                var data = con.Execute("usp_UpdateEmployeeData", parameter, null, null, CommandType.StoredProcedure);

            }
        }

        public void DeleteEmployee(string employeeID)
        {
            var parameter = new
            {
                employeeID = employeeID
            };

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                con.Open();

                var data = con.Execute("usp_DeleteEmployeeData", parameter, null, null, CommandType.StoredProcedure);

            }
        }


    }
}

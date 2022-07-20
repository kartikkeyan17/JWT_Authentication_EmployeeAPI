using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Model;

namespace employeeAPI.Interface
{
    public interface IAdminService
    {
        public employee AddEmployee(employee employee);

        public List<employee> GetEmployeeAll();

        public employee GetEmployeeByID(string employeeID);

        public void UpdateEmployee(string employeeID,employee employee);

        public void DeleteEmployee(string employeeID);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Model;
using employeeAPI.Service;

namespace employeeAPI.Interface
{
    public interface IEmployeeService
    {
        public employee GetEmployeeByID(string employeeID);

       
    }
}

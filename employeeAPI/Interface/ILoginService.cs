using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employeeAPI.Service;
using employeeAPI.Model;

namespace employeeAPI.Interface
{
    public interface ILoginService
    {
        public login login(string email, string password);
    }
}

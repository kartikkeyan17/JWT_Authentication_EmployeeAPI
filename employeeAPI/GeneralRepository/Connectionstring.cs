using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace employeeAPI
{
    public class Connectionstring
    {
        public readonly string _ConnectionString;

       

        public Connectionstring(IConfiguration config)
        {
            _ConnectionString = config.GetConnectionString("cs");

            
        }
    }
}

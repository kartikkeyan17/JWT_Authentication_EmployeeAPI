
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Model
{
    public class employee
    {
        public string employeeID { get; set; }

        public string name { get; set; }

        public string department { get; set; }

        public DateTime DOJ { get; set; }

        public int age { get; set; }

        public string gender { get; set; }

        public string address { get; set; }

        public int contactNumber { get; set; }

        public string emialID { get; set; }
    }
}

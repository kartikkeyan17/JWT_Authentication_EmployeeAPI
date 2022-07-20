using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Model
{
    public class admin
    {
        public string adminID { get; set; }

        public string name { get; set; }

        public DateTime DOJ { get; set; }

        public int age { get; set; } 

        public string gender { get; set; }

        public int contactNumber { get; set; }

        public string address { get; set; }
    }
}

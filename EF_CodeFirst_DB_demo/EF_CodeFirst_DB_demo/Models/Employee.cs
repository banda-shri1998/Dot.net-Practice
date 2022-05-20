using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_DB_demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
    }
}
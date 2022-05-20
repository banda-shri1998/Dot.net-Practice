using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_DB_demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
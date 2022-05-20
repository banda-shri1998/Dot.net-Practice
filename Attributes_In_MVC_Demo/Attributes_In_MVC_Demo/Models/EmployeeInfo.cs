using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attributes_In_MVC_Demo.Models
{
    public partial class EmployeeInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Personalwebsite { get; set; }
        public string Designation { get; set; }
    }
}
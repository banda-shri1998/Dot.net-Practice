using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validation_Model_Demo.Models;

namespace Validation_Model_Demo.Models
{
    //[MetadataType(EmployeeJK)]
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int age { get; set; }
        public string DOB { get; set; }
        public string postalCode { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string ConfirmPass { get; set; }
        public string URL { get; set; }



    }
}
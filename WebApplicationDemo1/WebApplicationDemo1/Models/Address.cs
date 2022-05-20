using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo1.Models
{
    public class Address
    {
        public int empID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
    }
}
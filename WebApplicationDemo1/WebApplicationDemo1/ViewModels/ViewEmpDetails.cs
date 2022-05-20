using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo1.Models;

namespace WebDemo1.ViewModels
{
    public class ViewEmpDetails
    {
        public List<Employee> Employee { get; set; }
        public List<Address> Address { get; set; }
        public string Title { get; set; }
    }
}
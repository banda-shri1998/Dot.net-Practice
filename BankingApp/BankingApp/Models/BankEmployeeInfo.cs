using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace BankingApp.Models
{
    
    [MetadataType(typeof(BankEmployeeInfo))]
    public partial class BankEmployee { 
    
    }
    public class BankEmployeeInfo
    {
        public int EmpId { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Enter Emp Name")]
        public string EmpName { get; set; }
        public string GENDER { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    [MetadataType(typeof(Customer))]
    public partial class Customer { }
    public class CustomerInfo
    {
        [Required]
        [Remote("IsUserNameAvailable", "Customer", ErrorMessage = "Phone number Already Exists")]
        public long PhoneNo { get; set; }
        [Required]
        public string CustName { get; set; }
        [Required]
        public string GENDER { get; set; }
    }
}
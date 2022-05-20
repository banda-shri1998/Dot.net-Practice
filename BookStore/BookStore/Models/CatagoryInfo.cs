using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    [MetadataType(typeof(Catagory))]
    public partial class Catagory { }
    public class CatagoryInfo
    {
        [Required]
        [Remote("IsUserNameAvailable", "Category", ErrorMessage = "Book Type Already Exists")]
        public string BookType { get; set; }
        [Required]
        public int id { get; set; }
    }
}
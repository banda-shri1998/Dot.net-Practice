using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    [MetadataType(typeof(Book))]
    public partial class Book { }
    public class BookInfo
    {
        [Remote("IsUserNameAvailable", "Book", ErrorMessage = "Book name Already Exists")]
        [ReadOnly(true)]
        public string UserName { get; set; }
        [Required]
        public int StockAvail { get; set; }
        [ReadOnly(true)]
        public int AuthorID { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [ReadOnly(true)]
        public System.DateTime PublicationY { get; set; }
    }
}
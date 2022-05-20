using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models
{
    [MetadataType(typeof(order))]
    public partial class order
    {
        
    }
    public class orderInfo
    {
        [ReadOnly(true)]
        public int CustID { get; set; }
        [ReadOnly(true)]
        public int bookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int id { get; set; }
        [ReadOnly(true)]
        [DataType(DataType.Currency)]
        public decimal BillAmount { get; set; }
    }
}
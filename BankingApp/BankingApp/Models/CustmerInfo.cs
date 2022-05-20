using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    [MetadataType(typeof(CustmerInfo))]
    public partial class Customer
    {
    }
    public class CustmerInfo
    {
        [Required]
        [DataType(DataType.Text)]
        public string CustName { get; set; }
        [DataType(DataType.Text)]
        public string CustAddress { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }
        [DataType(DataType.PhoneNumber)]
        //[MinLength(10,ErrorMessage ="less than 10 digits")]
        //[StringLength(10)]
        public long PhoneNo { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string AccountType { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="Enter Balance")]
        [DefaultValue(0)]
        public decimal Balance { get; set; }
        [Required]
        public int BranchIFSC { get; set; }
    }
}
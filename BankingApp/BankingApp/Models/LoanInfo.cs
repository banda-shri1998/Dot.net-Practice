using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    [MetadataType(typeof(LoanInfo))]
    public partial class Loan
    {
        /*[Range(10,18)]
        internal readonly decimal interest;*/
    }
    public class LoanInfo
    {
        public int LoanID { get; set; }
        [DisplayName("Enter Type of Loan")]
        [DataType(DataType.Text)]
        public string LoanType { get; set; }
        [DefaultValue(0)]
        [DisplayName("Enter Amount")]
        [DataType(DataType.Currency)]
        public int LoanAmt { get; set; }
        /*[Required]
        [Range(12,60,ErrorMessage ="Range is invalid")]
        public int duration { get; set; }*/
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    [MetadataType(typeof(TransactionInfo))]
    public partial class Transaction { }
    public class TransactionInfo
    {
        [DataType(DataType.DateTime)]
        public DateTime TransTime { get; set; }
        [DataType(DataType.Text)]
        public string TransType { get; set; }
        //[ReadOnly(true)]
        [DataType(DataType.Currency)]
        public decimal transAmount { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.Text)]
        public string trans_remark { get; set; }
    }
}
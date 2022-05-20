using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApp.Models
{

    [MetadataType(typeof(BranchInfo))]
    public partial class Branch { 
    }
    public class BranchInfo
    {
        public int IFSC { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string BranchName { get; set; }
        [DataType(DataType.Text)]
        public string BranchAddress { get; set; }
    }
}
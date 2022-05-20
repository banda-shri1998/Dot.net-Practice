using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attributes_In_MVC_Demo.Models
{
    [MetadataType(typeof(EmployeeInfoMeta))]
    public partial class EmployeeInfo { }
    public class EmployeeInfoMeta
    {
        public int Id { get; set; }
        //[DisplayName("Full Name")]
        [DisplayAttribute(Name = "Employee Full Name")]
        // [HiddenInput(DisplayValue =false)]
        public string Name { get; set; }
        [DisplayFormat(NullDisplayText = "Gender not Specified")]

        public string Gender { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<int> Age { get; set; }
        [DataType(DataType.Date)]
        //  [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime? HireDate { get; set; }
        [DataType(DataType.EmailAddress)]
        [ReadOnly(true)]
        public string EmailAddress { get; set; }
        // [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public Nullable<int> Salary { get; set; }
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string Personalwebsite { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemoteValidationDemo.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User 
    {
    }
    public class UserMetaData { 
        [Remote("IsUsernameAvail","Users",HttpMethod ="POST",ErrorMessage ="Username Is already in Use.")]
        public string Username { get; set; }
    }
}
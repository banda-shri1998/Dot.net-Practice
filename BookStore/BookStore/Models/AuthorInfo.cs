using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BookStore.Models
{
    [MetadataType(typeof(Author))]
    public partial class Author { }
    public class AuthorInfo
    {
        [Remote("IsUserNameAvailable", "Author", ErrorMessage = "Author Already Available")]
        public string UserName{ get; set; }
        [Required]
        public Nullable<int> AuthorAge { get; set; }

    }
}
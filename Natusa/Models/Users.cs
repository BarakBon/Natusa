using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Natusa.Models

{
    public class Users
    {
        public string userType { get; set; }

        [Key]
        [Required(ErrorMessage ="mail field is required")]
        public string mail { get; set; }

        [Required(ErrorMessage = "password field is required")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "password must be 2 char minimum")]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}

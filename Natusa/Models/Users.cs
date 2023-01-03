using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Natusa.Models

{
    public class Users
    {
        [Required]
        public string userType { get; set; }

        [Key]
        [Required]
        public string mail { get; set; }

        [Required]
        public string password { get; set; }
    }
}

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
        [Required]
        public string mail { get; set; }

        [Required]
        public string password { get; set; }
    }
}

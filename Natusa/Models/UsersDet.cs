using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Natusa.Models
{
    public class UsersDet
    {
        [Key]
        public string mail { get; set; }

        public string passportNum { get; set; }

        [Required]
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }

        public string addres { get; set; }

        public string Country { get; set; }

        public int zip { get; set; }

        public string cardname { get; set; }

        public int creditCard { get; set; }

        public string expDate { get; set; }

        public int cvc { get; set; }

    }
}
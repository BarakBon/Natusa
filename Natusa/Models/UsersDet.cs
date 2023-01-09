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

        public string fname { get; set; }

        public string lname { get; set; }

        public int creditCard { get; set; }

        public string expDate { get; set; }

        public int cvc { get; set; }

    }
}
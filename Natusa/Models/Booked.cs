using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Natusa.Models
{
    public class Booked
    {
        [Key]
        public string mail { get; set; }

        [Key]
        public string flightNum { get; set; }

        public int chairsNum { get; set; }

    }
}

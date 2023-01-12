using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Natusa.Models
{
    public class Booked
    {
        [Key , Column(Order = 0)]
        public string mail { get; set; }

        [Key , Column(Order = 1)]
        public string flightNum { get; set; }
      
        public int chairsNum { get; set; }

    }
}

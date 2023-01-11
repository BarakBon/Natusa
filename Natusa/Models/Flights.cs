using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Natusa.Dal;
using System.Diagnostics;

namespace Natusa.Models
{
    public class Flights
    {
        [Key]
        public String flightNum { get; set;}

        public String destination { get; set; }

        public String origin { get; set;}

        public string flightDate { get; set;} 

        public String flightTime { get; set;}

        public int price { get; set; }

        public int availableSeats { get; set;}                
    }
}


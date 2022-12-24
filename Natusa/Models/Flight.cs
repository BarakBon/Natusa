using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Natusa.Models
{
    public class Flight
    {
        [Key]
        public String flightNum {get; set;}

        public String origin { get; set;}

        public String flightDate { get; set;} 

        public String flightTime { get; set;}

        public String destination { get; set;}

        public int availableSeats { get; set;}                
    }
}
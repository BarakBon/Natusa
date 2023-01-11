using Natusa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natusa.ViewModel
{
    public class BookingViewModel
    {
        
        public string SavePay { get; set; }

        public UsersDet user { get; set; }

        public Flights outboundFlights { get; set; }

        public Flights returnFlights { get; set; }

        public Booked outboundBook { get; set; }

        public Booked returnBook { get; set;}
    }
}
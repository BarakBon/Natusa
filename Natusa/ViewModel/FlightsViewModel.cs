using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Natusa.Models;

namespace Natusa.ViewModel
{
    public class FlightsViewModel
    {
        public Flight flight { get; set; }

        public List<Flight> flights { get; set;}
    }
}
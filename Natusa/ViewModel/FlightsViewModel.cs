using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Natusa.Models;

namespace Natusa.ViewModel
{
    public class FlightsViewModel
    {
        public Flights flight { get; set; }

        public List<Flights> flightsList { get; set;}
    }
}
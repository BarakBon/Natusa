using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Natusa.Models;
using Natusa.Dal;
using Natusa.ViewModel;

namespace Natusa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Search()
        {
            FlightsViewModel fly = new FlightsViewModel();
            fly.tripType = "";
            fly.flight = new Flights();
            fly.outboundFlightsList = new List<Flights>();
            fly.returnFlightsList = new List<Flights>();
            return View("Search", fly);
        }

        public ActionResult SearchResults()
        {
            FlightsDal dal = new FlightsDal();
            string origin = Request.Form["fromCountry"].ToString();
            string destination = Request.Form["toCountry"].ToString();
            string date = Request.Form["depDate"].ToString();
            List<Flights> foundFlights = (from x in dal.Flights where (x.origin.Contains(origin) && x.destination.Contains(destination)) select x).ToList<Flights>();
            FlightsViewModel flightsVM = new FlightsViewModel();
            flightsVM.outboundFlightsList = foundFlights;
            flightsVM.tripType = "";
            flightsVM.flight = new Flights();
            flightsVM.returnFlightsList = new List<Flights>();
            return View("Search", flightsVM);
        }

        public ActionResult Booking(String flightID)
        {
            return View();
        }

        public ActionResult VerifyBooking(String flightID)
        {
            return View("Booking");
        }
    }
}
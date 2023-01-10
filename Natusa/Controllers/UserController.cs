using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Natusa.Models;
using Natusa.Dal;
using Natusa.ViewModel;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Natusa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Search()
        {
            FlightsViewModel fly = new FlightsViewModel();
            fly.flight = new Flights();
            fly.outboundFlightsList = new List<Flights>();
            fly.returnFlightsList = new List<Flights>();
            return View("Search", fly);
        }

        public ActionResult SearchResults()
        {
            FlightsViewModel flightsVM = new FlightsViewModel();
            FlightsDal dal = new FlightsDal();
            string origin = Request.Form["fromCountry"].ToString();
            string destination = Request.Form["toCountry"].ToString();
            string date = Request.Form["depDate"].ToString();
            string retDate = Request.Form["retDate"].ToString();
            //Request.Form["retDate"].ToString().Equals("")
            if (retDate.Equals(""))
            {
                List<Flights> oFlight = (from x in dal.Flights where (x.origin.Contains(origin) && x.destination.Contains(destination)) select x).ToList<Flights>();
                flightsVM.outboundFlightsList = oFlight;
                flightsVM.returnFlightsList = new List<Flights>();
            }
            else
            {
                List<Flights> oFlight = (from x in dal.Flights where (x.origin.Contains(origin) && x.destination.Contains(destination)) select x).ToList<Flights>();
                flightsVM.outboundFlightsList = oFlight;
                List<Flights> rFlight = (from x in dal.Flights where (x.origin.Contains(destination) && x.destination.Contains(origin)) select x).ToList<Flights>();
                flightsVM.returnFlightsList = rFlight;

            }

            flightsVM.flight = new Flights();
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
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
using System.Data.SqlTypes;
using System.Runtime.Remoting.Messaging;

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

        //checks date values as strings
        public bool dateCheck (string time1, string time2)
        {
            DateTime time1Conv = Convert.ToDateTime(time1);
            DateTime time2Conv = Convert.ToDateTime(time2);
            if (time1Conv > time2Conv)
            {
                return true;
            }
            return false;
        }
       
        public ActionResult SearchResults()
        {
            FlightsViewModel flightsVM = new FlightsViewModel();
            FlightsDal dal = new FlightsDal();
            string origin = Request.Form["fromCountry"].ToString();
            string destination = Request.Form["toCountry"].ToString();
            string date = Request.Form["depDate"].ToString();
            string retDate = Request.Form["retDate"].ToString();
            string time = Request.Form["depTime"].ToString();

            if (date.Equals("")){
                date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            }
            if (time.Equals(""))
            {
                time = DateTime.UtcNow.AddHours(2).ToString("HH:mm");
                
            }
            

            if (retDate.Equals(""))
            {
                List<Flights> oFlight = (from x in dal.Flights where (x.origin.Contains(origin) && x.destination.Contains(destination) && 
                                         (x.flightDate).Equals(date)) select x).ToList<Flights>();
                flightsVM.outboundFlightsList = oFlight;
                flightsVM.returnFlightsList = new List<Flights>();
            }
            else
            {
                List<Flights> oFlight = (from x in dal.Flights where (x.origin.Contains(origin) && x.destination.Contains(destination) && 
                                         (x.flightDate).Equals(date)) select x).ToList<Flights>();
                flightsVM.outboundFlightsList = oFlight;
                
                List<Flights> rFlight = (from x in dal.Flights where (x.origin.Contains(destination) && x.destination.Contains(origin) && 
                                         (x.flightDate).Equals(retDate)) select x).ToList<Flights>();
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
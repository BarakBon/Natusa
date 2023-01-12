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
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.Migrations;

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

            if (Request.Form["selected"] != null)
            {
                string flightId = Request.Form["flightID"].ToString();
                string retFlightID = Request.Form["retFlightID"].ToString();
                return View("Booking", flightId ,retFlightID);
            }

            return View("Search", flightsVM);
        }

        public ActionResult Booking(string flightID, string retFlightID)
        {
            FlightsDal Fdal = new FlightsDal();
            UsersDetDal Udal = new UsersDetDal();
            BookingViewModel booking = new BookingViewModel();
            booking.SavePay = "";

            booking.user = new UsersDet();
            booking.user.mail = Session["logedUser"].ToString();
            List<UsersDet> userDet = (from x in Udal.UsersDet where (x.mail).Equals(booking.user.mail) select x).ToList<UsersDet>();
            booking.user.fname = userDet[0].fname;
            booking.user.lname = userDet[0].lname;
            booking.user.passportNum= userDet[0].passportNum;
            booking.user.addres = userDet[0].addres;
            booking.user.Country = userDet[0].Country;
            booking.user.zip = userDet[0].zip;
            booking.user.cardname = userDet[0].cardname;
            booking.user.creditCard = userDet[0].creditCard;
            booking.user.expDate = userDet[0].expDate;
            booking.user.cvc = userDet[0].cvc;

            booking.outboundFlights = new Flights();
            booking.outboundFlights.flightNum = flightID;
            List<Flights> oFlight = (from x in Fdal.Flights where (x.flightNum).Equals(flightID) select x).ToList<Flights>();
            booking.outboundFlights.origin = oFlight[0].origin;
            booking.outboundFlights.destination = oFlight[0].destination;
            booking.outboundFlights.price = oFlight[0].price;

            booking.returnFlights = new Flights();
            if (retFlightID != null)
            {
                booking.returnFlights.flightNum = retFlightID;
                List<Flights> rFlight = (from x in Fdal.Flights where (x.flightNum).Equals(retFlightID) select x).ToList<Flights>();
                booking.returnFlights.origin = rFlight[0].origin;
                booking.returnFlights.destination = rFlight[0].destination;
                booking.returnFlights.price = rFlight[0].price;
            }

            booking.outboundBook = new Booked();
            booking.returnBook = new Booked();

            return View(booking);
        }

        public ActionResult VerifyBooking()
        {
            UsersDetDal Udal = new UsersDetDal();
            FlightsDal Fdal = new FlightsDal();
            BookedDal Bdal= new BookedDal();
            BookingViewModel book = new BookingViewModel();
            book.outboundBook= new Booked();
            FlightsViewModel flights= new FlightsViewModel();

            string oFlightNum = Request.Form["onFlightID"].ToString();
            int tickets = int.Parse(Request.Form["numOfTickets"]);
            List<Flights> flight = (from x in Fdal.Flights where (x.flightNum).Equals(oFlightNum) select x).ToList<Flights>();
            
            if ((flight[0].availableSeats - tickets) > 0)
            {
                if (Request.Form["savePay"] !=null)
                {
                    
                    book.user = new UsersDet();
                    book.user.mail = Session["logedUser"].ToString();
                    List<UsersDet> userDet = (from x in Udal.UsersDet where (x.mail).Equals(book.user.mail) select x).ToList<UsersDet>();
                    book.user.fname = userDet[0].fname;
                    book.user.lname = userDet[0].lname;
                    book.user.passportNum = Request.Form["passport"].ToString();
                    book.user.addres = Request.Form["addres"].ToString();
                    book.user.Country = Request.Form["Country"].ToString();
                    book.user.zip = int.Parse(Request.Form["zip"]);
                    book.user.cardname = Request.Form["cardname"].ToString();
                    book.user.creditCard = int.Parse(Request.Form["cardnumber"]);
                    book.user.expDate = Request.Form["expdate"].ToString();
                    book.user.cvc = int.Parse(Request.Form["cvc"]);

                    Udal.UsersDet.AddOrUpdate(book.user);
                    Udal.SaveChanges();
                }

                book.outboundBook.flightNum = flight[0].flightNum.ToString(); 
                book.outboundBook.mail = Session["logedUser"].ToString();
                book.outboundBook.chairsNum = tickets;
                Bdal.Booked.Add(book.outboundBook);
                Bdal.SaveChanges();

                flight[0].availableSeats = flight[0].availableSeats - tickets;
                Fdal.Flights.AddOrUpdate(flight[0]);
                Fdal.SaveChanges();

                return RedirectToAction(controllerName: "User", actionName: "Search");
            }

            return View("Booking",book);
        }

        public ActionResult Logout()
        {
            Session["logedUser"] = "";
            return RedirectToAction(controllerName: "Home", actionName: "Login");
        }
    }

}
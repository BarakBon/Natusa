using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Natusa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResults()
        {
            return View("Search");
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
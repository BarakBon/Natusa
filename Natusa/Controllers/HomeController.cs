﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Natusa.Models;
using Natusa.Dal;
using Natusa.ViewModel;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;
using System.Net.Http.Headers;
using System.Web.Helpers;

namespace Natusa.Controllers
{
    
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CheckUser(Users newUser)
        {
            UsersDal dal = new UsersDal();
            
            List<Users> user = (from x in dal.Users where (x.mail).Equals(newUser.mail) select x).ToList<Users>();

            if (ModelState.IsValid)
            {
                if (user.Count() != 0)
                {
                    if ((newUser.password == user[0].password))
                    {
                        Session["logedUser"] = newUser.mail;
                        return RedirectToAction(controllerName: "User", actionName: "search");
                    }
                }
            }
            return View("Login", new Users());
            
           
        }

        public ActionResult Login()
        {
            return View(new Users());
        }

        public ActionResult Registration()
        {
            UsersViewModel det = new UsersViewModel();
            det.user = new Users();
            det.name = new UsersDet();
            return View("Registration" ,det);
        }

        [HttpPost]
        public ActionResult add(UsersViewModel user)
        {
            UsersViewModel newUser = new UsersViewModel();
            UsersDetDal dal1 = new UsersDetDal();
            UsersDal dal2 = new UsersDal();
            newUser.user = new Users();
            newUser.name = new UsersDet();

            newUser.name.mail = Request.Form["mail"];
            newUser.name.fname = Request.Form["fname"];
            newUser.name.lname = Request.Form["lname"];
            newUser.user.userType = "user";
            newUser.user.mail = newUser.name.mail.ToString();
            newUser.user.password = Request.Form["Password"];

            if (ModelState.IsValid)
            {
                dal1.UsersDet.Add(newUser.name);
                dal2.Users.Add(newUser.user);
                dal1.SaveChanges();
                dal2.SaveChanges();
            }
            else
            {
                View("Registration", user);
            }
            return View("Login", new Users());
        }
    }
}
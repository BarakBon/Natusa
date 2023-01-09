using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using Natusa.Models;

namespace Natusa.ViewModel
{
    public class UsersViewModel
    {
        public Users user { get; set; }

        public UsersDet name { get; set; }

    }
}
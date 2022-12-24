using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Natusa.Models;

namespace Natusa.Dal
{
    public class FlightDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>().ToTable("tblFlights");
        }

        public DbSet<Flight> Flights { get; set;}
    }

}
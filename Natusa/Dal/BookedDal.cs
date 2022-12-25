using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Natusa.Models;

namespace Natusa.Dal
{
    public class BookedDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booked>().ToTable("tblBooked");
        }

        public DbSet<Booked> Booked { get;set; }
    }
}
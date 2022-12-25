using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Natusa.Models;

namespace Natusa.Dal
{
    public class UsersDetDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsersDet>().ToTable("tblUsersDet");
        }

        public DbSet <UsersDet> UsersDet { get; set; }
    }
}
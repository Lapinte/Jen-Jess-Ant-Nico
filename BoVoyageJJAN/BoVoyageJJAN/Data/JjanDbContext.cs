using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Data
{
    public class JjanDbContext : DbContext
    {
        public JjanDbContext() : base("jjantest")
        {
            
        }

        public DbSet<Agency> Agencies { get; set; }

        public DbSet<Civility> Civilities { get; set; }

        public DbSet<Commercial> Commercials { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<DestinationFile> DestinationFiles { get; set; }

        public DbSet<UserDemand> UserDemands { get; set; }

    }
}
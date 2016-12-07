using Microsoft.AspNet.Identity.EntityFramework;
using PublicTransportApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PublicTransportApp.DAL
{
    public class PublicTransportContext : IdentityDbContext<ApplicationUser>
    {
        public PublicTransportContext() : base("name=PublicTransportContext")
        {
        }

        public static PublicTransportContext Create()
        {
            return new PublicTransportContext();
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
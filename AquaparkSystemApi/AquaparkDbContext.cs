using AquaparkSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi
{
    public class AquaparkDbContext : DbContext
    {
        public AquaparkDbContext() : base("AquaparkContext")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<AttractionHistory> AttractionHistories { get; set; }
        public DbSet<PeriodicDiscount> PeriodicDiscounts { get; set; }
        public DbSet<SocialClassDiscount> SocialClassDiscounts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneHistory> ZoneHistories { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
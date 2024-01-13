using Airbnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore;

namespace Airbnb.Persistence.Contexts
{
    public class AirbnbDbContext : DbContext
    {
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=AirbnbDb;Uid=root;Pwd=153592;");
        }
    }
}

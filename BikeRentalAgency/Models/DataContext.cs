using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

using edunext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;

namespace edunext
{
    public class EduDbContext : DbContext
    {
        public EduDbContext() : base()
        {

        }
        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ComicBook>()
                .Property(c => c.PricePerDay)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Rental>();
            modelBuilder.Entity<RentalDetail>()
                .Property(r => r.PricePerDay)
                .HasColumnType("decimal(18, 2)");


        }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }
    }
}

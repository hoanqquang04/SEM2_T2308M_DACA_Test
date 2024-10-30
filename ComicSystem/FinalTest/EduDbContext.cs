using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalTest
{
    public class EduDbContext : DbContext
    {
        public EduDbContext() : base()
        {

        }

        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<ComicBooks> ComicBooks { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<RentalDetails> RentalDetails { get; set; }
    }
}

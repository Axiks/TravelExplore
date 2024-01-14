using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using TravelExplore.Data.Entities;

namespace TravelExplore.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .IsRequired();
        }
    }
}

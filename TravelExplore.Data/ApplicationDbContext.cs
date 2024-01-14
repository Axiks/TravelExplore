using Microsoft.EntityFrameworkCore;
using TravelExplore.Data.Entities;

namespace TravelExplore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}

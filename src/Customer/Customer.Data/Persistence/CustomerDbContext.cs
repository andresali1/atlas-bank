using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Persistence
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Entities.Customer> Customers { get; set; }
    }
}

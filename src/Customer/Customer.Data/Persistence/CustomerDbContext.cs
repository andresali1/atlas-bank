using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Persistence
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
        public DbSet<Entities.Customer> Customers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Customer>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}

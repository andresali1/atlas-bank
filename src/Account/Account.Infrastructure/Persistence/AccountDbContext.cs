using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Persistence
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Account> Accounts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Account>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Domain.Account>()
                .Property(x => x.CustomerId)
                .IsRequired();

            modelBuilder.Entity<Domain.Account>()
                .Property(x => x.Balance)
                .HasPrecision(18, 2)
                .IsRequired();

            modelBuilder.Entity<Domain.Account>()
                .Property(x => x.AccountType)
                .IsRequired();

            modelBuilder.Entity<Domain.Account>()
                .Property(x => x.AccountStatus)
                .IsRequired();
        }
    }
}

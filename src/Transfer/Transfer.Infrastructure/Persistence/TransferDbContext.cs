using Microsoft.EntityFrameworkCore;

namespace Transfer.Infrastructure.Persistence
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options) { }

        public DbSet<Domain.Transfer> Transfers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Transfer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Domain.Transfer>()
                .Property(x => x.SourceAccountId)
                .IsRequired();

            modelBuilder.Entity<Domain.Transfer>()
                .Property(x => x.TargetAccountId)
                .IsRequired();

            modelBuilder.Entity<Domain.Transfer>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}

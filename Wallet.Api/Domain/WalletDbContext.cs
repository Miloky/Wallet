using Microsoft.EntityFrameworkCore;

namespace Wallet.Api.Domain;

public class WalletDbContext: DbContext
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Entity && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            var entity = (Entity)entityEntry.Entity;
            var date = DateTime.UtcNow;

            entity.ModifiedOn = date;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedOn = date;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        throw new NotImplementedException();
    }
}
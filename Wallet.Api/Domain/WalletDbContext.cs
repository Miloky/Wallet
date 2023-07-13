using Microsoft.EntityFrameworkCore;

namespace Wallet.Api.Domain;

public class WalletDbContext: DbContext
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Account> Accounts { get; set; }
    // public DbSet<Currency> Currencies { get; set; }
}
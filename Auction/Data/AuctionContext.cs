using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data;

public class AuctionContext : DbContext
{
    public DbSet<Wallet> Wallet { get; set; }

    public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetLimits(modelBuilder);
        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public void SetLimits(ModelBuilder builder)
    {
        // Wallet
        builder.Entity<Wallet>().HasIndex(p => p.Id).IsUnique();
        builder.Entity<Wallet>().Property(p => p.Id).HasMaxLength(36).IsRequired();
        builder.Entity<Wallet>().Property(p => p.UserId).HasMaxLength(36).IsRequired();
        builder.Entity<Wallet>().Property(p => p.Currency).HasMaxLength(36).IsRequired();
    }

    public void SeedData(ModelBuilder builder)
    {
        builder.Entity<Wallet>().HasData(
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1000000.0M },
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1004300.0M },
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1023100.0M }
        );
    }
}
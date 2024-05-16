using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data;

public class AuctionContext : DbContext
{
    public DbSet<Wallet> Wallet { get; set; }
    public DbSet<Lot> Lot { get; set; }

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

        //Lot
        builder.Entity<Lot>().HasIndex(l => l.Id).IsUnique();
        builder.Entity<Lot>().Property(l => l.Id).HasMaxLength(36).IsRequired();
        builder.Entity<Lot>().Property(l => l.UserId).HasMaxLength(36).IsRequired();
        builder.Entity<Lot>().Property(l => l.Name).HasMaxLength(20).IsRequired();
        builder.Entity<Lot>().Property(l => l.Description).HasMaxLength(40).IsRequired();
        builder.Entity<Lot>().Property(l => l.Images).HasMaxLength(80).IsRequired();
        builder.Entity<Lot>().Property(l => l.StartPrice).HasMaxLength(4).IsRequired();
        builder.Entity<Lot>().Property(l => l.Tags).HasMaxLength(15).IsRequired();
        builder.Entity<Lot>().Property(l => l.TradingStart).HasMaxLength(20).IsRequired();
        builder.Entity<Lot>().Property(l => l.TradingDuration).HasMaxLength(20).IsRequired();
    }

    public void SeedData(ModelBuilder builder)
    {
        builder.Entity<Wallet>().HasData(
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1000000.0M },
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1004300.0M },
            new Wallet { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1023100.0M }
        );
        builder.Entity<Lot>().HasData(
            new Lot
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "Lot #1",
                Description = "Lorem ipsum dolor sit amet" +
                              " consectetur adipisicing elit. Earum, voluptas!",
                Images =
                    "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                StartPrice = 937.1M,
                Tags = "Test",
                TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
                TradingDuration = new DateTime(2020, 02, 12, 12, 0, 0)
            },
            new Lot
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = "Lot #1",
                Description = "Lorem ipsum dolor sit amet" +
                              " consectetur adipisicing elit. Earum, voluptas!",
                Images =
                    "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                StartPrice = 937.1M,
                Tags = "Test",
                TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
                TradingDuration = new DateTime(2020, 02, 12, 12, 0, 0)
            }
        );
    }
}
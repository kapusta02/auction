using Auction.Entities;
using Auction.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auction.Data;

public class AuctionContext : IdentityDbContext<User>
{
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Bid> Bids { get; set; }
    public DbSet<Lot> Lots { get; set; }

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
        builder.Entity<Wallet>().Property(p => p.Currency).HasMaxLength(36).IsRequired();

        // Bidding
        builder.Entity<Bid>().HasIndex(b => b.Id).IsUnique();
        builder.Entity<Bid>().Property(b => b.Id).HasMaxLength(36).IsRequired();

        //Lot
        builder.Entity<Lot>().HasIndex(l => l.Id).IsUnique();
        builder.Entity<Lot>().Property(l => l.Id).HasMaxLength(36).IsRequired();
        builder.Entity<Lot>().Property(l => l.UserId).HasMaxLength(36).IsRequired();
        builder.Entity<Lot>().Property(l => l.Name).HasMaxLength(256).IsRequired();
        builder.Entity<Lot>().Property(l => l.Description).HasMaxLength(500).IsRequired();
        builder.Entity<Lot>().Property(l => l.ImageLink).HasMaxLength(256).IsRequired();
        builder.Entity<Lot>().Property(l => l.StartPrice).HasMaxLength(4).IsRequired();
        builder.Entity<Lot>().Property(l => l.Tags).HasMaxLength(15).IsRequired();
    }

    public void SeedData(ModelBuilder builder)
    {
        string userId = Guid.NewGuid().ToString();
        string roleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = roleId,
                Name = UserRole.User.ToString(),
                NormalizedName = UserRole.User.ToString().ToUpper()
            }
        );
        var user = new User
        {
            Id = userId,
            FirstName = "Peter",
            LastName = "Parker",
            Email = "peter@example.com",
            NormalizedEmail = "PETER@EXAMPLE.COM",
            UserName = "peter",
            NormalizedUserName = "PETER",
            PhoneNumber = "+77771234567",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = "7b97acba-6bd1-4bcf-a319-e568f4890c9e"
        };
        IPasswordHasher<User> hasher = new PasswordHasher<User>();
        user.PasswordHash = hasher.HashPassword(user, "1234");

        builder.Entity<User>().HasData(user);

        builder.Entity<Wallet>().HasData(
            new Wallet
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Sum = 1000000.0M,
                CreatedAt = DateTime.Now
            }
        );

        builder.Entity<Lot>().HasData(
            new Lot
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = "Lot #1",
                Description = "Lorem ipsum dolor sit amet" +
                              " consectetur adipisicing elit. Earum, voluptas!",
                ImageLink =
                    "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                StartPrice = 937.1M,
                Tags = "Test",
                TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
                TradingDurationMinutes = 10,
                CreatedAt = DateTime.Now,
                IsBiddingStarted = false,
                IsArchived = false
            }
        );
    }
}
using Auction.Entities;
using Auction.Enums;
using Microsoft.EntityFrameworkCore;

namespace Auction;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity?> Users { get; set; } = null!;
    public DbSet<WalletEntity> Wallets { get; set; } = null!;
    public DbSet<LotEntity> Lots { get; set; } = null!;
    public DbSet<BiddingEntity> Biddings { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.NewGuid(), 
                UserName = "Tom", 
                PasswordHash = GenerateRandomPasswordHash(),
                Role = UserRole.User
            },
            new UserEntity
            {
                Id = Guid.NewGuid(), 
                UserName = "Jerry", 
                PasswordHash = GenerateRandomPasswordHash(),
                Role = UserRole.Moderator
            },
            new UserEntity
            {
                Id = Guid.NewGuid(), 
                UserName = "Bob", 
                PasswordHash = GenerateRandomPasswordHash(),
                Role = UserRole.Admin
            }
        );
        modelBuilder.Entity<WalletEntity>().HasData(
            new WalletEntity { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1000000.0 },
            new WalletEntity { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1004300.0 },
            new WalletEntity { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Balance = 1023100.0 }
        );
        modelBuilder.Entity<LotEntity>().HasData(
            new LotEntity
            {
                Id = Guid.NewGuid(), 
                UserId = Guid.NewGuid(), 
                Name = "Lot #1", 
                Description = "Lorem ipsum dolor sit amet," +
                              " consectetur adipisicing elit. Earum, voluptas!",
                Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                StartPrice = 937.1,
                Tags = "Test",
                TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
                TradingDuration = "2 days"
            },
            new LotEntity
            {
                Id = Guid.NewGuid(), 
                UserId = Guid.NewGuid(), 
                Name = "Lot #1", 
                Description = "Lorem ipsum dolor sit amet," +
                              " consectetur adipisicing elit. Earum, voluptas!",
                Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
                StartPrice = 937.1,
                Tags = "Test",
                TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
                TradingDuration = "2 days"
            }
        );
        modelBuilder.Entity<BiddingEntity>().HasData(
            new BiddingEntity
            {
                Id = Guid.NewGuid(), 
                LotId = Guid.NewGuid(), 
                Bid = 0.0,
                FinalPrice = 1000.0
            },
            new BiddingEntity
            {
                Id = Guid.NewGuid(), 
                LotId = Guid.NewGuid(), 
                Bid = 0.0,
                FinalPrice = 1020.0
            }
        );
    }
    private string GenerateRandomPasswordHash()
    {
        string password = "123123";
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
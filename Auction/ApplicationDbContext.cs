// using Auction.Entities;
// using Auction.Enums;
// using Microsoft.EntityFrameworkCore;
//
// namespace Auction;
//
// public sealed class ApplicationDbContext : DbContext
// {
//     public DbSet<Wallet> Wallets { get; set; } = null!;
//     public DbSet<Lot> Lots { get; set; } = null!;
//     public DbSet<Bidding> Biddings { get; set; } = null!;
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//         :base(options)
//     {
//         Database.EnsureCreated();
//     }
//     
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Lot>().HasData(
//             new Lot
//             {
//                 Id = Guid.NewGuid(), 
//                 UserId = Guid.NewGuid(), 
//                 Name = "Lot #1", 
//                 Description = "Lorem ipsum dolor sit amet," +
//                               " consectetur adipisicing elit. Earum, voluptas!",
//                 Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
//                 StartPrice = 937.1,
//                 Tags = "Test",
//                 TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
//                 TradingDuration = "2 days"
//             },
//             new Lot
//             {
//                 Id = Guid.NewGuid(), 
//                 UserId = Guid.NewGuid(), 
//                 Name = "Lot #1", 
//                 Description = "Lorem ipsum dolor sit amet," +
//                               " consectetur adipisicing elit. Earum, voluptas!",
//                 Images = "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user",
//                 StartPrice = 937.1,
//                 Tags = "Test",
//                 TradingStart = new DateTime(2020, 02, 10, 12, 0, 0),
//                 TradingDuration = "2 days"
//             }
//         );
//         modelBuilder.Entity<Bidding>().HasData(
//             new Bidding
//             {
//                 Id = Guid.NewGuid(), 
//                 LotId = Guid.NewGuid(), 
//                 Bid = 0.0,
//                 FinalPrice = 1000.0
//             },
//             new Bidding
//             {
//                 Id = Guid.NewGuid(), 
//                 LotId = Guid.NewGuid(), 
//                 Bid = 0.0,
//                 FinalPrice = 1020.0
//             }
//         );
//     }
//     private string GenerateRandomPasswordHash()
//     {
//         string password = "123123";
//         return BCrypt.Net.BCrypt.HashPassword(password);
//     }
// }
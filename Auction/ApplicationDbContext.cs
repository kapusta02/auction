// using Auction.Entities;
// using Auction.Enums;
// using Microsoft.EntityFrameworkCore;
//
// namespace Auction;
//
// public sealed class ApplicationDbContext : DbContext
// {
//     public DbSet<Bidding> Biddings { get; set; } = null!;
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//         :base(options)
//     {
//         Database.EnsureCreated();
//     }
//     
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
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
// }
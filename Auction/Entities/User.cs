using Microsoft.AspNetCore.Identity;

namespace Auction.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool IsBlocked { get; set; }
    public Wallet? Wallet { get; set; }
    public List<Bidding> Biddings { get; set; } = null!;
    public List<Lot> Lots { get; set; } = null!;
}
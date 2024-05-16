using Microsoft.AspNetCore.Identity;

namespace Auction.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool IsBlocked { get; set; }
}
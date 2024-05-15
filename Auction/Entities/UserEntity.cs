using Microsoft.AspNetCore.Identity;

namespace Auction.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PasswordHash { get; set; }
}
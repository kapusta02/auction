using Auction.Enums;
using Microsoft.AspNetCore.Identity;

namespace Auction.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public bool IsBlocked { get; set; }
}
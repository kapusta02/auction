using Auction.Enums;
using Microsoft.AspNetCore.Identity;

namespace Auction.DTOs;

public class UserDto: IdentityUser<Guid>
{
    public string UserName { get; set; }
    public string? Password { get; set; }
    public UserRole? Role { get; set; }
}
using Auction.Contracts.Auth;

namespace Auction.Services.Auth;

public class PasswordHashService : IPasswordHash
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public bool VerifyPassword(string? hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
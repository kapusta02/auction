namespace Auction.Contracts.Auth;

public interface IPasswordHash
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}
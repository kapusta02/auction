namespace Auction.Contracts.Auth;

public interface IAuthService
{
    Task<string?> LoginAsync(string username, string password);
    Task<string> RegisterUserAsync(string username, string password);
}
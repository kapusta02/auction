using Auction.Entities;

namespace Auction.Contracts.Auth;

public interface IAuthService
{
    Task<UserEntity?> LoginAsync(string username, string password);
    Task<string> RegisterUserAsync(string username, string password);
    Task<bool> SetUserBlockedStatusAsync(string userName, bool isBlocked);
}
using Auction.Entities;

namespace Auction.Contracts.Auth;

public interface IAuthRepository
{
    Task<UserEntity?> LoginAsync(string username, string password);
    Task<UserEntity> RegisterUserAsync(string username, string password);
}
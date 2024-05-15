using Auction.Contracts.Auth;
using Auction.Entities;

namespace Auction.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<UserEntity?> LoginAsync(string username, string password)
    {
        var user = await _authRepository.LoginAsync(username, password);
        if (user == null)
            return null;
        return user;
    }

    public async Task<string?> RegisterUserAsync(string username, string password)
    {
        var existingUser = await _authRepository.LoginAsync(username, password);
        if (existingUser != null)
            return null;
        var newUser = await _authRepository.RegisterUserAsync(username, password);
        return $"{newUser}";
    }
    
    public async Task<bool> SetUserBlockedStatusAsync(string userName, bool isBlocked)
    {
        return await _authRepository.SetUserBlockedStatusAsync(userName, isBlocked);
    }

}
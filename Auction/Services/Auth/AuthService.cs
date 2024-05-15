using Auction.Contracts.Auth;

namespace Auction.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<string?> LoginAsync(string username, string password)
    {
        var user = await _authRepository.LoginAsync(username, password);
        if (user == null)
            return null;
        return $"{user.Id}";
    }

    public async Task<string?> RegisterUserAsync(string username, string password)
    {
        var existingUser = await _authRepository.LoginAsync(username, password);
        if (existingUser != null)
            return null;
        var newUser = await _authRepository.RegisterUserAsync(username, password);
        return $"{newUser}";
    }
}
using Auction.DTOs;

namespace Auction.Interfaces;

public interface IAuthService
{
    Task<UserDto?> RegisterAsync(UserRegisterDto dto);

    Task<UserDto?> GetUserByIdAsync(Guid id);

    Task<bool> LogOutAsync();
    Task<UserDto?> LoginAsync(UserLoginDto dto);
}
using Auction.DTOs;
using Auction.Model;

namespace Auction.Interfaces;

public interface IUserService
{
    Task<UserBlockResponse> UserBlockByIdAsync(Guid id);
    Task<UserDto?> UpdateUserRoleAsync(Guid id);
    Task<UserDto?> DeleteModeratorRoleAsync(Guid id);
}
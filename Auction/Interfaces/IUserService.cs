using Auction.DTOs;

namespace Auction.Interfaces;

public interface IUserService
{
   Task<UserDto?> UserBlockByIdAsync(Guid id);
   Task<UserDto?> UpdateUserRoleAsync(Guid id);
   Task<UserDto?> DeleteModeratorRoleAsync(Guid id);
}
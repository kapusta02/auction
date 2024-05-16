using Auction.DTOs;

namespace Auction.Interfaces;

public interface IUserService
{
   Task<UserDto?> UserBlockByIdAsync(Guid id);
}
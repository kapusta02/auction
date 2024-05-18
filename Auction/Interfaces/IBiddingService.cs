using Auction.DTOs;

namespace Auction.Interfaces;

public interface IBiddingService
{
    Task<string> StartBidding(Guid id, string userId);
    Task<UserDto?> EndBidding(Guid lotId, string userId);
    Task<string> PlaceBid(string userId, Guid lotId, decimal amount);
}
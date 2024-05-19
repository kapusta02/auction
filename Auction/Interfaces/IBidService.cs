using Auction.DTOs;

namespace Auction.Interfaces;

public interface IBidService
{
    Task<BidDto?> CreateBid(BidCreateDto bidCreateDto);
}
using Auction.DTOs;

namespace Auction.Interfaces;

public interface IWalletService
{
    Task<List<WalletDto>> GetWalletsByUserId(Guid userId);
    Task<WalletDto?> GetWalletById(Guid id);
    Task<List<WalletDto>> GetAll();
}
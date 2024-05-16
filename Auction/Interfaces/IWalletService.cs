using Auction.DTOs;

namespace Auction.Interfaces;

public interface IWalletService
{
    Task<List<WalletDto>> GetAll();
    Task<WalletDto?> GetWalletById(Guid id);
    Task<List<WalletDto>> GetWalletsByUserId(Guid userId);
    Task<WalletDto> CreateWallet(WalletCreateDto dto);
    Task<WalletDto> UpdateBalance(WalletUpdateBalance dto);
}
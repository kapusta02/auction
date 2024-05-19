using Auction.DTOs;

namespace Auction.Interfaces;

public interface IWalletService
{
    Task<List<WalletDto>> GetAll();
    Task<WalletDto?> GetWalletById(Guid id);
    Task<WalletDto?> GetWalletByUserId(string userId);
    Task<WalletDto> CreateWallet(WalletCreateDto dto);
    Task<WalletDto?> UpdateWallet(WalletUpdateDto dto);
    Task<bool> DebitingCash(string userId, decimal sum);
    Task<bool> ReturnCash(string userId, decimal sum);
    Task<bool> DeleteWallet(Guid walletId);
}
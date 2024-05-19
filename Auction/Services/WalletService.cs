using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class WalletService : IWalletService
{
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;

    public WalletService(IMapper mapper, AuctionContext db)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<WalletDto>> GetAll()
    {
        var wallets = await _db.Wallets.ToListAsync();

        var walletDtos = _mapper.Map<List<WalletDto>>(wallets);
        return walletDtos;
    }

    public async Task<WalletDto?> GetWalletById(Guid id)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.Id == id);
        if (wallet == null)
            return null;

        var walletDto = _mapper.Map<WalletDto>(wallet);
        return walletDto;
    }

    public async Task<WalletDto?> GetWalletByUserId(string userId)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);

        var walletDto = _mapper.Map<WalletDto>(wallet);
        return walletDto;
    }

    public async Task<WalletDto> CreateWallet(WalletCreateDto dto)
    {
        var wallet = _mapper.Map<Wallet>(dto);
        wallet.Currency = "Kaspi Coin";
        wallet.CreatedAt = DateTime.Now;

        _db.Wallets.Add(wallet);
        await _db.SaveChangesAsync();

        var walletDto = _mapper.Map<WalletDto>(wallet);
        return walletDto;
    }

    public async Task<WalletDto?> UpdateWallet(WalletUpdateDto dto)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == dto.UserId);
        if (wallet == null)
            return null;

        wallet.Sum += Math.Abs(dto.Sum);
        wallet.UpdatedAt = DateTime.Now;
        _db.Update(wallet);
        await _db.SaveChangesAsync();

        var walletDto = _mapper.Map<WalletDto>(wallet);
        return walletDto;
    }

    public async Task<bool> DebitingCash(string userId, decimal sum)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        if (wallet == null)
            return false;

        wallet.Sum -= Math.Abs(sum);
        wallet.UpdatedAt = DateTime.Now;
        
        _db.Wallets.Update(wallet);
        return true;
    }

    public async Task<bool> ReturnCash(string userId, decimal sum)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
        if (wallet == null)
            return false;

        wallet.Sum += Math.Abs(sum);
        wallet.UpdatedAt = DateTime.Now;

        _db.Wallets.Update(wallet);
        return true;
    }

    public async Task<bool> DeleteWallet(Guid walletId)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);
        if (wallet == null)
            return false;

        _db.Wallets.Remove(wallet);
        await _db.SaveChangesAsync();

        return true;
    }
}
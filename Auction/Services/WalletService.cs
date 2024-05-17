using System.Security.Claims;
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
        return _mapper.Map<List<WalletDto>>(wallets);
    }

    public async Task<WalletDto?> GetWalletById(Guid id)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.Id == id);
        if (wallet == null)
            return null;

        return _mapper.Map<WalletDto>(wallet);
    }

    public async Task<List<WalletDto>> GetWalletsByUserId(string userId)
    {
        var wallet = await _db.Wallets.Where(w => w.UserId.ToUpper() == userId.ToUpper())
            .ToListAsync();

        return _mapper.Map<List<WalletDto>>(wallet);
    }

    public async Task<WalletDto> CreateWallet(WalletCreateDto dto)
    {
        var wallet = _mapper.Map<Wallet>(dto);
        wallet.Currency = "Kaspi Coin";

        _db.Wallets.Add(wallet);
        await _db.SaveChangesAsync();

        return _mapper.Map<WalletDto>(wallet);
    }

    public async Task<WalletDto?> UpdateBalance(WalletUpdateBalance dto)
    {
        var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.UserId == dto.UserId);
        if (wallet == null)
            return null;

        wallet.Balance += dto.Balance;
        await _db.SaveChangesAsync();

        return _mapper.Map<WalletDto>(wallet);
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
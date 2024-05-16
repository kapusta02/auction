using System.Security.Claims;
using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class WalletService : IWalletService
{
    private readonly UserManager<User> _userManager;
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    

    public WalletService(IMapper mapper, AuctionContext db, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _db = db;
        _mapper = mapper;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<List<WalletDto>> GetAll()
    {
        var wallets = await _db.Wallet.ToListAsync();
        return _mapper.Map<List<WalletDto>>(wallets);
    }
    
    public async Task<WalletDto?> GetWalletById(Guid id)
    {
        var wallet = await _db.Wallet.FirstOrDefaultAsync(w => w.Id == id);
        if (wallet == null)
            return null;

        return _mapper.Map<WalletDto>(wallet);
    }

    public async Task<List<WalletDto>> GetWalletsByUserId(Guid userId)
    {
        var wallet = await _db.Wallet.Where(w => w.UserId.ToString().ToUpper() == userId.ToString().ToUpper()).ToListAsync();

        return _mapper.Map<List<WalletDto>>(wallet);
    }

    public async Task<WalletDto> CreateWallet(WalletCreateDto dto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new InvalidOperationException("Пользователь не авторизован");
        }

        var id = Guid.Parse(userId);
        if (_db.Wallet.Any(w => w.UserId == id))
        {
            throw new InvalidOperationException("Кошелек уже создан");
        }

        var wallet = _mapper.Map<Wallet>(dto);
        wallet.Id = Guid.NewGuid();
        wallet.UserId = id;
        wallet.Currency = "Kaspi Coin";

        _db.Wallet.Add(wallet);
        await _db.SaveChangesAsync();

        return _mapper.Map<WalletDto>(wallet);
    }

    public async Task<WalletDto> UpdateBalance(WalletUpdateBalance dto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new InvalidOperationException("Пользователь не авторизован");
        }

        var id = Guid.Parse(userId);
        var wallet = await _db.Wallet.FirstOrDefaultAsync(w => w.UserId == id);
        if (wallet == null)
        {
            throw new InvalidOperationException("Кошелек не найден");
        }

        wallet.Balance += dto.Balance;
        await _db.SaveChangesAsync();

        return _mapper.Map<WalletDto>(wallet);
    }

}
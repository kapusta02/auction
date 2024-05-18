using Auction.Data;
using Auction.DTOs;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class BiddingService : IBiddingService
{
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;

    public BiddingService(IMapper mapper, AuctionContext db)
    {
        _mapper = mapper;
        _db = db;
    }

    public async Task<string> StartBidding(Guid lotId, string userId)
    {
        var lot = await _db.Lots.FirstOrDefaultAsync(l => l.Id == lotId);
        if (lot == null)
            return "Лот не найден";

        if (DateTime.Now > lot.TradingDuration)
        {
            if (lot.CurrentBid == 0)
            {
                lot.IsArchived = true;
                await _db.SaveChangesAsync();
                return "Торги закончились, ни одной ставки не было сделано";
            }
            await EndBidding(lotId, userId);
            return "Торги закончились";
        }

        if (DateTime.Now > lot.TradingStart)
        {
            lot.IsStarted = true;
            await _db.SaveChangesAsync();

            var bidding = await _db.Biddings.FirstOrDefaultAsync(b => b.Lot.Contains(lot));
            if (bidding != null)
            {
                bidding.IsBindingsStarted = true;
                await _db.SaveChangesAsync();
            }

            return "Торги идут";
        }

        return "Торги еще не начались";
    }

    public async Task<UserDto?> EndBidding(Guid lotId, string userId)
    {
        var lot = await _db.Lots.FirstOrDefaultAsync(l => l.Id == lotId);
        if (lot == null)
            return null;

        var highestBid = lot.CurrentBid;

        var winner = await _db.Users.Include(u => u.Wallet).FirstOrDefaultAsync(u => u.Id == userId);
        if (winner == null)
        {
            lot.IsArchived = true;
            await _db.SaveChangesAsync();
            return null;
        }

        lot.IsArchived = true;
        await _db.SaveChangesAsync();
        return _mapper.Map<UserDto>(winner);
    }


    public async Task<string> PlaceBid(string userId, Guid lotId, decimal amount)
    {
        var user = await _db.Users.Include(u => u.Wallet).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return "Пользователь не найден";

        var lot = await _db.Lots.FirstOrDefaultAsync(l => l.Id == lotId);
        if (lot == null)
            return "Лот не найден";

        if (!lot.IsStarted)
            return "Торги еще не начались";

        if (amount <= lot.CurrentBid)
            return "Ставка должна быть выше текущей цены";

        if (user.Wallet == null || user.Wallet.Balance < amount)
            return "Недостаточно средств на счету";

        lot.CurrentBid = amount;
        user.Wallet.Balance -= amount;

        await _db.SaveChangesAsync();

        return "Ставка успешно сделана";
    }
}
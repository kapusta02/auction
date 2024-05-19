using Auction.Configurations;
using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Enums;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class BidService : IBidService
{
    private readonly AuctionContext _db;
    private readonly ILotService _lotService;
    private readonly IWalletService _walletService;
    private readonly IMapper _mapper;

    public BidService(IMapper mapper, AuctionContext db, ILotService lotService, IWalletService walletService)
    {
        _mapper = mapper;
        _db = db;
        _lotService = lotService;
        _walletService = walletService;
    }

    public async Task<BidDto?> CreateBid(BidCreateDto bidCreateDto)
    {
        var user = await _db.Users.Include(u => u.Wallet).FirstOrDefaultAsync(u => u.Id == bidCreateDto.UserId);
        if (user == null)
            throw new ExceptionsExtension(ExceptionTypes.EntityNotFoundException,
                "Запрашиваемого пользователя не существует");

        var lot = await _lotService.GetLotById(bidCreateDto.LotId);
        if (lot == null)
            throw new ExceptionsExtension(ExceptionTypes.EntityNotFoundException, "Запрашиваемого лота не существует");

        var lotDto = await _db.Lots.FirstOrDefaultAsync(l => l.Id == bidCreateDto.LotId);


        if (DateTime.Now >= lot.TradingStart)
        {
            if (lotDto != null)
            {
                lotDto.IsBiddingStarted = true;
                _db.Lots.Update(lotDto);
            }

            await _db.SaveChangesAsync();
        }

        if (!lot.IsBiddingStarted)
            throw new ExceptionsExtension(ExceptionTypes.ConflictException, "Торги еще не начались");

        if (DateTime.Now >= lot.TradingStart.AddMinutes(lot.TradingDurationMinutes))
        {
            if (!await _db.Bids.AnyAsync(b => b.Lot.Id == bidCreateDto.LotId))
            {
                if (lotDto != null)
                {
                    lotDto.IsArchived = true;
                    _db.Lots.Update(lotDto);
                }

                await _db.SaveChangesAsync();
                throw new ExceptionsExtension(ExceptionTypes.ConflictException,
                    "Время торгов истекло, лот перенесен в архив");
            }

            var winningBid = await GetCurrentLeadingBidByLotId(bidCreateDto.LotId);
            if (winningBid != null)
            {
                var auctionWinnerId = winningBid.UserId;
                var auctionWinner = await _db.Users.FindAsync(auctionWinnerId);
                if (auctionWinner != null)
                    lot.UserId = auctionWinnerId;

                throw new ExceptionsExtension(ExceptionTypes.ConflictException,
                    $"Торги закончены, победитель {auctionWinner}");
            }
        }

        if (user.Wallet == null || user.Wallet.Sum < bidCreateDto.Sum)
            throw new ExceptionsExtension(ExceptionTypes.ConflictException, "Недостаточно средств на счету");

        var currentLeadingBid = await GetCurrentLeadingBidByLotId(bidCreateDto.LotId);
        if (currentLeadingBid != null && bidCreateDto.Sum <= currentLeadingBid.Sum)
            throw new ExceptionsExtension(ExceptionTypes.ConflictException,
                "Сумма ставки должна быть выше текущей ставки");

        var bid = _mapper.Map<Bid>(bidCreateDto);
        bid.CreatedAt = DateTime.Now;

        var added = await _db.Bids.AddAsync(bid);

        var isPaymentSuccessed = await PaymentOperations(bidCreateDto.UserId, bidCreateDto.Sum, currentLeadingBid);
        if (!isPaymentSuccessed)
            throw new ExceptionsExtension(ExceptionTypes.ConflictException, "Не удалось выполнить финансовые операции");

        var result = await _lotService.SetCurrentLeadingBid(lot.Id, added.Entity.Id);
        if (!result)
            throw new ExceptionsExtension(ExceptionTypes.ConflictException, "Не удалось установить текущую ставку");

        var bidDto = _mapper.Map<BidDto>(bid);
        return bidDto;
    }

    public async Task<BidDto?> GetCurrentLeadingBidByLotId(Guid lotId)
    {
        var bid = await _db.Bids.FirstOrDefaultAsync(b => b.LotId == lotId);
        if (bid == null)
            return null;

        var bidDto = _mapper.Map<BidDto>(bid);
        return bidDto;
    }

    private async Task<bool> PaymentOperations(string debitingUserId, decimal debitingSum, BidDto? currentLeadingBid)
    {
        var debitingResult = await _walletService.DebitingCash(debitingUserId, debitingSum);

        if (currentLeadingBid != null)
        {
            var returningResult = await _walletService.ReturnCash(currentLeadingBid.UserId, currentLeadingBid.Sum);

            if (!debitingResult || !returningResult)
                return false;

            await _db.SaveChangesAsync();
            return true;
        }

        if (!debitingResult)
            return false;

        await _db.SaveChangesAsync();
        return true;
    }
}
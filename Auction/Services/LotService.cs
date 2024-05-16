using System.Security.Claims;
using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class LotService : ILotService
{
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LotService(IMapper mapper, AuctionContext db, IHttpContextAccessor httpContextAccessor)
    {
        _db = db;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<LotDto>> GetAll()
    {
        var lots = await _db.Lot.ToListAsync();
        return _mapper.Map<List<LotDto>>(lots);
    }

    public async Task<LotDto?> GetLotById(Guid id)
    {
        var lot = await _db.Lot.FirstOrDefaultAsync(l => l.Id == id);
        if (lot == null)
            return null;

        return _mapper.Map<LotDto>(lot);
    }

    public async Task<LotDto> CreateLot(LotCreateDto dto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            throw new InvalidOperationException("Пользователь не авторизован");

        var lot = _mapper.Map<Lot>(dto);
        lot.Id = Guid.NewGuid();
        lot.UserId = Guid.Parse(userId);

        _db.Lot.Add(lot);
        await _db.SaveChangesAsync();

        return _mapper.Map<LotDto>(lot);
    }

    public async Task<LotDto> UpdateLot(LotUpdateDto dto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            throw new InvalidOperationException("Пользователь не авторизован");

        var id = Guid.Parse(userId);

        var lot = await _db.Lot.FirstOrDefaultAsync(w => w.UserId == id);
        if (lot == null)
            throw new InvalidOperationException("Лот не найден");
        if (lot.UserId.ToString() != userId)
            throw new InvalidOperationException("Вы не можете редактировать этот лот");

        _mapper.Map(dto, lot);
        await _db.SaveChangesAsync();
        return _mapper.Map<LotDto>(lot);
    }

    public async Task DeleteLot(Guid lotId)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            throw new InvalidOperationException("Пользователь не авторизован");

        var lot = await _db.Lot.FirstOrDefaultAsync(w => w.Id == lotId);
        if (lot == null)
            throw new InvalidOperationException("Лот не найден");

        _db.Lot.Remove(lot);
        await _db.SaveChangesAsync();
    }
}
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

    public LotService(IMapper mapper, AuctionContext db)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<LotDto>> GetAll()
    {
        var lots = await _db.Lots.ToListAsync();
        return _mapper.Map<List<LotDto>>(lots);
    }

    public async Task<LotDto?> GetLotById(Guid id)
    {
        var lot = await _db.Lots.FirstOrDefaultAsync(l => l.Id == id);
        if (lot == null)
            return null;

        return _mapper.Map<LotDto>(lot);
    }

    public async Task<List<LotDto>> GetLotsByUserId(string userId)
    {
        var lots = await _db.Lots.Where(l => l.UserId == userId).ToListAsync();
        return _mapper.Map<List<LotDto>>(lots);
    }

    public async Task<LotDto> CreateLot(LotCreateDto dto)
    {
        var lot = _mapper.Map<Lot>(dto);
        lot.CreatedAt = DateTime.Now;

        _db.Lots.Add(lot);
        await _db.SaveChangesAsync();

        return _mapper.Map<LotDto>(lot);
    }

    public async Task<LotDto?> UpdateLot(LotUpdateDto dto)
    {
        var lot = await _db.Lots.FirstOrDefaultAsync(w => w.UserId == dto.UserId);
        if (lot == null)
            return null;

        lot.UpdatedAt = DateTime.Now;
        _mapper.Map(dto, lot);
        await _db.SaveChangesAsync();

        return _mapper.Map<LotDto>(lot);
    }

    public async Task<bool> DeleteLot(Guid lotId)
    {
        var lot = await _db.Lots.FirstOrDefaultAsync(w => w.Id == lotId);
        if (lot == null)
            return false;

        _db.Lots.Remove(lot);
        await _db.SaveChangesAsync();

        return true;
    }
}
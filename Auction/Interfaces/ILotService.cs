using Auction.DTOs;

namespace Auction.Interfaces;

public interface ILotService
{
    Task<List<LotDto>> GetAll();
    Task<LotDto?> GetLotById(Guid id);
    Task<List<LotDto>> GetLotsByUserId(string userId);
    Task<LotDto> CreateLot(LotCreateDto dto);
    Task<LotDto> UpdateLot(LotUpdateDto dto);
    Task DeleteLot(Guid lotId);
}
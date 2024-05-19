using System.Security.Claims;
using Auction.DTOs;
using Auction.Enums;
using Auction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LotsController : ControllerBase
{
    private readonly ILotService _lotService;
    private readonly ILogger<WalletsController> _logger;

    public LotsController(ILotService lotService, ILogger<WalletsController> logger)
    {
        _lotService = lotService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? userId)
    {
        List<LotDto> lotDtos;
        if (userId != null)
            lotDtos = await _lotService.GetLotsByUserId(userId);
        else
            lotDtos = await _lotService.GetAll();

        return Ok(lotDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var walletDto = await _lotService.GetLotById(id);
        if (walletDto == null)
            return StatusCode(404, "Лот не найден");

        return Ok(walletDto);
    }

    [Authorize]
    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> CreateLot([FromBody] LotCreateDto dto)
    {
        try
        {
            var walletDto = await _lotService.CreateLot(dto);
            return Ok(walletDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(400, "Невозможно создать больше одного лота");
        }
    }

    [Authorize]
    [HttpPut]
    [ActionName("updateLot")]
    public async Task<IActionResult> UpdateLot([FromBody] LotUpdateDto dto)
    {
        if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value != dto.UserId)
            return StatusCode(403, "Недостаточно средств");

        var lotDto = await _lotService.UpdateLot(dto);
        if (lotDto == null)
            return StatusCode(400, "Лот не найден");

        return Ok(lotDto);
    }

    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> DeleteLot(Guid lotId)
    {
        if (!User.IsInRole(UserRole.Admin.ToString()) && !User.IsInRole(UserRole.Moderator.ToString()))
            return StatusCode(403, "Недостаточно прав");

        var isDeleted = await _lotService.DeleteLot(lotId);
        if (!isDeleted)
            return StatusCode(404, "Лот не найден");

        return Ok("Лот успешно удален");
    }
}
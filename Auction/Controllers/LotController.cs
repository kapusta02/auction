using Auction.DTOs;
using Auction.Enums;
using Auction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LotController : ControllerBase
{
    private readonly ILotService _lotService;
    private readonly ILogger<WalletsController> _logger;

    public LotController(ILotService lotService, ILogger<WalletsController> logger)
    {
        _lotService = lotService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lotDtos = await _lotService.GetAll();
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
        catch (InvalidOperationException e)
        {
            _logger.LogError(e.Message);
            return StatusCode(400, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [Authorize]
    [HttpPut]
    [ActionName("updateLot")]
    public async Task<IActionResult> UpdateLot([FromBody] LotUpdateDto dto)
    {
        try
        {
            var walletDto = await _lotService.UpdateLot(dto);
            return Ok(walletDto);
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e.Message);
            return StatusCode(400, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> DeleteLot(Guid lotId)
    {
        try
        {
            if (!User.IsInRole(UserRole.Moderator.ToString()) && !User.IsInRole(UserRole.Admin.ToString()))
                return StatusCode(403, "Недостаточно прав");

            await _lotService.DeleteLot(lotId);
            return Ok("Лот успешно удален");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }
}
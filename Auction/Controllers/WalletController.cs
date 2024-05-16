using Auction.DTOs;
using Auction.Enums;
using Auction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _walletService;
    private readonly ILogger<WalletsController> _logger;


    public WalletsController(IWalletService walletService, ILogger<WalletsController> logger)
    {
        _walletService = walletService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var walletDtos = await _walletService.GetAll();
        
        return Ok(walletDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!User.IsInRole(UserRole.Admin.ToString()))
        {
            return StatusCode(403, "Недостаточно прав");
        }
        
        var walletDto = await _walletService.GetWalletById(id);
        
        return Ok(walletDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromQuery] Guid userId)
    {
        var walletDtos = await _walletService.GetWalletsByUserId(userId);
        
        return Ok(walletDtos);
    }

    [Authorize]
    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> CreateWallet([FromBody] WalletCreateDto dto)
    {
        try
        {
            var walletDto = await _walletService.CreateWallet(dto);
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
    [HttpPatch]
    [ActionName("updateBalance")]
    public async Task<IActionResult> UpdateBalance([FromBody] WalletUpdateBalance dto)
    {
        try
        {
            var walletDto = await _walletService.UpdateBalance(dto);
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
    public async Task<IActionResult> DeleteWallet(Guid walletId)
    {
        try
        {
            await _walletService.DeleteWallet(walletId);
            return Ok("Кошелек успешно удален");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
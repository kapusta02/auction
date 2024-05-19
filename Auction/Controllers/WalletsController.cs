using System.Security.Claims;
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
    public async Task<IActionResult> Get([FromQuery] string? userId)
    {
        var walletDtos = new List<WalletDto>();
        if (userId != null)
        {
            var userWallet = await _walletService.GetWalletByUserId(userId);
            if (userWallet != null)
                walletDtos.Add(userWallet);
        }
        else
        {
            if (User.IsInRole(UserRole.Admin.ToString()))
                walletDtos = await _walletService.GetAll();
        }

        return Ok(walletDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!User.IsInRole(UserRole.Admin.ToString()))
            return StatusCode(403, "Недостаточно прав");

        var walletDto = await _walletService.GetWalletById(id);
        return Ok(walletDto);
    }

    [Authorize]
    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] WalletCreateDto dto)
    {
        try
        {
            var walletDto = await _walletService.CreateWallet(dto);
            return Ok(walletDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(400, "Невозможно создать более одного кошелька");
        }
    }

    [Authorize]
    [HttpPut]
    [ActionName("update")]
    public async Task<IActionResult> Update([FromBody] WalletUpdateDto dto)
    {
        var walletDto = await _walletService.UpdateWallet(dto);
        if (walletDto == null)
            return StatusCode(400, "Кошелек не найден");

        return Ok(walletDto);
    }

    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> Delete(Guid walletId, string? userId)
    {
        if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value != userId)
            return StatusCode(403, "Недостаточно прав");

        bool isDeleted = await _walletService.DeleteWallet(walletId);

        if (!isDeleted)
            return StatusCode(404, "Кошелек не найден");

        return Ok("Кошелек успешно удален");
    }
}
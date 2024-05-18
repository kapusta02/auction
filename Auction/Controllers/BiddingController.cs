using Auction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BiddingController : ControllerBase
{
    private readonly IBiddingService _biddingService;
    private readonly ILogger<BiddingController> _logger;

    public BiddingController(IBiddingService biddingService, ILogger<BiddingController> logger)
    {
        _biddingService = biddingService;
        _logger = logger;
    }

    [HttpGet]
    [ActionName("start")]
    public async Task<IActionResult> StartBiddingAsync([FromQuery] Guid lotId, [FromQuery] string userId)
    {
        try
        {
            var message = await _biddingService.StartBidding(lotId, userId);
            if (message == "Торги закончились")
            {
                var winner = await _biddingService.EndBidding(lotId, userId);
                if (winner != null)
                {
                    return Ok(new {message, winner});
                }
            }
            return Ok(message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, "Ошибка при начале торгов");
        }
    }

    
    [HttpPost]
    [ActionName("bid")]
    public async Task<IActionResult> PlaceBid([FromQuery] string userId, [FromQuery] Guid lotId, [FromQuery] decimal amount)
    {
        var result = await _biddingService.PlaceBid(userId, lotId, amount);
        return Ok(result);
    }
}
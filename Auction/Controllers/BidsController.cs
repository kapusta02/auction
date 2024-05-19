using Auction.Configurations;
using Auction.DTOs;
using Auction.Enums;
using Auction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BidsController : ControllerBase
{
    private readonly IBidService _biddingService;
    private readonly ILogger<BidsController> _logger;

    public BidsController(IBidService biddingService, ILogger<BidsController> logger)
    {
        _biddingService = biddingService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BidCreateDto bidCreateDto)
    {
        try
        {
            var bidDto = await _biddingService.CreateBid(bidCreateDto);
            return Ok(bidDto);
        }
        catch (ExceptionsExtension e)
        {
            _logger.LogError(e.Message);

            if (e.ExceptionType == ExceptionTypes.EntityNotFoundException)
                return StatusCode(404, e.Message);

            if (e.ExceptionType == ExceptionTypes.ConflictException)
                return StatusCode(409, e.Message);

            return StatusCode(400, e.Message);
        }
    }
}
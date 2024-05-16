using Auction.Enums;
using Auction.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;


    public UserController(IAuthService authService, IUserService userService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _userService = userService;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!User.IsInRole(UserRole.Admin.ToString()))
            return StatusCode(403, "Недостаточно прав");

        var users = await _authService.GetUserByIdAsync(id);
        return Ok(users);
    }

    [HttpPatch]
    [ActionName("updateRole")]
    public async Task<IActionResult> UpdateUserRoleAsync([FromBody] Guid id)
    {
        try
        {
            if (!User.IsInRole(UserRole.Admin.ToString()))
                return StatusCode(403, "Недостаточно прав");

            var result = await _userService.UpdateUserRoleAsync(id);
            if (result == null)
                return NotFound("Пользователь не найден");

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [ActionName("deleteRole")]
    public async Task<IActionResult> DeleteModeratorRoleAsync([FromBody] Guid id)
    {
        try
        {
            if (!User.IsInRole(UserRole.Admin.ToString()))
                return StatusCode(403, "Недостаточно прав");

            var result = await _userService.DeleteModeratorRoleAsync(id);
            if (result == null)
                return NotFound("Пользователь не найден");

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [ActionName("block")]
    public async Task<IActionResult> BlockUserAsync([FromBody] Guid id)
    {
        try
        {
            if (!User.IsInRole(UserRole.Moderator.ToString()) && !User.IsInRole(UserRole.Admin.ToString()))
                return StatusCode(403, "Недостаточно средств");

            var result = await _userService.UserBlockByIdAsync(id);
            if (result == null)
                return StatusCode(404, "Данный пользователь не найден");
            return Ok(result);
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
}
using Auction.DTOs;
using Auction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost]
    [ActionName("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterDto userRegisterDto)
    {
        try
        {
            var result = await _authService.RegisterAsync(userRegisterDto);
            if (result == null)
                return Unauthorized("Неверный логин или пароль");
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [ActionName("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userLoginDto)
    {
        try
        {
            var result = await _authService.LoginAsync(userLoginDto);
            if (result == null)
                return Unauthorized("Неверный логин или пароль");
            if (result.IsBlocked)
                return BadRequest("Пользователь заблокироан");

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, e);
        }
    }

    [Authorize]
    [HttpGet]
    [ActionName("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogOutAsync();

        return NoContent();
    }
}
using Auction.Contracts.Auth;
using Auction.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers.Auth;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [ActionName("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserDto userDto)
    {
        try
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Логин и пароль должны быть заполнены");
            }

            var result = await _authService.LoginAsync(userDto.UserName, userDto.Password);
            if (result == null)
            {
                return Unauthorized("Неверный логин или пароль");
            }

            return Ok("Пользователь успешно вошел");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Произошла ошибка при обработке вашего запроса");
        }
    }
    
    [HttpPost]
    [ActionName("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserDto userDto)
    {
        try
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Логин и пароль должны быть заполнены");
            }

            var result = await _authService.RegisterUserAsync(userDto.UserName, userDto.Password);
            if (result == null)
            {
                return BadRequest("Пользователь с таким именем уже существует");
            }
            return Ok($"Пользователь успешно зарегистрирован");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Произошла ошибка при обработке вашего запроса");
        }
    }

}
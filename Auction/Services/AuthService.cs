using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Enums;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;

    public AuthService(IMapper mapper, AuctionContext db, RoleManager<IdentityRole> roleManager,
        SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _mapper = mapper;
        _db = db;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<UserDto?> RegisterAsync(UserRegisterDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.UserName = dto.Email.Substring(0, dto.Email.IndexOf('@'));

        var role = UserRole.User.ToString();
        if (await _roleManager.FindByIdAsync(role) is null)
            await _roleManager.CreateAsync(new IdentityRole(role));

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            await _signInManager.SignInAsync(user, false);
        }
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }

    public async Task<UserDto?> LoginAsync(UserLoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return null;

        await _signInManager.PasswordSignInAsync(
            user,
            dto.Password,
            true,
            false);
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }

    public async Task<bool> LogOutAsync()
    {
        await _signInManager.SignOutAsync();
        return true;
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
        if (user == null)
            return null;
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
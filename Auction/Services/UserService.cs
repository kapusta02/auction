using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Enums;
using Auction.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuthContext _db;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, AuthContext db, RoleManager<IdentityRole> roleManager,
        SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _mapper = mapper;
        _db = db;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task<UserDto?> UserBlockByIdAsync(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u=> u.Id == id.ToString());
        if (user is null)
            return null;
        
        if (user.IsBlocked)
            throw new InvalidOperationException("Пользователь уже заблокирован");
        user.IsBlocked = true;
        
        await _db.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> UpdateUserRoleAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return null;

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, UserRole.Moderator.ToString());
        
        return _mapper.Map<UserDto>(user);
    }
    
    public async Task<UserDto?> DeleteModeratorRoleAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return null;

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, UserRole.User.ToString());

        return _mapper.Map<UserDto>(user);
    }
}
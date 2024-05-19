using Auction.Data;
using Auction.DTOs;
using Auction.Entities;
using Auction.Enums;
using Auction.Interfaces;
using Auction.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auction.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly AuctionContext _db;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, AuctionContext db, UserManager<User> userManager)
    {
        _mapper = mapper;
        _db = db;
        _userManager = userManager;
    }

    public async Task<UserDto?> UpdateUserRoleAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return null;

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, UserRole.Moderator.ToString());

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto?> DeleteModeratorRoleAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return null;

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, UserRole.User.ToString());

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserBlockResponse> UserBlockByIdAsync(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
        if (user is null)
            return new UserBlockResponse { Result = UserBlockResult.UserNotFound };

        if (user.IsBlocked)
            return new UserBlockResponse { Result = UserBlockResult.UserAlreadyBlocked };

        user.IsBlocked = true;
        await _db.SaveChangesAsync();

        var userDto = _mapper.Map<UserDto>(user);

        return new UserBlockResponse
        {
            Result = UserBlockResult.Success,
            User = userDto
        };
    }
}
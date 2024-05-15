using Auction.Contracts.Auth;
using Auction.Entities;
using Auction.Enums;
using Microsoft.EntityFrameworkCore;

namespace Auction.Repositories.Auth;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext _context;

    public AuthRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> LoginAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }

    public async Task<UserEntity> RegisterUserAsync(string username, string password)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new UserEntity
        {
            UserName = username,
            PasswordHash = hashedPassword,
            Role = UserRole.User
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> SetUserBlockedStatusAsync(string userName, bool isBlocked)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        if (user == null)
        {
            return false;
        }

        user.IsBlocked = isBlocked;
        await _context.SaveChangesAsync();
        return true;
    }
}
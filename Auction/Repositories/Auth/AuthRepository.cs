using Auction.Contracts.Auth;
using Auction.Entities;
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
        var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (result == null || !BCrypt.Net.BCrypt.Verify(password, result.PasswordHash))
        {
            return null;
        }
        return result;
    }
    public async Task<UserEntity> RegisterUserAsync(string username, string password)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new UserEntity
        {
            UserName = username,
            PasswordHash = hashedPassword
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
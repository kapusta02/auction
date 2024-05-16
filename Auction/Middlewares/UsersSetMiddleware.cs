using Auction.Entities;
using Auction.Enums;
using Microsoft.AspNetCore.Identity;

namespace Auction.Middlewares;

public abstract class UsersSetMiddleware
{
    public static async Task Run(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var provider = scope.ServiceProvider;
        try
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            await SetAdminUser(roleManager, userManager);
            await SetModeratorUser(roleManager, userManager);
        }
        catch (Exception e)
        {
            var logger = provider.GetRequiredService<ILogger<Program>>();
            logger.LogError(e, "Admin doesn't set");
        }
    }

    private static async Task SetAdminUser(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        User admin = new User
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            FirstName = "admin",
            LastName = "admin"
        };

        string password = "!Qwerty1234!";

        string role = UserRole.Admin.ToString();
        if (await roleManager.FindByIdAsync(role) is null)
            await roleManager.CreateAsync(new IdentityRole(role));

        if (await userManager.FindByEmailAsync(admin.Email) == null)
        {
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, role);
        }
    }

    private static async Task SetModeratorUser(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        User admin = new User
        {
            UserName = "moder@moder.com",
            Email = "moder@moder.com",
            FirstName = "moder",
            LastName = "moder"
        };

        string password = "!Moder111!";

        string role = UserRole.Moderator.ToString();
        if (await roleManager.FindByIdAsync(role) is null)
            await roleManager.CreateAsync(new IdentityRole(role));

        if (await userManager.FindByEmailAsync(admin.Email) == null)
        {
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, role);
        }
    }
}
using Auction.Configurations;
using Auction.Data;
using Auction.Entities;
using Auction.Interfaces;
using Auction.Mappers;
using Auction.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddSwaggerGen();

var appConnetcionString = "Data Source=usersData.db";

services.AddDbContext<AuctionContext>(options => options.UseSqlite(appConnetcionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking))
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<AuctionContext>();

services.AddAutoMapper(typeof(AppMappingProfile));
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IWalletService, WalletService>();
services.AddScoped<ILotService, LotService>();
services.AddScoped<IBidService, BidService>();

var app = builder.Build();

await SetUserRights.Run(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
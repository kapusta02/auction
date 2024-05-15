using Auction;
using Auction.Contracts.Auth;
using Auction.Entities;
using Auction.Repositories.Auth;
using Auction.Services.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddIdentity<UserEntity, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

services.AddScoped<UserManager<UserEntity>>();
services.AddScoped<SignInManager<UserEntity>>();


services.AddScoped<SignInManager<UserEntity>>();
services.AddSingleton<IPasswordHash, PasswordHashService>();

services.AddTransient<IAuthService, AuthService>();
services.AddScoped<IAuthRepository, AuthRepository>();
services.AddScoped<IPasswordHash, PasswordHashService>();



string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connection));

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
// app.MapGet("/", (ApplicationDbContext db) => db.Users.ToList());
// app.MapGet("/wallet", (ApplicationDbContext db) => db.Wallets.ToList());
// app.MapGet("/lot", (ApplicationDbContext db) => db.Lots.ToList());
// app.MapGet("/bidding", (ApplicationDbContext db) => db.Biddings.ToList());

app.Run();
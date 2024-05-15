using Auction;
using Auction.Contracts.Auth;
using Auction.Entities;
using Auction.Repositories.Auth;
using Auction.Services.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddIdentity<UserEntity, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

services.AddTransient<IAuthService, AuthService>();
services.AddScoped<IAuthRepository, AuthRepository>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connection));

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/login";
        options.AccessDeniedPath = "/auth/block";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    });

services.AddAuthorization();

services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "MySession";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

services.AddDistributedMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
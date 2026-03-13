using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using UKHSA.Controllers;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

builder.Services.AddDbContext<UKHSA_DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<UKHSA.Models.User, IdentityRole>()
    .AddEntityFrameworkStores<UKHSA_DbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication()
    .AddCookie(options => options.LoginPath = "/Account/Login");

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

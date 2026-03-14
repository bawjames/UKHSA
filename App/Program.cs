using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UKHSA.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Connect to Postgres
builder.Services.AddDbContext<UKHSA_DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configure Login
builder.Services.AddIdentity<UKHSA.Models.User, IdentityRole>()
    .AddEntityFrameworkStores<UKHSA_DbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication()
    .AddCookie(options => options.LoginPath = "/Account/Login");

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Perform EFCore database migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UKHSA_DbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Redirect from root
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UKHSA.Controllers;
using UKHSA.Models;

namespace UKHSA;

class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var environment = builder.Environment;

        // Connect to database
        var connectionString = builder.Configuration.GetConnectionString("Connection");
        builder.Services.AddDbContext<UKHSA_DbContext>(options => options.UseNpgsql(connectionString));

        builder.Services
        .AddIdentity<UKHSA.Models.User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequiredLength = 5;
        })
        .AddEntityFrameworkStores<UKHSA_DbContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddAuthentication()
        .AddCookie(options => options.LoginPath = "/Account/Login");

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        using (var scope = app.Services.CreateScope())
        {
            string[] roles = { Roles.AdminRole, Roles.ApproverRole, Roles.UserRole };

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in roles)
            {
                var _ = await roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();

        // Redirect from root
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=User}/{action=Home}/{id?}")
        .WithStaticAssets();

        app.Run();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UKHSA.Controllers;

namespace UKHSA;

class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var environment = builder.Environment;

        // Connect to Postgres
        builder.Services.AddDbContext<UKHSA_DbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (environment.IsDevelopment())
            {
                options.UseSqlite(connectionString);
            } else {
                options.UseNpgsql(connectionString);
            }
        });

        ConfigureIdentity(builder);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        using (var scope = app.Services.CreateAsyncScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<UKHSA_DbContext>();
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
                await dbContext.Database.MigrateAsync();
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

        await app.RunAsync();
    }

    static void ConfigureIdentity(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<UKHSA.Models.User, IdentityRole>()
        .AddEntityFrameworkStores<UKHSA_DbContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddAuthentication()
        .AddCookie(options => options.LoginPath = "/Account/Login");
    }
}

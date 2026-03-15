using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UKHSA.Controllers;

namespace UKHSA;

class Program
{
    public static void Main(string[] args)
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
            var dbContext = scope.ServiceProvider.GetRequiredService<UKHSA_DbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
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

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sihri.Visa.Data;
using Sihri.Visa.Domain;

namespace Sihri.Visa;

public static class VisaStartup
{
    #region ConfigureServices
    public static void AddVisaServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext(configuration);
        services.AddScopedServices();
        services.AddIdentityServices();
    }
    private static void AddScopedServices(this IServiceCollection services)
    {

    }
    private static void AddDbContext(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Db");

        services.AddDbContext<VisaDbContext>(options =>
        {
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
        });
    }
    public static void AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<VisaDbContext>();


        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });

    }
    #endregion



    #region Configure
    public static void VisaStartupConfigure(this IApplicationBuilder app)
    {
        app.UpdateDatabase();
    }
    public static void UpdateDatabase(this IApplicationBuilder app)
    {

        using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
        {

            using (var context = serviceScope.ServiceProvider.GetService<VisaDbContext>())
            {
                context.Database.Migrate();

                context.SaveChanges();
            }
        }
    }
    #endregion
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Sihri.Flight.Data;
using Sihri.Flight.Domain;

namespace Sihri.Flight;

public static class FlightStartup
{
    #region ConfigureServices
    public static void AddFlightServices(this IServiceCollection services, ConfigurationManager configuration)
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

        services.AddDbContext<FlightDbContext>(options =>
        {
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
        });
    }
    public static void AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<FlightDbContext>();


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
    public static void FlightStartupConfigure(this IApplicationBuilder app)
    {
        app.UpdateDatabase();
    }
    public static void UpdateDatabase(this IApplicationBuilder app)
    {

        using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
        {

            using (var context = serviceScope.ServiceProvider.GetService<FlightDbContext>())
            {
                context.Database.Migrate();

                context.SaveChanges();
            }
        }
    }
    #endregion
}

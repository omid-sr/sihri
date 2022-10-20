using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sihri.Infrastructure.Implementation.Cache;
using Sihri.Infrastructure.Interfaces;

namespace Sihri.Infrastructure;

public static class InfrastructureStartup
{
    #region ConfigureServices
    public static void AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Db");
        services.AddScopedServices();
        services.AddRedisService(configuration);
    }
    private static void AddScopedServices(this IServiceCollection services)
    {

    }
    private static void AddRedisService(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
        services.AddSingleton<RedisBuilder>();
        services.AddScoped<ICacheService, RedisStackExchangeCacheService>();
    }

    #endregion



    #region Configure
    public static void InfraStructureStartupConfigure(this IApplicationBuilder app)
    {
    }

  
    #endregion
}

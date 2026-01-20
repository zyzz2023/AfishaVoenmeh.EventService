using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Services;
using AfishaVoenmeh.EventService.Infrastructure.Common;
using AfishaVoenmeh.EventService.Infrastructure.Data;
using AfishaVoenmeh.EventService.Infrastructure.Data.Repositories;
using AfishaVoenmeh.EventService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AfishaVoenmeh.EventService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbContext(configuration);

        services.AddScoped<IEventRepository, EventRepository>();

        services.AddRedisCaching(configuration);

        return services;
    }

    private static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultPostgresConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }

    private static void AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RedisOptions>(configuration.GetSection(RedisOptions.RedisOptionsSection));

        var redisConnectionString = configuration[RedisOptions.RedisConnectionStringSection];

        var redisInstanceName = configuration[RedisOptions.RedisInstanceNameSection];

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
            options.InstanceName = redisInstanceName;
        });

        services.AddScoped<ICacheService, RedisDistributedCacheService>();
    }
}
using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Infrastructure.Data;
using AfishaVoenmeh.EventService.Infrastructure.Data.Repositories;
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
}
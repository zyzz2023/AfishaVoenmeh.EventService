using AfishaVoenmeh.EventService.Application.Common.Mappings;
using AfishaVoenmeh.EventService.WebAPI.Common.Handlers;
using AfishaVoenmeh.EventService.WebAPI.Common.Mappings;
using Mapster;
using Microsoft.OpenApi;

namespace AfishaVoenmeh.EventService.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddConfiguredSwagger();

        services.AddConfiguredMapster();

        services.AddGlobalExceptionHandler();

        return services;
    }

    // Нужно сконфигурировать сваггер на требование JWT Token при запросах !!!
    private static void AddConfiguredSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "EventService (AfishaVoenmeh)",
                Version = "v1",
                Description = "Microservice for managing and storing user events."
            });
        });
    }

    private static void AddConfiguredMapster(this IServiceCollection services)
    {
        var applicationAssembly = typeof(EventMappingConfiguration).Assembly;
        var presentationAssembly = typeof(EventRequestsMappingConfig).Assembly;

        var configuration = TypeAdapterConfig.GlobalSettings;
        configuration.Scan(applicationAssembly, presentationAssembly);

        services.AddSingleton(configuration);
        services.AddMapster();
    }

    private static void AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
            };
        });
    }
}

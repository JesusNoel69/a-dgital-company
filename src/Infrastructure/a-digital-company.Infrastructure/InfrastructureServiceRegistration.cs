using a-digital-company.Application.Interfaces.Logging;
using a-digital-company.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace a-digital-company.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}

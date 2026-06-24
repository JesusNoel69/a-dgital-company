using ADigitalCompany.Application.Interfaces.Logging;
using ADigitalCompany.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ADigitalCompany.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}

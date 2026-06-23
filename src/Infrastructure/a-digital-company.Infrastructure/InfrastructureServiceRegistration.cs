using a_digital_company.Application.Interfaces.Logging;
using a_digital_company.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace a_digital_company.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}

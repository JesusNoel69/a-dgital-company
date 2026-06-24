using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ADigitalCompany.Persistence.Repositories;

namespace ADigitalCompany.Persistence;

public static class PersistenceServiceRegistration
{
      public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services
            , IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");
            if (useInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ADigitalCompanyDB"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
            }
           
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IWorkItemRepository, WorkItemRepository>();
            
            return services;
        }
}

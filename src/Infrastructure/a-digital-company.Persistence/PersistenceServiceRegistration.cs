using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using a_digital_company.Persistence.Repositories;

namespace a_digital_company.Persistence;

public static class PersistenceServiceRegistration
{
      public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services
            , IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");
            if (useInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("a_digital_companyDB"));
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

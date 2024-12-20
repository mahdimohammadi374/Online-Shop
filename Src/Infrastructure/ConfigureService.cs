using Application.Contracts;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureConfigureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataBaseContext>(
           x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}

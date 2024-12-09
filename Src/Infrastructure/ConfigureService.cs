using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddApplicationConfigureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataBaseContext>(
           x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

        return services;
    }
}

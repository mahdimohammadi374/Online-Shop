using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Web;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataBaseContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

        return builder.Services;
    }
}

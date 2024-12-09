using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Web;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Services;
    }

    public async static Task<IApplicationBuilder> AddWebAppBuilder(this WebApplication app)
    {

        //Get Services
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

        //var context = app.Services.GetRequiredService<DataBaseContext>();

        #region Auto Migration
        try
        {
            await context.Database.MigrateAsync();
            await GenerateSeedData.SeedData(context, loggerFactory);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "An Error occured with auto migration. Error Message" + ex.Message);
        }
        #endregion

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();
        app.Run();

        return app;
    } 
}

using Domain.Exceptions;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.SeedData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Middlewares;

namespace Web;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddControllers();
        ApiBehaviorOptions(builder);


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", action =>
            {
                action.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["ClientUrl:HttpUrl"], builder.Configuration["ClientUrl:HttpsUrl"]);
            });
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();
        return builder.Services;
    }

    private static void ApiBehaviorOptions(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.InvalidModelStateResponseFactory = action =>
            {
                var errors = action.ModelState.
                Where(x => x.Value.Errors.Count() > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(new ApiExcpetionReturn(errors, 400));
            };
        });
    }

    public async static Task<IApplicationBuilder> AddWebAppBuilder(this WebApplication app)
    {
        app.UseMiddleware<MiddlewareExceptionHandler>();
        
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
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        return app;
    } 
}

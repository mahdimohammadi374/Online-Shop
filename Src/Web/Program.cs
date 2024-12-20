using Application;
using Application.Contracts;
using Infrastructure;
using Infrastructure.Persistance;
using Web;
using Web.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationConfigureService();
builder.Services.AddInfrastructureConfigureService(builder.Configuration);
builder.AddWebServiceCollection();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
//app.UseMiddleware<MiddlewareExceptionHandler>();
app.UseStaticFiles();

await app.AddWebAppBuilder().ConfigureAwait(false);



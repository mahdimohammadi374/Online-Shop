using Infrastructure;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.SeedData;
using Microsoft.EntityFrameworkCore;
using Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApplicationConfigureService(builder.Configuration);
builder.AddWebServiceCollection();
var app = builder.Build();

await app.AddWebAppBuilder().ConfigureAwait(false);



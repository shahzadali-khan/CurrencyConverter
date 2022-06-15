
using Application;
using FluentValidation.AspNetCore;
using Host.Configurations;
using Infrastructure;
using Infrastructure.Common;
using Serilog;

StaticLogger.EnsureStartup();
Log.Information("Host starting now ...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();
    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console().ReadFrom.Configuration(builder.Configuration);
    });

    
    // Add services to the container.

    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseInfrastructure(builder.Configuration);

    app.MapEndpoints();
    app.Run();

}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureStartup();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureStartup();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
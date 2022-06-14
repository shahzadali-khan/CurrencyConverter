using System.Reflection;
using Infrastructure.Common;
using Infrastructure.Cors;
using Infrastructure.Middleware;
using Infrastructure.OpenApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddApiVersioning()
                .AddCorsPolicy(config)
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddOpenApiDocumentation(config)
                .AddRequestLogging(config)
                .AddRouting(options => options.LowercaseUrls = true)
                .AddServices();
        }

        private static IServiceCollection AddApiVersioning(this IServiceCollection services) =>
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
            builder
                .UseRequestLocalization()
                .UseStaticFiles()
                .UseRouting()
                .UseCorsPolicy()
                .UseRequestLogging(config)
                .UseOpenApiDocumentation(config);

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapControllers();
            return builder;
        }
    }
}
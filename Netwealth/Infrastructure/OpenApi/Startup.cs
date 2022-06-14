using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema.Generation.TypeMappers;
using ZymLabs.NSwag.FluentValidation;

namespace Infrastructure.OpenApi;

internal static class Startup
{
    internal static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
        if (settings.Enable)
        {
            services.AddVersionedApiExplorer(o => o.SubstituteApiVersionInUrl = true);
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument((document, serviceProvider) =>
            {
                document.PostProcess = doc =>
                {
                    doc.Info.Title = settings.Title;
                    doc.Info.Version = settings.Version;
                    doc.Info.Description = settings.Description;
                    doc.Info.Contact = new()
                    {
                        Name = settings.ContactName,
                        Email = settings.ContactEmail,
                        Url = settings.ContactUrl
                    };
                    doc.Info.License = new()
                    {
                        Name = settings.LicenseName
                    };
                };

               

                var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetService<FluentValidationSchemaProcessor>();
                document.SchemaProcessors.Add(fluentValidationSchemaProcessor);
            });
            services.AddScoped<FluentValidationSchemaProcessor>();
        }

        return services;
    }

    internal static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder app, IConfiguration config)
    {
        if (config.GetValue<bool>("SwaggerSettings:Enable"))
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(options =>
            {
                options.DefaultModelsExpandDepth = -1;
                options.DocExpansion = "none";
                options.TagsSorter = "alpha";
            });
        }

        return app;
    }
}
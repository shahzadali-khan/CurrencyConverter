namespace Host.Configurations
{
    internal static class Startup
    {
        internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
                const string configurationsSource = "Configurations/sources";
                var env = context.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/logger.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/logger.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/cors.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/cors.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/middleware.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/middleware.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/openapi.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsSource}/openapi.{env.EnvironmentName}.json", optional: true,
                        reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
            return host;
        }
    }
}
using System.Net.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ServerlessHost.Services;
using Shared.Interfaces;

[assembly: FunctionsStartup(typeof(ServerlessHost.Startup))]

namespace ServerlessHost
{
    public class Startup :FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ICurrencyConverterService>((service) => new CurrencyConverterRequestHandler(new HttpClient()));
        }
    }
}

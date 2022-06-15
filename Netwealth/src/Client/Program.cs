using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var hostUri = new Uri("https://netwealthcurrencyconverterhost.azurewebsites.net");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = hostUri });
builder.Services.AddScoped<CurrencyConverterService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();

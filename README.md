# CurrencyConverter
[![Host](https://github.com/shahzadali-khan/CurrencyConverter/actions/workflows/Host.yml/badge.svg)](https://github.com/shahzadali-khan/CurrencyConverter/actions/workflows/Host.yml) [![Client](https://github.com/shahzadali-khan/CurrencyConverter/actions/workflows/Client.yml/badge.svg)](https://github.com/shahzadali-khan/CurrencyConverter/actions/workflows/Client.yml)

##Introduction
CurrencyConverter consist of a Blazor WASM client and .Net core WebAPI.Solution is developed in Microsoft .Net 6.0 LTS.

Client takes input from user in terms of Currency Codes and amount to be converted and return result as per conversion rates provided by [fixer.io](https://fixer.io/). Host exposes one controller to be used by Client and under the hood consumes [fixer.io](https://fixer.io/) API.

## Framework
- .Net 6.0 [Read More](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6) 
- [Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

#### Structure
Solution is divided into following two main componants. Relevant third-party libraries are mentioned under componant name.

- Client (Blazor WASM APP)
- - [MudBlazor ](https://mudblazor.com/)
- HOST (.Net Core WebAPI)
- - MediaTr
- - Swashbuckle
- - Swagger
- - FluentValidations
- - RestSharp
- - Serilog (Console, AspNetCore, FileSink)

In addition to these componants, solution contains following class libraries to maintain different important classes relevant to domain, application and infrastructure of CurrencyConverter Solution.

- src/Core/Application
- src/Core/Domain
- src/Infrastructure
- src/Shared

## How?
### build

CLI
- `dotnet build`
- `dotnet build --configuration Release`

[Read more](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build)

### CI/CD
Both componants are continuesly being build and deployed to azure infrastructure upon commit. GitHub Actions (YAML) are used to deploy said packages.

Path: CurrencyConverter/.github/workflows/
- **Client.yml** is used to deploy Blazor APP
- **Host.yml** is used for WebApi deployment

### Production/Deployed Resources:
- [Client App](https://netwealthcurrencyconverterclient.azurewebsites.net/)
- [WebApi](https://netwealthcurrencyconverterhost.azurewebsites.net/)
- [WebApi Swagger UI](https://netwealthcurrencyconverterhost.azurewebsites.net/swagger/index.html)
- [OpenAPI v3.0 file](https://netwealthcurrencyconverterhost.azurewebsites.net/swagger/v1/swagger.json)

----
Wisdom?

![Jokes Card](https://readme-jokes.vercel.app/api)

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ServerlessHost.Models;
using Shared.Interfaces;

namespace ServerlessHost
{
    public class CurrencyConverter
    {
        private readonly ILogger<CurrencyConverter> _logger;
        private ICurrencyConverterService _service;
        

        public CurrencyConverter(ICurrencyConverterService service,ILogger<CurrencyConverter> log)
        {
            this._service = service;
            this._logger = log;
        }

        [FunctionName("CurrencyConverter")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiParameter(name: "from", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **base currency** parameter")]
        [OpenApiParameter(name: "to", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **target currency** parameter")]
        [OpenApiParameter(name: "amount", In = ParameterLocation.Query, Required = true, Type = typeof(decimal), Description = "The **amount to be converted in target currency** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post",
                Route = "convert/{from:alpha}&{to:alpha}&{amount:decimal}")] HttpRequest req,string from,string to , decimal amount)
        {
            _logger.LogInformation("CurrencyConverter Function processed a request.");
            
            try
            {
                QueryParameters query = new QueryParameters(from, to, amount);

                var response = await _service.GetCurrencyConverted(query.FromCurrency, query.ToCurrency, query.Amount ?? decimal.Zero).ConfigureAwait(false);
                
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                throw;
            }
        }

        
    }
}


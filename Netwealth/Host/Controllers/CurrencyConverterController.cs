using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RestSharp;

namespace Host.Controllers
{
    public class CurrencyConverterController : VersionedApiController
    {
        [HttpGet("{from:alpha},{to:alpha},{amount:decimal}")]
        [OpenApiOperation("Get Currency Conversion Rates", "")]
        public async Task<decimal> ConvertCurrency(string from, string to, decimal amount)
        {

            var output = await GetFixerResult(@from, to, amount);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FixerResponseModel>(output);

            return (decimal) result.info.rate;
        }

        internal async Task<string?> GetFixerResult(string @from, string to, decimal amount)
        {
            var url = $"https://api.apilayer.com/fixer/convert?to={to}&from={@from}&amount={amount}";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("apikey", "TcTepQjxEvLXAb0cETb4IGbPV37BWJcb");
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;

            return output;
        }
    }
}

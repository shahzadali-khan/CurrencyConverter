using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Shared.Exceptions;
using Shared.Interfaces;
using Shared.Models;

namespace ServerlessHost.Services;

public class CurrencyConverterService : ICurrencyConverterService
{
    public async Task<CurrencyConverterDto> GetCurrencyConverted(string @from, string to, decimal amount)
    {
        var param = $"to={to}&from={from}&amount={amount}";
        var url = $"https://api.apilayer.com/fixer/convert?{param}";

        var client = new RestClient(url);
        var restRequest = new RestRequest(url, Method.Get);
        restRequest.AddHeader("apikey", "TcTepQjxEvLXAb0cETb4IGbPV37BWJcb");

        try
        {
            RestResponse response = await client.ExecuteAsync(restRequest);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FixerResponseModel>(response.Content);

            return new CurrencyConverterDto()
            {
                Request = new Query { @from = result.query.from, to = result.query.to, amount = result.query.amount },
                Rate = result.info.rate,
                Result = result.result,
                Timestamp = result.info.timestamp

            };
        }
        catch
        {
            throw new NotFoundException($"Response cannot be generated for this request {param}");
        }
    }
}

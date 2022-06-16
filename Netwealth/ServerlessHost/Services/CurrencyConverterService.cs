using System;
using System.Net.Http;
using System.Threading.Tasks;
using Shared;
using Shared.Exceptions;
using Shared.Interfaces;
using Shared.Models;

namespace ServerlessHost.Services;

public class CurrencyConverterRequestHandler : ICurrencyConverterService
{
    private readonly HttpClient _client;

    public CurrencyConverterRequestHandler(HttpClient client)
    {
        _client = client;
    }

    public async Task<CurrencyConverterDto> GetCurrencyConverted(string @from, string to, decimal amount)
    {
        var url = new Uri($"https://api.apilayer.com/fixer/");
        _client.BaseAddress = url;

        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.Add("apikey", "TcTepQjxEvLXAb0cETb4IGbPV37BWJcb");


        try
        {
            var response = await _client.GetAsync($"convert?to={to}&from={from}&amount={amount}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var result = await response.Content.ReadAsAsync<FixerResponseModel>().ConfigureAwait(false);

            return new CurrencyConverterDto()
            {
                Request = new Query { @from = result.query.@from, to = result.query.to, amount = result.query.amount },
                Rate = result.info.rate,
                Result = result.result,
                Timestamp = result.info.timestamp

            };

        }
        catch
        {
            throw new NotFoundException($"Response cannot be generated for this request {from}");
        }
    }
}
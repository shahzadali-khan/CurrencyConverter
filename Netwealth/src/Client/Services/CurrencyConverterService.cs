using System.Net.Http.Json;
using Shared.Interfaces;
using Shared.Models;

namespace Client.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly HttpClient _client;


        public CurrencyConverterService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrencyConverterDto> GetCurrencyConverted(string? @from, string to, decimal amount)
        {
            try
            {
                return (await _client.GetFromJsonAsync<CurrencyConverterDto>($"/{@from}&{to}&{amount}") ?? null) ?? throw new InvalidOperationException();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Error fetching currency rates : " + e.Message);
            }

#pragma warning disable CS8603
            return null;
#pragma warning restore CS8603
        }
    }
}

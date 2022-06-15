using System.Net.Http.Json;
using Shared;

namespace Client.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly HttpClient _client;


        public CurrencyConverterService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrencyConverterDto?> GetCurrencyConverted(string @from, string to, decimal amount)
        {
            try
            {
                return await _client.GetFromJsonAsync<CurrencyConverterDto>($"/api/{from}&{to}&{amount}");
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Error fetching currency rates : " + e.Message);
            }

            return null;
        }
    }
    public interface ICurrencyConverterService
    {
        Task<CurrencyConverterDto> GetCurrencyConverted(string from, string to, decimal amount);
    }
}

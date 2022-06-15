using Shared;

namespace Client.Services
{
    public class CurrencyConverterService: ICurrencyConverterService
    {
        public Task<CurrencyConverterDto> GetCurrencyConverted(string @from, string to, decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICurrencyConverterService
    {
        Task<CurrencyConverterDto> GetCurrencyConverted(string from, string to, decimal amount);
    }
}

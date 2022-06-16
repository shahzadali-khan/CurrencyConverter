using Shared.Models;

namespace Shared.Interfaces;

public interface ICurrencyConverterService
{
    Task<CurrencyConverterDto> GetCurrencyConverted(string? from, string to, decimal amount);
}
using MediatR;
using Shared.Models;

namespace Application.CurrencyConverter;

public class GetCurrencyConverterRequest : IRequest<CurrencyConverterDto>
{
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public decimal Amount { get; set; }

    public GetCurrencyConverterRequest(string fromCurrency, string toCurrency, decimal amount)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Amount = amount;
    }
}
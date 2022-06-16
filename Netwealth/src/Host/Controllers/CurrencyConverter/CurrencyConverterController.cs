using Application.CurrencyConverter;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Shared.Models;

namespace Host.Controllers.CurrencyConverter
{
    public class CurrencyConverterController : VersionedApiController
    {
        [HttpGet("{from:alpha}&{to:alpha}&{amount:decimal}")]
        [OpenApiOperation("Convert Currency", "This controller can be used to get current conversion rate and convert amount into specified currency.")]
        public Task<CurrencyConverterDto> ConvertCurrency2(string from, string to, decimal amount)
        {
            return Mediator.Send(new GetCurrencyConverterRequest(from, to, amount));
        }
    }
}

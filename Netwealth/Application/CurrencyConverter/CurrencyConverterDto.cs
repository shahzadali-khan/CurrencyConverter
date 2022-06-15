using Infrastructure.Interfaces;
using Query = Application.Common.Models.Query;

namespace Application.CurrencyConverter;

public class CurrencyConverterDto : IDto
{
    public Query? Request { get; set; }
    public int Timestamp { get; set; }
    public decimal Rate { get; set; }
    public decimal Result { get; set; }
}
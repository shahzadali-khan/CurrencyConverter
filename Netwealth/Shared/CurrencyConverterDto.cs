using Infrastructure.Interfaces;
using Query = Shared.Models.Query;

namespace Shared;

public class CurrencyConverterDto : IDto
{
    public Query? Request { get; set; }
    public int Timestamp { get; set; }
    public decimal Rate { get; set; }
    public decimal Result { get; set; }
}
// ReSharper disable InconsistentNaming
namespace Domain.Models;

public class Query
{
#pragma warning disable CS8618
    
    public string from { get; set; }
    public string to { get; set; }
    public decimal amount { get; set; }

#pragma warning restore CS8618
}
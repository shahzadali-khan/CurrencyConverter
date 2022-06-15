#pragma warning disable CS8618
namespace Shared.Models;

public class Query
{
    public string? from { get; set; }
    public string to { get; set; }
    public decimal amount { get; set; }
}
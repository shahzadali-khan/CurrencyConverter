#pragma warning disable CS8618
namespace Shared.Models;

public class FixerResponseModel
{
    public bool success { get; set; }
    public Query query { get; set; }
    public Info info { get; set; }
    public string date { get; set; }
    public decimal result { get; set; }
}
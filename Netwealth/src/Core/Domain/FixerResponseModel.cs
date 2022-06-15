namespace Domain;

public class FixerResponseModel
{
    public bool success { get; set; }
    public Query query { get; set; }
    public Info info { get; set; }
    public string date { get; set; }
    public decimal result { get; set; }
}
 

public class Query
{
    public string from { get; set; }
    public string to { get; set; }
    public decimal amount { get; set; }
}

public class Info
{
    public int timestamp { get; set; }
    public decimal rate { get; set; }
}

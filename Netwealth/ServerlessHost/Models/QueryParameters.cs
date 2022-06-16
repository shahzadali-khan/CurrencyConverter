using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessHost.Models
{
    public class QueryParameters
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal? Amount { get; set; }
        
        public QueryParameters(string fromCurrency, string toCurrency, decimal? amount)
        {
            if (string.IsNullOrWhiteSpace(fromCurrency)) throw new ArgumentException("Value cannot be null or empty.", nameof(fromCurrency));
            if (string.IsNullOrWhiteSpace(toCurrency)) throw new ArgumentException("Value cannot be null or empty.", nameof(toCurrency));
            
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency; 
            Amount = amount ?? 0;
        }
    }
}

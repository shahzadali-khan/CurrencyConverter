using Application.Common.Exceptions;
using Domain;
using MediatR;
using RestSharp;
using FixerResponseModel = Application.Common.Models.FixerResponseModel;

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

public class GetCurrencyConverterRequestHandler : IRequestHandler<GetCurrencyConverterRequest, CurrencyConverterDto>
{
    public async Task<CurrencyConverterDto> Handle(GetCurrencyConverterRequest request, CancellationToken cancellationToken)
    {
        var url = $"https://api.apilayer.com/fixer/convert?to={request.ToCurrency}&from={request.FromCurrency}&amount={request.Amount}";
        var client = new RestClient(url);
        var restRequest = new RestRequest(url, Method.Get);
        restRequest.AddHeader("apikey", "TcTepQjxEvLXAb0cETb4IGbPV37BWJcb");

        try
        {
            RestResponse response = await client.ExecuteAsync(restRequest, cancellationToken);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FixerResponseModel>(response.Content);

            return new CurrencyConverterDto()
            {
                Request = result.query,
                Rate = result.info.rate,
                Result = result.result,
                Timestamp = result.info.timestamp

            };
        }
        catch
        {
            throw new NotFoundException($"Response cannot be generated for this request {request}" );
        }
        
    }
}
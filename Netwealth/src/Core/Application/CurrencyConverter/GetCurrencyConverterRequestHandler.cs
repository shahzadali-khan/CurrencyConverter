using MediatR;
using RestSharp;
using Shared.Exceptions;
using Shared.Models;
using Query = Shared.Models.Query;

namespace Application.CurrencyConverter;

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

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Shared.Models.FixerResponseModel>(response.Content);

            return new CurrencyConverterDto()
            {
                Request = new Query { @from = result.query.from,to = result.query.to, amount = result.query.amount },
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
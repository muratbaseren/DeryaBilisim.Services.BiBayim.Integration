using RestSharp;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public partial class BiBayimService
    {
        private readonly IRestClient _client;
        public BiBayimService(string endpoint, string token)
        {
            _client = new RestClient(endpoint);
            _client.Authenticator = new RestSharp.Authenticators.JwtAuthenticator(token);
        }

        public IRestResponse<BiBayimServiceResponse<object>> AddCommissionToDealer(CommissionApiModel model)
        {
            var request = new RestRequest("/DealerApi/AddCommission", Method.POST, DataFormat.Json);
            request.AddJsonBody(model);
            return _client.Post<BiBayimServiceResponse<object>>(request);
        }
    }
}
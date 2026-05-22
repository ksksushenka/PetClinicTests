using RestSharp;
using Serilog;
using PetClinicTests.Common.Configuration;

namespace PetClinicTests.Core.Client
{
    public class ApiClient
    {
        private static readonly ILogger _logger = LogManager.CreateLogger();

        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Environment.GetEnvironmentVariable("PetclinicAPI"))
            {
                ThrowOnAnyError = false,
                Timeout = TimeSpan.FromSeconds(20)
            };

            _restClient = new RestClient(options);
        }

        public ApiClient(string url, string bearer)
        {
            var options = new RestClientOptions(url)
            {
                //Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(bearer, "Bearer"),
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromSeconds(10)
            };

            _restClient = new RestClient(options);
        }

        public RestResponse Execute(RestRequest request)
        {
            var response = _restClient.Execute(request);

            _logger.Information("Response URL: " + response.ResponseUri);
            _logger.Information("Response Status: " + response.ResponseStatus);
            _logger.Information("Response Body: " + response.Content);

            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = _restClient.Execute<T>(request);

            _logger.Information("Response URL: " + response.ResponseUri);
            _logger.Information("Response Status: " + response.ResponseStatus);
            _logger.Information("Response Body: " + response.Content);

            return response.Data;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            var response = await _restClient.ExecuteAsync(request);

            _logger.Information("Response URL: " + response.ResponseUri);
            _logger.Information("Response Status: " + response.ResponseStatus);
            _logger.Information("Response Body: " + response.Content);

            return response;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            var response = await _restClient.ExecuteAsync<T>(request);

            _logger.Information("Response URL: " + response.ResponseUri);
            _logger.Information("Response Status: " + response.ResponseStatus);
            _logger.Information("Response Body: " + response.Content);

            return response.Data;
        }
    }
}

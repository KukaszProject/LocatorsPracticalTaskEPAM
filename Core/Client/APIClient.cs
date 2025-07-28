using RestSharp;
using log4net;

namespace Core.Client
{
    public class ApiClient
    {
        private readonly RestClient _client;
        private readonly ILog _logger;

        public ApiClient(string baseUrl, ILog logger)
        {
            _client = new RestClient(baseUrl);
            _logger = logger;
        }

        public RequestBuilder CreateRequest() => new RequestBuilder();

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            _logger?.Info($"Executing {request.Method} {request.Resource}");
            var response = await _client.ExecuteAsync(request);
            _logger?.Info($"Received {(int)response.StatusCode} from {request.Resource}");
            return response;
        }
    }
}

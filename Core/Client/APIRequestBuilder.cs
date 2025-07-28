using RestSharp;

namespace Core.Client
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;

        public RequestBuilder()
        {
            _request = new RestRequest();
        }

        public RequestBuilder WithResource(string resource)
        {
            _request.Resource = resource;
            return this;
        }

        public RequestBuilder WithMethod(Method method)
        {
            _request.Method = method;
            return this;
        }

        public RequestBuilder AddHeader(string name, string value)
        {
            _request.AddHeader(name, value);
            return this;
        }

        public RequestBuilder AddJsonBody(object body)
        {
            _request.AddJsonBody(body);
            return this;
        }

        public RestRequest Build() => _request;
    }
}

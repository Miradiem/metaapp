using Flurl.Http;

namespace metaapp.WeatherApi
{
    public class ApiClient
    {
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public IFlurlClient Create()
        {
            var client = new FlurlClient(_baseUrl);

            client.Settings.BeforeCall = (call) =>
            {
                Logging.Log.Info($"Calling {call.HttpRequestMessage.RequestUri}");
            };
            client.Settings.AfterCall = (call) =>
            {
                Logging.Log.Info($"Call status code: {call.Response.StatusCode}");
            };
            client.Settings.OnError = (call) =>
            {
                Logging.Log.Error(call.HttpResponseMessage.ReasonPhrase);
            };

            return client;
        }
    }
}

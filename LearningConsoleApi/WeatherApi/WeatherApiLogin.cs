using Flurl.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace metaapp.WeatherApi
{
    public class WeatherApiLogin
    {
        private readonly IFlurlClient _client;

        public WeatherApiLogin(IFlurlClient client)
        {
            _client = client;
        }
        public async Task<AuthorizedWeatherApi> Login(Credentials credentials)
        {
            var authenticationToken = await _client
                .Request("/api/authorize")
                .WithHeader("content-type", "application/json")
                .PostJsonAsync(credentials.ToJObject())
                .ReceiveJson<AuthenticationBearer>();

            return new AuthorizedWeatherApi(authenticationToken.Token, _client);
        }

        private class AuthenticationBearer
        {
            [JsonProperty("bearer")]
            public string Token { get; set; }
        }
    }
}

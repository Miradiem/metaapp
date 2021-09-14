using Flurl.Http;
using System.Threading.Tasks;

namespace LearningConsoleApi.NewAPI
{
    public class WeatherApiLogin
    {
        public async Task<WeatherApi> Login(Credentials credentials)
        {
            var authorizeUrl = "https://metasite-weather-api.herokuapp.com/api/authorize";

            var authenticationToken = await authorizeUrl
                .WithHeader("content-type", "application/json")
                .PostJsonAsync(credentials.ToJObject())
                .ReceiveJson<AuthenticationBearer>();
            return new WeatherApi(authenticationToken.Bearer);
        }

        private class AuthenticationBearer
        {
            public string Bearer { get; set; }
        }
    }
}

using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace metaapp.WeatherApi
{
    public class AuthorizedWeatherApi
    {
        private readonly string _token;
        private readonly IFlurlClient _client;

        public AuthorizedWeatherApi(string token, IFlurlClient client)
        {
            _token = token;
            _client = client;
        }
     
        public async Task<List<string>> Cities()
        {
            return await "https://metasite-weather-api.herokuapp.com/api/Cities"
                .WithHeader("Authorization", $"bearer {_token}")
                .GetJsonAsync<List<string>>();
        }

        public async Task<WeatherModel> WeatherData(string city)
        {
            return await _client.Request($"api/Weather/{city}")
                .WithHeader("Authorization", $"bearer {_token}")
                .GetJsonAsync<WeatherModel>();
        }
 
    }
}

using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningConsoleApi.NewAPI
{
    public class WeatherApi
    {
        private readonly string _token;

        public WeatherApi(string token)
        {
            _token = token;
        }
     
        public async Task<List<string>> Cities()
        {
            var citiesUrl = "https://metasite-weather-api.herokuapp.com/api/Cities";
            var cityNames = await citiesUrl
                .WithHeader("Authorization", $"bearer {_token}")
                .GetJsonAsync<List<string>>();
   
            return cityNames;
        }

        public async Task<WeatherModel> WeatherData(string city)
        {
            var baseUrl = "https://metasite-weather-api.herokuapp.com";
            var weatherModelUrl = baseUrl.AppendPathSegment($"api/Weather/{city}");

            return await weatherModelUrl
                .WithHeader("Authorization", $"bearer {_token}")
                .GetJsonAsync<WeatherModel>();
        }
        public class WeatherModel
        {
            public string City { get; set; }
            public double Temperature { get; set; }
            public int Precipitation { get; set; }
            public string Weather { get; set; }
        }
    }
}

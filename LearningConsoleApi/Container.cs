using LearningConsoleApi.NewAPI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearningConsoleApi
{
    public class Container
    {
        public static async Task Build(string[] args)
        {
            await CommandLineParse.ArgsParse(args);
            await HalfMinuteInterval(); 
        }

        private static async Task<WeatherApi> WeatherApi()
        {
            var apiCredentials = new Credentials("meta", "site");
            var userAuthentication = new WeatherApiLogin();
            var weatherApi = await userAuthentication.Login(apiCredentials);

            return weatherApi;
        }

        private static async Task<IEnumerable<string>> IntersectedCities()
        {
            var cities = await WeatherApi();

            var argsList = CommandLineParse.ArgsList();
            var citiesList = await cities.Cities();
            var intersectedCities = citiesList.Intersect(argsList);

            return intersectedCities;
        }

        private static async Task<List<string>> WeatherData()
        {
            var intersectedCities = await IntersectedCities();
            var weatherApi = await WeatherApi();

            var weatherDataList = new List<string>();
            foreach (var town in intersectedCities)
            {
                var weatherData = await weatherApi.WeatherData(town);
                var city = weatherData.City;
                var temperature = weatherData.Temperature;
                var precipitation = weatherData.Precipitation;
                var weather = weatherData.Weather;
                var weatherString = $"{ city } { temperature } { precipitation } { weather }";

                weatherDataList.Add(weatherString);
            }
            return weatherDataList;
        }

        private static async Task WeatherLog()
        {
            var weatherDataList = await WeatherData();

            Logging.WeatherLogger();
            foreach (var city in weatherDataList)
            { 
                Log.Information(city);
            }
        }

        private static async Task HalfMinuteInterval()
        {
            Timer timer = new Timer(
            async e => await WeatherLog(),
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(30));
        }
    }
}

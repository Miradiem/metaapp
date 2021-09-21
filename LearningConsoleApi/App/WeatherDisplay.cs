using metaapp.WeatherApi;
using System;

namespace metaapp.App
{
    public class WeatherDisplay
    {
        public void Show(WeatherModel weather)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine($"City: {weather.City}");
            Console.WriteLine($"Temperature: {weather.Temperature}");
            Console.WriteLine($"Precipitation: {weather.Precipitation}");
            Console.WriteLine($"Description: {weather.Weather}");
            Console.WriteLine("=================================");
        }
    }
}

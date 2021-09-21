using metaapp.Storring;
using metaapp.WeatherApi;
using System.Threading.Tasks;

namespace metaapp.App
{
    public class WeatherCommands
    {
        private readonly string[] _argsCities;
        private readonly AuthorizedWeatherApi _api;
        private readonly WeatherFile _file;
        private readonly WeatherDisplay _display;

        public WeatherCommands(
            string[] argsCities,
            AuthorizedWeatherApi api,
            WeatherFile file,
            WeatherDisplay display)
        {
            _argsCities = argsCities;
            _api = api;
            _file = file;
            _display = display;
        }

        public async Task Build()
        {
            foreach (var town in _argsCities)
            {
                var weather = await _api.WeatherData(town);
                await _file.Save(weather);
                _display.Show(weather);
            } 
        }
    }
}

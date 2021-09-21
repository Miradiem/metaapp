using System.Threading.Tasks;

namespace metaapp.App
{
    public class WeatherPeriodTimer
    {
        private readonly WeatherCommands _commands;

        public WeatherPeriodTimer(WeatherCommands commands)
        {
            _commands = commands;
        }

        public async Task Invoke(int time)
        {
            while (true)
            {
                await _commands.Build();
                await Task.Delay(time);
            }
        }
    }
}

using metaapp.App;
using metaapp.Storring;
using metaapp.WeatherApi;
using System.Threading.Tasks;

namespace metaapp
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                Logging.Log.Info($"Starting app: {string.Join(" ", args)}");

                return await CommandLineArgs.Parse(args, async argsCities =>
                {
                    var api = await new WeatherApiLogin(
                    new ApiClient("https://metasite-weather-api.herokuapp.com")
                        .Create())
                    .Login(new Credentials("meta", "site"));

                    var file = new WeatherFile("weatherData.txt");
                    var display = new WeatherDisplay();
                    var commands = new WeatherCommands(argsCities, api, file, display);

                    await new WeatherPeriodTimer(commands).Invoke(30000);

                    Logging.Log.Info("Exiting");

                    return 0;
                });
            }
            catch (System.Exception ex)
            {
                Logging.Log.Error("Unknown error", ex);

                return 1;
            }
           
        }
    }
}
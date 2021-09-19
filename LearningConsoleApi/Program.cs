using metaapp.WeatherApi;
using System.Threading.Tasks;

namespace metaapp
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await CommandLineArgs.Parse(args, async argsCities =>
            {
                var api = await new WeatherApiLogin(
                new ApiClient("https://metasite-weather-api.herokuapp.com")
                    .Create())
                .Login(new Credentials("meta", "site"));

                while (true)//Daug paprastestis timeris, nei naudojau, reikai sugalvoti kaip perkelti i metoda necopinant 
                {
                    foreach (var town in argsCities)
                    {

                        WeatherDisplay.Show(await api.WeatherData(town));
                        
                    }
                    await Task.Delay(5000);
                }

                return 0;
            });
        }
    }
}
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace metaapp.App
{
    public class CommandLineArgs
    {
        public static async Task<int> Parse(string[] args, Func<string[], Task<int>> handleWeather)
        {
            var weather = new Command("weather")
            {
                new Option<string[]>(
                "--city",
                () => Array.Empty<string>())
                {
                    Name = "argsCities"
                }
            };

            weather.Handler = CommandHandler.Create(handleWeather);

            var rootCommand = new RootCommand("metaapp.exe")
            {
               weather
            };
           
            return await rootCommand.InvokeAsync(args);
        }
    }
}

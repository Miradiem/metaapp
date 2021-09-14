using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace LearningConsoleApi
{
    public class CommandLineParse
    {
        private static readonly List<string> _argsList = new List<string>();
        public static async Task ArgsParse(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Argument<string>("weather", "Enter word: weather."),
                new Option<string[]>("--city", "Enter cities you wish"),
            };

            rootCommand.Handler = CommandHandler.Create<string, string[]>(HandleWeather);
            await rootCommand.InvokeAsync(args);
        }

        private static void HandleWeather(string weather, string[] city)
        {
            weather = "";
            foreach (var word in city)
            {
                _argsList.Add(word);
            }
        }
        public static List<string> ArgsList()
        {
            var returnList = _argsList;
            return returnList;
        }
    }
}

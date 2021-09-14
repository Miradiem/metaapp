using Serilog;

namespace LearningConsoleApi
{
    public class Logging
    {
        public static void WeatherLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Message}{NewLine}")
                .WriteTo.File("logs/metaapp.txt", outputTemplate: "{Message}{NewLine}")
                .CreateLogger();
        }
    }
}

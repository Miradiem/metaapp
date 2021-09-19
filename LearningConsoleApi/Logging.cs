using Serilog;

namespace metaapp
{
    public class Logging
    {
        public static void WeatherLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/metaapp.txt")
                .CreateLogger();
        }
    }
}

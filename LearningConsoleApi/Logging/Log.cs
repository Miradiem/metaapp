using Serilog;
using Serilog.Core;
using System;

namespace metaapp.Logging
{
    public static class Log
    {
        private static readonly Logger _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/metaapp.txt")
                .CreateLogger();

        public static void Info(string message) 
        {
            _logger.Information(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(string message, Exception error)
        {
            _logger.Error($"{message} {error.Message}");
        }
    }
}

using Microsoft.Extensions.Configuration;
using Serilog;

namespace Logging
{
    public static class LogConfigurator
    {
        public static void Configure(IConfiguration configuration)
        {
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Logger = log;

            Log.Debug("Log configured");
        }
    }
}

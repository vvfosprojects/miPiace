using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Logging
{
    public static class LogConfigurator
    {
        public static void Configure()
        {
            //var log = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.Trace()
            //    .CreateLogger();

            var log = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();

            Log.Logger = log;

            Log.Debug("Log configured");

            //var configuration = new ConfigurationBuilder()
            //                        .AddJsonFile("appsettings.json")
            //                        .Build();

            //var logger = new LoggerConfiguration()
            //                        .ReadFrom.Configuration(configuration)
            //                        .CreateLogger();
        }
    }
}

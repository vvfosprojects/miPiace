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
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
            .CreateLogger();

            Log.Logger = log;

            //Log.Debug("Log configured");
        }
    }
}

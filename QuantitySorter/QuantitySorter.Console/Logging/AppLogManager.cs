using NLog;
using System;

namespace QuantitySorter.Console.Logging
{
    public static class AppLogManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void LogErrors(Exception ex)
        {
            Logger.Debug(ex.Message);
            Logger.Debug(ex.StackTrace);
            Logger.Debug(ex.InnerException);
        }
    }
}
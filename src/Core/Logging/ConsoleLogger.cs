using System;
using System.Threading;

namespace WebApiReferenceImpl.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        // ReSharper disable InconsistentNaming
        private const string OUTPUT_FORMAT = @"{0}:{1}:{2} ==> {3}";
        // ReSharper restore InconsistentNaming

        public void LogMessage(string message, LogSeverity severity)
        {
            var color = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;

            switch (severity)
            {
                case LogSeverity.Error:
                case LogSeverity.Critical:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }


            Console.WriteLine(OUTPUT_FORMAT,
                            severity.ToString().ToUpper(),
                            SystemTime.Now.LocalDateTime.ToShortTimeString(),
                            Thread.CurrentThread.ManagedThreadId,
                            message);

            Console.ForegroundColor = color;
        }
    }
}
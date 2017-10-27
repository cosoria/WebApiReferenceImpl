using System;

namespace WebApiReferenceImpl.Core.Logging
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception ex)
        {
            logger.LogCritical(ex.ToString());
        }

        public static void LogCritical(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Critical);
        }

        public static void LogCritical(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogCritical(string.Format(message, parameters));
        }
        
        public static void LogError(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Error);
        }

        public static void LogError(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogError(string.Format(message, parameters));
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Warning);
        }

        public static void LogWarning(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogWarning(string.Format(message, parameters));
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Info);
        }

        public static void LogInfo(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogInfo(string.Format(message, parameters));
        }

        public static void LogDebug(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Debug);
        }

        public static void LogDebug(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogDebug(string.Format(message, parameters));
        }

        public static void LogTrace(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Trace);
        }

        public static void LogTrace(this ILogger logger, string message, params object[] parameters)
        {
            logger.LogTrace(string.Format(message, parameters));
        }
    }
}
using System;
using System.Diagnostics;
using System.Threading;
using WebApiReferenceImpl.Core.Threading;

namespace WebApiReferenceImpl.Core.Logging
{
    public class SystemEventLogger : ILogger
    {
        private readonly string _logSource;
        private readonly string _logName;
        private readonly ReaderWriterLockSlim _logLock;

        public SystemEventLogger(string logSource, string logName)
        {
            if (string.IsNullOrEmpty(logSource) || string.IsNullOrEmpty(logName))
            {
                throw new ArgumentNullException(@"Neither logSource or logName can be null");
            }

            _logSource = logSource;
            _logName = logName;
            _logLock = Locks.GetLockInstance(LockRecursionPolicy.NoRecursion);

            if (!EventLog.SourceExists(_logSource))
            {
                EventLog.CreateEventSource(_logSource, _logName);
            }
        }

        public void LogMessage(string message, LogSeverity severity)
        {
            // Do not log debug or trace messages to the System Event Log 
            if (severity == LogSeverity.Debug || severity == LogSeverity.Trace)
            {
                return;
            }

            using (new WriteLock(_logLock))
            {
                EventLog.WriteEntry(_logSource, message, severity.ToEventLogEntry(), 100);
            }
        }
    }

    public static class LogSeverityExtensions
    {
        public static EventLogEntryType ToEventLogEntry(this LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    return EventLogEntryType.Error;
                case LogSeverity.Warning:
                    return EventLogEntryType.Warning;
                case LogSeverity.Info:
                case LogSeverity.Debug:
                case LogSeverity.Trace:
                    return EventLogEntryType.Information;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
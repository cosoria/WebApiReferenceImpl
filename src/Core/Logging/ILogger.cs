namespace WebApiReferenceImpl.Core.Logging
{
    public interface ILogger
    {
        void LogMessage(string message, LogSeverity severity);
    }
}
namespace WebApiReferenceImpl.Core.Logging
{
    public class NullLogger : ILogger
    {
        public void LogMessage(string message, LogSeverity severity)
        {
            // Does nothing ;) 
        }
    }
}
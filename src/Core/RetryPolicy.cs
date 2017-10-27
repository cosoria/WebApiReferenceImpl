using System;
using System.Threading;
using Rigel.Core.Logging;

namespace Rigel.Core
{
    public class RetryPolicy : IDisposable 
    {
        private readonly int _maxRetries;
        private readonly ILogger _logger;

        public RetryPolicy(int maxRetries, ILogger logger = null)
        {
            _maxRetries = maxRetries;
            _logger = logger;
        }

        public void Execute(Action retryAction)
        {
            for (var i = 0; i < _maxRetries; i++ )
            {
                try
                {
                    retryAction();
                    return;
                }
                catch (Exception ex)
                {
                    if (_logger != null)
                    {
                        _logger.LogException(ex);
                    }

                    Thread.Sleep(200);
                    
                    if (_maxRetries > 3)
                    {
                        Thread.Sleep(300);
                    }

                    if (_maxRetries > 5)
                    {
                        Thread.Sleep(500);
                    }

                    if (_maxRetries > 10)
                    {
                        Thread.Sleep(1000);
                    }

                    if (_maxRetries > 20)
                    {
                        Thread.Sleep(3000);
                    }
                }
            }

            throw new InvalidOperationException(string.Format("Could not complete the operation after {0} retries", _maxRetries));
        }

        public void Dispose()
        {
            // Nothing to dispose, this is just for added syntax to make the code clearer
        }
    }
}
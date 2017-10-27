using System;

namespace WebApiReferenceImpl.Core.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly ILogger _logger;

        public LoggerFactory(ILogger logger)
        {
            Ensure.Argument.NotNull(() => logger);
            _logger = logger;
        }

        public ILogger Create()
        {
            return _logger;
        }

        public ILogger Create(object instance)
        {
            Ensure.Argument.NotNull(() => instance);
            return Create(instance.GetType());
        }

        public ILogger Create(Type instanceType)
        {
            Ensure.Argument.NotNull(() => instanceType);
            _logger.LogInfo("--[Type:{0}]--", instanceType.Name);
            return _logger;
        }
    }
}
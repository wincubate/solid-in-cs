using Admin.Domain.Logging.Interfaces;

namespace Admin.Domain.Logging
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name) => new ConsoleLogger(name);
    }
}

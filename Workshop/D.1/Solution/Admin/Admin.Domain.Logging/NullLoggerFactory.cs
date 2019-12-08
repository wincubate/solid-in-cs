using Admin.Domain.Logging.Interfaces;

namespace Admin.Domain.Logging
{
    public class NullLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name) => new NullLogger();
    }
}

using Admin.Domain.Logging.Interfaces;

namespace Admin.Domain.Logging
{
    internal class NullLogger : ILogger
    {
        public void Info(string message, params object[] additional) { }
        public void Warn(string message, params object[] additional) { }
        public void Error(string message, params object[] additional) { }
    }
}

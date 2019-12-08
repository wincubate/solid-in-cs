using Admin.Domain.Logging.Interfaces;
using Newtonsoft.Json;
using System.Linq;

namespace Admin.Domain.Logging
{
    abstract class LoggerBase : ILogger
    {
        protected readonly string _name;

        #region Template Methods

        protected abstract void OnInfo(string line);
        protected abstract void OnWarn(string line);
        protected abstract void OnError(string line);

        #endregion

        public LoggerBase(string name)
        {
            _name = name;
        }

        public void Info(string message, params object[] additional) =>
            OnInfo(FormatLogLine(message, additional));

        public void Warn(string message, params object[] additional) =>
            OnWarn(FormatLogLine(message, additional));

        public void Error(string message, params object[] additional) =>
            OnError(FormatLogLine(message, additional));

        protected string FormatLogLine(string message, params object[] additional) =>
            $"[[{_name}]] {message}" +
            string.Join(
                string.Empty,
                additional.Select(a => $" // {JsonConvert.SerializeObject(a)}"));
    }
}

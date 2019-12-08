using System;
using System.IO;

namespace Admin.Domain.Logging
{
    internal class FileLogger : LoggerBase
    {
        private readonly string _path;

        public FileLogger(string name, string path) : base(name)
        {
            _path = path;
        }

        protected override void OnInfo(string line) =>
            WriteToFile("INFO  -- ", line);

        protected override void OnWarn(string line) =>
            WriteToFile("WARN  -- ", line);

        protected override void OnError(string line) =>
            WriteToFile("ERROR -- ", line);

        private void WriteToFile(string prepend, string line)
        {
            File.AppendAllText(_path, $"{prepend}{line}{Environment.NewLine}");
        }
    }
}

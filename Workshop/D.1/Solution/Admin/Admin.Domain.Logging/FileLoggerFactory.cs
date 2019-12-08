using Admin.Domain.Logging.Interfaces;
using System;
using System.IO;

namespace Admin.Domain.Logging
{
    public class FileLoggerFactory : ILoggerFactory
    {
        public FileLoggerFactory()
        {
        }

        public ILogger Create(string name) =>
            new FileLogger(
                name,
                Path.Combine(
                    Environment.CurrentDirectory,
                    $"{name}.log"
                    )
                );
    }
}

using System;

namespace Admin.Domain.Logging
{
    internal class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(string name) : base(name)
        {
        }

        protected override void OnInfo(string line) =>
            WriteInColor(ConsoleColor.Green, line);

        protected override void OnWarn(string line) =>
            WriteInColor(ConsoleColor.Yellow, line);

        protected override void OnError(string line) =>
            WriteInColor(ConsoleColor.Red, line);

        private void WriteInColor(ConsoleColor color, string line)
        {
            lock( typeof( Console ))
            {
                Console.ForegroundColor = color;
                Console.WriteLine(line);
                Console.ResetColor();
            }
        }
    }
}

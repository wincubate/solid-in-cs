using System;
using Unity;
using Unity.Lifetime;

namespace LifeStyle
{
    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger, IDisposable
    {
        public ConsoleLogger()
        {
            Console.WriteLine( "Creating ConsoleLogger" );
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposing {nameof(ConsoleLogger)}");
        }
    }

    class Consumer
    {
        private readonly ILogger _logger;

        public Consumer( ILogger logger )
        {
            _logger = logger;
        }

        public void DoStuff()
        {
            _logger.Log("Hello, World!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<ILogger, ConsoleLogger>();

                Consumer consumer1 = container.Resolve<Consumer>();
                consumer1.DoStuff();

                Consumer consumer2 = container.Resolve<Consumer>();
                consumer2.DoStuff();
            } // <-- Dispose
        }
    }
}

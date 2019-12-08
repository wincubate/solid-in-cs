using System;

namespace Wincubate.Module3.ManagingDependencies
{
    public class Consumer
    {
        public IDependency Dependency { get; set; }

        public void UseDependency()
        {
            Dependency.DoStuff();
        }
    }

    public interface IDependency
    {
        void DoStuff();
    }

    internal class Implementation1 : IDependency
    {
        public void DoStuff()
        {
            Console.WriteLine( $"I am {nameof(Implementation1)}" );
        }
    }

    internal class Implementation2 : IDependency
    {
        public void DoStuff()
        {
            Console.WriteLine($"I am {nameof(Implementation2)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            consumer.Dependency = new Implementation1();
            consumer.UseDependency();
            consumer.Dependency = new Implementation2();
            consumer.UseDependency();
        }
    }
}

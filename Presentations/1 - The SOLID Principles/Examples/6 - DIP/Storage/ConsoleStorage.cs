using System;

namespace Wincubate.Solid.Module01
{
    class ConsoleStorage : IStorage
    {
        public string GetDataAsString()
        {
            return Console.ReadLine();
        }

        public void StoreDataAsString(string outputDataAsString)
        {
            Console.WriteLine( outputDataAsString );
        }
    }
}

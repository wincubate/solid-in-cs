using System;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class ConsoleStorage : IStorage
    {
        public Task<string> GetDataAsStringAsync()
        {
            string s = Console.ReadLine();
            return Task.FromResult(s);
        }

        public Task StoreDataAsStringAsync(string outputDataAsString)
        {
            Console.WriteLine(outputDataAsString);
            return Task.CompletedTask;
        }
    }
}
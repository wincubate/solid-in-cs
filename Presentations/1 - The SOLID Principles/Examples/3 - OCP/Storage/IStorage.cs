using System.Threading.Tasks;

namespace Wincubate.Solid
{
    interface IStorage
    {
        Task<string> GetDataAsStringAsync(string sourceFilePath);
        Task StoreDataAsStringAsync(string destinationFilePath, string outputDataAsString);
    }
}

using System.Threading.Tasks;

namespace Wincubate.Solid.Module01
{
    interface IWriteStorage
    {
        Task StoreDataAsStringAsync(string outputDataAsString);
    }
}

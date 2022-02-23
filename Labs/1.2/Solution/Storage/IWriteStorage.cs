using System.Threading.Tasks;

namespace Wincubate.Solid
{
    interface IWriteStorage
    {
        Task StoreDataAsStringAsync(string outputDataAsString);
    }
}

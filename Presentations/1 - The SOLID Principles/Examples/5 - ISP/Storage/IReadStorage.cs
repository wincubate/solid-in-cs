using System.Threading.Tasks;

namespace Wincubate.Module1
{
    interface IReadStorage
    {
        Task<string> GetDataAsStringAsync();
    }
}

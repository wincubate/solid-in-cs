using System.Threading.Tasks;

namespace Wincubate.Solid.Module01
{
    interface IReadStorage
    {
        Task<string> GetDataAsStringAsync();
    }
}

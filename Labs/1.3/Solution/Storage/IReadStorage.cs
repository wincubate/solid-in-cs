using System.Threading.Tasks;

namespace Wincubate.Solid
{
    interface IReadStorage
    {
        Task<string> GetDataAsStringAsync();
    }
}

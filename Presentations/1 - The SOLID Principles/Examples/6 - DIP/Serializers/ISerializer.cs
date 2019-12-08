using System.Collections.Generic;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    interface ISerializer
    {
        string SerializeData(IEnumerable<StockPosition> outputData);
    }
}

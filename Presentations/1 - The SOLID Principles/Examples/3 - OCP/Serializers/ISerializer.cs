using System.Collections.Generic;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
{
    interface ISerializer
    {
        string SerializeData(IEnumerable<StockPosition> outputData);
    }
}

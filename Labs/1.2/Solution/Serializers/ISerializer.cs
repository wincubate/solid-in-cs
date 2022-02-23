using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    interface ISerializer
    {
        string SerializeData(IEnumerable<StockPosition> outputData);
    }
}

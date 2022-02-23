using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    interface IParser
    {
        IEnumerable<StockPosition> Parse(string dataAsString);
    }
}

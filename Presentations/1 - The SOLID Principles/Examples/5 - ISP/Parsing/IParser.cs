using System.Collections.Generic;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
{
    interface IParser
    {
        IEnumerable<StockPosition> Parse(string dataAsString);
    }
}

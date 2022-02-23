using System.Collections.Generic;
using System.Linq;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class Computation
    {
        public IEnumerable<StockPosition> Execute(IEnumerable<StockPosition> inputData)
        {
            return inputData
                .GroupBy(stockPosition => stockPosition.Ticker)
                .Select(group => new StockPosition(
                    group.Key,
                    group.Sum(stockPosition => stockPosition.Size))
                )
                .ToList()
                ;
        }
    }
}

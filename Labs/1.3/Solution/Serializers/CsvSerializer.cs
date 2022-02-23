using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class CsvSerializer : ISerializer
    {
        public string SerializeData(IEnumerable<StockPosition> outputData)
        {
            IEnumerable<string> outputLines = outputData
                .Select(stockPosition => $"{stockPosition.Ticker},{stockPosition.Size}")
                ;
            return string.Join(Environment.NewLine, outputLines);
        }
    }
}

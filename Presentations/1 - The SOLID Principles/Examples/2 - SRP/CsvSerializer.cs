using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class CsvSerializer
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

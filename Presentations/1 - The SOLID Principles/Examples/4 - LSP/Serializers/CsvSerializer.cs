using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
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

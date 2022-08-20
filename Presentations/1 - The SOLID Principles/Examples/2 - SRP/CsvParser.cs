using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
{
    class CsvParser
    {
        public IEnumerable<StockPosition> Parse(string dataAsString)
        {
            try
            {
                return dataAsString
                    .Split('\n', '\r', '\t')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(line => line.Split(','))
                    .Select(parts => new StockPosition(
                        parts[0],
                        int.Parse(parts[1]))
                    )
                    .ToList()
                    ;
            }
            catch (Exception exception)
            {
                string message = $"Could not parse CSV string: \"{dataAsString}\"";
                throw new StockException(message, exception);
            }
        }
    }
}

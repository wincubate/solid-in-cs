using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class Parser
    {
        public virtual IEnumerable<StockPosition> Parse(string dataAsString)
        {
            try
            {
                return dataAsString
                    .Split('\n', '\r', '\t')
                    .Where(s => string.IsNullOrWhiteSpace(s) == false)
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
                throw new StockFormatException(message, exception);
            }
        }
    }
}

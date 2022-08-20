using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Wincubate.Module1.DomainLayer;
using System.Linq;

namespace Wincubate.Module1
{
    class JsonParser : IParser
    {
        public IEnumerable<StockPosition> Parse(string dataAsString)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString)
                    ?? Enumerable.Empty<StockPosition>();
            }
            catch (Exception exception)
            {
                string message = $"Could not parse as JSON: \"{dataAsString}\"";
                throw new StockFormatException(message, exception);
            }
        }
    }
}

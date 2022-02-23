using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class JsonParser : IParser
    {
        public IEnumerable<StockPosition> Parse(string dataAsString)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString);
            }
            catch (Exception exception)
            {
                string message = $"Could not parse as JSON: \"{dataAsString}\"";
                throw new StockFormatException(message, exception);
            }
        }
    }
}

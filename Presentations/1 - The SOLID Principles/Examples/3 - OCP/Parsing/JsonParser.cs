using Newtonsoft.Json;
using System.Collections.Generic;
using Wincubate.Module1.DomainLayer;
using System.Linq;

namespace Wincubate.Module1
{
    class JsonParser : IParser
    {
        public IEnumerable<StockPosition> Parse(string dataAsString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString)
                ?? Enumerable.Empty<StockPosition>();
        }
    }
}

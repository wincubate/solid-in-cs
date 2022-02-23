using Newtonsoft.Json;
using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class JsonParser : IParser
    {
        public IEnumerable<StockPosition> Parse(string dataAsString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString);
        }
    }
}

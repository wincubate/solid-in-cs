using Newtonsoft.Json;
using System.Collections.Generic;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class JsonSerializer : ISerializer
    {
        public string SerializeData(IEnumerable<StockPosition> outputData)
        {
            return JsonConvert.SerializeObject(outputData);
        }
    }
}

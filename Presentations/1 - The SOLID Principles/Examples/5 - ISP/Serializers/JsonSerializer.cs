using Newtonsoft.Json;
using System.Collections.Generic;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
{
    class JsonSerializer : ISerializer
    {
        public string SerializeData(IEnumerable<StockPosition> outputData)
        {
            return JsonConvert.SerializeObject(outputData);
        }
    }
}

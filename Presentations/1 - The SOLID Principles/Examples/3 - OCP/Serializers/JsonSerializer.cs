using Newtonsoft.Json;
using System.Collections.Generic;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class JsonSerializer : ISerializer
    {
        public string SerializeData(IEnumerable<StockPosition> outputData)
        {
            return JsonConvert.SerializeObject(outputData);
        }
    }
}

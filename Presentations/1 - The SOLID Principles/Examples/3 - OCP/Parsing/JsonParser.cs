using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class JsonParser : Parser
    {
        public override IEnumerable<StockPosition> Parse(string dataAsString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<StockPosition>>(dataAsString);
        }
    }
}

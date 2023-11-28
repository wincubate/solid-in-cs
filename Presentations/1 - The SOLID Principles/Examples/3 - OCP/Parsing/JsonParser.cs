using System.Text.Json;
using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class JsonParser : IParser
{
    public IEnumerable<StockPosition> Parse(string dataAsString)
    {
        return JsonSerializer.Deserialize<IEnumerable<StockPosition>>(dataAsString)
            ?? Enumerable.Empty<StockPosition>();
    }
}

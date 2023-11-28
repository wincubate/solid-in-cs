using System.Text.Json;
using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class JsonFormatter : IFormatter
{
    public string FormatData(IEnumerable<StockPosition> outputData)
    {
        return JsonSerializer.Serialize(outputData);
    }
}

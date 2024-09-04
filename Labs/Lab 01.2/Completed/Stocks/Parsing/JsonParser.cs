using System.Text.Json;
using Wincubate.Module1.Domain;
using Wincubate.Module1.Exceptions;

namespace Wincubate.Module1.Parsing;

class JsonParser : IParser
{
    public IEnumerable<StockPosition> Parse(string dataAsString)
    {
        try
        {
            return JsonSerializer.Deserialize<IEnumerable<StockPosition>>(dataAsString)
                ?? Enumerable.Empty<StockPosition>();
        }
        catch (Exception exception)
        {
            string message = $"Could not parse as JSON: \"{dataAsString}\"";
            throw new StockFormatException(message, exception);
        }
    }
}

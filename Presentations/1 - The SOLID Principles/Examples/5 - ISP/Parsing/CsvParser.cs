using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class CsvParser : IParser
{
    public IEnumerable<StockPosition> Parse(string dataAsString)
    {
        try
        {
            return dataAsString
                .Split('\n', '\r', '\t')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(line => line.Split(','))
                .Select(parts => new StockPosition(
                    parts[0],
                    int.Parse(parts[1]))
                )
                .ToList()
                ;
        }
        catch (Exception exception)
        {
            string message = $"Could not parse CSV string: \"{dataAsString}\"";
            throw new StockFormatException(message, exception);
        }
    }
}

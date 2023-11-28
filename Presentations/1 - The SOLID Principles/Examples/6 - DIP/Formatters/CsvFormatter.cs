using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class CsvFormatter : IFormatter
{
    public string FormatData(IEnumerable<StockPosition> outputData)
    {
        IEnumerable<string> outputLines = outputData
            .Select(stockPosition => $"{stockPosition.Ticker},{stockPosition.Size}")
            ;
        return string.Join(Environment.NewLine, outputLines);
    }
}
